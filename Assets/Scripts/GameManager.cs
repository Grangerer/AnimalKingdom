using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	//Test
	public GameObject testUnit;
	//Test

	public PlayerController playerController;
	bool playersTurn;

	AI ai;


	private LevelSpawner levelSpawner;
	private List<GameObject> tileList;




	// Use this for initialization
	void Start () {
		ai = AI.instance;
		//Spawn Level
		Level level = new Level();
		level.LoadLevel(0);
		levelSpawner = this.GetComponent<LevelSpawner>();
		tileList = levelSpawner.SpawnLevel(level);
		//Spawn Units
		//Test: Spawn PlayerUnit on Tile(3)(1)
		if (GameObject.Find ("Tile(3)(1)") != null) {
			GameObject spawnOnTile = GameObject.Find ("Tile(3)(1)");
			Vector3 position = new Vector3 (spawnOnTile.transform.position.x, testUnit.transform.position.y, spawnOnTile.transform.position.z);
			GameObject tmpUnit = Instantiate (testUnit, position, Quaternion.identity);
			tmpUnit.GetComponent<Unit> ().Setup (spawnOnTile);
			tmpUnit.GetComponent<Unit> ().OwnedByPlayer = true;
			spawnOnTile.GetComponent<Tile> ().ReferenceUnit(tmpUnit);
			playerController.AddUnit (tmpUnit);
		}
		//Test: Spawn second playerUnit on Tile (2)(2)
		if (GameObject.Find ("Tile(2)(2)") != null) {
			GameObject spawnOnTile = GameObject.Find ("Tile(2)(2)");
			Vector3 position = new Vector3 (spawnOnTile.transform.position.x, testUnit.transform.position.y, spawnOnTile.transform.position.z);
			GameObject tmpUnit = Instantiate (testUnit, position, Quaternion.identity);
			tmpUnit.GetComponent<Unit> ().Setup (spawnOnTile);
			tmpUnit.GetComponent<Unit> ().OwnedByPlayer = true;
			spawnOnTile.GetComponent<Tile> ().ReferenceUnit(tmpUnit);
			playerController.AddUnit (tmpUnit);
		}

		playerController.OnTurnStart ();
		playersTurn = true;
	}

	void Awake() {
		if (instance != null) {
			Debug.LogError("More than one GameManager in scene!");
			return;
		}
		instance = this;
	}
	// Update is called once per frame
	void Update () {

	}

	//Turnstuff
	public void NextTurn(){

		playersTurn = !playersTurn;
		if (!playersTurn) {
			Debug.Log ("AiTurn");
			//initiate AI stuff
			StartCoroutine (AIStart ());

		} else {
			playerController.OnTurnStart ();
			playersTurn = true;
		}
	}
	IEnumerator AIStart(){
		ai.StartTurn ();
		yield return new WaitForSeconds (2);
		Debug.Log ("AiTurn End");
		NextTurn();
	}
		
	//Win Match
	public void WinMatch(){
		Debug.Log ("Player has won the match");
		Time.timeScale = 0;
	}
	public void LooseMatch(){
		Debug.Log ("Player has lost the match");
		Time.timeScale = 0;
	}
}
