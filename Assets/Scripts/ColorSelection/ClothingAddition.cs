using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClothingAddition : MonoBehaviour {
	public GameObject item;
	int multiplier = 255;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void toggleItem() {

		if (Input.GetMouseButtonUp(1)) {

			item.SetActive(false);

		} else {

			item.SetActive(true);
			GetComponentInParent<PanelInit> ().currentItem = item.GetComponent<Image>();
			
			Slider[] sliders = GetComponentInParent<PanelInit>().GetComponentsInChildren<Slider>();
			
			float newRed =  item.GetComponent<Image>().color.r;
			float newGreen = item.GetComponent<Image>().color.g;
			float newBlue =  item.GetComponent<Image>().color.b;
			
			
			sliders[0].value = Mathf.Round(newRed * multiplier);
			sliders[1].value = Mathf.Round(newGreen * multiplier);
			sliders[2].value = Mathf.Round(newBlue * multiplier);
		}

	}

}
