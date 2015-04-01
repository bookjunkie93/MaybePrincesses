using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SubOptions : MonoBehaviour {
	public Toggle parent;
	public Image correspondingItem;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void chooseOption() {
//		parent.GetComponent<ClothingTabs>().matchingItem = correspondingItem;
		print ("set matching item to: " + correspondingItem.name);
	}
}
