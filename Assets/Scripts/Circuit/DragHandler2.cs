using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler2 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public static GameObject itemBeingDragged; //static so only 1 object can be dragged at a time
	Vector3 startPosition;
	Transform startParent;
	public GameObject newWire;
	
	#region IBeginDragHandler implementation
	
	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		//if user drags object to invalid position, it will drop back to where it started
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	
	#endregion
	
	
	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}
	#endregion
	
	
	#region IEndDragHandler implementation
	
	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeingDragged = null;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		if (transform.parent == startParent) {
			transform.position = startPosition;
		}
		else {
			GameObject myObj = Instantiate(newWire) as GameObject;
			myObj.transform.SetParent (GameObject.Find("Wire Slot").transform);
			myObj.transform.position = transform.position;
			myObj.transform.localScale = new Vector3 (1, 1, 1);
			
		}
	}
	
	
	#endregion
}
