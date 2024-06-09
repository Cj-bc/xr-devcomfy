/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using UnityEngine;
using TMPro;

public class UguiVector3ValueStore : Vector3ValueStore
{
    [SerializeField] TMP_InputField x;
    [SerializeField] TMP_InputField y;
    [SerializeField] TMP_InputField z;

    protected override bool SetValue(object newValue)
    {
        if (newValue is Vector3 v3)
        {
            x.text = v3.x.ToString();
            y.text = v3.y.ToString();
            z.text = v3.z.ToString();
            return true;
        }
        else
        {
            return false;
        }
    }
}
