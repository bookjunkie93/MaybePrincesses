using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogNode : MonoBehaviour {
	string prompt;
	List<string> responses;
	List<DialogNode> children;
	public TextAsset content;
	// Use this for initialization
	void Start () {
		children = new List<DialogNode>();
		responses = new List<string>();
		ParseContent();
		PrintContent();
	}
	void ParseContent ()
	{
		bool addChildren = false;
		string [] sourceText = content.text.Split('\n');
		prompt = sourceText[0];
		for(int i = 1; i < sourceText.Length; i++)
		{	
			responses.Add(sourceText[i].TrimStart('\t'));
		}	
	}

	public void SetChildren (DialogNode[] nodeList)
	{
		for (int i = 0; i < children.Count; i++)
		{
			children.Add(nodeList[i]);
		}
	}
	
	public string getPrompt ()
	{
		return prompt;
	}
	
	public List<string> getResponses ()
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

	/*DialogNode GoToChild ()
	{
	}*/
	
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
