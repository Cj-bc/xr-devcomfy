using UnityEngine;
using UnityEngine.UI;

public class UguiActionMethodStore : ActionMethodStore
{
    [SerializeField] Button callButton;

    void OnEnable()
    {
	callButton.onClick.AddListener(Call);
    }

    void OnDisable()
    {
	callButton.onClick.RemoveListener(Call);
    }

}
