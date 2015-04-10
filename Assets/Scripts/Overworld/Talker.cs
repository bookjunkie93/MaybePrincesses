using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Talker : MonoBehaviour
{
	public static Talker instance;
	public string proximityText;
	string dialogText;
	public string noText;
	bool proximity;
	public bool cutscene;
	public bool propagates;
	public RectTransform dialogBox;
	DialogNode current;
	public Image spriteFace;
	public Sprite charSprite;
	public Text boxText;
	List<DialogNode.response> responses;
	public List<DialogNode> dialogTree;
	public GameObject buttons;
	public Button responsePrefab;
	public TextAsset content;
	Button response;	
		
	void Awake()
	{
		instance = this;
	}
	void Start ()
	{	
		proximity = false;
		dialogTree = new List<DialogNode>();
		ParseText();
		current = dialogTree[0];
		UpdateCurrent();
		spriteFace.sprite = charSprite;
	}
	void ParseText ()
	{
		int num;
		string prompt;
		List<DialogNode.response> rList;
		DialogNode.response tempR;
		DialogNode temp;
		string [] nodes = content.text.Split('\n');
		for(int i = 0; i < nodes.Length; i++)
		{	
			temp = new DialogNode();
			rList = new List<DialogNode.response>();
			string [] vars = nodes[i].Split('|');
			num = int.Parse (vars[0].Trim ('|'));
			prompt = vars [1].Trim('|');
			for(int j = 2; j < vars.Length; j++)
			{
				string[] components = vars[j].Split('/');
				//Debug.Log("split components into " + components[0] + " and " + components[1]);
				tempR = new DialogNode.response();
				tempR.text = components[0].TrimStart('/');
				tempR.goToNode = int.Parse (components[1].TrimStart('|'));
				rList.Add(tempR);
			}
			temp.SetNode(num, prompt, rList);
			dialogTree.Add(temp);
		}
	}
	public void ChangeCurrent (int node)
	{
		if(node == 999){return;}
		current = dialogTree[node];
		UpdateCurrent();
	}
	void UpdateCurrent()
	{
		dialogText = current.getPrompt();
		responses = current.getResponses();
		boxText.text = dialogText;
		CleanButtons();
		AddResponses();
		if(!cutscene) 
		{
			dialogBox.gameObject.SetActive(false);
		}
	}
	void CleanButtons()
	{
		foreach(Transform child in buttons.transform)
		{
			GameObject.Destroy (child.gameObject);
		}
	}
		
	
	void OnTriggerEnter2D (Collider2D collider)
	{
		proximity = true;
		boxText.text = proximityText;
		
	}
	void OnTriggerExit2D (Collider2D collider)
	{
		boxText.text = noText;
		proximity = false;
	}
		
	void AddResponses ()
	{
		for(int i = 0; i < responses.Count; i++)
		{
			response = Instantiate(responsePrefab) as Button;
			response.transform.SetParent(buttons.transform);
			response.transform.FindChild("Text").GetComponent<Text>().text = responses[i].text;
			int index = responses[i].goToNode;
			response.onClick.AddListener(() => ChangeCurrent(index));
			response.transform.localScale = new Vector3(1,1,1);
			if(propagates)
			{
				//if this Talker effects changes in the game, add the requisite DialogCourier child to the OnClick events
				DialogCourier temp = GetComponent<DialogCourier>();
				response.onClick.AddListener(()=> temp.ResponsePropagate(index));
			}
		}
	}	
	void OnGUI ()
	{
		if (cutscene)
		{
			dialogBox.gameObject.SetActive(true);
		}
		else if(proximity && Input.GetKeyUp("space"))
		{
			dialogBox.gameObject.SetActive(true);
		}
		/*else if (proximity && Input.GetKeyDown)
		{
		GUI.Label(dialogBox, speakText, format);		
		}*/
	}
}
