using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateColor() {
		InputField f = GetComponent<InputField>();
		Slider s = GetComponentInParent<Slider>();
		int newVal = int.Parse(f.text);
		if (newVal > 255) {
			print ("Too large a number!");
			s.value = 255;
			f.text = "255";
		} else {
			s.value = newVal;
		}
	}
}
