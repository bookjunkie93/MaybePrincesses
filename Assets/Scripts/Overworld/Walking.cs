using UnityEngine;
using System.Collections;

public class Walking : MonoBehaviour 
{
	public static Walking instance;

	public float walkspeed = 3F;
	public float runspeed = 7F;
	public float dist;

	public Cursor cursor;

	private float speed;
	private Vector3 pos;
	private Transform tr;

	private Animator anim;


	void Awake()
	{
		instance = this;
	}
	
	void Start ()
	{
		//Here we set the Values from the current position	
		anim = GetComponent<Animator>();

		pos = GameManagerScript.control.overworldPos;
		transform.position = pos;
		tr = transform;
	}
	
	void Update () 
	{
		Movement ();
		GetSpeed ();
		Interact ();
	
	}

	private void GetSpeed ()
	{
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			speed = runspeed;
		}
		else
		{
			speed = walkspeed;
		}
	}
	
	private void Movement() 
	{
		//If we press any Key we will add a direction to the position ...
		//using Vector3.'anydirection' will add 1 to that direction
		
		
		//But we Check if we are at the new Position, before we can add some more
		//it will prevent to move before you are at your next 'tile'
		if ((Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow)) && tr.position == pos /*&& CheckTarget (Vector3.right)*/) 
		{
			anim.SetInteger("state", 7);
//			transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z);
			pos += Vector3.right;

		}
		else if ((Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow)) && tr.position == pos /*&& CheckTarget (Vector3.left)*/) 
		{
			anim.SetInteger("state", 5);
			transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
			pos += Vector3.left;
		}
		else if ((Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow)) && tr.position == pos /*&& CheckTarget (Vector3.up)*/) 
		{
			anim.SetInteger("state", 4);
			pos += Vector3.up;
	
		}
		else if ((Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow)) && tr.position == pos /*&& CheckTarget (Vector3.down)*/) 
		{
			anim.SetInteger("state", 6);
			pos += Vector3.down;
		} 

		if(!Input.anyKey) {

			if (anim.GetInteger("state") == 4) {
				anim.SetInteger("state", 0);
			} else if (anim.GetInteger("state") == 5) {
				anim.SetInteger("state", 2);
			} else if (anim.GetInteger("state") == 6) {
				anim.SetInteger("state", 1);
			} else if(anim.GetInteger("state") == 7) {
				anim.SetInteger("state", 3);
			}
		}

		//Here you will move Towards the new position ...
		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
		
		
	}

	private bool CheckTarget (Vector3 dir)
	{
		RaycastHit2D obst;
		obst = Physics2D.Raycast (transform.position, dir, 1F);
		dist = obst.distance;
		if (dist > 0.6F)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	private void Interact ()
	{
		if (Input.GetKeyDown(KeyCode.Space) && tr.position == pos)
		{
			cursor.Interact ();
		}
	}
}





