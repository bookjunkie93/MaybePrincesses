using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DogbotMovement : MonoBehaviour {
	public static GameObject movingDogbot;
	public static DogbotMovement dogbot_instance;
	static bool codeGameWon;
	Vector3 lastPos;

	public int score;

	void Awake () {
		dogbot_instance = this;
	}

	// Use this for initialization
	void Start () {
		movingDogbot = gameObject;
		codeGameWon = false;
		lastPos = transform.position;
		score = 0;
	}
	
//	// Update is called once per frame
//	void Update () {
//	
//	}


	public void resetDogbot() {
		score = 0;
		if (ExecuteCode.numOfSheep == 2) {
			score += 10;
		} else if (ExecuteCode.numOfSheep == 1) {
			score += 10;
		}
		Vector3 newPos = new Vector3((float)69.6, (float)203.3, (float)0.0);
		transform.position = newPos;
		Vector3 s1pos = new Vector3((float)552.5, (float)469.6, (float)0.0);
		Vector3 s2pos = new Vector3((float)272.9, (float)328.2, (float)0.0);
		Vector3 s3pos = new Vector3((float)758.0, (float)331.5, (float)0.0);
		if (Sheep1.sheep1_instance) {
			Sheep1.sheep1_instance.transform.position = s1pos;
		}
		if (Sheep2.sheep2_instance) {
			Sheep2.sheep2_instance.transform.position = s2pos;
		}
		if (Sheep3.sheep3_instance) {
			Sheep3.sheep3_instance.transform.position = s3pos;
		}
	}

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
			lastPos = transform.position;
					if (commands [i] == "Up") {
							//				Debug.Log(i);
//							Debug.Log (commands [i]);
							transform.position += Vector3.up * Time.deltaTime * 4096;
//							Debug.Log (transform.position);
							call = false;
//							StartCoroutine (Wait ());
					} else if (commands [i] == "Down") {
							//				Debug.Log(i);
//							Debug.Log (commands [i]);
							transform.position += Vector3.down * Time.deltaTime * 4096;
//							Debug.Log (transform.position);
							call = false;
//							StartCoroutine (Wait ());
					} else if (commands [i] == "Left") {
							//				Debug.Log(i);
//							Debug.Log (commands [i]);
							transform.position += Vector3.left * Time.deltaTime * 4096;
//							Debug.Log (transform.position);
							call = false;
//							StartCoroutine (Wait ());
					} else if (commands [i] == "Right") {
							//				Debug.Log(i);
//							Debug.Log (commands [i]);
							transform.position += Vector3.right * Time.deltaTime * 4096;
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
					score++;
					yield return null; //wait for a frame
					yield return new WaitForSeconds(1);
					if (ExecuteCode.numOfSheep == 0) {
				// END GAME
						codeGameWon = true;
				Debug.Log (score);
						if (score <= 20) {
							GameManagerScript.control.codeGameScore = 1;
						} else if (score <= 30) {
							GameManagerScript.control.codeGameScore = 2;
						} else {
							GameManagerScript.control.codeGameScore = 3;
						}
//						Debug.Log ("end game");
					}
			checkPos();
//				}
			}
	}

	void checkPos(){
		if (transform.position.x >= 887 || transform.position.x <= -2.2 || transform.position.y >= 657 || transform.position.y <= 147) {
			transform.position = lastPos;
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
