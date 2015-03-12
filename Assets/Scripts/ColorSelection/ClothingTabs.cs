using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClothingTabs : MonoBehaviour {
	public GameObject matchingPanel;
	public Image matchingItem;
	public GameObject[] otherPanels;

	float multiplier = 255;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setPanel() {

		if(matchingPanel != null) {

			foreach (GameObject g in otherPanels) {
				g.SetActive(false);
			}
			
			matchingPanel.SetActive (true);
		}
	
		GetComponentInParent<PanelInit> ().currentItem = matchingItem;
		Slider[] sliders = GetComponentInParent<PanelInit>().GetComponentsInChildren<Slider>();

		float newRed =  matchingItem.color.r;
		float newGreen =  matchingItem.color.g;
		float newBlue =  matchingItem.color.b;


		sliders[0].value = Mathf.Round(newRed * multiplier);
		sliders[1].value = Mathf.Round(newGreen * multiplier);
		sliders[2].value = Mathf.Round(newBlue * multiplier);
	
	}


}
