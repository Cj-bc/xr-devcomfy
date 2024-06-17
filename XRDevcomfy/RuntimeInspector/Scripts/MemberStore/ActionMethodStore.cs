using System.Reflection;
using UnityEngine;

public abstract class ActionMethodStore : MemberStore
{
    protected MethodInfo methodInfo;

    public bool Bind(object obj, MethodInfo methodInfo)
    {
	boundObject = obj;
	this.methodInfo = methodInfo;
	return true;
    }

    public override bool Bind(object obj, MemberInfo memberInfo) => memberInfo switch
    {
	MethodInfo m => Bind(obj, m),
	_ => false
    };
    

    public void Call() => methodInfo.Invoke(boundObject, new object[]{});
}
