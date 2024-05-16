using System;
using System.Reflection;
using UnityEngine;

/// <summary>An reference to some component's property.</summary>
[System.Serializable]
public struct ComponentPropertyReference
{
    public Component Target;
    public string PropertyName;

    public ComponentPropertyReference(Component _target, string _propertyName)
    {
        Target = _target;
        PropertyName = _propertyName;
    }

    /// Returns appropreate PropertyInfo for given combination.
    public PropertyInfo? PropertyInfo {
        get => Target.GetType().GetProperty(PropertyName);
        set => PropertyName = value.Name;
    }

    public object? GetValue() => PropertyInfo.GetValue(Target);
    public void SetValue(object val) => PropertyInfo.SetValue(Target, val);
}
