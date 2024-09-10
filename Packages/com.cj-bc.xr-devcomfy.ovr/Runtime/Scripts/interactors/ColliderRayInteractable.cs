using Oculus.Interaction;
using UnityEngine;

namespace XRDevcomfy.OVR
{
    /// <summary>Ray Interactable that uses Collider instead of Pointable</summary>
    public class ColliderRayInteractable : Interactable<ColliderRayInteractor, ColliderRayInteractable>
    {
        [SerializeField] Transform _origin;
        /// <summary>Origin of interactable. Used to calculate distance from interactor to compare interactables</summary>
        public Transform Origin { get => _origin; }

        /// <summary>Collider that Ray should interact with</summary>
        [SerializeField] Collider interactionCollider;

        /// <summary>Raycast against this interactable.</summary>
        public bool Raycast(Ray ray, out RaycastHit hit, float maxDistance)
            => interactionCollider.Raycast(ray, out hit, maxDistance);
    }
}
