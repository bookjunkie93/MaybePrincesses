using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


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
		PlayerManager dataStore = GameObject.FindGameObjectWithTag("Clothing Data").GetComponent<PlayerManager>();
		foreach(GameObject g in GameObject.FindGameObjectsWithTag("CharacterClothingItem")) {
			if (g.activeInHierarchy && g.GetComponent<Image>().enabled) {
				dataStore.AddItem(g.GetComponent<Image>().name, g.GetComponent<Image>().sprite,g.GetComponent<Image>().color);
				PlayerPrefs.SetString(g.GetComponent<Image>().name, g.GetComponent<Image>().sprite.name);
				PlayerPrefs.SetFloat(g.GetComponent<Image>().name + "R", g.GetComponent<Image>().color.r);
				PlayerPrefs.SetFloat(g.GetComponent<Image>().name + "G", g.GetComponent<Image>().color.g);
				PlayerPrefs.SetFloat(g.GetComponent<Image>().name + "B", g.GetComponent<Image>().color.b);

				
			} else {
				dataStore.RemoveItem(g.GetComponent<Image>().name);
				PlayerPrefs.SetString(g.GetComponent<Image>().name, "");
				PlayerPrefs.SetFloat(g.GetComponent<Image>().name + "R", g.GetComponent<Image>().color.r);
				PlayerPrefs.SetFloat(g.GetComponent<Image>().name + "G", g.GetComponent<Image>().color.g);
				PlayerPrefs.SetFloat(g.GetComponent<Image>().name + "B", g.GetComponent<Image>().color.b);
			}

		}
		PlayerPrefs.Save();
	}
}
