using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Follower1 : MonoBehaviour {
	public static Follower1 instance;
	
	Transform target; //the enemy's target 
	public float distance;
	Vector3 lastPosition;
	
	public Queue prevPositions = new Queue();
	public Queue prevDirections = new Queue ();
	
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
		//prevDirections.Enqueue (anim.GetInteger("state"));
	}
	
	void Update () { 
		//		Debug.Log ("UPDATING");
		distance = Vector3.Distance(transform.position,target.position);
		int count = Walking.instance.prevPositions.Count;
		
		if (lastPosition != transform.position) {
			prevPositions.Enqueue (transform.position);
//			prevDirections.Enqueue (anim.GetInteger("state"));
		}
		lastPosition = transform.position;
		
		if (distance > 0.75) {
			if (count != 0) {
				myTransform.position = (Vector3) Walking.instance.prevPositions.Dequeue();
				int dir = (int)Walking.instance.prevDirections.Dequeue();
				Debug.Log (dir);
//				anim.SetInteger();
			}
		}
		
	}
}
