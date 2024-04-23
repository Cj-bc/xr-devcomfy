using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Controls template gameObejct that represents one property of type.</summary>
public abstract class PropertyTemplate : MonoBehaviour
{
    /// 
    public abstract void Set(PropertyInfo info, object originalObj);
}
