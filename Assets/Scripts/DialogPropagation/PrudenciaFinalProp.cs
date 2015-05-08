using UnityEngine;
using System.Collections;

public class PrudenciaFinalProp : DialogCourier {
	public override void ResponsePropagate (int response)
	{
		switch (response)
		{
		case 999:
			EnterMiniGame.instance.ReturnToOverworld();
			break;
		}
	}

}
