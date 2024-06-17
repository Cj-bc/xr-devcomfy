using UnityEngine;
using UnityEngine.UI;

public class UguiBoolPropertyStore : BoolPropertyStore
{
    [SerializeField] Toggle toggle;

    protected override void SetupValueModificationListeners()
	=> toggle.onValueChanged.AddListener(v => {Setter(v); return;});

    protected override void SetValue(bool newValue) => toggle.isOn = newValue;
}
