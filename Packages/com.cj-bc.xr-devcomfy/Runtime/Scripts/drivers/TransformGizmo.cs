using UnityEngine;

namespace XRDevcomfy
{
    public class TransformGizmo : MonoBehaviour, IGetTransformGizmoResultUseCase, ISetTransformGizmoUseCase
    {
	private TransformValue? before = null;
	private Transform? target = null;

	public (TransformValue before, TransformValue after)? GetTransformGizmoResult()
	{
	    if (before is TransformValue b && target is Transform t)
	    {
		before = null;
		target = null;
		return (b, TransformValue.FromTransform(t));
	    }
	    return null;

	}

	public void SetTransformGizmoTo(Transform _target)
	{
	    before = TransformValue.FromTransform(_target);
	    target = _target;
            transform.position = _target.position;
            transform.localScale = _target.localScale;
            transform.rotation = _target.rotation;
	}

        void LateUpdate()
        {
            if (target is null)
                return;

            target.position = transform.position;
            target.rotation = transform.rotation;
        }
    }
}
