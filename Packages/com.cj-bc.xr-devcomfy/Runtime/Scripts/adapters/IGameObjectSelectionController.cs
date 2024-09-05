using UnityEngine;

namespace XRDevcomfy
{
    /// <summary>A Controller that is responsible for game object selection input</summary>
    public interface IGameObjectSelectionController
    {
        public void SelectGameObject(GameObject obj);
    }

}
