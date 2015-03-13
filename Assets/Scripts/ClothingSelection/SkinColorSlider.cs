using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkinColorSlider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeSkinColor() {
		Slider[] sliders = GetComponentInParent<PanelInit>().GetComponentsInChildren<Slider>();
		Color c = new Color(sliders[0].value, sliders[1].value, sliders[2].value);
		GetComponentInParent<PanelInit>().character.color = c;
	}

	string ColorToHex(Color32 color)
	{
		string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
		return hex;
	}

	Color HexToColor(string hex)
	{
		byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		return new Color32(r,g,b, 255);
	}

}
