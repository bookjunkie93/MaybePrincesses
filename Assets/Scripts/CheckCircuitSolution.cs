﻿using UnityEngine;
using System.Collections;

public class CheckCircuitSolution : MonoBehaviour {
	bool solved;
	bool message;
	bool waiting; 
	Rect rect;
	// Use this for initialization
	void Start () {
		message = false;
		rect = new Rect(150,150,300,300);
	}

	public void Check(){
		Debug.Log("check");
		solved = false;
		message = true;
		solved = CircuitBoard.instance.CheckSolution();
	}

	void OnGUI() 
	{
		if (message == true) {
			if (solved == true) {
				Debug.Log("win");
				GUI.Label (rect, "You Won!");
				EnterMiniGame.instance.ReturnToOverworld();
			} else if (waiting == false){
			//	Debug.Log("try again");
				GUI.Label (rect, "Try Again");
				StartCoroutine(Wait());
			}

		} //else {
		//	GUI.Label (rect, "");
		//}
		//message = false;
	}

	IEnumerator Wait() {
		//Debug.Log("wait");
		yield return null;
		yield return new WaitForSeconds(3);
	}

	// Update is called once per frame
	void Update () {
	
	}
}