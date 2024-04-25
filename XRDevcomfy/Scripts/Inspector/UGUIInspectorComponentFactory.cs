/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/// <summary>Factory class that produces uGUI based InspectorComponent</summary>
public class UGUIInspectorComponentFactory: InspectorComponentFactory
{
    public TMP_Text nameLabel;

    public override Transform CreateComponent(Component target)
    {
	var node = base.CreateComponent(target);
	LayoutRebuilder.MarkLayoutForRebuild(transform.parent as RectTransform);
	return this.transform as RectTransform;
    }

    public override void SetName(string name)
    {
	nameLabel.SetText(name);
    }
}
