using System;
using System.Reflection;
using UnityEngine;
using System.Collections.Generic;

namespace XRDevcomfy
{
    /// Control transform
    public class TransformGizmoController : IGameObjectSelectionController
    {
	private PropertyInfo positionProperty = typeof(Transform).GetProperty("position");
	private PropertyInfo rotationProperty = typeof(Transform).GetProperty("rotation");
	private PropertyInfo localScaleProperty = typeof(Transform).GetProperty("localScale");
	private IGetTransformGizmoResultUseCase getGizmoResult;
	private ISetTransformGizmoUseCase setGizmo;
	private ICommitModificationUseCase commitModification;
	private IModificationRepository modifRepo;

        private GameObject? SelectedGameObject;

	public TransformGizmoController(IGetTransformGizmoResultUseCase _getGizmoResult,
					ISetTransformGizmoUseCase _setGizmo,
					IModificationRepository _modifRepo,
					ICommitModificationUseCase _commitModification)
	{
	    getGizmoResult = _getGizmoResult;
	    setGizmo = _setGizmo;
	    modifRepo = _modifRepo;
	    commitModification = _commitModification;
	}

        public void SelectGameObject(GameObject? obj)
	{
	    if (SelectedGameObject is not null
		&& getGizmoResult.GetTransformGizmoResult() is (TransformValue before, TransformValue after))
	    {
		switch (before, after)
		{
		    case (TransformValue b, TransformValue a) when b.Position != a.Position:
			commitModification.CommitModification(obj.transform, positionProperty, b.Position, a.Position);
			break;
		    case (TransformValue b, TransformValue a) when b.Rotation != a.Rotation:
			commitModification.CommitModification(obj.transform, rotationProperty, b.Rotation, a.Rotation);
			break;
		    case (TransformValue b, TransformValue a) when b.Scale != a.Scale:
			commitModification.CommitModification(obj.transform, localScaleProperty, b.Scale, a.Scale);
			break;
		    default:
			break;
		}

	    }

	    SelectedGameObject = null;
	    if (obj is GameObject go)
	    {
		SelectedGameObject = go;
		setGizmo.SetTransformGizmoTo(SelectedGameObject.transform);
	    }
	}
    }
}
