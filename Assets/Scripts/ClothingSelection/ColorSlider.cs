using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorSlider : MonoBehaviour {
	Slider s;

<<<<<<< HEAD:Assets/Scripts/ColorSelection/ColorSlider.cs
=======
	float divisor = 255f;
	Image currentItem;
>>>>>>> d0c583d1bbf9a2b8598ad994291e4606af9ade75:Assets/Scripts/ClothingSelection/ColorSlider.cs
	// Use this for initialization
	void Start () {
		s = GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SetColor() {
<<<<<<< HEAD:Assets/Scripts/ColorSelection/ColorSlider.cs
		Debug.Log (s.value);
		float redRaw = s.value / (256f * 256f);
		Debug.Log ("red:" + Mathf.Round (redRaw));
		float greenRaw = s.value % 256f;
		Debug.Log ("green: " + Mathf.Round (greenRaw));
		float blueRaw = s.value % (256f * 256f);
		Debug.Log("blue: " + Mathf.Round(blueRaw));
=======

		Slider[] sliders = GetComponentInParent<PanelInit>().GetComponentsInChildren<Slider>();
		Color c = new Color(sliders[0].value / divisor, sliders[1].value / divisor, sliders[2].value / divisor);
		currentItem = GetComponentInParent<PanelInit>().currentItem;
		currentItem.color = c;
		InputField[] fields = GetComponentInParent<PanelInit>().GetComponentsInChildren<InputField>();
		for (int i = 0; i < 3; i++) {
			fields[i].text = sliders[i].value.ToString();
		}
>>>>>>> d0c583d1bbf9a2b8598ad994291e4606af9ade75:Assets/Scripts/ClothingSelection/ColorSlider.cs
	
	}
}
