using UnityEngine;
using System.Collections;

public class EnterMiniGameREMOVETHISTEXT : MonoBehaviour
{
	public static EnterMiniGameREMOVETHISTEXT instance;
	public int gameNumber;

	void Awake()
	{
		instance = this;
	}

	public void OnTriggerEnter2D (Collider2D collider)
	{
		//save Player progress and location for re-loading after minigame
		GameManagerScript.control.setPos(Walking.instance.transform.position);
		Application.LoadLevel(gameNumber);
	}

	public void ReturnToOverworld ()
	{
		Application.LoadLevel(0);
	}
	//Create Save Game Helper function
}
