using UnityEngine;
using System.Collections.Generic;

namespace XRDevcomfy
{
    /// Control transform
    public class TransformGizmoController : IGameObjectSelectionController
    {
	private IGetTransformGizmoResultUseCase getGizmoResult;
	private ISetTransformGizmoUseCase setGizmo;

        private GameObject? SelectedGameObject;

	public TransformGizmoController(IGetTransformGizmoResultUseCase _getGizmoResult,
					ISetTransformGizmoUseCase _setGizmo)
	{
	    getGizmoResult = _getGizmoResult;
	    setGizmo = _setGizmo;
	}

        public void SelectGameObject(GameObject obj)
	{
	    if (SelectedGameObject is not null
		&& getGizmoResult.GetTransformGizmoResult() is (TransformValue before, TransformValue after))
	    {
		// Commit modification
	    }

	    SelectedGameObject = obj;
	    setGizmo.SetTransformGizmoTo(SelectedGameObject.transform);
	}
    }
}
