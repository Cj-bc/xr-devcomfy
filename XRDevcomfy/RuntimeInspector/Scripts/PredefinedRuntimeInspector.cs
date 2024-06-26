/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using XRDevcomfy.PropertyReference;

namespace XRDevcomfy.RuntimeInspector
{
    /// Runtime inspector with restricted/predefined set of properties
    public class PredefinedRuntimeInspector : MonoBehaviour
    {
	public List<PropertyReference.PropertyReference> predefinedBindings;
	public List<PropertyReference.MethodReference> predefinedMethodBindings;
	/// Root Transform that contains all template instances
	public Transform propertiesRoot;

        public MemberStoreFactory factory;

	void Start()
	{
	    foreach (var bind in predefinedBindings)
	    {
		var instance = factory.Create(bind.Target, bind.PropertyInfo);
		instance.transform.SetParent(propertiesRoot, false);
	    }

	    foreach (var bind in predefinedMethodBindings)
	    {
		var instance = factory.Create(bind.Target, bind.MethodInfo);
		instance.transform.SetParent(propertiesRoot, false);
	    }
	}

	public void Log()
	{
	    Debug.Log("Hi! Called!");
	}

    }
}
