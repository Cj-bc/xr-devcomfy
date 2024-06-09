/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

namespace XRDevcomfy.RuntimeInspector
{
    /// Runtime inspector with restricted/predefined set of properties
    public class PredefinedRuntimeInspector : MonoBehaviour
    {
	public List<PropertyReference> predefinedBindings;
	/// Root Transform that contains all template instances
	public Transform propertiesRoot;

        public ValueStoreFactory factory;

	void Start()
	{
	    foreach (var bind in predefinedBindings)
	    {
		var instance = factory.Create(bind.Target, bind.PropertyInfo.GetSetMethod(), bind.PropertyInfo.GetGetMethod());
		instance.transform.SetParent(propertiesRoot, false);
	    }
	}

    }
}
