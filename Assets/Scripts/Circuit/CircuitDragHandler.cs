using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CircuitDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public static GameObject itemBeingDragged; //static so only 1 object can be dragged at a time
	Vector3 startPosition;
	Transform startParent;
	public GameObject newWire;
	public GameObject newCornerWire;
	bool spawn = false;

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
		//itemBeingDragged = null;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		//Debug.Log(transform.parent.name + "2");
		if (transform.parent == startParent) {
			//Debug.Log ("back to parent");
			transform.position = startPosition;
		} 
		else {
			if (spawn == true && transform.parent.name == "Trash Slot") {
				//Debug.Log("destory");
				Destroy(CircuitDragHandler.itemBeingDragged);
			}
			if (spawn == false && itemBeingDragged.name == "Wire"){
				//Debug.Log("wire being dragged");
				GameObject myObj = Instantiate(newWire) as GameObject;
				myObj.transform.SetParent (GameObject.Find("Wire Slot").transform);
				//get position of parent
				myObj.transform.position = transform.parent.transform.position;
				myObj.name = "Wire";
				myObj.transform.localScale = new Vector3 (1, 1, 1);
				spawn = true;
				if (transform.parent.name == "Trash Slot") {
					//Debug.Log("destory");
					Destroy(CircuitDragHandler.itemBeingDragged);
				}
			}
			/*else if (spawn == false && itemBeingDragged.name == "Corner Wire"){
				Debug.Log("corner wire being dragged");
				GameObject myObj = Instantiate(newCornerWire) as GameObject;
				myObj.transform.SetParent (GameObject.Find("Corner Wire Slot").transform);
				//get position of parent
				myObj.transform.position = transform.parent.transform.position;
				myObj.name = "Corner Wire";
				myObj.transform.localScale = new Vector3 (1, 1, 1);
				spawn = true;
			}*/
		}
	}


	#endregion
}
