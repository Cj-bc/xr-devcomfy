/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// Manage Util Tools
class Toolholster : MonoBehaviour
{
    public List<UtilTool> Tools;
    private int activeToolIndex = 0;

    private UtilTool? activeTool
    {
	get => Tools.ElementAtOrDefault(activeToolIndex);
    }

    public void Show()
    {
	activeTool?.Show();
    }

    public void Close()
    {
	activeTool?.Close();
    }
}

public abstract class UtilTool : MonoBehaviour
{
    public abstract void Show();
    public abstract void Close();
}
