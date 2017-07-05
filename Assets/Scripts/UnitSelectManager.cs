using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectManager : MonoBehaviour {

	[SerializeField]
	List<GameObject> tiles = new List<GameObject>();

	List<GameObject> units = new List<GameObject>();



	// Use this for initialization
	void Start () {
		int playerUnits = Data.currentData.ChosenLevel.PlayerUnitPositions.Count;
		Setup (playerUnits);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100)) {
				if (hit.transform.parent.name == "ArrowLeft" || hit.transform.name == "ArrowLeft") {
					int tileID = GetTileID (hit);

					Debug.Log ("Test");
					StartCoroutine(LastUnit (tileID));
				} else if (hit.transform.root.name == "ArrowRight") {
					int tileID = GetTileID (hit);
					StartCoroutine(NextUnit (tileID));
				}
			}
		}
	}

	IEnumerator NextUnit(int tileID){
		if (units[tileID].GetComponent<Unit>().baseUnit.id < Data.currentData.units.Count-1) {
			/*Display Arrow Right animation
			arrowRightAnimation.Stop ();
			arrowRightAnimation.Play ();
			yield return new WaitForSeconds (arrowRightAnimation.clip.length/4*3);
			//Display next Unit*/
			Debug.Log ("Test");
			DisplayUnit(units[tileID].GetComponent<Unit>().baseUnit.id +1, tileID);
		} else {
			//Display "Cannot next" animation
		}
		Debug.Log ("Test");
		yield return 0;
	}
	IEnumerator LastUnit(int tileID){
		if (units[tileID].GetComponent<Unit>().baseUnit.id > 0) {
			/*//Display Arrow Left animation
			arrowLeftAnimation.Stop ();
			arrowLeftAnimation.Play ();
			yield return new WaitForSeconds (arrowLeftAnimation.clip.length/4*3);
			//Display next Unit*/
			Debug.Log ("Test");
			DisplayUnit(units[tileID].GetComponent<Unit>().baseUnit.id-1,tileID);
		} else {
			//Display "Cannot last" animation
		}
		yield return 0;
	}

	void Setup(int playerUnits){
		for (int i = tiles.Count-1; i >= playerUnits; i--) {
			tiles [i].SetActive (false);
		}
		RepositionCamera (playerUnits);
	
		//Spawn units based on prioritylist
		for (int i = 0; i < playerUnits; i++) {
			DisplayUnitPriority (i);
		}	
	}
	void DisplayUnitPriority(int i){
		Vector3 position = new Vector3 (tiles[i].transform.position.x, Data.currentData.units[Player.current.PriorityIDList [i]].transform.position.y, tiles[i].transform.position.z);
		GameObject tmpUnit = Instantiate (Data.currentData.units[Player.current.PriorityIDList [i]], position, Quaternion.identity * Quaternion.Euler(0,25,0));
		tmpUnit.GetComponent<Unit> ().Setup (tiles [i]);

		if (units.Count > i && units [i] != null) {
			Debug.Log ("Test Display");
			Destroy (units [i]);
			units [i] = tmpUnit;
		} else {
			units.Add (tmpUnit);				
		}
	}
	void DisplayUnit(int unitID, int tileID){
		Vector3 position = new Vector3 (tiles[tileID].transform.position.x, Data.currentData.units[unitID].transform.position.y, tiles[tileID].transform.position.z);
		GameObject tmpUnit = Instantiate (Data.currentData.units[unitID], position, Quaternion.identity * Quaternion.Euler(0,25,0));
		tmpUnit.GetComponent<Unit> ().Setup (tiles [tileID]);

		if (units.Count > unitID && units [unitID] != null) {
			Debug.Log ("Test Display");
			Destroy (units [unitID]);
			units [unitID] = tmpUnit;
		} else {
			units.Add (tmpUnit);				
		}
	}

	void RepositionCamera(int playerUnits){
		switch (playerUnits) {
		case 1:
			Camera.main.transform.position = new Vector3 (0, 1.5f, -2);
			break;
		case 2:
			Camera.main.transform.position = new Vector3 (1, 1.75f, -2.25f);
			break;
		default:
			Camera.main.transform.position = new Vector3 (2, 2f, -2.75f);
			break;
		}
	}

	int GetTileID(RaycastHit hit){
		if (hit.transform.root.name == "Unit1") {
			return 0;
		} else if (hit.transform.root.name == "Unit2") {
			return 1;
		} else if (hit.transform.root.name == "Unit3") {
			return 2;
		} else if (hit.transform.root.name == "Unit4") {
			return 3;
		} else if (hit.transform.root.name == "Unit5") {
			return 4;
		} else if (hit.transform.root.name == "Unit6") {
			return 5;
		} 
		Debug.LogError ("Error in GetTileID");
		return -1;
	}


	/*
	 * Display amount of tiles, equal to amount of playunits in chosen level (This includes repositioning the camera)
	 * Spawn units on tiles, based on current unitpriorityList
	 * Mark Tiles red, whenever a unit is chosen multiple times
	 * Allow transition to next scene, if no duplicate is chosen
	 * 
	 * */
}

/*
Camera Positions:
1: x=0 y=1.5 z=-2
2: x=1 y=1.75 z=-2.25
3-6: x=2 y=2 z=-2.75
 * */
