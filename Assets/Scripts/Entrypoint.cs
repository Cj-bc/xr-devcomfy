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
	var committer = new CommitModificationUseCaseImpl(modificationRepo);
        var controller = new TransformGizmoController(transformGizmoPrefab, transformGizmoPrefab, modificationRepo, committer);
        var selector = new RuntimeHierarchySelector(hier, controller);
    }
}
