using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitSelectManager : MonoBehaviour {

	[SerializeField]
	List<GameObject> tiles = new List<GameObject>();

	List<GameObject> units = new List<GameObject>();

	public Material doubleWarnColor;
	bool noCurrentDuplicates = true;

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
					StartCoroutine(LastUnit (tileID));
				} else if (hit.transform.parent.name == "ArrowRight" || hit.transform.root.name == "ArrowRight") {
					int tileID = GetTileID (hit);
					StartCoroutine(NextUnit (tileID));
				}
			}
		}
	}

	IEnumerator NextUnit(int tileID){
		int currentIndex = Data.currentData.units.FindIndex (x => x.GetComponent<Unit>().baseUnit.id == units [tileID].GetComponent<Unit>().baseUnit.id);
		if (currentIndex < Data.currentData.units.Count-1) {
			/*Display Arrow Right animation
			arrowRightAnimation.Stop ();
			arrowRightAnimation.Play ();
			yield return new WaitForSeconds (arrowRightAnimation.clip.length/4*3);
			//Display next Unit*/
			//Debug.Log ("TestNext");
			DisplayUnit(currentIndex+1, tileID);
		} else {
			//Display "Cannot next" animation
		}
		yield return 0;
	}
	IEnumerator LastUnit(int tileID){
		int currentIndex = Data.currentData.units.FindIndex (x => x.GetComponent<Unit>().baseUnit.id == units [tileID].GetComponent<Unit>().baseUnit.id);
		if (currentIndex > 0) {
			/*//Display Arrow Left animation
			arrowLeftAnimation.Stop ();
			arrowLeftAnimation.Play ();
			yield return new WaitForSeconds (arrowLeftAnimation.clip.length/4*3);
			//Display next Unit*/
			//Debug.Log ("TestLast");
			DisplayUnit(currentIndex-1,tileID);
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
		int currentIndex = Data.currentData.units.FindIndex (x => x.GetComponent<Unit>().baseUnit.id == Player.current.PriorityIDList [i]);
		Vector3 position = new Vector3 (tiles[i].transform.position.x, Data.currentData.units[currentIndex].transform.position.y + tiles[i].transform.position.y, tiles[i].transform.position.z);
		GameObject tmpUnit = Instantiate (Data.currentData.units[currentIndex], position, Quaternion.identity * Quaternion.Euler(0,25,0));
		tmpUnit.GetComponent<Unit> ().Setup (tiles [i]);

		if (units.Count > i && units [i] != null) {
			//Debug.Log ("Test Display Prio");
			Destroy (units [i]);
			units [i] = tmpUnit;
		} else {
			units.Add (tmpUnit);				
		}
	}
	void DisplayUnit(int unitID, int tileID){
		Vector3 position = new Vector3 (tiles[tileID].transform.position.x, Data.currentData.units[unitID].transform.position.y + tiles[tileID].transform.position.y, tiles[tileID].transform.position.z);
		GameObject tmpUnit = Instantiate (Data.currentData.units[unitID], position, Quaternion.identity * Quaternion.Euler(0,25,0));
		tmpUnit.GetComponent<Unit> ().Setup (tiles [tileID]);

		if (units.Count > tileID && units [tileID] != null) {
			//Debug.Log ("Test Display");
			Destroy (units [tileID]);
			units [tileID] = tmpUnit;
		} else {
			units.Add (tmpUnit);				
		}
		CheckDoubles ();
	}

	void CheckDoubles(int tileID){
		bool noDoubleFound = true;
		for (int i = 0; i < units.Count-1; i++) {			
			if (units[i].GetComponent<Unit> ().baseUnit.id == units [tileID].GetComponent<Unit> ().baseUnit.id && i != tileID) {
				Recolor(tileID);
				Recolor (i);
				noDoubleFound = false;
			}
		}
		if (noDoubleFound) {
			Recolor (tileID, false);

		}
	}

	void CheckDoubles(){
		List<int> idList = new List<int> ();
		List<int> doublesIDlist = new List<int> ();
		noCurrentDuplicates = true;
		for (int i = 0; i < units.Count; i++) {
			if (!idList.Contains (units [i].GetComponent<Unit> ().baseUnit.id)) {
				idList.Add (units [i].GetComponent<Unit> ().baseUnit.id);
			} else {				
				doublesIDlist.Add (units [i].GetComponent<Unit> ().baseUnit.id);
			}
		}
		for (int i = 0; i < units.Count; i++) {
			if (doublesIDlist.Contains (units [i].GetComponent<Unit> ().baseUnit.id)) {
				Recolor (i);
				noCurrentDuplicates = false;
			} else {
				Recolor(i, false);
			}
		}

	}

	void Recolor(int tileID,bool duplicate = true){
		if (duplicate) {
			tiles [tileID].GetComponentInChildren<Tile> ().Recolor (doubleWarnColor);
		} else {
			tiles [tileID].GetComponentInChildren<Tile> ().ResetColor ();
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

	public void GoToBattle(){
		if (noCurrentDuplicates) {
			SetPlayerPriorityList ();
			Data.currentData.LoadScene ("Battle");
		} else {
			Debug.Log ("Insert duplicate-warning");
		}
	}

	public void GoBack(){
		//Replace with "LevelSelect", once implemented
		Data.currentData.LoadScene (Data.currentData.previousLevelName);
	}
	public void GoToUpgrade(){
		Data.currentData.LoadScene ("UpgradeScene");
	}


	void SetPlayerPriorityList(){
		for (int i = 0; i < units.Count; i++) {
			Player.current.PriorityIDList [i] = units [i].GetComponent<Unit> ().baseUnit.id;
		}
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
