﻿using UnityEngine;
using System.Collections;

public class EnterMiniGame : MonoBehaviour {
	public int gameNumber;

	void OnTriggerEnter2D (Collider2D collider) {
		//save Player progress and location for re-loading after minigame
		Application.LoadLevel(gameNumber);
	}
	public void ReturnToOverworld () {
		Application.LoadLevel(0);
	}
	//Create Save Game Helper function
}