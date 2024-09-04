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
public abstract class FieldTemplate : MonoBehaviour
{
    /// <summary>Type of property this instance is bound to.</summary>
    private System.Type valueType;
    private object boundObject;
    private FieldInfo boundInfo;

    /// <summary>Bind this template instance to given Property of originalObj</summary>
    /// <param name="info">Specifies which property to bind.</param>
    /// <param name="originalObj">Actual object to bind</param>
    public virtual void Bind(FieldInfo info, object originalObj)
    {
	boundObject = originalObj;
	valueType = info.FieldType;
	boundInfo = info;
    }

    void LateUpdate()
    {
	SetValue(boundInfo?.GetValue(boundObject));
    }

    /// <summary>Set Property value to visual.</summary>
    /// <param name="newValue">value to set.</param>
    protected abstract bool SetValue(object newValue);
}
