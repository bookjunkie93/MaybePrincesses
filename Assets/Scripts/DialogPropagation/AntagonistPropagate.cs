using UnityEngine;
using System.Collections;

public class AntagonistPropagate : DialogCourier {
	public override void ResponsePropagate (int response)
	{
		if(response == 999) 
		{
			GameManagerScript.control.antagonistIntro = true;	
			Application.LoadLevel(11);
		}
	}
}
