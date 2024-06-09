/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using UnityEngine;
using TMPro;
using System;

public class UguiVector3ValueStore : Vector3ValueStore
{
    [SerializeField] TMP_InputField x;
    [SerializeField] TMP_InputField y;
    [SerializeField] TMP_InputField z;

    void OnEnable()
    {
	x.onSelect.AddListener((_) => isValueModificationOnGoing = true);
	x.onDeselect.AddListener((s) => UpdateValue(s, (v, old) => new Vector3(v, old.y, old.z)));
	y.onSelect.AddListener((_) => isValueModificationOnGoing = true);
	y.onDeselect.AddListener((s) => UpdateValue(s, (v, old) => new Vector3(old.x, v, old.z)));
	z.onSelect.AddListener((_) => isValueModificationOnGoing = true);
	z.onDeselect.AddListener((s) => UpdateValue(s, (v, old) => new Vector3(old.x, old.y, v)));
    }

    void UpdateValue(string newValue, Func<float, Vector3, Vector3> converter)
    {
	isValueModificationOnGoing = false;
	if (float.Parse(newValue) is float v)
	{
	    var currentValue = (Vector3)Getter();
	    Setter(converter(v, currentValue));
	}
    }

    protected override bool SetValue(object newValue)
    {
        if (newValue is Vector3 v3)
        {
            x.text = v3.x.ToString();
            y.text = v3.y.ToString();
            z.text = v3.z.ToString();
            return true;
        }
        else
        {
            return false;
        }
    }
}
