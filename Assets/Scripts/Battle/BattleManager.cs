using System.Collections;
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

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			OpenInBattleMenu ();
		}
	
	}

	/// <summary>
    /// Hands over control to the next battle participant
    /// </summary>
	public void NextTurn(){

		playersTurn = !playersTurn;
		if (!playersTurn) {
			StartCoroutine (AIStart ());
		} else {
			playerController.OnTurnStart ();
			playersTurn = true;
		}
	}

    /// <summary>
    /// Coroutine which initiates the ai turn
    /// Gives control to the next party after it is finished
    /// </summary>
    /// <returns></returns>
	IEnumerator AIStart(){
		StartCoroutine( ai.StartTurn ());
		yield return new WaitForSeconds (ai.Units.Count * ai.waitTime);
		Debug.Log ("AiTurn End");
		NextTurn();
	}

    /// <summary>
    /// Ends a match with a win
    /// Adds experience and possibly unlocks additional levels
    /// Presents the player with all possible options after a defeat
    /// </summary>
    public void WinMatch(){
		gameOver = true;
		Debug.Log ("Player has won the match");
        int experienceGain = 50 + 50 * (Data.currentData.ChosenLevel.LevelID+1);
        UIController.instance.ShowBattleWonMenu (Player.current.Experience, experienceGain);
        Player.current.Experience += experienceGain;
        if (Player.current.UnlockedLevel == Data.currentData.ChosenLevel.LevelID + 1) {
			Player.current.UnlockedLevel++;
		}
	}
    /// <summary>
    /// Ends the game and presents the player with all possible options after a defeat
    /// </summary>
	public void LoseMatch(){
		gameOver = true;
		Debug.Log ("Player has lost the match");
		Time.timeScale = 0;
		UIController.instance.ShowBattleOverMenu ();
	}
	
	/// <summary>
    /// Pauses the game and opens the layover menu
    /// </summary>
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
    /// <summary>
    /// Resumes action after all menuinteractions are finished
    /// </summary>
	public void Resume(){
		BattleMenu.SetActive(false);
		gamePaused = false;
		Time.timeScale = 1;
	}
    /// <summary>
    /// Restarts the level with the same setup (Without new team compositions)
    /// </summary>
	public void RestartLevel(){
		string sceneToLoadName = SceneManager.GetActiveScene ().name;
		Data.currentData.LoadScene (sceneToLoadName);
	}
    /// <summary>
    /// Scenechange to the main menu
    /// </summary>
	public void GoToMainMenu(){
		SaveLoad.SavePlayer ();
		string sceneToLoadName = "MainMenu";
		Data.currentData.LoadScene (sceneToLoadName);
	}
    /// <summary>
    /// Scenechange to the upgrade menu
    /// </summary>
	public void GoToUpgrade(){
		string sceneToLoadName = "UpgradeScene";
		Data.currentData.LoadScene (sceneToLoadName, "MainMenu");
	}
    /// <summary>
    /// Scenechange to the unitselectscreen
    /// Sets the next Level
    /// </summary>
	public void NextLevel(){
		Data.currentData.ChosenLevel.LoadLevel (Data.currentData.ChosenLevel.LevelID + 1);
		Data.currentData.LoadScene ("UnitSelectScene");
	}

	//Property
	public bool GamePaused {
		get {
			return gamePaused;
		}
		set {
			gamePaused = value;
		}
	}
}
