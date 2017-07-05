using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Data : MonoBehaviour {

	public static Data currentData;
	//Contains all Units. All scenes use this list to setup
	public List<GameObject> units = new List<GameObject>();
	//Contains all Obstacles. All scenes use this list to setup
	public List<GameObject> obstacles = new List<GameObject>();
	Level chosenLevel = new Level();

	void Start(){
		chosenLevel.LoadLevel (0);
	}

	void Setup(){
		LoadLevelData ();	
	}

	void LoadLevelData(){
		//Read the "levels.txt" file and create levels based of this
	}

	public Level ChosenLevel {
		get {
			return chosenLevel;
		}
	}
}
