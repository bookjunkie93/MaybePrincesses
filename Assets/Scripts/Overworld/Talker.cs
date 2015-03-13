using UnityEngine;
using System.Collections;

public class Talker : MonoBehaviour
{
	GUIContent speakText;
	GUIStyle format;
	public string proximityText;
	public string dialogText;
	public string noText;
	bool proximity;
	Rect dialogBox;
	public TextAsset textCorpus;
	
	void Start ()
	{
		ParseText();
		FormatText ();
		speakText.text = noText;
		proximity = false;
		dialogBox = new Rect ((Screen.width/3)+30, Screen.height-50f, 300f, 300f);
	}
	
	void OnTriggerEnter2D (Collider2D collider)
	{
		Debug.Log("Trigger!");
		proximity = true;
		speakText.text = proximityText;
		
	}
	void OnTriggerExit2D (Collider2D collider)
	{
		speakText.text = noText;
		proximity = false;
	}
	
	void ParseText ()
	{
		
		
	}
	void FormatText ()
	{
		speakText = new GUIContent();
		format =new GUIStyle();
		format.alignment = TextAnchor.UpperCenter;
		format.fontSize = 48;
	}
	
	void OnGUI ()
	{
		
		if(proximity && Input.GetKeyDown("space"))
		{
			speakText.text = dialogText;
		}
		GUI.Label(dialogBox, speakText, format);
		
		
	}
}
