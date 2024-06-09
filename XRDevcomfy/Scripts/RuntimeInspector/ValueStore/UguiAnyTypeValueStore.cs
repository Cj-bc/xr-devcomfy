using UnityEngine;
using TMPro;

public class UguiAnyTypeValueStore : AnyTypeValueStore
{
    [SerializeField] private TMP_InputField valueField;

    protected override bool SetValue(object newValue)
    {
	valueField.text = newValue?.ToString() ?? "_INVALID VALUE_";
	return true;
    }
}
