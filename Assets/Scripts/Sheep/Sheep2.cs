using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Sheep2 : MonoBehaviour {
//	Vector3 startingPosition;
	int i = 0;
	bool call = true;
	public static Sheep2 sheep2_instance;
	
	void Awake () {
		sheep2_instance = this;
	}

	// Use this for initialization
	void Start () {
//		startingPosition = transform.position;
	}

	IEnumerator Wait() {
		yield return new WaitForSeconds(1);
		call = true;
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
	
	public void BarkedAt (Vector3 dogpos) {
		if (dogpos.x <= transform.position.x) {
			if (dogpos.y <= transform.position.y) {
				transform.position += Vector3.up * (Time.deltaTime) * 4000;
				transform.position += Vector3.right * (Time.deltaTime) * 4000;
			} else {
				transform.position += Vector3.down * (Time.deltaTime) * 4000;
				transform.position += Vector3.right * (Time.deltaTime) * 4000;
			}
		} else {
			if (dogpos.y <= transform.position.y) {
				transform.position += Vector3.up * (Time.deltaTime) * 4000;
				transform.position += Vector3.left * (Time.deltaTime) * 4000;
			} else {
				transform.position += Vector3.down * (Time.deltaTime) * 4000;
				transform.position += Vector3.left * (Time.deltaTime) * 4000;
			}
		}
		checkForDeletion ();
//		Debug.Log (transform.position);
	}
	
	public void KickedAt (Vector3 dogpos) {
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
//		Debug.Log (transform.position);
	}
	
	public void JumpedAt (Vector3 dogpos) {
		if (dogpos.x >= transform.position.x) {
			if (dogpos.y >= transform.position.y) {
				transform.position += Vector3.up * (Time.deltaTime) * 4000;
				transform.position += Vector3.right * (Time.deltaTime) * 4000;
			} else {
				transform.position += Vector3.down * (Time.deltaTime) * 4000;
				transform.position += Vector3.right * (Time.deltaTime) * 4000;
			}
		} else {
			if (dogpos.y >= transform.position.y) {
				transform.position += Vector3.up * (Time.deltaTime) * 4000;
				transform.position += Vector3.left * (Time.deltaTime) * 4000;
			} else {
				transform.position += Vector3.down * (Time.deltaTime) * 4000;
				transform.position += Vector3.left * (Time.deltaTime) * 4000;
			}
		}
		checkForDeletion ();
//		Debug.Log (transform.position);
	}
	
	void checkForDeletion() {
		if (transform.position.x >= 450 && transform.position.x <= 650 && transform.position.y >= 100 && transform.position.y <= 250) {
//			Debug.Log ("deleting");
			Destroy(gameObject);
			ExecuteCode.numOfSheep--;
		}
	}
}
