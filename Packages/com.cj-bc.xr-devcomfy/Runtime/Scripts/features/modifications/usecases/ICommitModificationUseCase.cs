using UnityEngine;
using System.Reflection;

public interface ICommitModificationUseCase
{
    public void CommitModification(Component comp, PropertyInfo info, object oldVal, object newVal);
}
