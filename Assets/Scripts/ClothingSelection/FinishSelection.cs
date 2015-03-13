using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinishSelection : MonoBehaviour {
	Image top;
	Image bottom;
	Image hair;
	public GameObject restart;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void saveClothing() {


		GameObject item = GameObject.Find("BasePanel");
		item.SetActive(false);


		restart.SetActive(true);


	}
}
