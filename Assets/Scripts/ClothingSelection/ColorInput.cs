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
		s.value = int.Parse(f.text);
	}
}
