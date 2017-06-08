using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	//Test
	public GameObject testUnit;
	//Test

	private float unitHeight = 0.38f;

	public Material movableMaterial;

	private LevelSpawner levelSpawner;
	private List<GameObject> tileList;

	//Turn and Unitcontrol
	private GameObject selectedUnitGO = null;
	public GameObject unitControl;

	// Use this for initialization
	void Start () {
		//Spawn Level
		levelSpawner = this.GetComponent<LevelSpawner>();
		tileList = levelSpawner.SpawnTiles(5,5);
		//Spawn Units
		//Test: Spawn on Tile(3)(1)
		if (GameObject.Find ("Tile(3)(1)") != null) {
			GameObject spawnOnTile = GameObject.Find ("Tile(3)(1)");
			Vector3 position = new Vector3 (spawnOnTile.transform.position.x, unitHeight, spawnOnTile.transform.position.z);
			GameObject tmpUnit = Instantiate (testUnit, position, Quaternion.identity);
			tmpUnit.GetComponent<Unit> ().Setup (spawnOnTile);
			tmpUnit.GetComponent<Unit> ().OwnedByPlayer = true;
			spawnOnTile.GetComponent<Tile> ().SetUnit(tmpUnit);
		}
		//Disable UI (Cleanup)
		unitControl.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			CheckMouseTarget ();
		}
	}

	void CheckMouseTarget(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 100)) {
			if (hit.transform.gameObject.tag == "Unit") {
				selectedUnitGO = hit.transform.gameObject;
			}else if(hit.transform.gameObject.tag == "Tile") {
				selectedUnitGO = hit.transform.gameObject.GetComponent<Tile> ().Unit;
			}
			if (selectedUnitGO != null) {
				Debug.Log ("Successful Hit: " + selectedUnitGO);
				//Check UnitOwner
				if (selectedUnitGO.GetComponent<Unit> ().OwnedByPlayer) {
					if (!selectedUnitGO.GetComponent<Unit> ().UsedThisRound) {
						//Display UI Buttons (Move, attack, End)
						unitControl.SetActive(true);
					}
				//Display stats
				}

			}
		}
	}

	public void Move(){
		selectedUnitGO.GetComponent<Unit>().FindAllMovableTiles (movableMaterial);
	}


}
