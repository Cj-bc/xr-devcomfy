/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using UnityEngine;
using TMPro;

public class UguiAnyTypeValueStore : AnyTypeValueStore
{
    [SerializeField] private TMP_InputField valueField;

    protected override bool SetValue(object newValue)
    {
	valueField.text = newValue?.ToString() ?? "_INVALID VALUE_";
	return true;
    }
}
