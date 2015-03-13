using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CircuitBoard : MonoBehaviour, IHasChanged {
	public static CircuitBoard instance;
	[SerializeField] Transform slots;
	int[,] grid;
	int[,] solution;
	// Use this for initialization
	void Awake(){
		instance = this;
	}
	void Start () {
		setGrid ();
		setSolution ();
		HasChanged ();
	}

	#region IHasChanged implementation

	public void HasChanged ()
	{
		int i = 0; int j = 0; int counter = 0;
		foreach (Transform slotTransform in slots) {
			GameObject item = slotTransform.GetComponent<Slot>().item;
			//if there is an item in the slot
			if (item){
				string name = item.name;
				if (name == "Wire"){
					grid[i,j] = 1;
					//Debug.Log("grid change");
				}
				else if (name == "Corner Wire"){
					grid[i,j] = 2;
				}
				else if (name == "Lightbulb"){
					grid[i,j] = 3;
				}
				else if (name == "Battery"){
					grid[i,j] = 4;
				}
			}
			else {
				grid[i,j] = -1;
			}
			counter++;
			//if not at the begining of a row
			if (counter % 7 != 0){
				i++; 
			}
			else {
				i = 0;
				j++;
			}
		}
	}
	
	private void setGrid(){
		
		// Obtain the entire collection
		//Panel[] slots = GetComponentInChildren<Panel>().
		
		// Iterate through it
		// foreach of the slots we get them in a 1D collection
		//     Then we can access them by creating another function
		//         string GetSlot(_x,y){
		//            slots + _x * 4 would recover a slot ina grid like manner
		//            return slots[x+ _x * 4)
		//        }
		
		int x = 7; int y =4; 
		grid = new int[x,y];
		for (int i = 0; i < x; i++) {
			for(int j = 0; j < y; j++){
				grid[i,j] = -1;
			}
		}
	}

	public bool CheckSolution(){
		bool check = true;
		for (int i = 0; i < 7; i++) {
			for(int j = 0; j < 4; j++){
			//	Debug.Log(i.ToString() + ", " + j.ToString());
				if (grid[i,j] != solution[i,j]){
					check = false;
					break;
				}
			}
		}
		return check;
	}
	
	private void setSolution(){
		int w = 7; int z = 4;
		solution = new int[w, z];
		for (int i = 0; i < w; i++) {
			for(int j = 0; j < z; j++){
				solution[i,j] = -1;
			}
		}
		//lightbulb slot
		solution[1,1] = 3;
		//battery slot
		solution[5,1] = 4;
		//straight wires between battery and lightbulb
		solution [2, 1] = 1;
		solution [3, 1] = 1;
		solution [4, 1] = 1;

}

	#endregion
}

namespace UnityEngine.EventSystems {
		public interface IHasChanged : IEventSystemHandler {
			void HasChanged();
		}
}
