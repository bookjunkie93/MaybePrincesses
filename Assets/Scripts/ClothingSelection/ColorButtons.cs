using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorButtons : MonoBehaviour {
	Button button;
	void Start(){
		button = GetComponent<Button> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void ChangeColor() {
		Slider[] sliders = GetComponentInParent<PanelInit>().GetComponentsInChildren<Slider>();
		ColorSlider.UpdateSliders(button.colors.normalColor, sliders);
		GetComponentInParent<PanelInit>().currentItem.color = button.colors.normalColor;
		
	}

	public void SetRandomColor() {
		ColorSlider.RandomizeColor(GetComponentInParent<PanelInit>().GetComponentsInChildren<Slider>());
	}
}

