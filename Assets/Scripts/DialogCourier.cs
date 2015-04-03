using UnityEngine;
using System.Collections;

public class DialogCourier : MonoBehaviour {
/*
	A base class designed to act as a mediator betweeen dialogNodes and the game world.
	Talkers which have an effect on the game should have a custom class inheriting DialogCourier
	with an overridden ResponsePropagate(int response) that outlines the proper methods to call given the response number
*/	

	
	public virtual void ResponsePropagate (int response)
	{
		/*
			When overriding this function, make sure to create contingencies for all of the possible responses, remembering
			that one Talker could have several DialogNodes, each with several responses that have effects. Use switch statements,
			arrays, helper functions, whatever you need, so long as an overriden version of this function exists.
			I didn't say this was a clean solution.
		*/
		Debug.Log("You called the base method! There's no functionality here! Ref: " + response.ToString());
	}
}
