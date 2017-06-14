using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	//This class needs to loadData, saveData, go to upgrade Screen, go to battleselect screen, goToOptions, Endgame
	//Display a looping animation of tiles, obstacles and units in the background

	Player player = null;

	// Use this for initialization
	void Start () {
		//DontDestroyOnLoad (player);
		LoadData ();

		player = new Player ();
		player.SpentExperience (-50);
		Player.current = player;
		SaveData ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadData(){
		Debug.Log ("Load");
		SaveLoad.Load ();
		if (SaveLoad.savedPlayers.Count != 0) {
			player = SaveLoad.savedPlayers [0];
			player.PrintOut ();
		}

	}
	void SaveData(){
		Debug.Log ("Save");
		SaveLoad.Save ();
	}
	public void GoToUpgradeScreen(){
		SceneManager.LoadScene ("UpgradeScene");
	}
	public void GoToBattleSelectScreen(){
	
	}
	public void GoToOptions(){
		
	}
}
