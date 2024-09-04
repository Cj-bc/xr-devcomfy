/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>Represents one HierarchyItem</summary>
public class HierarchyItem : MonoBehaviour
{
    [SerializeField] private Toggle activeToggle;
    [SerializeField] private TMP_Text nameDisplay;

    [SerializeField]
    private GameObject target;
    public GameObject Target { get => target; }

    void Start()
    {
	if (target is GameObject t)
	{
	    Initialize(t);
	}
    }

    public void Initialize(GameObject _target)
    {
	target = _target;
	nameDisplay.text = target.name;
	activeToggle.isOn = target.activeSelf;
	activeToggle.onValueChanged.AddListener(onActiveToggled);
    }

    void onActiveToggled(bool newState)
    {
	target.SetActive(newState);
    }
}
