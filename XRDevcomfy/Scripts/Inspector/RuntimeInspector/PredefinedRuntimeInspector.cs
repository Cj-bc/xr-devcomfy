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
	[System.Serializable]
	public class TargetBinding
	{
	    public Component Target;
	    public string TargetQualifiedName;
	    public string PropertyName;

            public TargetBinding(Component _target, string _propertyName)
            {
                Target = _target;
                PropertyName = _propertyName;
            }

            /// Returns appropreate PropertyInfo for given combination.
            public PropertyInfo? PropertyInfo {
                get => Target.GetType().GetProperty(PropertyName);
                set => PropertyName = value.Name;
            }
	}
	
	public List<TargetBinding> predefinedBindings;
	public PropertyTemplate propertyTemplate;
	/// Root Transform that contains all template instances
	public Transform propertiesRoot;

	void Start()
	{
            // debug
            predefinedBindings = new List<TargetBinding>{new TargetBinding(transform, "position")};
	    foreach (var bind in predefinedBindings)
	    {
		var instance = Instantiate(propertyTemplate);
		instance.Bind(bind.PropertyInfo, bind.Target);
		instance.transform.SetParent(propertiesRoot, false);
	    }
	}

    }
}
