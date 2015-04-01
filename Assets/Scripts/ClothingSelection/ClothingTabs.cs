using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClothingTabs : MonoBehaviour {
	public GameObject matchingPanel;
	public Image[] matchingItems;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setPanel() {

		foreach (GameObject g in GameObject.FindGameObjectsWithTag("Panel")) {
			g.SetActive(false);
		}

		if (matchingPanel != null) {

			matchingPanel.SetActive (true);
		}

		foreach(Image i in matchingItems) {

			if (i.enabled) {
				
				GetComponentInParent<PanelInit> ().currentItem = i;
				
				Slider[] sliders = GetComponentInParent<PanelInit>().GetComponentsInChildren<Slider>();
				ColorSlider.UpdateSliders(i.color, sliders);
				break;
			}
			
		}
	
	
	}


}
