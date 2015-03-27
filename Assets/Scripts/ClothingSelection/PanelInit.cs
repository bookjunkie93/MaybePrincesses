using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PanelInit : MonoBehaviour {
	public Image character;
	public Image currentItem;
	List<Color> skinColors;

	// Use this for initialization
	void Start () {
		skinColors = new List<Color>();
		GameObject[] skinButtons = GameObject.FindGameObjectsWithTag("SkinButton");

		foreach (GameObject g in skinButtons) {
			skinColors.Add(g.GetComponent<Button>().colors.normalColor);
		}

//		RandomizeCharacter(skinColors, true);
		LoadCharacter();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void RandomizeCharacter(List<Color> skinColors, bool humanSkin) {
		Color skin = skinColors[Random.Range(0, skinColors.Count)];
		Color hair = new Color(Random.value, Random.value, Random.value);
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("CharacterClothingItem")) {
			if (humanSkin && (go.name == "characterBody" || go.name == "characterFace" || go.name == "characterEyelids")) {
				go.GetComponent<Image>().color = skin;
			} else if (go.name.Contains("Hair") || go.name.Contains("Eyebrows")) {
				go.GetComponent<Image>().color = hair;
			} 
			else {
				go.GetComponent<Image>().color = new Color(Random.value, Random.value, Random.value);
			}
		}
	}

	public static void LoadCharacter() {
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("CharacterClothingItem")) {
			if (PlayerPrefs.GetString(go.name) != "") {
				Sprite item = Resources.Load("Full-Size/" + PlayerPrefs.GetString(go.name), typeof(Sprite)) as Sprite;
				float r = PlayerPrefs.GetFloat(go.name + "R");
				float g = PlayerPrefs.GetFloat(go.name + "G");
				float b = PlayerPrefs.GetFloat(go.name + "B");
				Color itemColor = new Color(r, g, b);
//				print (go.name);
//				print (itemColor.ToString());
				if (item != null) {
					go.GetComponent<Image>().sprite = item;
					go.GetComponent<Image>().color = itemColor;
				}
			} else {
				go.GetComponent<Image>().enabled = false;
//				print ("didn't show " + go.name);
			}
		}
	}
	

}
