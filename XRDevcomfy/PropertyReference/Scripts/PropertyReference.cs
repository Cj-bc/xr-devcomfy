using System;
using System.Reflection;
using UnityEngine;

namespace XRDevcomfy.PropertyReference
{
    /// <summary>An reference to some component's property.</summary>
    [System.Serializable]
    public struct PropertyReference
    {
	public Component Target;
	public string PropertyName;

	public PropertyReference(Component _target, string _propertyName)
	{
	    Target = _target;
	    PropertyName = _propertyName;
	}

	/// Returns appropreate PropertyInfo for given combination.
	public PropertyInfo? PropertyInfo {
	    get => Target.GetType().GetProperty(PropertyName);
	    set => PropertyName = value.Name;
	}

	public object? Value
	{
	    get => PropertyInfo?.GetValue(Target);
	    set => PropertyInfo?.SetValue(Target, value);
	}
    }
}
