/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMProFieldTemplate : FieldTemplate
{
    [SerializeField] private TMP_Text fieldName;
    [SerializeField] private TMP_InputField valueField;

    public override void Bind(FieldInfo info, object originalObj)
    {
	base.Bind(info, originalObj);
	fieldName.SetText(info.Name);
    }

    protected override bool SetValue(object newValue)
    {
	valueField.text = newValue?.ToString() ?? "_INVALID VALUE_";
	return true;
    }
}
