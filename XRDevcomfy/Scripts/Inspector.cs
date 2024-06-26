/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// Manage Inspector view
public class Inspector : MonoBehaviour
{
    [SerializeField] private TMP_Text nameField;
    [SerializeField] private TMP_Text positionField;
    [SerializeField] private TMP_Text rotationField;
    [SerializeField] private TMP_Text scaleField;
    [SerializeField] private RectTransform componentsRoot;
    [SerializeField] private InspectorComponentFactory componentFactory;

    [SerializeField]
    private GameObject? target;

    public List<Component> ComponentsToInspect;
    private List<Type> targetComponentTypes;

    void Start()
    {
	targetComponentTypes = ComponentsToInspect.Select((c) => c.GetType()).ToList();
    }

    public void Inspect(GameObject obj)
    {
	target = obj;
	updateData();

	// TODO: Reuse them by making pool or something.
	for (int i = 0; i < componentsRoot.childCount; i++)
	{
	    Destroy(componentsRoot.GetChild(i).gameObject);
	}

	foreach (Type targetType in targetComponentTypes)
	{
	    var actualComponent = obj.GetComponent(targetType);
	    if (actualComponent is null)
	    {
		continue;
	    }
	    var node = Instantiate(componentFactory).CreateComponent(actualComponent);
	    node.SetParent(componentsRoot, false);
	}
	LayoutRebuilder.MarkLayoutForRebuild(transform as RectTransform);
    }
    private void updateData()
    {
	nameField.SetText(target.name);
	positionField.SetText(target.transform.localPosition.ToString());
	rotationField.SetText(target.transform.localRotation.ToString());
	scaleField.SetText(target.transform.localScale.ToString());
    }

    void LateUpdate()
    {
	if (target != null)
	{
	    updateData();
	}
    }
}
