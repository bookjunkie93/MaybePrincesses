using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemToggle : MonoBehaviour {
	public Image matchingItem;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SelectToggle() {
		GetComponentInParent<PanelInit>().currentItem = matchingItem;
	}
}
