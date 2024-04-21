/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Canvas))]
public class HideWhenNotFacing : MonoBehaviour
{
    public Transform oppornent;
    public float threshold = -0.4f;

    [SerializeField] private Canvas canvas;

    void Update()
    {
	if (Vector3.Dot(gameObject.transform.forward, oppornent.forward) > threshold)
	{
	    ShouldOpened();
	} else
	{
	    ShouldClosed();
	}
    }

    void ShouldOpened()
    {
	canvas.enabled = true;
    }

    void ShouldClosed()
    {
	canvas.enabled = false;
    }
}
