using UnityEngine;

namespace XRDevcomfy
{
    /// <summary>Hold snapshot of transform</summary>
    public struct TransformValue
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Scale;

        public TransformValue(Vector3 pos, Quaternion rot, Vector3 scale)
        {
            Position = pos;
            Rotation = rot;
            Scale = scale;
        }

        public static TransformValue FromTransform(Transform trans)
            => new TransformValue(trans.position, trans.rotation, trans.localScale);

        public void ApplyToTransform(Transform trans)
        {
            trans.position = Position;
            trans.rotation = Rotation;
            trans.localScale = Scale;
        }
    }
}
