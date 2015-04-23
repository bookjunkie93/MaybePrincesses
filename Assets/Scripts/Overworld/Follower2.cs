using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Follower2: MonoBehaviour {
	Transform target; //the enemy's target 
//	float moveSpeed = 8F; //move speed 
//	float rotationSpeed = 3F; //speed of turning
	public float distance;
//	Quaternion perp = new Quaternion (0f, 0f, 0f, 1f);
//	static int rerotate;
	
//	Transform myTransform; //current transform data of this enemy
	
	void Awake() { 
//		myTransform = transform; //cache transform data for easy access/preformance 
	}
	
	void Start() { 
		target = GameObject.FindWithTag("Follower1").transform; //target the player
//		rerotate = 0;
	}
	
	void Update () { 
		//rotate to look at the player 
		distance =Vector3.Distance(transform.position,target.position);
		
		if (distance > 0.75) {

				transform.position = (Vector3) Follower1.instance.prevPositions.Dequeue();
			
			//			Vector3 vectorToTarget = target.position - myTransform.position;
			//			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			//			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			//			myTransform.rotation = Quaternion.Slerp(myTransform.rotation, q, Time.deltaTime * moveSpeed);
			
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
			
			//move towards the player
			//			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
		
	}
}
