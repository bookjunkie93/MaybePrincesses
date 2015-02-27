using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour
{
	public GameObject Player;

	public Talker selected;

	private Vector3 pos;

	// Use this for initialization
	void Start ()
	{
	
		pos = transform.position;

	}
	
	// Update is called once per frame
	void Update ()
	{
		Movement ();
		Interact ();
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == ("Talker"))
		{
			GameObject over = coll.gameObject;
			selected = over.GetComponent <Talker> ();
		}
	}

	void OnTriggerStay2D (Collider2D coll)
	{
		if (coll.gameObject.tag == ("Talker"))
		{
			GameObject over = coll.gameObject;
			selected = over.GetComponent <Talker> ();
		}
	}

	private void Movement ()
	{
		if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
		{
			pos = Vector3.right;
		}
		else if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
		{
			pos = Vector3.left;
		}
		else if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
		{
			pos = Vector3.up;
		}
		else if (Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow)) 
		{
			pos = Vector3.down;
		}

		transform.position = Player.transform.position + pos;
	}

	public void Interact ()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			if(selected != null)
			{
				selected.Speak ();
			}
		}
	}
}


