using UnityEngine;
using System.Collections;

public class ElementSpawner : MonoBehaviour {
	
	public GameObject newWire;

	void Start () {
		
		// this creates a new game object called myObj (on the left side of the = sign)
		// 		and spawns a new instance of randomGO
		//		and then assigns that instance of randomGO to myObj so we can change it
		GameObject myObj = Instantiate(newWire) as GameObject;
		myObj.transform.parent = GameObject.Find("Slot1").transform;
		// at this point, after the above line is finished, we have a new game object called
		//		myObj which is a copy of a game object called randomGO
		
		/* the next line of code does this:
		 * 		take this new game object we made and assign it's position to be the same
		 * 		as the current object's position -- so that this new object we just made called myObj
		 * 		will start out in the same position as the spawner object that this script
		 * 		will be attached to.
		 */
		myObj.transform.position = transform.position;
		myObj.transform.localScale = new Vector3 (1, 1, 1);
	//	Debug.Log ("position is" + myObj.transform.position);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
