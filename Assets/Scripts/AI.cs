using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

	GameManager gameManager;

	List<GameObject> units = new List<GameObject> ();
	// Use this for initialization
	void Start () {
		gameManager = GameManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartTurn(){
		//Choose random unit
		//Find all enemy units in move+attackrange=>choose (1.The one you can kill 2.The one with the least hp)
		//move to the tile with the most adjacent obstacles within attackrange and attack
		//Repeat until all units acted
		//End turn
	}

	//Unit
	public void AddUnit(GameObject unit){
		units.Add (unit);
	}
}
