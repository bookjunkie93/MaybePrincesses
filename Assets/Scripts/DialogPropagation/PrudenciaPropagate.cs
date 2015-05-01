using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PrudenciaPropagate : DialogCourier {
	public InputField input;
	InputField.SubmitEvent submitEvent;

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
			case 2:	
				input.gameObject.SetActive(false);
				Talker.instance.UpdatePersistents(2);
				break;
				//instantiate Name input field
			case 999:
				Application.LoadLevel(4);
				break;
		}
	}	
}
