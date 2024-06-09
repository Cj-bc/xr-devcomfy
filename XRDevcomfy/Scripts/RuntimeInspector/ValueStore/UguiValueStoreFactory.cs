using System.Reflection;
using UnityEngine;

public class UguiValueStoreFactory : ValueStoreFactory
{
    [SerializeField] UguiVector3ValueStore vector3;
    [SerializeField] UguiAnyTypeValueStore anyType;

    public override Transform CreateVector3(object targetObj, MethodInfo setter, MethodInfo getter)
    {
        var go = UnityEngine.Object.Instantiate(vector3);
        go.Bind(setter, getter, targetObj);
        return go.transform;
    }

    public override Transform CreateAny(object targetObj, MethodInfo setter, MethodInfo getter)
    {
        var go = UnityEngine.Object.Instantiate(anyType);
        anyType.Bind(setter, getter, targetObj);
        return go.transform;
    }
}
