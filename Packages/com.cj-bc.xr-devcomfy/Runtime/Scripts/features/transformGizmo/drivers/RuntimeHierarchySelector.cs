using RuntimeInspectorNamespace;
using UnityEngine;
using System.Collections.ObjectModel;

namespace XRDevcomfy
{
    /// <summary>Select gameobject by using yasirkula's RuntimeHierarchy</summary>
    public class RuntimeHierarchySelector
    {
        RuntimeHierarchy hierarchy;
        IGameObjectSelectionController selection;

        public RuntimeHierarchySelector(RuntimeHierarchy hier, IGameObjectSelectionController sel)
        {
            hierarchy = hier;
            selection = sel;
            hierarchy.OnSelectionChanged += Selected;
        }

        ~RuntimeHierarchySelector()
        {
            hierarchy.OnSelectionChanged -= Selected;
        }

        public void Selected(ReadOnlyCollection<Transform> selections)
        {
            if (selections.Count <= 0)
                return;

            selection.SelectGameObject(selections[0].gameObject);
        }
    }
}
