using UnityEngine;
using System.Collections;

public class SheepPrincessPropagate : DialogCourier {
	public override void ResponsePropagate (int response)
	{
		if(response == 999) 
		{
			GameManagerScript.control.sheepIntro = true;
			if(GameManagerScript.control.sheepIntro){
				Debug.Log ("successSheep");
			}
			Application.LoadLevel(2);
		}
	}
	
}
