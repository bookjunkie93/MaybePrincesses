using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public static GameObject itemBeingDragged;
	GameObject itemClicked;
	Vector3 startPosition;
	Transform startParent;
	//	public GameObject Up;
	bool spawn = false;
	
	[SerializeField] Transform slots;
	
	void OnMouseOver() {
		Debug.Log (gameObject.name);
	}
	
	void OnMouseDown() {
		Debug.Log ("moused down");
		itemClicked = gameObject;
		bool placed = false;
		slots = GameObject.FindWithTag ("ExecutedCode").transform;
		
		foreach (Transform slotTransform in slots) {
			GameObject item = slotTransform.GetComponent<Slot1>().item;
			if (!item){
				Debug.Log ("no item");
				itemClicked.transform.SetParent(slotTransform);
				placed = true;
				break;
				//				Debug.Log(item.name);
			}
			
		}
		
		if (placed) {
			if (spawn == false && itemClicked.name == "Up"){
				spawnUp();
			} else if (spawn == false && itemClicked.name == "Down"){
				spawnDown();
			} else if (spawn == false && itemClicked.name == "Left"){
				spawnLeft();
			} else if (spawn == false && itemClicked.name == "Right"){
				spawnRight();
			} else if (spawn == false && itemClicked.name == "Jump"){
				spawnJump();
			} else if (spawn == false && itemClicked.name == "Kick"){
				spawnKick();
			} else if (spawn == false && itemClicked.name == "Bark"){
				spawnBark();
			}
		}
	}
	
	void Update() {
		//		if (Input.GetMouseButton (0))
		//			OnMouseDown ();
	}
	
	
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
				spawnUp();
			} else if (spawn == false && itemBeingDragged.name == "Down"){
				spawnDown();
			} else if (spawn == false && itemBeingDragged.name == "Left"){
				spawnLeft();
			} else if (spawn == false && itemBeingDragged.name == "Right"){
				spawnRight();
			} else if (spawn == false && itemBeingDragged.name == "Jump"){
				spawnJump();
			} else if (spawn == false && itemBeingDragged.name == "Kick"){
				spawnKick();
			} else if (spawn == false && itemBeingDragged.name == "Bark"){
				spawnBark();
			}
		}
	}
	
	#endregion
	
	#region IDragHandler implementation
	
	void spawnUp () {
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
	}
	
	void spawnDown() {
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
	}
	
	void spawnRight() {
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
	}
	
	void spawnLeft() {
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
	}
	
	void spawnKick() {
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
	}
	
	void spawnJump() {
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
	}
	
	void spawnBark() {
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
	
	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}
	
	#endregion
}
