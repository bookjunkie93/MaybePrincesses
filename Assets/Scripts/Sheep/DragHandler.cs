using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public static GameObject itemBeingDragged;
	Vector3 startPosition;
	Transform startParent;
//	public GameObject Up;
	bool spawn = false;

	
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
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		if (transform.parent == startParent) {
			transform.position = startPosition;
		} else {
			if (spawn == true && transform.parent.name == "Trash") {
				Destroy(DragHandler.itemBeingDragged);
			}
			if (spawn == false && itemBeingDragged.name == "Up"){
				GameObject myObj = Instantiate(Resources.Load ("Up")) as GameObject;
				myObj.transform.SetParent (GameObject.Find("Up Slot").transform);
				//get position of parent
				myObj.transform.position = transform.parent.transform.position;
				myObj.name = "Up";
				myObj.transform.localScale = new Vector3 (1, 1, 1);
				spawn = true;
				if (transform.parent.name == "Trash") {
					Destroy(DragHandler.itemBeingDragged);
				}
			} else if (spawn == false && itemBeingDragged.name == "Down"){
				GameObject myObj = Instantiate(Resources.Load ("Down")) as GameObject;
				myObj.transform.SetParent (GameObject.Find("Down Slot").transform);
				//get position of parent
				myObj.transform.position = transform.parent.transform.position;
				myObj.name = "Down";
				myObj.transform.localScale = new Vector3 (1, 1, 1);
				spawn = true;
				if (transform.parent.name == "Trash") {
					Destroy(DragHandler.itemBeingDragged);
				}
			} else if (spawn == false && itemBeingDragged.name == "Left"){
				GameObject myObj = Instantiate(Resources.Load ("Left")) as GameObject;
				myObj.transform.SetParent (GameObject.Find("Left Slot").transform);
				//get position of parent
				myObj.transform.position = transform.parent.transform.position;
				myObj.name = "Left";
				myObj.transform.localScale = new Vector3 (1, 1, 1);
				spawn = true;
				if (transform.parent.name == "Trash") {
					Destroy(DragHandler.itemBeingDragged);
				}
			} else if (spawn == false && itemBeingDragged.name == "Right"){
				GameObject myObj = Instantiate(Resources.Load ("Right")) as GameObject;
				myObj.transform.SetParent (GameObject.Find("Right Slot").transform);
				//get position of parent
				myObj.transform.position = transform.parent.transform.position;
				myObj.name = "Right";
				myObj.transform.localScale = new Vector3 (1, 1, 1);
				spawn = true;
				if (transform.parent.name == "Trash") {
					//Debug.Log("destory");
					Destroy(DragHandler.itemBeingDragged);
				}
			} else if (spawn == false && itemBeingDragged.name == "Jump"){
				GameObject myObj = Instantiate(Resources.Load ("Jump")) as GameObject;
				myObj.transform.SetParent (GameObject.Find("Jump Slot").transform);
				//get position of parent
				myObj.transform.position = transform.parent.transform.position;
				myObj.name = "Jump";
				myObj.transform.localScale = new Vector3 (1, 1, 1);
				spawn = true;
				if (transform.parent.name == "Trash") {
					//Debug.Log("destory");
					Destroy(DragHandler.itemBeingDragged);
				}
			} else if (spawn == false && itemBeingDragged.name == "Kick"){
				GameObject myObj = Instantiate(Resources.Load ("Kick")) as GameObject;
				myObj.transform.SetParent (GameObject.Find("Kick Slot").transform);
				//get position of parent
				myObj.transform.position = transform.parent.transform.position;
				myObj.name = "Kick";
				myObj.transform.localScale = new Vector3 (1, 1, 1);
				spawn = true;
				if (transform.parent.name == "Trash") {
					//Debug.Log("destory");
					Destroy(DragHandler.itemBeingDragged);
				}
			} else if (spawn == false && itemBeingDragged.name == "Bark"){
				GameObject myObj = Instantiate(Resources.Load ("Bark")) as GameObject;
				myObj.transform.SetParent (GameObject.Find("Bark Slot").transform);
				//get position of parent
				myObj.transform.position = transform.parent.transform.position;
				myObj.name = "Bark";
				myObj.transform.localScale = new Vector3 (1, 1, 1);
				spawn = true;
				if (transform.parent.name == "Trash") {
					//Debug.Log("destory");
					Destroy(DragHandler.itemBeingDragged);
				}
			}
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
