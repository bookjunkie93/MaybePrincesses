using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ClothingSelection : MonoBehaviour {
	Image clothingItem;
	public Image currentItem;

	void Start(){
		clothingItem = GetComponentInChildren<Image> ();

	}
	
	// Update is called once per frame
	void Update () {
		clothingItem = GetComponentInChildren<Image> ();
	}

	public void ChangeItem() {
		GetComponentInParent<PanelInit>().currentItem = currentItem;

		Slider[] sliders = GetComponentInParent<PanelInit>().GetComponentsInChildren<Slider>();
		ColorSlider.UpdateSliders(currentItem.color, sliders);

		if(clothingItem.name.Contains("none")) {
			currentItem.enabled = false;
		} else {
			currentItem.enabled = true;
			currentItem.sprite = clothingItem.sprite;
		}



	}
	
}
