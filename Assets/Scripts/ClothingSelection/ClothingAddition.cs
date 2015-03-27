using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClothingAddition : MonoBehaviour {
	public GameObject item;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void toggleItem() {
		item.SetActive(!item.activeInHierarchy);
		GetComponentInParent<PanelInit> ().currentItem = item.GetComponent<Image>();
	}

	public void removeItem() {
		item.GetComponent<Renderer>().enabled = false;
	}
}
