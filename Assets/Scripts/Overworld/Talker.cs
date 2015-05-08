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
	string nameHolder;	
		
	void Awake()
	{
		instance = this;
		nameHolder = "[name]";
	}
	//initialize variables and import dialogue data
	void Start ()
	{	
		proximity = false;
		dialogTree = new List<DialogNode>();
		ParseText();
		current = dialogTree[0];
		UpdateCurrent();
		spriteFace.sprite = charSprite;
	}
	
	//Swap out text variables with player data entered via UI
	public void UpdatePersistents()
	{
		for (int i =0; i < dialogTree.Count; i++){
			dialogTree[i].SetPrompt(AddPersistentText(dialogTree[i].getPrompt()));
		}
		UpdateCurrent();
	}

	//swap a text holder with player input
	string AddPersistentText (string text)
	{	
		string retval;
		if(GameManagerScript.control.playerName == "")
		{
			return text;
		}
		retval = text.Replace(nameHolder, GameManagerScript.control.playerName);
		return retval;
	}
	//takes a .txt file of a dialogue tree and parses it into
	//DialogNodes stored in a Generic List
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
			prompt = AddPersistentText(vars[1]); //go through and swap text holders with player prefs
			for(int j = 2; j < vars.Length; j++)
			{
				string[] components = vars[j].Split('/');
				//Debug.Log("split components into " + components[0] + " and " + components[1]);
				tempR = new DialogNode.response();	
				tempR.text = components[0].TrimStart('/');
				Debug.Log (components[1].ToString());
				tempR.goToNode = int.Parse (components[1].TrimStart('|'));
				rList.Add(tempR);
			}
			temp.SetNode(num, prompt, rList); //construct a DialogNode from parsed data
			dialogTree.Add(temp);
		}
	}
	
	//switch current node to the next chosen node
	public void ChangeCurrent (int node)
	{
		if(node == 999){return;}
		current = dialogTree[node];
		UpdateCurrent();
	}
	
	//"refresh" the current node to propagate changes
	public void UpdateCurrent()
	{
		dialogText = current.getPrompt();
		responses = current.getResponses();
		boxText.text = dialogText; //update UI text
		CleanButtons(); //remove old buttons
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
		
	//when triggered, initiate proximity text algorithms
	void OnTriggerEnter2D (Collider2D collider)
	{
		proximity = true;
		boxText.text = proximityText;
		
	}
	//remove proximity text when leaving radius of Talker
	void OnTriggerExit2D (Collider2D collider)
	{
		boxText.text = noText;
		proximity = false;
	}
	
	//instantiate buttons, add text, and add them to the tree	
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

	//monitor scene for interactions
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
