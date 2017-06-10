using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	//Test
	public GameObject testUnit;
	//Test

	public Player player;
	bool playersTurn;

	AI ai;


	private LevelSpawner levelSpawner;
	private List<GameObject> tileList;




	// Use this for initialization
	void Start () {
		ai = AI.instance;
		//Spawn Level
		levelSpawner = this.GetComponent<LevelSpawner>();
		tileList = levelSpawner.SpawnTiles(10,7);
		//Spawn Units
		//Test: Spawn PlayerUnit on Tile(3)(1)
		if (GameObject.Find ("Tile(3)(1)") != null) {
			GameObject spawnOnTile = GameObject.Find ("Tile(3)(1)");
			Vector3 position = new Vector3 (spawnOnTile.transform.position.x, testUnit.transform.position.y, spawnOnTile.transform.position.z);
			GameObject tmpUnit = Instantiate (testUnit, position, Quaternion.identity);
			tmpUnit.GetComponent<Unit> ().Setup (spawnOnTile);
			tmpUnit.GetComponent<Unit> ().OwnedByPlayer = true;
			spawnOnTile.GetComponent<Tile> ().ReferenceUnit(tmpUnit);
			player.AddUnit (tmpUnit);
		}
		//Test: Spawn EnemyUnit on Tile (2)(1)
		if (GameObject.Find ("Tile(2)(1)") != null) {
			GameObject spawnOnTile = GameObject.Find ("Tile(2)(1)");
			Vector3 position = new Vector3 (spawnOnTile.transform.position.x, testUnit.transform.position.y, spawnOnTile.transform.position.z);
			GameObject tmpUnit = Instantiate (testUnit, position, Quaternion.identity);
			tmpUnit.GetComponent<Unit> ().Setup (spawnOnTile);
			tmpUnit.GetComponent<Unit> ().OwnedByPlayer = false;
			spawnOnTile.GetComponent<Tile> ().ReferenceUnit(tmpUnit);
			ai.AddUnit (tmpUnit);
		}
		//Test: Spawn second playerUnit on Tile (2)(2)
		if (GameObject.Find ("Tile(2)(2)") != null) {
			GameObject spawnOnTile = GameObject.Find ("Tile(2)(2)");
			Vector3 position = new Vector3 (spawnOnTile.transform.position.x, testUnit.transform.position.y, spawnOnTile.transform.position.z);
			GameObject tmpUnit = Instantiate (testUnit, position, Quaternion.identity);
			tmpUnit.GetComponent<Unit> ().Setup (spawnOnTile);
			tmpUnit.GetComponent<Unit> ().OwnedByPlayer = true;
			spawnOnTile.GetComponent<Tile> ().ReferenceUnit(tmpUnit);
			player.AddUnit (tmpUnit);
		}

		player.OnTurnStart ();
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


	public void NextTurn(){

		playersTurn = !playersTurn;
		if (!playersTurn) {
			Debug.Log ("AiTurn");
			//initiate AI stuff
			StartCoroutine (AIStart ());

		} else {
			player.OnTurnStart ();
			playersTurn = true;
		}
	}
	IEnumerator AIStart(){
		ai.StartTurn ();
		yield return new WaitForSeconds (5);
		Debug.Log ("AiTurn End");
		NextTurn();
	}
		
}
