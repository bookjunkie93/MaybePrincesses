using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorSlider : MonoBehaviour {

	float divisor = 255f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetColor() {

		Slider[] sliders = GetComponentInParent<PanelInit>().GetComponentsInChildren<Slider>();
		Color c = new Color(sliders[0].value / divisor, sliders[1].value / divisor, sliders[2].value / divisor);
		GetComponentInParent<PanelInit>().currentItem.color = c;
		InputField[] fields = GetComponentInParent<PanelInit>().GetComponentsInChildren<InputField>();
		for (int i = 0; i < 3; i++) {
			fields[i].text = sliders[i].value.ToString();
		}
	

	}
	
}
