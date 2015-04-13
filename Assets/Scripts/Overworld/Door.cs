using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
	public GameObject twin;
	public GameObject player;
	private Vector3 dest;

	void Start ()
	{
		dest = twin.transform.position;
	}

	public void OnTriggerEnter2D (Collider2D collider)
	{
		Debug.Log("Door");
		Walking.instance.Door2Door(dest);
	}
}