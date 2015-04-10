﻿using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
	public static GameManagerScript control;
	public Vector2 overworldPos;
	public bool exitMiniGame;

	void Awake () {
	
		if(control == null)
		{
			DontDestroyOnLoad(this.gameObject);
			control = this;
		}
		else if (control != this)
		{
			Destroy (this.gameObject);
		}		exitMiniGame = false;	
	}

	public void setPos (Vector2 curPos)
	{
		overworldPos = curPos;
	}

	void OnLevelWasLoaded(int level) {
		if (level == 0) {
			PlayerManager dataStore = GameObject.FindGameObjectWithTag("Clothing Data").GetComponent<PlayerManager>();
			if (dataStore == null) {
				print ("no clothes set");
			} else {

			}
		}
	}
	
}
