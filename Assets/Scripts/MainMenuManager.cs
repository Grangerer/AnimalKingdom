using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	//This class needs to loadData, saveData, go to upgrade Screen, go to battleselect screen, goToOptions, Endgame
	//Display a looping animation of tiles, obstacles and units in the background

	Player player = null;

	public List<GameObject> basePlayerUnits = new List<GameObject> (); 

	// Use this for initialization
	void Start () {
		LoadData ();
		//SaveData ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadData(){
		Debug.Log ("Load");
		SaveLoad.Load ();
		if (SaveLoad.savedPlayers.Count != 0) {
			//Insert a way to specify, which player should be loaded
			player = SaveLoad.savedPlayers [0];
			player.PrintOut ();
		} else {
			Debug.Log ("No saved player found");
			player = new Player ();
			player.SetupNewPlayer (basePlayerUnits);
			player.Experience = 200;
		}
		Player.current = player;
	}
	void SaveData(){
		Debug.Log ("Save");
		SaveLoad.Save ();
	}
	public void GoToUpgradeScreen(){
		SceneManager.LoadScene ("UpgradeScene");
	}
	public void GoToBattleSelectScreen(){
		SceneManager.LoadScene ("TestScene");
	}
	public void GoToOptions(){
		
	}
}
