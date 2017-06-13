using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {

	public List<GameObject> units;
	private int currentUnitID = 0;
	private GameObject currentShownUnit;

	public GameObject ShowTile;
	public GameObject ArrowLeft;
	public GameObject ArrowRight;
	// Use this for initialization
	void Start () {
		 DisplayUnit (ShowTile, currentUnitID);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100)) {
				if (hit.transform.root.name == "ArrowLeft") {
					LastUnit ();
				} else if (hit.transform.root.name == "ArrowRight") {
					NextUnit ();
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
			if (currentUnitID > 0) {
				LastUnit ();
			} else {
				//Display "Cannot next" animation
			}
		}else if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)){
			if (currentUnitID < units.Count-1) {
				NextUnit ();
			} else {
				//Display "Cannot next" animation
			}
		}//Upgrade
		else if(Input.GetKeyDown(KeyCode.U)){
			ShowTalentTree();
		}

	}
	void NextUnit(){
		Debug.Log ("Next unit");
		currentUnitID++;
		//Display Arrow Left animation

		//Display next Unit
		DisplayUnit(ShowTile,currentUnitID);
	}
	void LastUnit(){
		Debug.Log ("Last unit");
		currentUnitID--;
		//Display Arrow Left animation

		//Display next Unit
		DisplayUnit(ShowTile,currentUnitID);
	}

	void DisplayUnit(GameObject spawnOnTile, int unitID){
		if (currentShownUnit != null) {
			Destroy (currentShownUnit);
		}
		Vector3 position = new Vector3 (spawnOnTile.transform.position.x, units[unitID].transform.position.y, spawnOnTile.transform.position.z);
		GameObject tmpUnit = Instantiate (units[unitID], position, Quaternion.identity * Quaternion.Euler(0,75,0));
		tmpUnit.GetComponent<Unit> ().Setup (spawnOnTile);
		currentShownUnit = tmpUnit;
	}

	public void ShowTalentTree(){
		//Display Talent Tree
		Debug.Log("Show Talent Tree");
		//Talent Tree enables spending experience points to unlock permanent powerups
	}

}
