using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;

	GameManager gameManager;
	UIController uiController;

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
		uiController = UIController.instance;
		//Disable UI (Cleanup)
		unitControl.SetActive(false);
	}
	void Awake() {
		if (instance != null) {
			Debug.LogError("More than one Player in scene!");
			return;
		}
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			CheckMouseTarget ();
		}
		if (myTurn && selectedUnit != null && selectedUnit.GetComponent<Unit>().OwnedByPlayer) {		
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
			}//Skip Turn
			else if (Input.GetKeyDown (KeyCode.Alpha3) && selectedUnit != null) {
				UnitEndTurn ();
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
			if (!moving && !attacking && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
					if (hit.transform.gameObject.tag == "Unit") {
					selectedUnit = hit.transform.root.gameObject;
					} else if (hit.transform.gameObject.tag == "Tile") {
						selectedUnit = hit.transform.gameObject.GetComponent<Tile> ().Unit;
					}
					if (selectedUnit != null) {						
						Debug.Log ("Successful Hit: " + selectedUnit);
						//Display stats
						uiController.SetUnitStatPanel(selectedUnit.GetComponent<Unit>());

						//Check UnitOwner
						if (selectedUnit.GetComponent<Unit> ().OwnedByPlayer) {
							//Display UI Buttons (Move, attack, End)
							ActivateUnitControl ();				
						} else {
							unitControl.SetActive (false);
						}
					}
			}
			if (moving) {
				if (hit.transform.gameObject.tag == "Unit") {
					selectedTile = hit.transform.root.gameObject.GetComponent<Unit> ().CurrentTile;
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
					selectedTile = hit.transform.root.gameObject.GetComponent<Unit> ().CurrentTile;
				} else if (hit.transform.gameObject.tag == "Tile") {
					selectedTile = hit.transform.gameObject;
				}
				//Attack Unit on target tile
				if (selectedTile != null && selectedTile.GetComponent<Tile>().CurrentlyAttackable) {
					selectedUnit.GetComponent<Unit> ().AttackTile (selectedTile);
					attacking = false;
					UnselectUnit ();
					selectedTile = null;
					AdjustUnitControl ();
				}
			}
		}
	}

	public void OnTurnStart(){
		foreach (GameObject unit in units) {
			//activate "not used this turn" marker
			unit.GetComponent<Unit>().OnTurnStart();
		}
		myTurn = true;
	}

	void ResetSelection(){
		if (moving || attacking) {
			selectedUnit.GetComponent<Unit> ().ResetCurrentlyColoredTiles ();
		} else {
			UnselectUnit ();
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
			if (selectedUnit.GetComponent<Unit> ().FindAllAttackableTiles (attackableMaterial)) {
				attacking = true;
				moving = false;
			}
		}
	}

	public void PrepareMove(){
		if (!selectedUnit.GetComponent<Unit> ().Moved) {
			if (selectedUnit.GetComponent<Unit> ().FindAllMovableTiles (movableMaterial)) {
				moving = true;
			}
		}
	}
	//Unit
	public void AddUnit(GameObject unit){
		units.Add (unit);
	}

	public void UnitEndTurn(){
		selectedUnit.GetComponent<Unit>().OnTurnEnd();

		AdjustUnitControl ();
	}

	void ActivateUnitControl(){
		unitControl.SetActive (true);

		AdjustUnitControl ();
	}

	void AdjustUnitControl(){
		GameObject Move = unitControl.transform.Find("MoveButton").gameObject;
		GameObject Attack = unitControl.transform.Find("AttackButton").gameObject;

		if (selectedUnit == null) {
			unitControl.SetActive (false);
		}else if (selectedUnit.GetComponent<Unit> ().TurnEnded) {
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
		//end all turns for units
		foreach (GameObject unit in units) {
			unit.GetComponent<Unit> ().TurnEnded = true;
		}
		myTurn = false;
		AdjustUnitControl();
		//Tell GameManager to go to next turn
		gameManager.NextTurn();
	}

	void UnselectUnit(){
		selectedUnit = null;
		uiController.UnsetUnitStatPanel ();
	}
	public bool OwnsUnit(GameObject checkUnit){
		return units.Contains (checkUnit);
	}
	public void RemoveUnit(GameObject unit){
		units.Remove (unit);
		//Check if no unit is left
		if (units.Count == 0) {
			//Player looses match
			gameManager.LooseMatch();
		}
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
