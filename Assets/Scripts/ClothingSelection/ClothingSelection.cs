using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClothingSelection : MonoBehaviour {
	Image clothingItem;
	public Image currentItem;

	void Start(){
		clothingItem = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		clothingItem = GetComponent<Image> ();
	}

	public void ChangeItem() {
		GetComponentInParent<PanelInit>().currentItem = currentItem;
		if(clothingItem.name == "none") {
			currentItem.enabled = false;
		} else {
			currentItem.enabled = true;
			currentItem.sprite = clothingItem.sprite;
		}



	}
	
}
