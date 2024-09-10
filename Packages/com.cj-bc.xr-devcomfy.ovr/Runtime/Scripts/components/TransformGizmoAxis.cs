using UnityEngine;
using System;
using Oculus.Interaction;

namespace XRDevcomfy.OVR
{
    /// Move TransformGizmo axis by using Interactables
    public class TransformGizmoAxis : MonoBehaviour
    {
        [SerializeField] ColliderRayInteractable interactable;
        private Func<Ray>? getInteractorRay;
        private Transform interactorTransform;

        private Plane xAxisPlane;
        private Plane yAxisPlane;
        private Plane zAxisPlane;

        void Start()
        {
            interactable.WhenSelectingInteractorAdded.Action += (interactor) =>
            {
                getInteractorRay = () => interactor.Ray;
                interactorTransform = interactor.transform;
            };
            interactable.WhenSelectingInteractorRemoved.Action += (_) =>
            {
                getInteractorRay = null;
                interactorTransform = null;
            };
        }
        void Update()
        {
            if (getInteractorRay is null)
            {
                return;
            }

            Ray ray = getInteractorRay();
            xAxisPlane.SetNormalAndPosition(transform.forward, transform.position);
            if (xAxisPlane.Raycast(ray, out float enter))
            {
                Vector3 diff = Vector3.Project(ray.GetPoint(enter) - transform.position, transform.right);
                transform.position += diff;
            }

        }
    }

}
