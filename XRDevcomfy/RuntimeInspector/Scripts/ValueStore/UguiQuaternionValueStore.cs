/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
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
