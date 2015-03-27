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
//		PlayerPrefs.DeleteAll();
		foreach(GameObject g in GameObject.FindGameObjectsWithTag("CharacterClothingItem")) {
			if (g.activeInHierarchy && g.GetComponent<Image>().enabled) {
				PlayerPrefs.SetString(g.GetComponent<Image>().name, g.GetComponent<Image>().sprite.name);
				PlayerPrefs.SetFloat(g.GetComponent<Image>().name + "R", g.GetComponent<Image>().color.r);
				PlayerPrefs.SetFloat(g.GetComponent<Image>().name + "G", g.GetComponent<Image>().color.g);
				PlayerPrefs.SetFloat(g.GetComponent<Image>().name + "B", g.GetComponent<Image>().color.b);
				
			} else {
				PlayerPrefs.SetString(g.GetComponent<Image>().name, "");
				PlayerPrefs.SetFloat(g.GetComponent<Image>().name + "R", 1f);
				PlayerPrefs.SetFloat(g.GetComponent<Image>().name + "G", 1f);
				PlayerPrefs.SetFloat(g.GetComponent<Image>().name + "B", 1f);
			}

		}

		PlayerPrefs.Save();
	}
}
