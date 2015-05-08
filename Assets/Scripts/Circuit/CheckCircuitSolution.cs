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
		Debug.Log("check");
		solved = false;
		message = true;
		waiting = false;
		solved = CircuitBoard.instance.CheckSolution();
	}

	void OnGUI() 
	{
		Rect rect = new Rect(300,100,300,300);
		GUIStyle style = new GUIStyle();
		style.fontSize = 50;
		style.richText = true;
		if (message == true) {
			if (solved == true) {
				Debug.Log("win");
				GUI.Label (rect, "<color=#ffffffff>You Won!</color>", style);
				//EnterMiniGame.instance.ReturnToOverworld();
			} else if (waiting == false){
			//	Debug.Log("try again");
				GUI.Label (rect, "<color=#ffffffff>Try Again</color>", style);
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
		yield return new WaitForSeconds(3);
		waiting = true;

	}

	// Update is called once per frame
	void Update () {
	
	}
}
