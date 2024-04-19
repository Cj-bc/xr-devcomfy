/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>Manage hierarchy view inside VR</summary>
public class VRHierarchyView : UtilTool
{
    [SerializeField]
    private HierarchyItem itemPrefab;

    /// White list of gameObjects to display.
    [SerializeField]
    private List<GameObject> items;

    void Start()
    {
	foreach (GameObject target in items)
	{
	    var item = Instantiate(itemPrefab, transform);
	    var itemComponent = item.GetComponent<HierarchyItem>();
	    itemComponent.Initialize(target);
	}
	LayoutRebuilder.MarkLayoutForRebuild(transform as RectTransform);
    }

    public override void Show()
    {
	gameObject.SetActive(true);
    }

    public override void Close()
    {
	gameObject.SetActive(false);
    }
}
