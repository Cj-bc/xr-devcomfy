using System;
using System.Reflection;
using UnityEngine;

namespace XRDevcomfy.PropertyReference
{
    [Serializable]
    public struct MethodReference
    {
	public Component Target;
	public string MethodName;

	public MethodReference(Component _target, string _methodName)
	{
	    Target = _target;
	    MethodName = _methodName;
	}

	public MethodInfo? MethodInfo
	{
	    get => Target.GetType().GetMethod(MethodName);
	    set => MethodName = value.Name;
	}
    }
}
