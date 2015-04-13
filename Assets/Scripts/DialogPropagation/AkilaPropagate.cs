using UnityEngine;
using System.Collections;

public class AkilaPropagate : DialogCourier {
	public override void ResponsePropagate (int response)
	{
		if(response == 999) 
		{
			Debug.Log ("Load Prudencia scene!");
			Application.LoadLevel(5);
		}
	}

}
