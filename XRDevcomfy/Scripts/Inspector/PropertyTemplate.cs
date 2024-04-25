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
public abstract class PropertyTemplate : MonoBehaviour
{
    /// 
    public abstract void Set(PropertyInfo info, object originalObj);
}
