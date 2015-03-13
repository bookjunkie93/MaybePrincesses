using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorSlider : MonoBehaviour {
	Slider s;

	float divisor = 255f;
	Image currentItem;


	// Use this for initialization
	void Start () {
		s = GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SetColor() {
		Debug.Log (s.value);
		float redRaw = s.value / (256f * 256f);
		Debug.Log ("red:" + Mathf.Round (redRaw));
		float greenRaw = s.value % 256f;
		Debug.Log ("green: " + Mathf.Round (greenRaw));
		float blueRaw = s.value % (256f * 256f);
		Debug.Log("blue: " + Mathf.Round(blueRaw));

		Slider[] sliders = GetComponentInParent<PanelInit>().GetComponentsInChildren<Slider>();
		Color c = new Color(sliders[0].value / divisor, sliders[1].value / divisor, sliders[2].value / divisor);
		currentItem = GetComponentInParent<PanelInit>().currentItem;
		currentItem.color = c;
		InputField[] fields = GetComponentInParent<PanelInit>().GetComponentsInChildren<InputField>();
		for (int i = 0; i < 3; i++) {
			fields[i].text = sliders[i].value.ToString();
		}	
		}
	
	}
