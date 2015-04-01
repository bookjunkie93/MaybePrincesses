using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClothingTabs : MonoBehaviour {
	public GameObject matchingPanel;
	public Image matchingItem;

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
	
		GetComponentInParent<PanelInit> ().currentItem = matchingItem;

		Slider[] sliders = GetComponentInParent<PanelInit>().GetComponentsInChildren<Slider>();
		ColorSlider.UpdateSliders(matchingItem.color, sliders);

	
	}


}
