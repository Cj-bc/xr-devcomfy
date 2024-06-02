/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMProPropertyTemplate : PropertyTemplate
{
    [SerializeField] private TMP_Text propertyName;
    [SerializeField] private TMP_InputField valueField;

    public override void Bind(PropertyInfo info, object originalObj)
    {
	base.Bind(info, originalObj);
	propertyName.SetText($"{originalObj.ToString()}.{info.Name}");
    }

    protected override bool SetValue(object newValue)
    {
	valueField.text = newValue?.ToString() ?? "_INVALID VALUE_";
	return true;
    }
}
