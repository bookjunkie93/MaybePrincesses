using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Follower1 : MonoBehaviour {
	public static Follower1 instance;

	Transform target; //the enemy's target 
//	float moveSpeed = 8F; //move speed 
//	float rotationSpeed = 3F; //speed of turning
	public float distance;
//	Quaternion perp = new Quaternion (0f, 0f, 0f, 1f);
//	static int rerotate;
	Vector3 lastPosition;

	public Queue prevPositions = new Queue();
	
	Transform myTransform; //current transform data of this enemy
	
	void Awake() { 
		instance = this;
		myTransform = transform; //cache transform data for easy access/preformance 
	}
	
	void Start() { 
		target = GameObject.FindWithTag("Player").transform; //target the player
//		rerotate = 0;

		lastPosition = transform.position;

		prevPositions.Enqueue (transform.position);
		prevPositions.Enqueue (transform.position);
		prevPositions.Enqueue (transform.position);
	}
	
	void Update () { 
//		Debug.Log ("UPDATING");
		//rotate to look at the player 
		distance =Vector3.Distance(transform.position,target.position);

		if (lastPosition != transform.position) {
			prevPositions.Enqueue (transform.position);
		}
		lastPosition = transform.position;
		
		if (distance > 0.75) {
			myTransform.position = (Vector3) Walking.instance.prevPositions.Dequeue();
		}
		
	}
}
