using UnityEngine;
using System.Collections;

public class PrudenciaPropagate : DialogCourier {

	public override void ResponsePropagate (int response)
	{
		switch (response)
		{
			case 2:
				Debug.Log("YOUR NAME IS WRINKLESNORT VAN WANKERSHIMS. YOU ARE A DISGRACE TO THE FAMILY");
				break;
				//instantiate Name input field
			case 4:
				Application.LoadLevel(4);
				break;
			case 7: 
				Debug.Log("I hate everything you stand for Mitt Romney");
				break;
				//remove DialogCanvas
		}
	}	
}
