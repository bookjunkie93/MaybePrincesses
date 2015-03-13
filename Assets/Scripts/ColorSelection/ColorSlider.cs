using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorSlider : MonoBehaviour {
	Slider s;

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
	
	}
}
