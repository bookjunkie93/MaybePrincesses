using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClothingAddition : MonoBehaviour {
	public Image item;
	Slider[] sliders;
	float multiplier = 255;
	// Use this for initialization
	void Start () {
		sliders = GetComponentInParent<PanelInit>().GetComponentsInChildren<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void toggleItem() {
	
		item.gameObject.SetActive(true);
		GetComponentInParent<PanelInit> ().currentItem = item;
		
		float newRed =  item.color.r;
		float newGreen =  item.color.g;
		float newBlue =  item.color.b;
		
		
		sliders[0].value = Mathf.Round(newRed * multiplier);
		sliders[1].value = Mathf.Round(newGreen * multiplier);
		sliders[2].value = Mathf.Round(newBlue * multiplier);


	}

	public void removeItem() {
		item.gameObject.SetActive(false);

		sliders[0].value = Mathf.Round(255);
		sliders[1].value = Mathf.Round(255);
		sliders[2].value = Mathf.Round(255);
	}

}
