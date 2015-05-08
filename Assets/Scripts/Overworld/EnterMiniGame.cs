using UnityEngine;
using System.Collections;

public class EnterMiniGame : MonoBehaviour
{
	public static EnterMiniGame instance;
	public int gameNumber;
	public Vector2 levelStartPos;

	void Awake()
	{
		instance = this;
	}

	public void OnTriggerEnter2D (Collider2D collider)
	{

			//save Player progress and location for re-loading after minigame
		switch(gameNumber)
		{
			case 9:
				if (GameManagerScript.control.sheepIntro) {gameNumber = 2;}
				break;
			case 8:
				if (GameManagerScript.control.circuitIntro) {gameNumber = 3;}
				break;
		}

		ReturnToLevel();

	}

	public void ReturnToOverworld ()
	{
		GameManagerScript.control.setPos(levelStartPos);
		Application.LoadLevel(0);
	}

	public void ReturnToLevel ()
	{
		GameManagerScript.control.setPos(levelStartPos);
		Application.LoadLevel(gameNumber);
	}

	public void ReturnToLevelWithoutPos ()
	{

		Application.LoadLevel(gameNumber);
	}
	//Create Save Game Helper function
}
