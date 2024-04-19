/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>An Vertical Layout with Selection capability</summary>
class VerticalLayoutGroupWithSelection : VerticalLayoutGroup, IPointerClickHandler
{
    /// <summary>Emit when Selection is changed by PointerClick</summary>
    public event Action OnSelectionChanged;

    private GameObject? _selected;
    public GameObject? selectedItem
    {
	get => _selected;
	set {
	    _selected = value;
	    OnSelectionChanged.Invoke();
	}
    }

    public void OnPointerClick(PointerEventData data)
    {
	// which implementation is faster to use 'data.hovered' or 'transform.GetChild()'?

	foreach (GameObject obj in data.hovered)
	{
	    if (obj.transform.parent == transform)
	    {
		selectedItem = obj;
		break;
	    }
	}
    }
}
