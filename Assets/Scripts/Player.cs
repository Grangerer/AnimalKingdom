using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	GameManager gameManager;

	List<GameObject> units = new List<GameObject> ();
	GameObject selectedUnit = null;
	bool myTurn;

	public Material movableMaterial;
	public Material attackableMaterial;

	//In-Turn modes
	bool moving = false;
	bool attacking = false;

	//Turn and Unitcontrol
	public GameObject unitControl;

	// Use this for initialization
	void Start () {
		gameManager = GameManager.instance;
		//Disable UI (Cleanup)
		unitControl.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			CheckMouseTarget ();
		}
		if (myTurn) {		
			//Moving	
			if (Input.GetKeyDown (KeyCode.Alpha1) && selectedUnit != null) {
				if (!selectedUnit.GetComponent<Unit> ().Moved) {
					PrepareMove ();
				}
			} //Attacking
			else if (Input.GetKeyDown (KeyCode.Alpha2) && selectedUnit != null) {
				if (!selectedUnit.GetComponent<Unit> ().Attacked) {
					PrepareAttack ();
				}
			}//Right click => Cancel
			else if (Input.GetMouseButtonDown (1)) {
				//Reset out of current state (unchoose moving/attacking etc)
				ResetSelection();
			}
		}
	}

	void CheckMouseTarget(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		GameObject selectedTile = null;

		if (Physics.Raycast (ray, out hit, 100)) {

			if (selectedUnit == null || !selectedUnit.GetComponent<Unit>().OwnedByPlayer) {
				if (Physics.Raycast (ray, out hit, 100)) {
					if (hit.transform.gameObject.tag == "Unit") {
						selectedUnit = hit.transform.gameObject;
					} else if (hit.transform.gameObject.tag == "Tile") {
						selectedUnit = hit.transform.gameObject.GetComponent<Tile> ().Unit;
					}
					if (selectedUnit != null) {						
						Debug.Log ("Successful Hit: " + selectedUnit);
						//Display stats


						if (selectedUnit.GetComponent<Unit> ().TurnEnded) {
							selectedUnit = null;
						} //Check UnitOwner
						else if (selectedUnit.GetComponent<Unit> ().OwnedByPlayer) {
								//Display UI Buttons (Move, attack, End)
								ActivateUnitControl ();				
						}
					}
				}
			}
			if (moving) {
				if (hit.transform.gameObject.tag == "Unit") {
					selectedTile = hit.transform.gameObject.GetComponent<Unit> ().CurrentTile;
				} else if (hit.transform.gameObject.tag == "Tile") {
					selectedTile = hit.transform.gameObject;
				}
				//Move Unit to new tile
				if (selectedTile != null && selectedTile.GetComponent<Tile>().CurrentlyMovable) {
					selectedUnit.GetComponent<Unit> ().MoveToTile (selectedTile);
					moving = false;
					selectedTile = null;
					//Disable Move Button
					AdjustUnitControl();
				}

			} else if (attacking) {
				if (hit.transform.gameObject.tag == "Unit") {
					selectedTile = hit.transform.gameObject.GetComponent<Unit> ().CurrentTile;
				} else if (hit.transform.gameObject.tag == "Tile") {
					selectedTile = hit.transform.gameObject;
				}
				//Attack Unit on target tile
				if (selectedTile != null && selectedTile.GetComponent<Tile>().CurrentlyAttackable) {
					selectedUnit.GetComponent<Unit> ().AttackTile (selectedTile);
					attacking = false;
					selectedTile = null;
					//Disable Move Button
					AdjustUnitControl();
				}
			}
		}
	}

	public void OnTurnStart(){
		foreach (GameObject unit in units) {
			//activate "not used this turn" marker
		}
		myTurn = true;
	}

	void ResetSelection(){
		if (moving || attacking) {
			selectedUnit.GetComponent<Unit> ().ResetCurrentlyColoredTiles ();
		} else {
			selectedUnit = null;
			unitControl.SetActive (false);
		}
		ResetTurnStat ();
	}

	void ResetTurnStat(){
		moving = false;
		attacking = false;
	}

	public void PrepareAttack(){
		if (!selectedUnit.GetComponent<Unit> ().Attacked) {
			selectedUnit.GetComponent<Unit> ().FindAllAttackableTiles (attackableMaterial);
			attacking = true;
		}
	}

	public void PrepareMove(){
		if (!selectedUnit.GetComponent<Unit> ().Moved) {
			selectedUnit.GetComponent<Unit> ().FindAllMovableTiles (movableMaterial);
			moving = true;
		}
	}

	void ActivateUnitControl(){
		unitControl.SetActive (true);

		AdjustUnitControl ();
	}

	void AdjustUnitControl(){
		GameObject Move = unitControl.transform.Find("MoveButton").gameObject;
		GameObject Attack = unitControl.transform.Find("AttackButton").gameObject;

		if (selectedUnit.GetComponent<Unit> ().TurnEnded) {
			unitControl.SetActive (false);
		} else if (Attack != null && selectedUnit.GetComponent<Unit> ().Attacked) {
			Move.SetActive (false);
			Attack.SetActive (false);
		} else if (Move != null && selectedUnit.GetComponent<Unit> ().Moved) {
			Move.SetActive (false);
			Attack.SetActive (true);
		} else {
			Move.SetActive (true);
			Attack.SetActive (true);
		}

		
	
	}

	public void EndTurn(){
		//Cleanupstuff

		//Tell GameManager to go to next turn
		gameManager.NextTurn();
	}


	//Properties
	public GameObject SelectedUnit {
		get {
			return selectedUnit;
		}
		set {
			selectedUnit = value;
		}
	}
}
