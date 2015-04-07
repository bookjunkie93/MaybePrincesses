using UnityEngine;
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
				EnterMiniGameREMOVETHISTEXT.instance.ReturnToOverworld();
			} else if (waiting == false){
				Debug.Log("try again");
				GUI.Label (rect, "Try Again");
				StartCoroutine(Wait());
			}

		} //else {
		//	GUI.Label (rect, "");
		//}
		//message = false;
	}

	IEnumerator Wait() {
		Debug.Log("wait");
		yield return null;
		yield return new WaitForSeconds(5);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
