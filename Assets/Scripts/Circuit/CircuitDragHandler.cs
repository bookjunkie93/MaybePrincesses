 using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CircuitDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public static GameObject itemBeingDragged; //static so only 1 object can be dragged at a time
	Vector3 startPosition;
	Transform startParent;
	public GameObject newCornerDownRight;
	public GameObject newCornerLeftDown;
	public GameObject newCornerLeftUp;
	public GameObject newCornerUpRight;
	public GameObject newHorizontalWire;
	public GameObject newVerticalWire;

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
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		//Debug.Log(transform.parent.name + "2");
		if (transform.parent == startParent) {
			//Debug.Log ("back to parent");
			//this is for git
			transform.position = startPosition;
		} else {
			if (spawn == true && transform.parent.name == "Trash Slot") {
				//Debug.Log("destory");
				Destroy (CircuitDragHandler.itemBeingDragged);
			}
			if (spawn == false && itemBeingDragged.name == "Horizontal Wire"){
				GameObject myObj = Instantiate(newHorizontalWire) as GameObject;
				myObj.transform.SetParent (GameObject.Find("Horizontal Wire Slot").transform);
				//get position of parent
				myObj.transform.position = transform.parent.transform.position;
				myObj.name = "Horizontal Wire";
				myObj.transform.localScale = new Vector3 (1, 1, 1);
				spawn = true;
				if (transform.parent.name == "Trash Slot") {
					//Debug.Log("destory");
					Destroy(CircuitDragHandler.itemBeingDragged);
				}
			}
			else if (spawn == false && itemBeingDragged.name == "Vertical Wire"){
				GameObject myObj = Instantiate(newVerticalWire) as GameObject;
				myObj.transform.SetParent (GameObject.Find("Vertical Wire Slot").transform);
				//get position of parent
				myObj.transform.position = transform.parent.transform.position;
				myObj.name = "Vertical Wire";
				myObj.transform.localScale = new Vector3 (1, 1, 1);
				spawn = true;
			}
			else if (spawn == false && itemBeingDragged.name == "Corner Up Right"){
				GameObject myObj = Instantiate(newCornerUpRight) as GameObject;
				myObj.transform.SetParent (GameObject.Find("Corner Up Right Slot").transform);
				//get position of parent
				myObj.transform.position = transform.parent.transform.position;
				myObj.name = "Corner Up Right";
				myObj.transform.localScale = new Vector3 (1, 1, 1);
				spawn = true;
			}
			else if (spawn == false && itemBeingDragged.name == "Corner Down Right"){
				GameObject myObj = Instantiate(newCornerDownRight) as GameObject;
				myObj.transform.SetParent (GameObject.Find("Corner Down Right Slot").transform);
				//get position of parent
				myObj.transform.position = transform.parent.transform.position;
				myObj.name = "Corner Down Right";
				myObj.transform.localScale = new Vector3 (1, 1, 1);
				spawn = true;
			}
			else if (spawn == false && itemBeingDragged.name == "Corner Left Down"){
				GameObject myObj = Instantiate(newCornerLeftDown) as GameObject;
				myObj.transform.SetParent (GameObject.Find("Corner Left Down Slot").transform);
				//get position of parent
				myObj.transform.position = transform.parent.transform.position;
				myObj.name = "Corner Left Down";
				myObj.transform.localScale = new Vector3 (1, 1, 1);
				spawn = true;
			}
			else if (spawn == false && itemBeingDragged.name == "Corner Left Up"){
				GameObject myObj = Instantiate(newCornerLeftUp) as GameObject;
				myObj.transform.SetParent (GameObject.Find("Corner Left Up Slot").transform);
				//get position of parent
				myObj.transform.position = transform.parent.transform.position;
				myObj.name = "Corner Left Up";
				myObj.transform.localScale = new Vector3 (1, 1, 1);
				spawn = true;
			}

		}
	}


	#endregion
}
