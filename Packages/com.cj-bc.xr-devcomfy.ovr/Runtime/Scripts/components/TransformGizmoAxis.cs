using UnityEngine;
using System;
using Oculus.Interaction;

namespace XRDevcomfy.OVR
{
    /// Move TransformGizmo axis by using Interactables
    public class TransformGizmoAxis : MonoBehaviour
    {
        [Serializable]
        public enum Axis { X, Y, Z }

        [SerializeField] ColliderRayInteractable interactable;
        [SerializeField] Axis axis;
        private Func<Ray>? getInteractorRay;
        private Transform interactorTransform;

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
            transform.position = CalculatePosition(transform);
        }

        Plane getAxisPlane(Transform _transform, Axis _axis)
        {
            var plane = new Plane();
            switch (_axis)
            {
                case Axis.X:
                    plane.SetNormalAndPosition(_transform.forward, _transform.position);
                    break;
                case Axis.Y:
                    plane.SetNormalAndPosition(_transform.forward, _transform.position);
                    break;
                case Axis.Z:
                    plane.SetNormalAndPosition(_transform.right, _transform.position);
                    break;
            }
            return plane;
        }

        Vector3 getProjectionVector(Transform _transform, Axis _axis) => (_axis) switch
        {
            Axis.X => _transform.right,
            Axis.Y => _transform.up,
            Axis.Z => _transform.forward,
        };

        /// <summary>Calculates world-space coordinate moved by
        /// interactable interaction.</summary>
        ///
        /// <param name="gizmoRoot">Root of Gizmo. It is considered to
        /// be transformed by result of this method.</param>
        ///
        /// <returns>Vector3 that represents world-space position that
        /// gizmo should be located. Returns <param name="gizmoRoot"
        /// />.position if it isn't affected by interaction.
        /// </returns>
        ///
        /// TODO: Use Hit position for smoother result
        public Vector3 CalculatePosition(Transform gizmoRoot)
        {
            if (getInteractorRay is null)
            {
                return gizmoRoot.position;
            }

            return ProjectRayInteresctionOntoAxis(getAxisPlane(gizmoRoot, axis)
                                                  , getProjectionVector(gizmoRoot, axis)
                                                  , getInteractorRay()) ?? gizmoRoot.position;
        }

        /// Rayを指定した軸へ投影し、そのワールド座標を返す
        /// <param name="axis">Axis to project against. In World space</param>
        /// <returns>Vector3 value that represents world-coordinate of result intersection.</returns>
        public static Vector3? ProjectRayInteresctionOntoAxis(Plane plane, Vector3 axis, Ray ray)
        {
            if (plane.Raycast(ray, out float enter))
            {
                Vector3 intersectionInGlobal = ray.GetPoint(enter);
                return Vector3.Project(intersectionInGlobal, axis);
            }
            return null;
        }
    }

}
