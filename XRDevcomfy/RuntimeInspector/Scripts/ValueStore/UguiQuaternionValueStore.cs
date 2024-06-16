/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UguiQuaternionValueStore : QuaternionValueStore
{
    [Header("Euler Angles")]
    [SerializeField] RectTransform eulerRepresentation;
    [SerializeField] TMP_InputField eulerX;
    [SerializeField] TMP_InputField eulerY;
    [SerializeField] TMP_InputField eulerZ;
    [Header("Quaternion Angles")]
    [SerializeField] RectTransform quaternionRepresentation;
    [SerializeField] TMP_InputField quaternionX;
    [SerializeField] TMP_InputField quaternionY;
    [SerializeField] TMP_InputField quaternionZ;
    [SerializeField] TMP_InputField quaternionW;
    [SerializeField] Button toggleEuler;
    bool showingAsEuler = true;

    void OnEnable()
    {
	toggleEuler.onClick.AddListener(ToggleEuler);
	ToggleEuler();
    }

    void ToggleEuler()
    {
	showingAsEuler = !showingAsEuler;
	eulerRepresentation.gameObject.SetActive(showingAsEuler);
	quaternionRepresentation.gameObject.SetActive(!showingAsEuler);
    }

    protected override void SetupValueModificationListeners()
    {
	eulerX.onSelect.AddListener(_ => isValueModificationOnGoing = true);
	eulerX.onValueChanged.AddListener(s => UpdateValue(showingAsEuler, s, (v, old) => Quaternion.Euler(v, old.eulerAngles.y, old.eulerAngles.z)));
	eulerY.onSelect.AddListener(_ => isValueModificationOnGoing = true);
	eulerY.onValueChanged.AddListener(s => UpdateValue(showingAsEuler, s, (v, old) => Quaternion.Euler(old.eulerAngles.x, v, old.eulerAngles.z)));
	eulerZ.onSelect.AddListener(_ => isValueModificationOnGoing = true);
	eulerZ.onValueChanged.AddListener(s => UpdateValue(showingAsEuler, s, (v, old) => Quaternion.Euler(old.eulerAngles.x, old.eulerAngles.y, v)));

	quaternionX.onSelect.AddListener(_ => isValueModificationOnGoing = true);
	quaternionX.onValueChanged.AddListener(s => UpdateValue(!showingAsEuler, s, (v, old) => new Quaternion(v, old.y, old.z, old.w)));
	quaternionY.onSelect.AddListener(_ => isValueModificationOnGoing = true);
	quaternionY.onValueChanged.AddListener(s => UpdateValue(!showingAsEuler, s, (v, old) => new Quaternion(old.x, v, old.z, old.w)));
	quaternionZ.onSelect.AddListener(_ => isValueModificationOnGoing = true);
	quaternionZ.onValueChanged.AddListener(s => UpdateValue(!showingAsEuler, s, (v, old) => new Quaternion(old.x, old.y, v, old.w)));
	quaternionW.onSelect.AddListener(_ => isValueModificationOnGoing = true);
	quaternionW.onValueChanged.AddListener(s => UpdateValue(!showingAsEuler, s, (v, old) => new Quaternion(old.x, old.y, old.z, v)));
    }

    void UpdateValue(bool pred, string newValue, Func<float, Quaternion, Quaternion> converter)
    {
	if (!pred)
	{
	    return;
	}

	isValueModificationOnGoing = false;
	if (float.Parse(newValue) is float v)
	{
	    var currentValue = (Quaternion)Getter();
	    Setter(converter(v, currentValue));
	}
    }

    protected override void SetValue(Quaternion newValue)
    {
	eulerX.text = newValue.eulerAngles.x.ToString();
	eulerY.text = newValue.eulerAngles.y.ToString();
	eulerZ.text = newValue.eulerAngles.z.ToString();
	quaternionX.text = newValue.x.ToString();
	quaternionY.text = newValue.y.ToString();
	quaternionZ.text = newValue.z.ToString();
	quaternionW.text = newValue.w.ToString();
    }
}
