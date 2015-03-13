using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour {	
	private Vector3 screenPoint;
	private Vector3 offset;
		
	void OnMouseDown() {
		Debug.Log("mousedown");
			
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
		
	void OnMouseDrag()
	{
		Debug.Log("Mouse drag");
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}
}

