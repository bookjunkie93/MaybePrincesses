using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
	public static GameManagerScript control;
	public Vector2 currentPos;
	public bool exitMiniGame;
	//PlayerPrefs
	public string playerName;
	public int codeGameScore;
	public bool sheepIntro;
	public bool circuitIntro;
	public bool antagonistIntro;

	void Awake () {
	
		if(control == null)
		{
			DontDestroyOnLoad(this.gameObject);
			control = this;
			sheepIntro = false;
			circuitIntro = false;
			antagonistIntro = false;
		}
		else if (control != this)
		{
			Destroy (this.gameObject);
		}		
		exitMiniGame = false;	
	}

	public void setPos (Vector2 newPos)
	{
		currentPos = newPos;
	}



	void OnLevelWasLoaded(int level) {
		if (level < 2) {
			GameObject data = GameObject.FindGameObjectWithTag("Clothing Data");
			if (data == null) {
				print ("no clothes set");
			} else {
				print ("setting colors");
				PlayerManager dataStore = data.GetComponent<PlayerManager>();
				GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

				foreach(ClothingItem c in dataStore.items) {
					for(int i = 0; i < playerObj.transform.childCount; i++) {
						GameObject child = playerObj.transform.GetChild(i).gameObject;
						SpriteRenderer s = child.GetComponent<SpriteRenderer>();
						ItemName n = child.GetComponent<ItemName>();
						if (n != null) {		
							if (n.name == c.getName()) {
								s.color = c.getColor();
							}

						}
					}
				}
			}
		}
		if (level == 0)
		{
			if((sheepIntro && circuitIntro)&&(!antagonistIntro))
			{
				Application.LoadLevel(10);
			}
		}
	}
	public void SetName(string name)
	{
		playerName = name;
	}

	public string GetName ()
	{
		return playerName;
	}
	
}
