using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class ClothingItem {
	string itemName;
	Sprite itemSprite;
	Color itemColor;


	public ClothingItem(string name, Sprite s, Color c) {
		itemName = name;
		itemSprite = s;
		itemColor = c;

	}

	public string getName() {
		return itemName;
	}

	public void setName(string n) {
		itemName = n;
	}

	public Sprite getSprite() {
		return itemSprite;
	}
	
	public void setSprite(Sprite s) {
		itemSprite = s;
	}

	public Color getColor() {
		return itemColor;
	}

	public void setColor(Color c) {
		itemColor = c;
	}
}

public class PlayerManager : MonoBehaviour {
	public static PlayerManager self;
	List<ClothingItem> items;

	void Awake () {
		if (self == null)
		{
			DontDestroyOnLoad(this.gameObject);
			self = this;
		}
		else if (self != this)
		{
			Destroy (this.gameObject);
		}		
	}

	// Use this for initialization
	void Start () {
		this.tag = "Clothing Data";
		items = new List<ClothingItem>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddItem(string name, Sprite s, Color c) {
		ClothingItem newItem = GetItem(name);

		if (newItem != null) {
			if (!newItem.getColor().Equals(c)) {
				newItem.setColor(c);
			}

			if (!newItem.getSprite().Equals(s)) {
				newItem.setSprite(s);
			}

		} else {
			newItem = new ClothingItem(name, s, c);
			items.Add(newItem);
		}
	}

	public void RemoveItem(string name) {
		ClothingItem toRemove = GetItem(name);

		if (toRemove != null) {
			items.Remove(toRemove);
		}
	}

	bool ItemsContains(string name) {
		foreach(ClothingItem c in items) {
			if (c.getName().Equals(name)) {
				return true;
			}
		}
		return false;
	}

	ClothingItem GetItem(string name) {
		foreach(ClothingItem c in items) {
			if (c.getName().Equals(name)) {
				return c;
			}
		}
		return null;
	}

	public void PrintList() {
		foreach(ClothingItem c in items) {
			print (c.getName() + ": " + c.getSprite().name + " " + c.getColor().ToString());
		}
	}
}
