﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour {

	public static BattleManager instance;

	bool gameOver = false;
	public PlayerController playerController;
	bool playersTurn;

	AI ai;

	private LevelSpawner levelSpawner;
	private List<GameObject> tileList;

	public GameObject BattleMenu;
	bool gamePaused = false;

	void Awake() {
		if (instance != null) {
			Debug.LogError("More than one GameManager in scene!");
			return;
		}
		instance = this;
	}


	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		ai = AI.instance;
		//Spawn Level
		levelSpawner = this.GetComponent<LevelSpawner>();
		tileList = levelSpawner.SpawnLevel(Data.currentData.ChosenLevel);
		playerController.ApplyUpgrades ();
		playerController.OnTurnStart ();
		playersTurn = true;
	}
		
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			OpenInBattleMenu ();
		}
	
	}

	//Turnstuff
	public void NextTurn(){

		playersTurn = !playersTurn;
		if (!playersTurn) {
			//initiate AI stuff
			StartCoroutine (AIStart ());

		} else {
			playerController.OnTurnStart ();
			playersTurn = true;
		}
	}
	IEnumerator AIStart(){
		StartCoroutine( ai.StartTurn ());
		yield return new WaitForSeconds (ai.Units.Count * ai.waitTime);
		Debug.Log ("AiTurn End");
		NextTurn();
	}
		
	//Win Match
	public void WinMatch(){
		gameOver = true;
		Debug.Log ("Player has won the match");
		UIController.instance.ShowBattleWonMenu (Player.current.Experience,100);
		Player.current.Experience += 100;
		if (Player.current.UnlockedLevel == Data.currentData.ChosenLevel.LevelID + 1) {
			Player.current.UnlockedLevel++;
		}
	}
	public void LooseMatch(){
		gameOver = true;
		Debug.Log ("Player has lost the match");
		Time.timeScale = 0;
		UIController.instance.ShowBattleOverMenu ();
	}
	//Menu
	public void OpenInBattleMenu(){
		if (!gameOver) {
			if (BattleMenu.activeSelf == false) {
				Time.timeScale = 0;
				gamePaused = true;
				BattleMenu.SetActive (true);
			} else {
				Resume ();
			}
		}
	}
	public void Resume(){
		BattleMenu.SetActive(false);
		gamePaused = false;
		Time.timeScale = 1;
	}
	public void RestartLevel(){
		string sceneToLoadName = SceneManager.GetActiveScene ().name;
		Data.currentData.LoadScene (sceneToLoadName);
	}
	public void OpenOptions(){}
	public void GoToMainMenu(){
		SaveLoad.SavePlayer ();
		string sceneToLoadName = "MainMenu";
		Data.currentData.LoadScene (sceneToLoadName);
	}
	public void GoToUpgrade(){
		string sceneToLoadName = "UpgradeScene";
		Data.currentData.LoadScene (sceneToLoadName, "MainMenu");
	}
	public void NextLevel(){
		Data.currentData.ChosenLevel.LoadLevel (Data.currentData.ChosenLevel.LevelID + 1);
		Data.currentData.LoadScene ("UnitSelectScene");
	}

	//Propertystuff
	public bool GamePaused {
		get {
			return gamePaused;
		}
		set {
			gamePaused = value;
		}
	}
}
