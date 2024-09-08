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
	private IModificationRepository modifRepo;

        private GameObject? SelectedGameObject;

	public TransformGizmoController(IGetTransformGizmoResultUseCase _getGizmoResult,
					ISetTransformGizmoUseCase _setGizmo,
					IModificationRepository _modifRepo)
	{
	    getGizmoResult = _getGizmoResult;
	    setGizmo = _setGizmo;
	    modifRepo = _modifRepo;
	}

        public void SelectGameObject(GameObject obj)
	{
	    if (SelectedGameObject is not null
		&& getGizmoResult.GetTransformGizmoResult() is (TransformValue before, TransformValue after))
	    {
		switch (before, after)
		{
		    case (TransformValue b, TransformValue a) when b.Position != a.Position:
			modifRepo.Push(new PropertyModificationCommand(obj.transform, positionProperty, b.Position, a.Position));
			break;
		    case (TransformValue b, TransformValue a) when b.Rotation != a.Rotation:
			modifRepo.Push(new PropertyModificationCommand(obj.transform, rotationProperty, b.Rotation, a.Rotation));
			break;
		    case (TransformValue b, TransformValue a) when b.Scale != a.Scale:
			modifRepo.Push(new PropertyModificationCommand(obj.transform, localScaleProperty, b.Scale, a.Scale));
			break;
		    default:
			break;
		}

	    }

	    SelectedGameObject = obj;
	    setGizmo.SetTransformGizmoTo(SelectedGameObject.transform);
	}
    }
}
