using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorSelection : MonoBehaviour {
	Button color;
	Image currentItem;
	void Start(){
		color = GetComponent<Button> ();
		currentItem = GetComponentInParent<PanelInit> ().currentItem;
	}
	
	// Update is called once per frame
	void Update () {
		currentItem = GetComponentInParent<PanelInit> ().currentItem;
	}
	
	public void ChangeColor() {
		currentItem.color = color.colors.normalColor;
	}
}
