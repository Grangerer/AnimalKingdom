using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	public BaseUnit baseUnit;

	//Status Ailments and remembering last turn stuff
	bool movedLastTurn;
	bool attackedLastTurn;

	private bool ownedByPlayer = false;
	[System.NonSerialized]
	private GameObject currentTile;
	[System.NonSerialized]
	private Transform healthBar;

	private bool moved = false;
	private bool attacked = false;
	private bool turnEnded = false;

	[System.NonSerialized]
	public UnitAI unitAI = new UnitAI();
	[System.NonSerialized]
	private AI ai;
	[System.NonSerialized]
	private PlayerController playerController;

	[System.NonSerialized]
	List<GameObject> currentlyColoredTiles;
	// Use this for initialization
	void Start () {
		ai = AI.instance;
		playerController = PlayerController.instance;
		healthBar = this.transform.Find ("HealthBar");
		baseUnit.SetupOnBattleStart ();
		unitAI.Unit = this;
		currentlyColoredTiles = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Movement
	public bool FindAllMovableTiles (Material movableMaterial)
	{
		ResetCurrentlyColoredTiles ();

		Tile baseTile = this.CurrentTile.GetComponent<Tile> ();
		List<GameObject> toColorTiles = new List<GameObject> ();
		//Add all adjacentTiles to recolor list

		foreach (GameObject tile in baseTile.AdjacentTiles) {
			if(!tile.GetComponent<Tile>().Occupied){
				toColorTiles.Add(tile);
			}
		}
		//add adjacent tiles of all added tiles, excluding already added tiles => repeat equal to movementspeed
		for (int i = 1; i < baseUnit.CurrentMovementspeed; i++) {
			List<GameObject> tmpTiles = new List<GameObject> ();
			foreach (GameObject tile in toColorTiles) {
				foreach (GameObject checkTile in tile.GetComponent<Tile>().AdjacentTiles) {
					if (!checkTile.GetComponent<Tile> ().Occupied && checkTile.name != baseTile.name) {
						tmpTiles.Add (checkTile);
					}
				}
			}
			foreach (GameObject tile in tmpTiles) {
				if (!toColorTiles.Exists (t => t.name == tile.name)) {
					toColorTiles.Add (tile);
				}
			}							
		}
		if (toColorTiles.Count == 0) {
			return false;
		}
			
		foreach (GameObject tileGO in toColorTiles) {
			tileGO.GetComponent<Tile> ().Recolor (movableMaterial);
			tileGO.GetComponent<Tile> ().CurrentlyMovable = true;
		}
		currentlyColoredTiles = toColorTiles;

		return true;
	}
	public void MoveToTile(GameObject tile){
		TurnTowards (tile);
		//Move
		Vector3 newPosition = new Vector3 (tile.transform.position.x, this.transform.position.y, tile.transform.position.z);
		this.transform.position = newPosition;
		this.Moved = true;
		//Dereference unit on old tile
		currentTile.GetComponent<Tile> ().ReferenceUnit (null);
		//reference unit on new tile;
		currentTile = tile;
		tile.GetComponent<Tile> ().ReferenceUnit (this.gameObject);
		//Uncolor tiles after movement
		foreach (GameObject tileGO in currentlyColoredTiles) {
			tileGO.GetComponent<Tile> ().ResetColor ();			
		}

		currentlyColoredTiles = new List<GameObject> ();

	}

	//Attack
	public bool FindAllAttackableTiles(Material attackableMaterial){
		ResetCurrentlyColoredTiles ();

		bool foundAttackableTile = false;
		Tile baseTile = this.CurrentTile.GetComponent<Tile> ();
		List<GameObject> toColorTiles = new List<GameObject> ();
		//Add all adjacentTiles to recolor list

		foreach (GameObject tile in baseTile.AdjacentTiles) {
			toColorTiles.Add(tile);
		}
		//add adjacent tiles of all added tiles, excluding already added tiles => repeat equal to attackrange
		for (int i = 1; i < baseUnit.CurrentAttackRange; i++) {
			List<GameObject> tmpTiles = new List<GameObject> ();
			foreach (GameObject tile in toColorTiles) {
				foreach (GameObject checkTile in tile.GetComponent<Tile>().AdjacentTiles) {
					if (checkTile.name != baseTile.name) {
						tmpTiles.Add (checkTile);
					}
				}
			}
			foreach (GameObject tile in tmpTiles) {
					if (!toColorTiles.Exists (t => t.name == tile.name)) {
						toColorTiles.Add (tile);
					}
			}							
		}

		foreach (GameObject tileGO in toColorTiles) {
			if (tileGO.GetComponent<Tile> ().Unit != null && !tileGO.GetComponent<Tile> ().Unit.GetComponent<Unit> ().OwnedByPlayer) {				
				tileGO.GetComponent<Tile> ().Recolor (attackableMaterial);
				tileGO.GetComponent<Tile> ().CurrentlyAttackable = true;
				foundAttackableTile = true;
			}
		}
		if (!foundAttackableTile) {
			return false;
		}
		currentlyColoredTiles = toColorTiles;
		return true;
	}
	public void AttackTile(GameObject tile){
		tile.GetComponent<Tile> ().Unit.GetComponent<Unit> ().Damage (baseUnit.CurrentAttackDamage);
		this.Attacked = true;
		OnTurnEnd ();
		TurnTowards (tile);
		//Uncolor tiles after attack
		foreach (GameObject tileGO in currentlyColoredTiles) {
			tileGO.GetComponent<Tile> ().ResetColor ();			
		}
		currentlyColoredTiles = new List<GameObject>();
	}
	public void Damage(int attackDamage){
		//Damage
		baseUnit.CurrentHealth -= attackDamage;
		//Adjust Healthbar
		healthBar.gameObject.SetActive(true);
		float xScale = (float)baseUnit.CurrentHealth/ (float)baseUnit.health;
		healthBar.Find("Health").localScale = new Vector3(xScale,1,1);
		//Do all relevant checks regarding death and abilities
		if (baseUnit.CurrentHealth <= 0) {
			DestroyUnit ();
		}
	}

	//General
	void TurnTowards(GameObject target){
		//Turn towards target
		Vector3 targetPoint = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;
		Quaternion targetRotation = Quaternion.LookRotation (-targetPoint, Vector3.up) * Quaternion.Euler(0,90,0);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1);
		//Set healthbar turnrate back
		healthBar.rotation = Quaternion.Euler(0,0,0);
	}
	public void ResetCurrentlyColoredTiles ()
	{
		foreach (GameObject tile in currentlyColoredTiles) {
			tile.GetComponent<Tile> ().ResetColor ();
		}
	}

	void DestroyUnit(){
		//Free the the tile from this unit
		if (currentTile != null) {
			currentTile.GetComponent<Tile> ().ReferenceUnit (null);
		}
		//Remove Unit from its owners unit list (Player or AI)
		if (playerController.OwnsUnit (this.gameObject)) {
			playerController.RemoveUnit (this.gameObject);
		} else if (ai.OwnsUnit (this.gameObject)) {
			ai.RemoveUnit (this.gameObject);
		}
		//Destroy
		Destroy(this.gameObject);
	}

	//Turn
	public void OnTurnStart(){
		movedLastTurn = moved;
		attackedLastTurn = attacked;
		moved = false;
		attacked = false;
		turnEnded = false;
		currentTile.GetComponent<Tile> ().ShowUsableUnit ();
	}
	public void OnTurnEnd(){
		turnEnded = true;
		currentTile.GetComponent<Tile> ().HideUsableUnit ();
	}

	//PropertyStuff
	public void Setup(GameObject tile){
		currentTile = tile;
	}
	public GameObject CurrentTile {
		get {
			return currentTile;
		}
	}
	public bool OwnedByPlayer {
		get {
			return ownedByPlayer;
		}
		set {
			ownedByPlayer = value;
		}
	}
	public bool Moved {
		get {
			return moved;
		}
		set {
			moved = value;
		}
	}
	public bool TurnEnded {
		get {
			return turnEnded;
		}
		set {
			turnEnded = value;
		}
	}
	public bool Attacked {
		get {
			return attacked;
		}
		set {
			attacked = value;
		}
	}

}
