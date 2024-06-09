using System.Reflection;
using UnityEngine;

public class UguiValueStoreFactory : ValueStoreFactory
{
    [SerializeField] UguiAnyTypeValueStore anyType;

    public override Transform CreateAny(object targetObj, MethodInfo setter, MethodInfo getter)
    {
        var go = UnityEngine.Object.Instantiate(anyType);
        anyType.Bind(setter, getter, targetObj);
        return go.transform;
    }
}
