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
    public PropertyTemplate propTemplate;
    public Transform propertiesRoot;

    /// Creates Transform that represents given Component
    public virtual Transform CreateComponent(Component target)
    {
	var type = target.GetType();
	SetName(type.Name);
	foreach (var prop in type.GetProperties())
	{
	    var instance = Instantiate(propTemplate);
	    instance.Set(prop, target);
	    instance.transform.SetParent(propertiesRoot, false);
	}

	return this.transform;
    }

    public abstract void SetName(string name);
}
