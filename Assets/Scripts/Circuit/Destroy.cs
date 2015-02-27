using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Destroy : MonoBehaviour, IDropHandler {
	public GameObject item {
		get {
			if(transform.childCount > 0){
				return transform.GetChild (0).gameObject;
			}
			return null;
		}
	}
	
	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
		//if it doesn't have an item already, grab the item beign dropped
		if (!item) {
			DragHandler.itemBeingDragged.transform.SetParent (transform);
			Debug.Log(transform.parent.name);
			Destroy(DragHandler.itemBeingDragged);
			ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject,null, (x,y) => x.HasChanged ());
		}
	}
	#endregion
}
