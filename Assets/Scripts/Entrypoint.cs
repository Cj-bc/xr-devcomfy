using UnityEngine;
using XRDevcomfy;
using RuntimeInspectorNamespace;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] RuntimeHierarchy hier;
    [SerializeField] TransformGizmo transformGizmoPrefab;

    void Start()
    {
	var modificationRepo = new InMemoryModificationRepository();
        var controller = new TransformGizmoController(transformGizmoPrefab, transformGizmoPrefab, modificationRepo);
        var selector = new RuntimeHierarchySelector(hier, controller);
    }
}
