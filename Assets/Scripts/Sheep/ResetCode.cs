using UnityEngine;
using System.Collections;

public class ResetCode : MonoBehaviour {
	[SerializeField] Transform slots;
	public static ResetCode instance;
	// Use this for initialization
	void Start () {
		instance = this;
	}

	public void EraseCode() {
		foreach (Transform slotTransform in slots) {
			GameObject item = slotTransform.GetComponent<Slot1>().item;
			if (item){
				Destroy(item);
				//				Debug.Log(item.name);
			}
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
