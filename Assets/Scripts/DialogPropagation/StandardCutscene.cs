using UnityEngine;
using System.Collections;

public class StandardCutscene : DialogCourier {

	public int levelToLoad;
	public override void ResponsePropagate (int response)
	{
		if(response == 999) 
		{
			Application.LoadLevel(levelToLoad);
		}
	}
}
