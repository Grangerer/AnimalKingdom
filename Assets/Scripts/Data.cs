using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour {

	public static Data currentData;
	//Contains all Units. All scenes use this list to setup
	public List<GameObject> units = new List<GameObject>();
	//Contains all Obstacles. All scenes use this list to setup
	public List<GameObject> obstacles = new List<GameObject>();
	Level chosenLevel = new Level();

	public string previousLevelName = null;

	void Start(){
		chosenLevel.LoadLevel (0);
	}
	 
	void Setup(){
		LoadLevelData ();	
	}

	void LoadLevelData(){
		//Read the "levels.txt" file and create levels based of this
	}

	public void LoadScene(string nextSceneName){
		if (nextSceneName != SceneManager.GetActiveScene ().name) {
			previousLevelName = SceneManager.GetActiveScene ().name;
		}
		SceneManager.LoadScene (nextSceneName);
	}

	//Propertystuff
	public Level ChosenLevel {
		get {
			return chosenLevel;
		}
		set {
			chosenLevel = value;
		}
	}
}
