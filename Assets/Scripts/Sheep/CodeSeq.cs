using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CodeSeq: MonoBehaviour, IHasChanged {
	[SerializeField] Transform slots1;
//	[SerializeField] Text inventoryText;
	// Use this for initialization
	void Start () {
		HasChanged ();
	}

	#region IHasChanged implementation

	public void HasChanged ()
	{
//		System.Text.StringBuilder builder = new System.Text.StringBuilder ();
//		builder.Append (" - ");
		foreach (Transform slotTransform in slots1) {
			GameObject item = slotTransform.GetComponent<Slot>().item;
			if (item){
				Debug.Log(item.name);
//				builder.Append (item.name);
//				builder.Append (" - ");
			}
		}
//		inventoryText.text = builder.ToString (); 
	}

	#endregion
}