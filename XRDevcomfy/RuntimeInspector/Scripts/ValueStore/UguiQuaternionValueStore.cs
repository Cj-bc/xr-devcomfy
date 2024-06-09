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
    [SerializeField] TMP_Text eulerX;
    [SerializeField] TMP_Text eulerY;
    [SerializeField] TMP_Text eulerZ;
    [Header("Quaternion Angles")]
    [SerializeField] RectTransform quaternionRepresentation;
    [SerializeField] TMP_Text quaternionX;
    [SerializeField] TMP_Text quaternionY;
    [SerializeField] TMP_Text quaternionZ;
    [SerializeField] TMP_Text quaternionW;
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

    protected override bool SetValue(object newValue)
    {
	if (newValue is Quaternion v)
	{
            eulerX.text = v.eulerAngles.x.ToString();
            eulerY.text = v.eulerAngles.y.ToString();
            eulerZ.text = v.eulerAngles.z.ToString();
            quaternionX.text = v.x.ToString();
            quaternionY.text = v.y.ToString();
            quaternionZ.text = v.z.ToString();
            quaternionW.text = v.w.ToString();
            return true;
	}
	else
	{
	    return false;
	}
    }
}
