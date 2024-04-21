/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>Make sure that this gameObject is kept as the desired index sibling</summary>
public class KeepSiblingIndex : MonoBehaviour
{
    /// <summary>Sibling index that you want gameObject to have. Negative numbers denotes count from last</summary>
    public int desiredSiblingIndex;

    void LateUpdate()
    {
	var currentIndex = transform.GetSiblingIndex();
	var currentSiblingsCount = transform.parent.childCount;
	bool isDirty = false;
	if (0 < desiredSiblingIndex)
	{
	    if (currentIndex != desiredSiblingIndex)
	    {
		transform.SetSiblingIndex(Mathf.Clamp(desiredSiblingIndex, 0, currentSiblingsCount - 1));
		isDirty = true;
	    }
	}
	else
	{
	    if (currentIndex != (currentSiblingsCount + desiredSiblingIndex))
	    {
		transform.SetSiblingIndex(Mathf.Clamp(currentSiblingsCount + desiredSiblingIndex, 0, currentSiblingsCount - 1));
		isDirty = true;
	    }
	}

	/// Call Layout rebuild if this is recttransform, because this could change how it looks.
	if (isDirty && transform is RectTransform r)
	{
	    LayoutRebuilder.MarkLayoutForRebuild(r.parent as RectTransform);
	}
    }
}
