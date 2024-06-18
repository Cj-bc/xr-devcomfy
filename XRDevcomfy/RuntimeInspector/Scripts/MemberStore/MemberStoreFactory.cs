/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using System;
using System.Reflection;
using UnityEngine;

/// <summar>Factory class for MemberStores</summar>
public abstract class MemberStoreFactory : ScriptableObject
{
    public abstract Transform CreateVector3(object targetObj, MethodInfo setter, MethodInfo getter);
    public abstract Transform CreateQuaternion(object targetObj, MethodInfo setter, MethodInfo getter);
    public abstract Transform CreateBool(object targetObj, MethodInfo setter, MethodInfo getter);

    /// <summary>Create PropertyStore for any type.</summary>
    public abstract Transform CreateAny(object targetObj, MethodInfo setter, MethodInfo getter);

    public Transform Create(object targetObj, MemberInfo info) => info switch
    {
	PropertyInfo i => CreateProperty(targetObj, i.GetSetMethod(), i.GetGetMethod()),
	null => throw new NullReferenceException(),
	_ => throw new NotImplementedException(),
    };

    /// <summary>Creates PropertyStore based on given getter's return type.</summary>
    public Transform CreateProperty(object targetObj, MethodInfo setter, MethodInfo getter) => getter.ReturnType switch
    {
        var t when t == typeof(Vector3) => CreateVector3(targetObj, setter, getter),
        var t when t == typeof(Quaternion) => CreateQuaternion(targetObj, setter, getter),
        var t when t == typeof(bool) => CreateBool(targetObj, setter, getter),
        _ => CreateAny(targetObj, setter, getter),
    };

}
