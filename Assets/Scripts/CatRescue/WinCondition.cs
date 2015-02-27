using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour 
{
	bool gamewon;
	void Start () 
	{
		gamewon = false;
	}
	
	void OnTriggerEnter2D(Collider2D collider) 
	{
		if (collider.gameObject.tag == "TriggerObject")
		{
			RunnerScript.instance.goal = true;
			gamewon = RunnerScript.instance.goal;			
		}
	}
	void OnGUI() 
	{
		Rect rect = new Rect(150,150,300,300);
		if(RunnerScript.instance.goal)
		{
			GUI.Label(rect, "You Won!");
		}
		else
		{			
			GUI.Label(rect, "");
		}
	}
}
