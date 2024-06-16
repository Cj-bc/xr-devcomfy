using UnityEngine;
using UnityEngine.UI;

public class UguiBoolValueStore : BoolValueStore
{
    [SerializeField] Toggle toggle;

    protected override void SetupValueModificationListeners()
	=> toggle.onValueChanged.AddListener(v => {Setter(v); return;});

    protected override void SetValue(bool newValue) => toggle.isOn = newValue;
}
