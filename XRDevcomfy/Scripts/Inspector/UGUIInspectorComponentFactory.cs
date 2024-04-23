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
