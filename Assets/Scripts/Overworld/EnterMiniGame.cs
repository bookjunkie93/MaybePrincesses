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
		if (gameNumber != 0) {
			GameManagerScript.control.saveOverworldPos(Walking.instance.transform.position);
		}

		GameManagerScript.control.setPos(levelStartPos);
		Application.LoadLevel(gameNumber);

	}

	public void ReturnToOverworld ()
	{

		Application.LoadLevel(0);
	}
	//Create Save Game Helper function
}
