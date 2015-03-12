using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorButtons : MonoBehaviour {
	Button button;
	float multiplier = 255;
	void Start(){
		button = GetComponent<Button> ();

	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void ChangeColor() {
		Slider[] sliders = GetComponentInParent<PanelInit>().GetComponentsInChildren<Slider>();
		sliders[0].value = Mathf.Round(button.colors.normalColor.r * multiplier);
		sliders[1].value = Mathf.Round(button.colors.normalColor.g * multiplier);
		sliders[2].value = Mathf.Round(button.colors.normalColor.b * multiplier);
	}
}
