/**
This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at https://mozilla.org/MPL/2.0/.
**/
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName="FactoryConfiguration", menuName="XRDevcomfy/UguiMemberStoreFactory")]
public class UguiMemberStoreFactory : MemberStoreFactory
{
    [SerializeField] UguiVector3PropertyStore vector3;
    [SerializeField] UguiQuaternionPropertyStore quaternion;
    [SerializeField] UguiBoolPropertyStore boolean;
    [SerializeField] UguiAnyTypePropertyStore anyType;

    public override Transform CreateVector3(object targetObj, MethodInfo setter, MethodInfo getter)
    {
        var go = UnityEngine.Object.Instantiate(vector3);
        go.Bind(setter, getter, targetObj);
        return go.transform;
    }

    public override Transform CreateQuaternion(object targetObj, MethodInfo setter, MethodInfo getter)
    {
        var go = UnityEngine.Object.Instantiate(quaternion);
        go.Bind(setter, getter, targetObj);
        return go.transform;
    }

    public override Transform CreateBool(object targetObj, MethodInfo setter, MethodInfo getter)
    {
        var go = UnityEngine.Object.Instantiate(boolean);
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
