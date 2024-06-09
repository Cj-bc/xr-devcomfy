using UnityEngine;
using TMPro;

public class UguiVector3ValueStore : Vector3ValueStore
{
    [SerializeField] TMP_Text x;
    [SerializeField] TMP_Text y;
    [SerializeField] TMP_Text z;

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
