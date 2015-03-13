using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DogbotMovement : MonoBehaviour {
	public static GameObject movingDogbot;
	public static DogbotMovement dogbot_instance;
	static bool codeGameWon;

	void Awake () {
		dogbot_instance = this;
	}

	// Use this for initialization
	void Start () {
		movingDogbot = gameObject;
		codeGameWon = false;
	}
	
//	// Update is called once per frame
//	void Update () {
//	
//	}




	//	Vector3 startingPosition;
	bool call = true;
	
	IEnumerator Wait() {
		yield return new WaitForSeconds(1);
		call = true;
	}

	public IEnumerator execCode(string[] commands) {
		int i = 0;
//		pos = DogbotMovement.movingDogbot.transform.position;
//		Debug.Log (pos);

		while (i < commands.Length) {
//			if (call) {
					if (commands [i] == "Up") {
							//				Debug.Log(i);
//							Debug.Log (commands [i]);
							transform.position += Vector3.up * Time.deltaTime * 4000;
//							Debug.Log (transform.position);
							call = false;
//							StartCoroutine (Wait ());
					} else if (commands [i] == "Down") {
							//				Debug.Log(i);
//							Debug.Log (commands [i]);
							transform.position += Vector3.down * Time.deltaTime * 4000;
//							Debug.Log (transform.position);
							call = false;
//							StartCoroutine (Wait ());
					} else if (commands [i] == "Left") {
							//				Debug.Log(i);
//							Debug.Log (commands [i]);
							transform.position += Vector3.left * Time.deltaTime * 4000;
//							Debug.Log (transform.position);
							call = false;
//							StartCoroutine (Wait ());
					} else if (commands [i] == "Right") {
							//				Debug.Log(i);
//							Debug.Log (commands [i]);
							transform.position += Vector3.right * Time.deltaTime * 4000;
//							Debug.Log (transform.position);
							call = false;
//							StartCoroutine (Wait ());
					} else if (commands [i] == "Bark") {
							//				Debug.Log(i);
							call = false;
//							StartCoroutine (Wait ());
//							Debug.Log (commands [i]);
							if (Sheep1.sheep1_instance != null) {
								Sheep1.sheep1_instance.BarkedAt(transform.position);
							}
							if (Sheep2.sheep2_instance != null) {
								Sheep2.sheep2_instance.BarkedAt(transform.position);
							}
							if (Sheep3.sheep3_instance != null) {
								Sheep3.sheep3_instance.BarkedAt(transform.position);
							}
					} else if (commands [i] == "Jump") {
							//				Debug.Log(i);
							call = false;
//							StartCoroutine (Wait ());
//							Debug.Log (commands [i]);
							if (Sheep1.sheep1_instance != null) {
								Sheep1.sheep1_instance.JumpedAt(transform.position);
							}
							if (Sheep2.sheep2_instance != null) {
								Sheep2.sheep2_instance.JumpedAt(transform.position);
							}
							if (Sheep3.sheep3_instance != null) {
								Sheep3.sheep3_instance.JumpedAt(transform.position);
							}
					} else if (commands [i] == "Kick") {
							//				Debug.Log(i);
//							Debug.Log (commands [i]);
							call = false;
//							StartCoroutine (Wait ());
							if (Sheep1.sheep1_instance != null) {
								Sheep1.sheep1_instance.KickedAt(transform.position);
							}
							if (Sheep2.sheep2_instance != null) {
								Sheep2.sheep2_instance.KickedAt(transform.position);
							}
							if (Sheep3.sheep3_instance != null) {
								Sheep3.sheep3_instance.KickedAt(transform.position);
							}
					}
					i++;
					yield return null; //wait for a frame
					yield return new WaitForSeconds(1);
					if (ExecuteCode.numOfSheep == 0) {
				// END GAME
						codeGameWon = true;
//						Debug.Log ("end game");
					}
//				}
			}
	}

	void OnGUI() 
	{
		Rect rect = new Rect(150,150,300,300);
		if(codeGameWon)
		{
			GUI.Label(rect, "You Won!");
//			Debug.Log ("won");
		}
		else
		{			
			GUI.Label(rect, "");
		}
	}
	
	// Update is called once per frame
//	void Update () {
//		if (call) {
//			if (i % 4 == 0) {
//				transform.position += Vector3.up * (Time.deltaTime) * 5000;
//				call = false;
//				StartCoroutine (Wait ());
//			} else if (i % 4 == 1) {
//				transform.position += Vector3.left * (Time.deltaTime) * 5000;
//				call = false;
//				StartCoroutine (Wait ());
//			} else if (i % 4 == 2) {
//				transform.position += Vector3.down * (Time.deltaTime) * 5000;
//				call = false;
//				StartCoroutine (Wait ());
//			} else if (i % 4 == 3) {
//				transform.position += Vector3.right * (Time.deltaTime) * 5000;
//				call = false;
//				StartCoroutine (Wait ());
//			}
//			i++;
//		}
//		
//	}
}
