using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClothingTabs : MonoBehaviour {
	public GameObject matchingPanel;
	public Image matchingItem;
	public GameObject[] otherPanels;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setPanel() {
		foreach (GameObject g in otherPanels) {
			g.SetActive(false);
		}

		matchingPanel.SetActive (true);
		GetComponentInParent<PanelInit> ().currentItem = matchingItem;
	}


}
