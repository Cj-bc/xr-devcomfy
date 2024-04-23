using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMProPropertyTemplate : PropertyTemplate
{
    [SerializeField] private TMP_Text propertyName;
    [SerializeField] private TMP_InputField valueField;

    public override void Set(PropertyInfo info, object originalObj)
    {
	propertyName.SetText(info.Name);
	// valueField.inputValidator = (val) => ;
	if (info.CanRead)
	{
	    try
	    {
	    valueField.textComponent.SetText(info.GetValue(originalObj)?.ToString());
	    }
	    catch (System.NotSupportedException)
	    {
		// TODO: When property is obsolate, GetValue() throws this exception.
		// I better to implement something to treat this.
	    }
	}
    }
}
