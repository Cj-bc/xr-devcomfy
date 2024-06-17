/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Component template
public abstract class InspectorComponentFactory : MonoBehaviour
{
    public FieldTemplate fieldTemplate;
    public MemberStoreFactory memberStoreFactory;

    public Transform propertiesRoot;

    /// Creates Transform that represents given Component
    public virtual Transform CreateComponent(Component target)
    {
	var type = target.GetType();
	SetName(type.Name);
	foreach (var prop in type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
	{
	    var instance = Instantiate(fieldTemplate);
	    instance.Bind(prop, target);
	    instance.transform.SetParent(propertiesRoot, false);
	}

	foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
	{
	    if (prop.GetGetMethod() is MethodInfo getter && prop.GetSetMethod() is MethodInfo setter)
	    {
		Transform instance = memberStoreFactory.Create(target, setter, getter);
		instance.transform.SetParent(propertiesRoot, false);
	    }
	}

	return this.transform;
    }

    public abstract void SetName(string name);
}
