using UnityEngine;
using System.Collections;

public class DragAndDropCat : MonoBehaviour {	
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 startPos;
	private Quaternion startRot;

	void Start ()
	{
		startPos = transform.position;
		startRot = transform.rotation;
	}
		
		
	void OnMouseDown() 
	{
		Debug.Log("mousedown");			
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
		
	void OnMouseDrag()
	{		
		//stop errant rotation when dragging
		this.GetComponent<Rigidbody2D>().angularVelocity = 0f;

		//rotate on spacebar
		if(Input.GetKeyDown("space"))
		{
			this.transform.Rotate(0,0,-90);
		}
		Debug.Log("Mouse drag");
		//make object follow mouse position
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}
	public void Reset ()
	{
		transform.position = startPos;
		transform.rotation = startRot;
	}
		
}

