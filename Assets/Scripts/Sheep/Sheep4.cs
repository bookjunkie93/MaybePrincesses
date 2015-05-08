using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Sheep4 : MonoBehaviour {
	//	Vector3 startingPosition;
	int i = 0;
	bool call = true;
	public static Sheep4 sheep4_instance;
	Vector3 lastPos;
	
	void Awake () {
		sheep4_instance = this;
	}
	
	// Use this for initialization
	void Start () {
		lastPos = transform.position;
		//		Debug.Log (transform.position);
		//		startingPosition = transform.position;
	}
	
	IEnumerator Wait() {
		yield return new WaitForSeconds(1);
		call = true;
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "gate") {
			Destroy(gameObject);
			ExecuteCode.numOfSheep--;
		}
	}
	
	// Update is called once per frame
	void Update () {
		checkForDeletion ();
		if (call) {
			if (i % 4 == 0) {
				transform.position += Vector3.up * (Time.deltaTime) * 500;
				call = false;
				StartCoroutine (Wait ());
			} else if (i % 4 == 1) {
				transform.position += Vector3.left * (Time.deltaTime) * 500;
				call = false;
				StartCoroutine (Wait ());
			} else if (i % 4 == 2) {
				transform.position += Vector3.down * (Time.deltaTime) * 500;
				call = false;
				StartCoroutine (Wait ());
			} else if (i % 4 == 3) {
				transform.position += Vector3.right * (Time.deltaTime) * 500;
				call = false;
				StartCoroutine (Wait ());
			}
			i++;
		}
		
	}
	
	public void KickedAt (Vector3 dogpos) {
		lastPos = transform.position;
		
		if (dogpos.x <= transform.position.x) {
			transform.position += Vector3.right * (Time.deltaTime) * 4096;
		} else {
			transform.position += Vector3.left * (Time.deltaTime) * 4096;
		}
		
		if (dogpos.y <= transform.position.y) {
			transform.position += Vector3.up * (Time.deltaTime) * 4096;
		} else {
			transform.position += Vector3.right * (Time.deltaTime) * 4096;
		}
		
		
		//		if (dogpos.x <= transform.position.x) {
		//			if (dogpos.y <= transform.position.y) {
		//				transform.position += Vector3.up * (Time.deltaTime) * 4096;
		//				transform.position += Vector3.right * (Time.deltaTime) * 4096;
		//			} else {
		//				transform.position += Vector3.down * (Time.deltaTime) * 4096;
		//				transform.position += Vector3.right * (Time.deltaTime) * 4096;
		//			}
		//		} else {
		//			if (dogpos.y <= transform.position.y) {
		//				transform.position += Vector3.up * (Time.deltaTime) * 4096;
		//				transform.position += Vector3.left * (Time.deltaTime) * 4096;
		//			} else {
		//				transform.position += Vector3.down * (Time.deltaTime) * 4096;
		//				transform.position += Vector3.left * (Time.deltaTime) * 4096;
		//			}
		//		}
		checkForDeletion ();
		checkPos ();
		//		Debug.Log (transform.position);
	}
	
	public void BarkedAt (Vector3 dogpos) {
		lastPos = transform.position;
		if (dogpos.x <= transform.position.x) {
			if (dogpos.y <= transform.position.y) {
				transform.position += Vector3.up * (Time.deltaTime) * 2000;
				transform.position += Vector3.right * (Time.deltaTime) * 2000;
			} else {
				transform.position += Vector3.down * (Time.deltaTime) * 2000;
				transform.position += Vector3.right * (Time.deltaTime) * 2000;
			}
		} else {
			if (dogpos.y <= transform.position.y) {
				transform.position += Vector3.up * (Time.deltaTime) * 2000;
				transform.position += Vector3.left * (Time.deltaTime) * 2000;
			} else {
				transform.position += Vector3.down * (Time.deltaTime) * 2000;
				transform.position += Vector3.left * (Time.deltaTime) * 2000;
			}
		}
		checkForDeletion ();
		checkPos ();
		//		Debug.Log (transform.position);
	}
	
	public void JumpedAt (Vector3 dogpos) {
		lastPos = transform.position;
		
		//		if (dogpos.x >= transform.position.x) {
		//			transform.position += Vector3.right * (Time.deltaTime) * 4096;
		//		} else {
		//			transform.position += Vector3.left * (Time.deltaTime) * 4096;
		//		}
		//		if (dogpos.y >= transform.position.y) {
		//			transform.position += Vector3.up * (Time.deltaTime) * 4096;
		//		} else {
		//			transform.position += Vector3.right * (Time.deltaTime) * 4096;
		//		}
		if (dogpos.x >= transform.position.x) {
			if (dogpos.y >= transform.position.y) {
				transform.position += Vector3.up * (Time.deltaTime) * 4096;
				transform.position += Vector3.right * (Time.deltaTime) * 4096;
			} else {
				transform.position += Vector3.down * (Time.deltaTime) * 4096;
				transform.position += Vector3.right * (Time.deltaTime) * 4096;
			}
		} else {
			if (dogpos.y >= transform.position.y) {
				transform.position += Vector3.up * (Time.deltaTime) * 4096;
				transform.position += Vector3.left * (Time.deltaTime) * 4096;
			} else {
				transform.position += Vector3.down * (Time.deltaTime) * 4096;
				transform.position += Vector3.left * (Time.deltaTime) * 4096;
			}
		}
		checkForDeletion ();
		checkPos ();
		//		Debug.Log (transform.position);
	}
	
	void checkForDeletion() {
		if (transform.position.x >= 345 && transform.position.x <= 565 && transform.position.y >= 131 && transform.position.y <= 225) {
			//			Debug.Log ("deleting");
			Destroy(gameObject);
			ExecuteCode.numOfSheep--;
		}
	}
	
	void checkPos(){
		if (transform.position.x >= 887 || transform.position.x <= -2.2 || transform.position.y >= 657 || transform.position.y <= 147) {
			transform.position = lastPos;
		}
	}
}
