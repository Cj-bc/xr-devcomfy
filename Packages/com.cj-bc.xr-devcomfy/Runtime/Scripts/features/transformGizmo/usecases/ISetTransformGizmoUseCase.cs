using UnityEngine;

namespace XRDevcomfy
{
    /// <summary>Set Transform Gizmo's target <c cref=C:UnityEngine.Transform>Transform</c>.</summary>
    public interface ISetTransformGizmoUseCase
    {
	/// <summary>Set Transform Gizmo's target <c cref=C:UnityEngine.Transform>Transform</c>.</summary>
	/// <param name="transform">The Transform gizmo will be shown.</param>
	public void SetTransformGizmoTo(Transform transform);
    }
}
