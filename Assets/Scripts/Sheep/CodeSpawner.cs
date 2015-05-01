using UnityEngine;
using System.Collections;

public class CodeSpawner : MonoBehaviour {
	GameObject itemClicked;
	[SerializeField] Transform slots;
	bool spawn = false;
	bool waiting = true;


	// Use this for initialization
	void Start () {
	
	}

	IEnumerator Wait() {
		Debug.Log("Before Waiting 2 seconds");
		yield return new WaitForSeconds(2);
		Debug.Log("After Waiting 2 Seconds");
		waiting = true;
	}
	
	// Update is called once per frame
	void Update () {
		CheckButtonDown ();
	}

	void CheckButtonDown () {
		if (waiting) {
			bool placed = false;
			bool pressed = false;
			slots = GameObject.FindWithTag ("ExecutedCode").transform;
		
			if (Input.GetKey (KeyCode.UpArrow)) {
				itemClicked = GameObject.Find ("Up");
				pressed = true;
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				itemClicked = GameObject.Find ("Down");
				pressed = true;
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				itemClicked = GameObject.Find ("Left");
				pressed = true;
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				itemClicked = GameObject.Find ("Right");
				pressed = true;
			}
			if (Input.GetKey (KeyCode.L)) {
				itemClicked = GameObject.Find ("Jump");
				pressed = true;
			}
			if (Input.GetKey (KeyCode.K)) {
				itemClicked = GameObject.Find ("Kick");
				pressed = true;
			}
		
			if (pressed) {
				foreach (Transform slotTransform in slots) {
					GameObject item = slotTransform.GetComponent<Slot1> ().item;
					if (!item) {
						//					Debug.Log ("no item");
						itemClicked.transform.SetParent (slotTransform);
						placed = true;
						break;
						//				Debug.Log(item.name);
					}
				
				}
			
				if (placed) {
					Debug.Log ("placed");
					if (spawn == false && itemClicked.name == "Up") {
						spawnUp ();
					} else if (spawn == false && itemClicked.name == "Down") {
						spawnDown ();
					} else if (spawn == false && itemClicked.name == "Left") {
						spawnLeft ();
					} else if (spawn == false && itemClicked.name == "Right") {
						spawnRight ();
					} else if (spawn == false && itemClicked.name == "Jump") {
						spawnJump ();
					} else if (spawn == false && itemClicked.name == "Kick") {
						spawnKick ();
					} else if (spawn == false && itemClicked.name == "Bark") {
						spawnBark ();
					}
				}
			}
			waiting = false;
			StartCoroutine (Wait ());
		}
	}

	void spawnUp () {
		//		Debug.Log("up spawning");
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
}
