using UnityEngine;

namespace XRDevcomfy
{
    /// <summary>A Controller that is responsible for game object selection input</summary>
    public interface IGameObjectSelectionController
    {
	/// <summary>Select given GameObject</summary>
	/// <param name="obj">GameObject to select. If it's <c>null</c>, it indicates to unselect.</param>
        public void SelectGameObject(GameObject? obj);
    }

}
