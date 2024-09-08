namespace XRDevcomfy
{
    /// <summary>Get result of Transform Gizmo manipulation.</summary>
    public interface IGetTransformGizmoResultUseCase
    {
	/// <summary>Get result of Transform Gizmo manipulation.</summary>
	/// <returns>
	///   <c cref="before">before</c> is Transform value before this Gizmo manipulation is done.
	///   <c cref="after">after</c> is Transform value the target currently have.
	/// </returns>
	public (TransformValue before, TransformValue after)? GetTransformGizmoResult();
    }
}
