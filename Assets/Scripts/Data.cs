using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

	public static Data currentData;
	//Contains all Units. All scenes use this list to setup
	public List<GameObject> units = new List<GameObject>();
	//Contains all Obstacles. All scenes use this list to setup
	public List<GameObject> obstacles = new List<GameObject>();
	//Contains all Levels. All Scenes use this list to Setup
	List<ImprovedLevel> levels = new List<ImprovedLevel>();

	void Start(){
		LoadLevelData ();


	
	}

	void LoadLevelData(){

	}
}
