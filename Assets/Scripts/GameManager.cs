using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager{

	public static GameManager globalInfo;

	//Contains all Units. All scenes use this list to setup
	List<GameObject> units = new List<GameObject>();
	//Contains all Obstacles. All scenes use this list to setup
	List<GameObject> obstacles = new List<GameObject>();
	//Contains all Levels. All Scenes use this list to Setup
	List<ImprovedLevel> levels = new List<ImprovedLevel>();

	public string previousScene;


	void SetupGameManager(){
			
	}


	//Propertystuff
	public List<GameObject> Units {
		get {
			return units;
		}
	}
	public List<GameObject> Obstacles {
		get {
			return obstacles;
		}
	}
	public List<ImprovedLevel> Levels {
		get {
			return levels;
		}
	}
}
