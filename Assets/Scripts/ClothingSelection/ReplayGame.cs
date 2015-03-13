using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ReplayGame : MonoBehaviour {
	public GameObject basePanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void replay() {
		basePanel.SetActive(true);
		PanelInit p = basePanel.GetComponent<PanelInit>();

		p.currentTop.sprite = p.defaultTop;
		p.currentTop.color = Color.white;

		p.currentBottom.sprite = p.defaultBottom;
		p.currentBottom.color = Color.white;

		p.currentHair.sprite = p.defaultHair;
		p.currentHair.color = Color.white;

		p.currentItem = p.currentTop;

		GameObject.Find("Restart").SetActive(false);
	}
}
