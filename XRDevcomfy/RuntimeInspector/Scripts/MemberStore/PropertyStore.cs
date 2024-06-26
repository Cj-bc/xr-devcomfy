/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Controls template gameObejct that represents one property of type.</summary>
public abstract class PropertyStore<T> : MemberStore
{
    /// <summary>Setter of property this instance is bound to. <c>Null</c> if it doesn't have public setter.</summary>
    private MethodInfo? boundSetter;
    /// <summary>Getter of property this instance is bound to. getter should be provided because ValueStore have no meaning without knowing it's value</summary>
    private MethodInfo boundGetter;
    private object boundObject;

    /// <summary>True if value is currently edited by this;</summary>
    protected bool isValueModificationOnGoing;

    /// <summary>Bind this template instance to given Property of originalObj</summary>
    /// <param name="info">Specifies which property to bind.</param>
    /// <param name="originalObj">Actual object to bind</param>
    public virtual bool Bind(PropertyInfo info, object originalObj)
    {
	if (info.PropertyType != typeof(T))
	{
	    return false;
	}

	boundObject = originalObj;
	foreach (MethodInfo m in info.GetAccessors())
	{
	    // Determine if it is getter or setter.
	    // https://learn.microsoft.com/en-us/dotnet/api/system.reflection.propertyinfo.getaccessors?view=net-8.0#system-reflection-propertyinfo-getaccessors
	    if (m.ReturnType == typeof(void))
		boundSetter = m;
	    else
		boundGetter = m;
	}

	return boundGetter is null;
    }

    /// <summary>Bind valueStore to given getter and setter</summary>
    /// <param name="originalObj">Actual object to bind</param>
    public virtual void Bind(MethodInfo setter, MethodInfo getter, object targetObj)
    {
        boundSetter = setter;
        boundGetter = getter;
	boundObject = targetObj;
    }

    public override bool Bind(object obj, MemberInfo memberInfo) => memberInfo switch
    {
	PropertyInfo prop => Bind(prop, obj),
	_ => false
    };

    void OnEnable()
    {
	SetupValueModificationListeners();
    }

    void LateUpdate()
    {
	if (!isValueModificationOnGoing)
	{
	    SetValue(Getter());
	}
    }

    /// <summary>Set Property value to visual.</summary>
    /// <param name="newValue">value to set.</param>
    protected abstract void SetValue(T newValue);

    /// <summary>Do necessary setups to receive value modification from UI.</summary>
    protected abstract void SetupValueModificationListeners();

    /// Invokes bound setter
    protected bool Setter(T val)
    {
	if (boundSetter is null || boundObject is null)
	{
	    return false;
	}

	var t = boundSetter.GetParameters();
	if (val.GetType() == t[0].ParameterType)
	{
	    boundSetter.Invoke(boundObject, new []{(object)val});
	    return true;
	}
	else
	{
	    return false;
	}
    }

    protected T Getter()
    {
	var got = boundGetter.Invoke(boundObject, new object[]{});
	if (got is T v)
	{
	    return v;
	}
	// TODO: what should I do when getter returns something else?
	return default(T);
    }
}
