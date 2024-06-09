using System.Reflection;
using UnityEngine;

/// <summar>Factory class for ValueStores</summar>
public abstract class ValueStoreFactory
{
    /// <summary>Create ValueStore for any type.</summary>
    public abstract Transform CreateAny(object targetObj, MethodInfo setter, MethodInfo getter);

    /// <summary>Creates ValueStore based on given getter's return type.</summary>
    public Transform Create(object targetObj, MethodInfo setter, MethodInfo getter) => getter.ReturnType switch
    {
        _ => CreateAny(targetObj, setter, getter),
    };

}
