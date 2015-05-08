using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class DogbotMovement : MonoBehaviour {
	public static GameObject movingDogbot;
	public static DogbotMovement dogbot_instance;
	static bool codeGameWon;
	Vector3 lastPos;
	public Text score_str;
	public Text wintext;
	static bool isLev2;
	static bool beginning;

	public static int level;
//	public Renderer win_rend;

	public int score;
	public int l1_score;

	void Awake () {
		dogbot_instance = this;
	}

	// Use this for initialization
	void Start () {
		beginning = true;
		isLev2 = false;
		level = 1;
		movingDogbot = gameObject;
		codeGameWon = false;
		lastPos = transform.position;
		score = 0;
		l1_score = 0;
//		win_rend = GetComponent<Renderer> ();
//		win_rend.enabled = false;
	}
	
//	// Update is called once per frame
	void Update () {
		score_str.text = "SCORE: " + score.ToString ();
		if (isLev2) {
			StartCoroutine (TmpText ());
		}
		if (beginning) {
			StartCoroutine (TmpBegText ());
		}
	}

	IEnumerator TmpText() {
		yield return new WaitForSeconds(3);
		isLev2 = false;
	}

	IEnumerator TmpBegText() {
		yield return new WaitForSeconds(3);
		beginning = false;
	}


	public void resetDogbot() {
		if (level == 1) {
			score = 0;
			Vector3 newPos = new Vector3 ((float)69.6, (float)203.3, (float)0.0);
			transform.position = newPos;
			Vector3 s1pos = new Vector3 ((float)552.5, (float)469.6, (float)0.0);
			Vector3 s2pos = new Vector3 ((float)272.9, (float)328.2, (float)0.0);
			Vector3 s3pos = new Vector3 ((float)758.0, (float)331.5, (float)0.0);

			if (Sheep1.sheep1_instance) {
				Sheep1.sheep1_instance.transform.position = s1pos;
			} else {
//			Debug.Log ("new 1");
				GameObject myObj = Instantiate (Resources.Load ("sheep1")) as GameObject;
				myObj.transform.SetParent (GameObject.Find ("Grass").transform);
				myObj.name = "sheep1";
//			myObj.transform.localScale = new Vector3 (1, 1, 1);
				Sheep1.sheep1_instance.transform.position = s1pos;
			}
			if (Sheep2.sheep2_instance) {
				Sheep2.sheep2_instance.transform.position = s2pos;
			} else {
//			Debug.Log ("new 2");
				GameObject myObj = Instantiate (Resources.Load ("sheep2")) as GameObject;
				myObj.transform.SetParent (GameObject.Find ("Grass").transform);
				myObj.name = "sheep2";
//			myObj.transform.localScale = new Vector3 (1, 1, 1);
				Sheep2.sheep2_instance.transform.position = s2pos;
			}
			if (Sheep3.sheep3_instance) {
				Sheep3.sheep3_instance.transform.position = s3pos;
			} else {
//			Debug.Log ("new 3");
				GameObject myObj = Instantiate (Resources.Load ("sheep3")) as GameObject;
				myObj.transform.SetParent (GameObject.Find ("Grass").transform);
				myObj.name = "sheep3";
//			myObj.transform.localScale = new Vector3 (1, 1, 1);
				Sheep3.sheep3_instance.transform.position = s3pos;
//			Debug.Log (Sheep3.sheep3_instance.transform.position);
			}
			ExecuteCode.instance.ResetNum1 ();
		} else if (level == 2) {
			score = l1_score;
			Vector3 newPos = new Vector3 ((float)69.6, (float)203.3, (float)0.0);
			transform.position = newPos;
			Vector3 s1pos = new Vector3 ((float)130.4, (float)608.9, (float)0.0);
			Vector3 s2pos = new Vector3 ((float)337.0, (float)322.7, (float)0.0);
			Vector3 s3pos = new Vector3 ((float)487.3, (float)467.4, (float)0.0);
			Vector3 s4pos = new Vector3 ((float)762.5, (float)248.6, (float)0.0);
			
			if (Sheep1.sheep1_instance) {
				Sheep1.sheep1_instance.transform.position = s1pos;
			} else {
				//			Debug.Log ("new 1");
				GameObject myObj = Instantiate (Resources.Load ("sheep1")) as GameObject;
				myObj.transform.SetParent (GameObject.Find ("Grass").transform);
				myObj.name = "sheep1";
				//			myObj.transform.localScale = new Vector3 (1, 1, 1);
				Sheep1.sheep1_instance.transform.position = s1pos;
			}
			if (Sheep2.sheep2_instance) {
				Sheep2.sheep2_instance.transform.position = s2pos;
			} else {
				//			Debug.Log ("new 2");
				GameObject myObj = Instantiate (Resources.Load ("sheep2")) as GameObject;
				myObj.transform.SetParent (GameObject.Find ("Grass").transform);
				myObj.name = "sheep2";
				//			myObj.transform.localScale = new Vector3 (1, 1, 1);
				Sheep2.sheep2_instance.transform.position = s2pos;
			}
			if (Sheep3.sheep3_instance) {
				Sheep3.sheep3_instance.transform.position = s3pos;
			} else {
				//			Debug.Log ("new 3");
				GameObject myObj = Instantiate (Resources.Load ("sheep3")) as GameObject;
				myObj.transform.SetParent (GameObject.Find ("Grass").transform);
				myObj.name = "sheep3";
				//			myObj.transform.localScale = new Vector3 (1, 1, 1);
				Sheep3.sheep3_instance.transform.position = s3pos;
				//			Debug.Log (Sheep3.sheep3_instance.transform.position);
			}
			if (Sheep4.sheep4_instance) {
				Sheep4.sheep4_instance.transform.position = s4pos;
			} else {
				//			Debug.Log ("new 3");
				GameObject myObj = Instantiate (Resources.Load ("sheep4")) as GameObject;
				myObj.transform.SetParent (GameObject.Find ("Grass").transform);
				myObj.name = "sheep4";
				//			myObj.transform.localScale = new Vector3 (1, 1, 1);
				Sheep4.sheep4_instance.transform.position = s4pos;
				//			Debug.Log (Sheep3.sheep3_instance.transform.position);
			}
			ExecuteCode.instance.ResetNum2 ();
		}
	}

	void Setup2 () {
		Vector3 newPos = new Vector3 ((float)69.6, (float)203.3, (float)0.0);
		transform.position = newPos;
		Vector3 s1pos = new Vector3 ((float)130.4, (float)608.9, (float)0.0);
		Vector3 s2pos = new Vector3 ((float)337.0, (float)322.7, (float)0.0);
		Vector3 s3pos = new Vector3 ((float)487.3, (float)467.4, (float)0.0);
		Vector3 s4pos = new Vector3 ((float)762.5, (float)248.6, (float)0.0);
		
		if (Sheep1.sheep1_instance) {
			Sheep1.sheep1_instance.transform.position = s1pos;
		} else {
			//			Debug.Log ("new 1");
			GameObject myObj = Instantiate (Resources.Load ("sheep1")) as GameObject;
			myObj.transform.SetParent (GameObject.Find ("Grass").transform);
			myObj.name = "sheep1";
			//			myObj.transform.localScale = new Vector3 (1, 1, 1);
			Sheep1.sheep1_instance.transform.position = s1pos;
		}
		if (Sheep2.sheep2_instance) {
			Sheep2.sheep2_instance.transform.position = s2pos;
		} else {
			//			Debug.Log ("new 2");
			GameObject myObj = Instantiate (Resources.Load ("sheep2")) as GameObject;
			myObj.transform.SetParent (GameObject.Find ("Grass").transform);
			myObj.name = "sheep2";
			//			myObj.transform.localScale = new Vector3 (1, 1, 1);
			Sheep2.sheep2_instance.transform.position = s2pos;
		}
		if (Sheep3.sheep3_instance) {
			Sheep3.sheep3_instance.transform.position = s3pos;
		} else {
			//			Debug.Log ("new 3");
			GameObject myObj = Instantiate (Resources.Load ("sheep3")) as GameObject;
			myObj.transform.SetParent (GameObject.Find ("Grass").transform);
			myObj.name = "sheep3";
			//			myObj.transform.localScale = new Vector3 (1, 1, 1);
			Sheep3.sheep3_instance.transform.position = s3pos;
			//			Debug.Log (Sheep3.sheep3_instance.transform.position);
		}
		if (Sheep4.sheep4_instance) {
			Sheep4.sheep4_instance.transform.position = s4pos;
		} else {
			//			Debug.Log ("new 3");
			GameObject myObj = Instantiate (Resources.Load ("sheep4")) as GameObject;
			myObj.transform.SetParent (GameObject.Find ("Grass").transform);
			myObj.name = "sheep4";
			//			myObj.transform.localScale = new Vector3 (1, 1, 1);
			Sheep4.sheep4_instance.transform.position = s4pos;
			//			Debug.Log (Sheep3.sheep3_instance.transform.position);
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
							score++;
							//				Debug.Log(i);
//							Debug.Log (commands [i]);
							transform.position += Vector3.up * Time.deltaTime * 4096;
//							Debug.Log (transform.position);
							call = false;
//							StartCoroutine (Wait ());
					} else if (commands [i] == "Down") {
							score++;
							//				Debug.Log(i);
//							Debug.Log (commands [i]);
							transform.position += Vector3.down * Time.deltaTime * 4096;
//							Debug.Log (transform.position);
							call = false;
//							StartCoroutine (Wait ());
					} else if (commands [i] == "Left") {
							score++;
							//				Debug.Log(i);
//							Debug.Log (commands [i]);
							transform.position += Vector3.left * Time.deltaTime * 4096;
//							Debug.Log (transform.position);
							call = false;
//							StartCoroutine (Wait ());
					} else if (commands [i] == "Right") {
							score++;
							//				Debug.Log(i);
//							Debug.Log (commands [i]);
							transform.position += Vector3.right * Time.deltaTime * 4096;
//							Debug.Log (transform.position);
							call = false;
//							StartCoroutine (Wait ());
					} else if (commands [i] == "Bark") {
							score++;
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
							if (Sheep4.sheep4_instance != null) {
								Sheep4.sheep4_instance.BarkedAt(transform.position);
							}
					} else if (commands [i] == "Jump") {
							score++;
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
							if (Sheep4.sheep4_instance != null) {
								Sheep4.sheep4_instance.JumpedAt(transform.position);
							}
					} else if (commands [i] == "Kick") {
							score++;
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
							if (Sheep4.sheep4_instance != null) {
								Sheep4.sheep4_instance.KickedAt(transform.position);
							}
					}
					i++;
					yield return null; //wait for a frame
					yield return new WaitForSeconds(1);
					if (ExecuteCode.numOfSheep == 0) {
				// END GAME
						if (level == 2) {
							codeGameWon = true;
							if (score <= 30) {
								GameManagerScript.control.codeGameScore = 1;
							} else if (score <= 45) {
								GameManagerScript.control.codeGameScore = 2;
							} else {
								GameManagerScript.control.codeGameScore = 3;
							}
	//						Debug.Log ("end game");
						} else {
							isLev2 = true;
							i = 1000000;
							l1_score = score;
							level++;
							ExecuteCode.instance.SetLev2();
							ResetCode.instance.EraseCode();
							Setup2();
						}
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
		Rect rect = new Rect(300,100,300,300);
		GUIStyle style = new GUIStyle();
		if (codeGameWon) {
			style.fontSize = 50;
			style.richText = true;
//			wintext.text = "You Win!";
//			win_rend.enabled = true;
			GUI.Label (rect, "<color=#ffffffff>You Won!</color>", style);
//			Debug.Log ("won");
		} else if (isLev2) {
			style.richText = true;
			style.fontSize = 30;
			GUI.Label (rect, "<color=#ffffffff>Level 2</color>", style);
		} else if (beginning) {
			style.richText = true;
			style.fontSize = 30;
			GUI.Label (rect, "<color=#ffffffff>Level 1</color>", style);
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
