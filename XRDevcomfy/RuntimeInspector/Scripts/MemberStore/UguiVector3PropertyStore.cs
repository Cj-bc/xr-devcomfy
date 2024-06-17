/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using UnityEngine;
using TMPro;
using System;

public class UguiVector3PropertyStore : Vector3PropertyStore
{
    [SerializeField] TMP_InputField x;
    [SerializeField] TMP_InputField y;
    [SerializeField] TMP_InputField z;

    protected override void SetupValueModificationListeners()
    {
	x.onSelect.AddListener((_) => isValueModificationOnGoing = true);
	x.onDeselect.AddListener((s) => UpdateValue(s, (v, old) => new Vector3(v, old.y, old.z)));
	x.onSubmit.AddListener((s) => UpdateValue(s, (v, old) => new Vector3(v, old.y, old.z)));
	y.onSelect.AddListener((_) => isValueModificationOnGoing = true);
	y.onDeselect.AddListener((s) => UpdateValue(s, (v, old) => new Vector3(old.x, v, old.z)));
	y.onSubmit.AddListener((s) => UpdateValue(s, (v, old) => new Vector3(old.x, v, old.z)));
	z.onSelect.AddListener((_) => isValueModificationOnGoing = true);
	z.onDeselect.AddListener((s) => UpdateValue(s, (v, old) => new Vector3(old.x, old.y, v)));
	z.onSubmit.AddListener((s) => UpdateValue(s, (v, old) => new Vector3(old.x, old.y, v)));
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

    protected override void SetValue(Vector3 newValue)
    {
	x.text = newValue.x.ToString();
	y.text = newValue.y.ToString();
	z.text = newValue.z.ToString();
    }
}
