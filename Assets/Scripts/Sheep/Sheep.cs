using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Sheep : MonoBehaviour {
//	Vector3 startingPosition;
	int i = 0;
	bool call = true;

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
		if (call) {
			if (i % 4 == 0) {
				transform.position += Vector3.up * (Time.deltaTime) * 1000;
				call = false;
				StartCoroutine (Wait ());
			} else if (i % 4 == 1) {
				transform.position += Vector3.left * (Time.deltaTime) * 1000;
				call = false;
				StartCoroutine (Wait ());
			} else if (i % 4 == 2) {
				transform.position += Vector3.down * (Time.deltaTime) * 1000;
				call = false;
				StartCoroutine (Wait ());
			} else if (i % 4 == 3) {
				transform.position += Vector3.right * (Time.deltaTime) * 1000;
				call = false;
				StartCoroutine (Wait ());
			}
			i++;
		}

	}
}
