using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CircuitBoard : MonoBehaviour, IHasChanged {
	public static CircuitBoard instance;
	[SerializeField] Transform slots;
	//width of the board, 10
	public int x;
	//height of the board, 7
	public int y;
	int[,] grid;

	// Use this for initialization
	void Awake(){
		instance = this;
	}
	void Start () {
		setGrid ();
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
			//	Debug.Log("item in" + i + ", " + j);
				string name = item.name;
				if (name == "Horizontal Wire"){
					grid[i,j] = 1;
				//	Debug.Log("horizontal wire");
				}
				else if (name == "Vertical Wire"){
					grid[i,j] = 2;
				}
				else if (name == "Corner Up Right"){
					grid[i,j] = 3;
				}
				else if (name == "Corner Down Right"){
					grid[i,j] = 4;
				}
				else if (name == "Corner Left Down"){
					grid[i,j] = 5;
				}
				else if (name == "Corner Left Up"){
					grid[i,j] = 6;
				}
				else if (name == "Light bulb"){
					grid[i,j] = 7;
				//	Debug.Log("bulb");
				}
				else if (name == "Battery"){
					grid[i,j] = 8;
				//	Debug.Log("battery");
				}
			}
			else {
			//	Debug.Log("i: " + i + "  j: " + j);
				grid[i,j] = -1;
			}
			counter++;
			//if not at the begining of a row
			if (counter % 10 != 0){
				i++; 
			}
			else {
				i = 0;
				j++;
			}
		}
	}
	
	private void setGrid(){
		grid = new int[x,y];
//		Debug.Log("x: " + x + "  y: " + y);
		for (int i = 0; i < x; i++) {
			for(int j = 0; j < y; j++){
				grid[i,j] = -1;
			}
		}
	}

	public bool CheckSolution(){
		int cur; int left; int right; int above; int below;
		//scanning column major
		for (int i = 0; i < x; i++) {
			for (int j = 0; j < y; j++) {
				cur = grid[i,j];
				Debug.Log("cur: " + cur + " i: " + i + " j: " + j);
				//need to check left and right
				if ((cur == 1) || (cur == 7) || (cur == 8)){
					//at the edge
					if ((i == 0) || (i == (x-1))){
						return false;
					}
					left = grid[i-1, j];
					//if left doesn't match up
					if ((left == 2) || (left == 5) || (left == 6) || (left == -1)){
						return false;
					}
					right = grid[i+1, j];
					//if right doesn't match up
					if ((right == 2) || (right == 3) || (right == 4) || (right == -1)){
						return false;
					}
				}
				else if (cur == 2){
					//at the edge
					if ((j == 0) || (j == (y-1))){
						return false;
					}
					above = grid[i, j-1];
					//if above doesn't match up
					if ((above == 1) || (above == 3) || (above == 6) || (above == 7) || (above == 8) || (above == -1)){
						return false;
					}
					below = grid[i, j+1];
					//if below doesn't match up
					if ((below == 1) || (below == 4) || (below == 5) || (below == 7) || (below == 8) || (below == -1)){
						return false;
					}
				}
				else if (cur == 3){
					//at the edge
					if ((j == 0) || (i == (x-1))){
						return false;
					}
					above = grid[i, j-1];
					//if above doesn't match up
					if ((above == 1) || (above == 3) || (above == 6) || (above == 7) || (above == 8) || (above == -1)){
						return false;
					}
					right = grid[i+1, j];
					//if right doesn't match up
					if ((right == 2) || (right == 3) || (right == 4) || (right == -1)){
						return false;
					}
				}
				else if (cur == 4){
				//at the edge
					if((j == (y-1)) || (i == (x-1))){
					//	Debug.Log("edge");
						return false;
					}
					below = grid[i, j+1];
					//if below doesn't match up
					if ((below == 1) || (below == 4) || (below == 5) || (below == 7) || (below == 8) || (below == -1)){
					//	Debug.Log("below:" + below + " doesn't match");
						return false;
					}
					right = grid[i+1, j];
					//if right doesn't match up
					if ((right == 2) || (right == 3) || (right == 4) || (right == -1)){
					//	Debug.Log("right doesn't match");
						return false;
					}
				}
				else if (cur == 5){
					//at edge
					if ((i == 0) || (j == (y-1))){
						return false;
					}
					left = grid[i-1, j];
					//if left doesn't match up
					if ((left == 2) || (left == 5) || (left == 6) || (left == -1)){
						return false;
					}
					below = grid[i, j+1];
					//if below doesn't match up
					if ((below == 1) || (below == 4) || (below == 5) || (below == 7) || (below == 8) || (below == -1)){
						return false;
					}
				}
				else if (cur == 6){
					//at edge
					if((i == 0) || (j == 0)){
						return false;
					}
					left = grid[i-1, j];
					//if left doesn't match up
					if ((left == 2) || (left == 5) || (left == 6) || (left == -1)){
						return false;
					}
					above = grid[i, j-1];
					//if above doesn't match up
					if ((above == 1) || (above == 3) || (above == 6) || (above == 7) || (above == 8) || (above == -1)){
						return false;
					}
				}
			}
		}
		Debug.Log("true");
			return true;
	}


	#endregion
}

namespace UnityEngine.EventSystems {
		public interface IHasChanged : IEventSystemHandler {
			void HasChanged();
		}
}
