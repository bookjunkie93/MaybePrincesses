using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Follower2: MonoBehaviour {
	Transform target; //the enemy's target 
<<<<<<< HEAD:Assets/Scripts/Overworld/Follower2.cs
//	float moveSpeed = 8F; //move speed 
//	float rotationSpeed = 3F; //speed of turning
	public float distance;
//	Quaternion perp = new Quaternion (0f, 0f, 0f, 1f);
//	static int rerotate;
	
//	Transform myTransform; //current transform data of this enemy
	
	void Awake() { 
//		myTransform = transform; //cache transform data for easy access/preformance 
=======
	//	float moveSpeed = 8F; //move speed 
	//	float rotationSpeed = 3F; //speed of turning
	public float distance;
	//	Quaternion perp = new Quaternion (0f, 0f, 0f, 1f);
	//	static int rerotate;
	
	//	Transform myTransform; //current transform data of this enemy
	
	void Awake() { 
		//		myTransform = transform; //cache transform data for easy access/preformance 
>>>>>>> caaadee27299b63f5783dece9524fa415e90e442:Assets/Follower2.cs
	}
	
	void Start() { 
		target = GameObject.FindWithTag("Follower1").transform; //target the player
<<<<<<< HEAD:Assets/Scripts/Overworld/Follower2.cs
//		rerotate = 0;
=======
		//		rerotate = 0;
>>>>>>> caaadee27299b63f5783dece9524fa415e90e442:Assets/Follower2.cs
	}
	
	void Update () { 
		//rotate to look at the player 
		distance =Vector3.Distance(transform.position,target.position);
		int count = Walking.instance.prevPositions.Count;
		
		if (distance > 0.75) {
<<<<<<< HEAD:Assets/Scripts/Overworld/Follower2.cs

				transform.position = (Vector3) Follower1.instance.prevPositions.Dequeue();
=======
			if (count != 0) {
				transform.position = (Vector3) Follower1.instance.prevPositions.Dequeue();
			}
>>>>>>> caaadee27299b63f5783dece9524fa415e90e442:Assets/Follower2.cs
			
			//			Vector3 vectorToTarget = target.position - myTransform.position;
			//			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			//			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			//			myTransform.rotation = Quaternion.Slerp(myTransform.rotation, q, Time.deltaTime * moveSpeed);
			
<<<<<<< HEAD:Assets/Scripts/Overworld/Follower2.cs
//			Debug.Log (myTransform.rotation);
//			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
//			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
//			Vector3 newpos = myTransform.position;
//			newpos.z = 0;
//			myTransform.position = newpos;
//			
//			if (rerotate == 10) {
//				myTransform.rotation = perp;
//				rerotate = 0;
//			}
//			
//			rerotate++;
=======
			//			Debug.Log (myTransform.rotation);
			//			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
			//			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
			//			Vector3 newpos = myTransform.position;
			//			newpos.z = 0;
			//			myTransform.position = newpos;
			//			
			//			if (rerotate == 10) {
			//				myTransform.rotation = perp;
			//				rerotate = 0;
			//			}
			//			
			//			rerotate++;
>>>>>>> caaadee27299b63f5783dece9524fa415e90e442:Assets/Follower2.cs
			
			//move towards the player
			//			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
		
	}
}
