using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogNode {
	public struct response {
		public string text;
		public int goToNode;
	};
	int nodeNum;
	string prompt;
	List<response> responses;
	public TextAsset content;

	void Awake () {
		responses = new List<response>();
		//PrintContent();
	}
	//in lieu of constructor
	public void SetNode (int num, string pmpt, List<response> input)
	{
		bool addChildren = false;
		nodeNum = num;
		prompt = pmpt;
		responses = input;	
	}
	
	public string getPrompt ()
	{
		return prompt;
	}

	public void SetPrompt (string input)
	{
		prompt = input;
	}
	
	public List<response> getResponses ()
	{
		return responses;
	}

	void PrintContent ()
	{
		Debug.Log(prompt);
		for (int i = 0; i < responses.Count; i++)
		{
			Debug.Log(responses[i]);
		}
	}

	public DialogNode GoToChild (int child)
	{
		return Talker.instance.dialogTree[child];
	}

}