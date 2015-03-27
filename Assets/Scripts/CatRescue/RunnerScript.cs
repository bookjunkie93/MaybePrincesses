using UnityEngine;
using System.Collections;

public class RunnerScript : MonoBehaviour {
	public static RunnerScript instance;
	CharacterController2D mover;
	public float jumpSpeed;
	public float speed;
	public Vector2 jump;
	public Vector2 movement;
	public bool triggered;
	public bool goal;
	float timeElapsed;
	float startTime;
	int count;
	bool trySolution;
	Vector3 startPos;
	Quaternion startRot;
	

	void Awake () 
	{
		instance = this;
		triggered = false;
		goal = false;
		trySolution = false;
		timeElapsed = 0;
		startPos = transform.position;
		startRot = transform.rotation;
	}	
	
	public void CheckSolution ()
	{
		trySolution = true;
	}

	public void FixedUpdate () 
	{ 
			if(trySolution &&( timeElapsed < 5000))
			{
				startTime = Time.time;
				if(!triggered){
					this.GetComponent<Rigidbody2D>().AddForce(movement * (speed*Time.deltaTime));
					timeElapsed += (Time.time - startTime);
				}
			
				else{
					Debug.Log("Jumping!");
					this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
					this.GetComponent<Rigidbody2D>().AddForce(jump * (jumpSpeed));
					triggered = false;
				}
				timeElapsed += Time.time - startTime;
			}
			if(goal){
				this.gameObject.SetActive(false);
			}

	}
	public void OnTriggerEnter2D (Collider2D collider) {
		Debug.Log("triggered!");
		if(trySolution && (collider.gameObject.tag == "Stackable" || collider.gameObject.tag == "wall")){
			Debug.Log("hit a stackable!");
			triggered = true;
		}
	}
	public void Reset () {
		this.gameObject.SetActive(true);
		this.transform.position = startPos;
		this.transform.rotation = startRot;
		this.GetComponent<Rigidbody2D>().angularVelocity = 0;
		this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
		triggered = false;
		trySolution = false;
		goal = false;
		instance.goal = false;
		timeElapsed = 0;
	}

}
