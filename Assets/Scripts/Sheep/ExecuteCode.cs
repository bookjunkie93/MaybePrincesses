using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExecuteCode : MonoBehaviour {
	[SerializeField] Transform slots;
	[SerializeField] Transform dogbot;
	Vector3 pos;
	static public int numOfSheep;
//	static string[] commands;
//	static int location;
	
	// Use this for initialization
	void Start () {
		numOfSheep = 3;
	}

	public void initCode () {
		string[] commands = new string[36];
		int location = 0;
//		Debug.Log ("here");
		foreach (Transform slotTransform in slots) {
			GameObject item = slotTransform.GetComponent<Slot1>().item;
			if (item){
				commands[location] = item.name;
				location++;
//				Debug.Log(item.name);
			}

		}
		StartCoroutine(DogbotMovement.dogbot_instance.execCode(commands));
	}

//	public void execCode(string[] commands) {
//		int i = 0;
//		pos = DogbotMovement.movingDogbot.transform.position;
//		Debug.Log (pos);
//		while (i < commands.Length) {
//			if (commands[i] == "Up") {
////				Debug.Log(i);
//				Debug.Log (commands[i]);
//				pos += Vector3.up * Time.deltaTime * 64;
//				Debug.Log (pos);
//			} else if (commands[i] == "Down") {
////				Debug.Log(i);
//				Debug.Log (commands[i]);
//				pos += Vector3.down * Time.deltaTime;
//				Debug.Log (pos);
//			} else if (commands[i] == "Left") {
////				Debug.Log(i);
//				Debug.Log (commands[i]);
//				pos += Vector3.left * Time.deltaTime;
//				Debug.Log (pos);
//			} else if (commands[i] == "Right") {
////				Debug.Log(i);
//				Debug.Log (commands[i]);
//				pos += Vector3.right * Time.deltaTime;
//				Debug.Log (pos);
//			} else if (commands[i] == "Bark") {
////				Debug.Log(i);
//				Debug.Log (commands[i]);
//			} else if (commands[i] == "Jump") {
////				Debug.Log(i);
//				Debug.Log (commands[i]);
//			} else if (commands[i] == "Kick") {
////				Debug.Log(i);
//				Debug.Log (commands[i]);
//			}
//			i++;
//		}
//	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
