using UnityEngine;
using System.Reflection;

/// <summary>Represents an object that STOREs member of an object.</summary>
public abstract class MemberStore : MonoBehaviour
{
    protected object boundObject;

    /// Bind this store to member of given object
    public abstract bool Bind(object obj, MemberInfo memberInfo);
}
