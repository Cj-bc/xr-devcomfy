
using Oculus.Interaction;
using System.Linq;
using UnityEngine;

namespace XRDevcomfy.OVR
{
    /// <summary>Ray Interactor that uses Collider instead of Pointable</summary>
    public class ColliderRayInteractor : Interactor<ColliderRayInteractor, ColliderRayInteractable>
    {
        [SerializeField] private Transform rayOrigin;
        [SerializeField] private float maxDistance;

#region Borrowed from "RayInteractor" implementation
        public Vector3 Origin { get; protected set; }
        public Quaternion Rotation { get; protected set; }
        public Vector3 Forward { get; protected set; }
        /// <summary>End of Raycast. Useful to place some indicator</summary>
        public Vector3 End { get; set; }
        public Ray Ray { get; protected set; }

        // Without Selector, no selection event will occur.
        //
        // details:
        // 
        // setter of Interactor.Selector registers to "WhenSelected"
        // event of selector.  That handler manipulates _selectorQueue
        // which is necessary to invoke selection event.
        [SerializeField, Interface(typeof(ISelector))]
        private UnityEngine.Object _selector;

        protected override void DoPreprocess()
        {
            Origin = rayOrigin.transform.position;
            Rotation = rayOrigin.transform.rotation;
            Forward = Rotation * Vector3.forward;
            Ray = new Ray(Origin, Forward);
        }

#endregion

        protected override void Awake()
        {
            base.Awake();
            Selector = _selector as ISelector;
        }

        protected override ColliderRayInteractable ComputeCandidate()
        {
            var closestCandidate = ColliderRayInteractable.Registry.List(this)
                .Where(interactable => interactable.Raycast(Ray, out _, maxDistance))
                .Aggregate<ColliderRayInteractable, ColliderRayInteractable>(null, (a, b) => (a, b) switch
                                                                             {
                                                                                 (null, _) => b,
                                                                                 (_, null) => a,
                                                                                 _ => Vector3.Distance(a.Origin.position, rayOrigin.position) < Vector3.Distance(b.Origin.position, rayOrigin.position) ? a : b,
                                                                             });

            // RayInteractorの実装では「最大限まで遠い場所」にしていた
            End = closestCandidate?.Origin.position ?? Origin + Forward * maxDistance;
            return closestCandidate;
        }
    }

}
