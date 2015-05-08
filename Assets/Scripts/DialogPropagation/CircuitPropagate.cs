using UnityEngine;
using System.Collections;

public class CircuitPropagate : DialogCourier {

	public override void ResponsePropagate (int response)
	{	
		if(response == 999) 
		{
			GameManagerScript.control.circuitIntro = true;	
			Application.LoadLevel(3);
		}	
	}
}
