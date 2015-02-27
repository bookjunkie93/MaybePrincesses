using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DragJump : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public static GameObject itemBeingDragged;
	Vector3 startPosition;
	Transform startParent;
	public GameObject Jump;
	
	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}
	#endregion
	
	
	#region IEndDragHandler implementation
	
	public void OnEndDrag (PointerEventData eventData)
	{
//		itemBeingDragged = null;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		if (transform.parent == startParent) {
			transform.position = startPosition;
		} else {
			GameObject myObj = Instantiate(Jump) as GameObject;
			myObj.transform.SetParent (GameObject.Find("Jump Slot").transform);
			myObj.transform.position = transform.parent.transform.position;
			myObj.name = "Jump";
			myObj.transform.localScale = new Vector3 (1, 1, 1);
		}
	}
	
	#endregion
	
	#region IDragHandler implementation
	
	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}
	
	#endregion
}
