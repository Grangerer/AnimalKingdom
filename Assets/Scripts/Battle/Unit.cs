using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	public BaseUnit baseUnit;

	//Status Ailments and remembering last turn stuff
	bool movedLastTurn = false;
	bool attackedLastTurn = false;

	private bool ownedByPlayer = false;
	private GameObject currentTile;
	private Transform healthBar;

	private bool moved = false;
	private bool attacked = false;
	private bool turnEnded = false;


	//Abilities
	public List<Ability> onBeingAttacked = new List<Ability>();
	public List<Ability> onAttacking = new List<Ability>(){};
	public List<Ability> onTurnStart = new List<Ability>();
	public List<Ability> onTurnEnd = new List<Ability>();
	public List<Ability> onMove = new List<Ability>();


	//Unit Selector
	Transform unitSelected;
	Transform unitOwned;
	[SerializeField]
	Material enemyOwnedMaterial;
	Transform unitMove;
	Transform unitAttack;


	public UnitAI unitAI = new UnitAI();
	private AI ai;
	private PlayerController playerController;

	List<GameObject> currentlyColoredTiles;
	// Use this for initialization
	void Awake () {
		ai = AI.instance;
		playerController = PlayerController.instance;
		healthBar = this.transform.Find("HealthBar");
		healthBar.gameObject.SetActive (false);
		unitAI.Unit = this;
		currentlyColoredTiles = new List<GameObject> ();
		//Get all unitSelectorObjects
		unitSelected = this.transform.FindChild("UnitSelector/UnitSelected");
		DisplayUnitSelector (false);
		unitOwned = this.transform.FindChild("UnitSelector/UnitOwned");
		unitMove = this.transform.FindChild("UnitSelector/UnitMove");
		unitAttack = this.transform.FindChild("UnitSelector/UnitAttack");
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
		ProcessMoving (true);
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

	void ProcessMoving(bool moveBool){
		moved = moveBool;
		unitMove.gameObject.SetActive (!moveBool);
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
		Attack attack = new Attack (this, tile.GetComponent<Tile> ().Unit.GetComponent<Unit> (), baseUnit.CurrentAttackDamage);
		attack = OnAttacking (attack);

		attack.Defender.OnBeingAttacked (attack);
		ProcessAttacking(true);
		OnTurnEnd ();
		TurnTowards (tile);
		//Uncolor tiles after attack
		foreach (GameObject tileGO in currentlyColoredTiles) {
			tileGO.GetComponent<Tile> ().ResetColor ();			
		}
		currentlyColoredTiles = new List<GameObject>();
	}
	void ProcessAttacking(bool attackBool){
		attacked = attackBool;
		unitAttack.gameObject.SetActive (!attackBool);
		unitMove.gameObject.SetActive (!attackBool);
	}

	Attack OnAttacking(Attack attack){
		//Apply OnAttackingAbilities
		attack = ApplyAbilities(onAttacking,attack);

		return attack;
	}

	public void OnBeingAttacked(Attack attack){
		//Apply OnBeingAttackedAbilities
		attack = ApplyAbilities(onBeingAttacked,attack);

		Damage (attack.GetFinalDamage ());
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
		healthBar.rotation = Quaternion.Euler(30,0,0);
	}
	public void ResetCurrentlyColoredTiles ()
	{
		foreach (GameObject tile in currentlyColoredTiles) {
			tile.GetComponent<Tile> ().ResetColor ();
		}
	}

	Attack ApplyAbilities(List<Ability> abilityList, Attack attack){
		foreach (Ability ability in abilityList) {
			ability.Apply(attack);
		}
		return attack;
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
		ProcessMoving (false);
		ProcessAttacking (false);
		turnEnded = false;
		//Display UnitSelector
	}
	public void OnTurnEnd(){
		turnEnded = true;
		unitMove.gameObject.SetActive (false);
		unitAttack.gameObject.SetActive (false);
		//Adjust UnitSelector
	}

	public void DisplayUnitSelector(bool display){
		unitSelected.gameObject.SetActive (display);
	}


	public void Setup(GameObject tile){
		currentTile = tile;
		baseUnit.SetupOnBattleStart ();
	}
	//PropertyStuff
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
			if (!ownedByPlayer) {
				unitOwned.GetComponent<Renderer> ().material = enemyOwnedMaterial;
			}
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
	public bool MovedLastTurn {
		get {
			return movedLastTurn;
		}
		set {
			movedLastTurn = value;
		}
	}
	public bool AttackedLastTurn {
		get {
			return attackedLastTurn;
		}
		set {
			attackedLastTurn = value;
		}
	}
}
