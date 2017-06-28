using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour {

	public static BattleManager instance;
	//Test
	public GameObject testUnit;
	//Test

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
		ai = AI.instance;
		//Spawn Level
		Level level = new Level();
		level.LoadLevel(1);
		levelSpawner = this.GetComponent<LevelSpawner>();
		tileList = levelSpawner.SpawnLevel(level);
		//Do Spawnchoserscript
		//Apply all playerUpgrades for units

		//Test: Spawn PlayerUnit on Tile(3)(1)
		if (GameObject.Find ("Tile(3)(1)") != null) {
			GameObject spawnOnTile = GameObject.Find ("Tile(3)(1)");
			Vector3 position = new Vector3 (spawnOnTile.transform.position.x, testUnit.transform.position.y, spawnOnTile.transform.position.z);
			GameObject tmpUnit = (GameObject) Instantiate (testUnit, position, Quaternion.identity);
			//This line links the units to each other
			tmpUnit.GetComponent<Unit> ().baseUnit = new BaseUnit(Player.current.Units [1]);
			tmpUnit.GetComponent<Unit> ().Setup (spawnOnTile);
			tmpUnit.GetComponent<Unit> ().OwnedByPlayer = true;
			spawnOnTile.GetComponent<Tile> ().ReferenceUnit(tmpUnit);
			playerController.AddUnit (tmpUnit);
		}
		//Test: Spawn second playerUnit on Tile (2)(2)
		if (GameObject.Find ("Tile(2)(2)") != null) {
			GameObject spawnOnTile = GameObject.Find ("Tile(2)(2)");
			Vector3 position = new Vector3 (spawnOnTile.transform.position.x, testUnit.transform.position.y, spawnOnTile.transform.position.z);
			GameObject tmpUnit = (GameObject) Instantiate (testUnit, position, Quaternion.identity);
			//This line links the units to each other
			tmpUnit.GetComponent<Unit> ().baseUnit = new BaseUnit(Player.current.Units [1]);
			tmpUnit.GetComponent<Unit> ().Setup (spawnOnTile);
			tmpUnit.GetComponent<Unit> ().OwnedByPlayer = true;
			spawnOnTile.GetComponent<Tile> ().ReferenceUnit(tmpUnit);
			playerController.AddUnit (tmpUnit);
		}//Test: Spawn second playerUnit on Tile (2)(2)
		if (GameObject.Find ("Tile(1)(1)") != null) {
			GameObject spawnOnTile = GameObject.Find ("Tile(1)(1)");
			Vector3 position = new Vector3 (spawnOnTile.transform.position.x, testUnit.transform.position.y, spawnOnTile.transform.position.z);
			GameObject tmpUnit = (GameObject) Instantiate (testUnit, position, Quaternion.identity);
			//This line links the units to each other
			tmpUnit.GetComponent<Unit> ().baseUnit = new BaseUnit(Player.current.Units [1]);
			tmpUnit.GetComponent<Unit> ().Setup (spawnOnTile);
			tmpUnit.GetComponent<Unit> ().OwnedByPlayer = true;
			spawnOnTile.GetComponent<Tile> ().ReferenceUnit(tmpUnit);
			playerController.AddUnit (tmpUnit);
		}
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
		yield return new WaitForSeconds (1);
		Debug.Log ("AiTurn End");
		NextTurn();
	}
		
	//Win Match
	public void WinMatch(){
		Debug.Log ("Player has won the match");
		Player.current.Experience += 100;
		Time.timeScale = 0;
		GoToMainMenu ();
	}
	public void LooseMatch(){
		Debug.Log ("Player has lost the match");
		Time.timeScale = 0;
		SceneManager.LoadScene ("UpgradeScene");
	}
	//Menu
	public void OpenInBattleMenu(){
		if (BattleMenu.activeSelf == false) {
			Time.timeScale = 0;
			gamePaused = true;
			BattleMenu.SetActive (true);
		} else {
			Resume ();
		}
	}
	public void Resume(){
		BattleMenu.SetActive(false);
		gamePaused = false;
		Time.timeScale = 1;
	}
	public void RestartLevel(){
		string sceneToLoadName = SceneManager.GetActiveScene ().name;
		SceneManager.LoadScene (sceneToLoadName);
	}
	public void OpenOptions(){}
	public void GoToMainMenu(){
		SaveLoad.SavePlayer ();
		string sceneToLoadName = "MainMenu";
		SceneManager.LoadScene (sceneToLoadName);
	}
	public void GoToUpgrade(){
		string sceneToLoadName = "UpgradeUnits";
		SceneManager.LoadScene (sceneToLoadName);
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
