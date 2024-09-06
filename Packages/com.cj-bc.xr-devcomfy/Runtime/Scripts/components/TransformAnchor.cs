using UnityEngine;

namespace XRDevcomfy.Components
{
    /// <summary>An anchor representation to manipulate gameObject's Transform</summary>
    public class TransformAnchor : MonoBehaviour
    {
        private Transform? anchoredTo = null;
        private TransformValue before;

        public void AnchorTo(Transform target)
        {
            before = TransformValue.FromTransform(target);
	    anchoredTo = target;
            transform.position = anchoredTo.position;
            transform.localScale = anchoredTo.localScale;
            transform.rotation = anchoredTo.rotation;
        }

        public (TransformValue before, TransformValue after) UnAnchor()
        {
            anchoredTo = null;
            return (before, TransformValue.FromTransform(transform));
        }

        void LateUpdate()
        {
            if (anchoredTo is null)
                return;

            anchoredTo.position = transform.position;
            anchoredTo.rotation = transform.rotation;
        }
    }
}
