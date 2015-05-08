using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PrudenciaPropagate : DialogCourier {
	public InputField input;
	InputField.SubmitEvent submitEvent;

	//Activate UI name field and listen for input
	void Start ()
	{
		submitEvent = new InputField.SubmitEvent();
		input.gameObject.SetActive(true);
		submitEvent.AddListener(GameManagerScript.control.SetName);
		input.onEndEdit = submitEvent;
	}

	public override void ResponsePropagate (int response)
	{
		switch (response)
		{	
			//add name entered by player
			case 2:	
				input.gameObject.SetActive(false); //remove name field
				Talker.instance.UpdatePersistents();
				break;
			//move to next level
			case 999:
				Application.LoadLevel(4);
				break;
		}
	}	
}
