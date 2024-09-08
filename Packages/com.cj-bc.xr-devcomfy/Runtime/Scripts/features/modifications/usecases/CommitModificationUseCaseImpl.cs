using System;
using System.Reflection;
using UnityEngine;

namespace XRDevcomfy
{
    public class CommitModificationUseCaseImpl : ICommitModificationUseCase
    {
	private IModificationRepository repo;

	public CommitModificationUseCaseImpl(IModificationRepository _repo)
	{
	    repo = _repo;
	}

	public void CommitModification(Component comp, PropertyInfo info, object oldVal, object newVal)
	{
	    repo.Push(new PropertyModificationCommand(comp, info, oldVal, newVal));
	}
    }
}
