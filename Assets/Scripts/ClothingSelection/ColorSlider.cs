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

		//Get color from sliders
		Color c = new Color(sliders[0].value / divisor, sliders[1].value / divisor, sliders[2].value / divisor);

		Image ci = GetComponentInParent<PanelInit>().currentItem;

		if (ci.name == "characterBody") {
			GameObject.Find("characterEyelids").GetComponent<Image>().color = c;
			GameObject.Find("characterFace").GetComponent<Image>().color = c;
		} 

		if (ci.name.Contains("Hair")) {
			GameObject.Find("currentHairBottom").GetComponent<Image>().color = c;
			GameObject.Find("currentHairTop").GetComponent<Image>().color = c;
			GameObject.Find("characterEyebrows").GetComponent<Image>().color = c;

		}

		ci.color = c;

		//Update input fields
		InputField[] fields = GetComponentInParent<PanelInit>().GetComponentsInChildren<InputField>();
		for (int i = 0; i < 3; i++) {
			fields[i].text = sliders[i].value.ToString();
		}
		
		
	}



	public static void UpdateSliders(Color c, Slider[] sliders) {
		float multiplier = 255f;
		
		float newRed = c.r;
		float newGreen = c.g;
		float newBlue = c.b;

		sliders[0].value = Mathf.Round(newRed * multiplier);
		sliders[1].value = Mathf.Round(newGreen * multiplier);
		sliders[2].value = Mathf.Round(newBlue * multiplier);

	}

	public static void RandomizeColor(Slider[] sliders) {
		Color random = new Color(Random.value, Random.value, Random.value);
		UpdateSliders(random, sliders);
		
	}
	
}
