using UnityEngine;
using UnityEngine.UI;

public class UguiBoolValueStore : BoolValueStore
{
    [SerializeField] Toggle toggle;

    void OnEnable()
    {
        toggle.onValueChanged.AddListener(v => {Setter(v); return;});
    }

    protected override void SetValue(bool newValue) => toggle.isOn = newValue;
}
