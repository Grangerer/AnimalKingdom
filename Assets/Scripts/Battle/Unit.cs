using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	public BaseUnit baseUnit;

	//Status Ailments and remembering last turn stuff
	bool movedLastTurn = false;
	int distanceMovedLastTurn = 0;
	int distanceMoved = 0;
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


	private UnitAI unitAI = new UnitAI();
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
		//Debug.Log ("MoveDistance: " + GetMoveDistance(tile.GetComponent<Tile>(),currentTile.GetComponent<Tile>()));
		distanceMoved = GetMoveDistance (tile.GetComponent<Tile> (), currentTile.GetComponent<Tile> ());
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

	public int GetMoveDistance(Tile a, Tile b){
		int distance = 0;
		List<Tile> tilesToCheckA = new List<Tile> ();
		List<Tile> tilesToCheckB = new List<Tile> ();

		//increase Distance
		//Add all adjacent tiles from a
		//increase Distance
		//Add all adjacent tiles from b
		if (a.Equals (b)) {
			return distance;
		}
		distance++;
		foreach (GameObject tile in a.AdjacentTiles) {
			if (tile.GetComponent<Tile> ().Equals (b)) {
				return distance = 1;
			} else if(!tile.GetComponent<Tile>().Occupied){
				tilesToCheckA.Add(tile.GetComponent<Tile>());
			}
		}
		distance++;
		foreach (GameObject tile in b.AdjacentTiles) {
			if (tilesToCheckA.Contains(tile.GetComponent<Tile>())) {
				return distance;
			} else if(!tile.GetComponent<Tile>().Occupied){
				tilesToCheckB.Add(tile.GetComponent<Tile>());
			}
		}

		List<Tile> tmpList = new List<Tile> ();
		List<Tile> tilesA = tilesToCheckA;
		List<Tile> tilesB = tilesToCheckB;
		while(true) {
			//A
			distance++;
			tmpList = new List<Tile> ();
			foreach (Tile tile in tilesToCheckA) {
				foreach (GameObject tileGO in tile.AdjacentTiles) {
					if (tileGO.GetComponent<Tile> ().Equals (b) || tilesB.Contains(tileGO.GetComponent<Tile>())) {
						return distance;
					} else {
						if (!tileGO.GetComponent<Tile> ().Occupied && !tilesA.Contains (tileGO.GetComponent<Tile> ()) && !tmpList.Contains (tileGO.GetComponent<Tile> ())) {
							tmpList.Add (tileGO.GetComponent<Tile> ());
						}
					}
				}
			}
			tilesToCheckA = tmpList;
			tilesA.AddRange(tmpList);
			//B
			distance++;
			tmpList = new List<Tile> ();
			foreach (Tile tile in tilesToCheckB) {
				foreach (GameObject tileGO in tile.AdjacentTiles) {
					if (tileGO.GetComponent<Tile> ().Equals (a) || tilesA.Contains(tileGO.GetComponent<Tile>())) {
						return distance;
					} else {
						if (!tileGO.GetComponent<Tile> ().Occupied && !tilesB.Contains (tileGO.GetComponent<Tile> ()) && !tmpList.Contains (tileGO.GetComponent<Tile> ())) {
							tmpList.Add (tileGO.GetComponent<Tile> ());
						}
					}
				}
			}
			tilesToCheckB = tmpList;
			tilesB.AddRange(tmpList);
		}
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
			//targets
			if (tileGO.GetComponent<Tile> ().Unit != null && !tileGO.GetComponent<Tile> ().Unit.GetComponent<Unit> ().OwnedByPlayer) {				
				tileGO.GetComponent<Tile> ().Recolor (attackableMaterial);
				tileGO.GetComponent<Tile> ().CurrentlyAttackable = true;
				foundAttackableTile = true;
			}//attackrange
			else if (!tileGO.GetComponent<Tile> ().Occupied){
				tileGO.GetComponent<Tile> ().Recolor (attackableMaterial);
			}
		}
		currentlyColoredTiles = toColorTiles;
		return foundAttackableTile;
	}

	public bool HasEnemiesWithinAttackrange(){
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
				foundAttackableTile = true;
			}
		}
		return foundAttackableTile;
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
		attack = ApplyAttackAbilities(onAttacking,attack);
		return attack;
	}

	public void OnBeingAttacked(Attack attack){
		//Apply OnBeingAttackedAbilities
		attack = ApplyAttackAbilities(onBeingAttacked,attack);
		Damage (attack);
	}

	public void Damage(Attack attack){
		int finalDamage;
		//Miss
		if (!attack.AttackHit && !attack.CannotMiss) {
			//Nothing happens
			//Will display the dodge in the combat log
			Debug.Log("Attack on me "+this.name+" missed!");
		} else {
			finalDamage = attack.GetFinalDamage ();
			//Damage
			baseUnit.CurrentHealth -= finalDamage;
			//Apply debuffs
			foreach(De_Buff debuff in attack.AppliedDebuffs ){
				AddAbility (debuff);
				Debug.Log ("Added " + debuff.Name);
			}
			//Adjust Healthbar
			healthBar.gameObject.SetActive(true);
			float xScale = (float)baseUnit.CurrentHealth/ (float)baseUnit.health;
			healthBar.Find("Health").localScale = new Vector3(xScale,1,1);
		}
		//Do all relevant checks regarding death and abilities
		if (baseUnit.CurrentHealth <= 0) {
			DestroyUnit ();
		}
	}
	public void Damage(float damage){
		int finalDamage;
			finalDamage = Mathf.RoundToInt(damage);
			//Damage
			baseUnit.CurrentHealth -= finalDamage;
			//Adjust Healthbar
			healthBar.gameObject.SetActive(true);
			float xScale = (float)baseUnit.CurrentHealth/ (float)baseUnit.health;
			healthBar.Find("Health").localScale = new Vector3(xScale,1,1);
		//Do all relevant checks regarding death and abilities
		if (baseUnit.CurrentHealth <= 0) {
			DestroyUnit ();
		}
	}

	public void DebuffDamage(int damage){
		//Damage
		baseUnit.CurrentHealth -= damage;
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
	public void AddAbility(Ability ability){
		if (ability.TriggerId == (int) Trigger.OnTurnStart) {
			onTurnStart.Add (ability);
		} else if (ability.TriggerId == (int) Trigger.OnTurnEnd) {
			onTurnEnd.Add (ability);
		} else if (ability.TriggerId == (int) Trigger.OnMove) {
			onMove.Add (ability);
		} else if (ability.TriggerId == (int) Trigger.OnAttack) {
			onAttacking.Add (ability);
		} else if (ability.TriggerId == (int) Trigger.OnBeingAttack) {
			onBeingAttacked.Add (ability);
		} else {
			Debug.Log ("Ability has no triggerID! Fix!");
		}
			
	}

	void CheckAllDeBuffs(){
		onTurnStart = RemoveExpiredDeBuffs (onTurnStart);
		onTurnEnd = RemoveExpiredDeBuffs (onTurnEnd);
		onMove = RemoveExpiredDeBuffs (onMove);
		onAttacking = RemoveExpiredDeBuffs (onAttacking);
		onBeingAttacked = RemoveExpiredDeBuffs (onBeingAttacked);
	}

	List<Ability> RemoveExpiredDeBuffs(List<Ability> deBuffList){
		List<Ability> tmpList = new List<Ability> ();

		foreach (Ability ability in deBuffList) {
			if (ability is De_Buff) {
				if (((De_Buff)ability).Duration > 0) {
					tmpList.Add (ability);
				}	
			} else {
				tmpList.Add (ability);
			}			
		}
		return tmpList;
	}

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

	Attack ApplyAttackAbilities(List<Ability> abilityList, Attack attack){
		foreach (Ability ability in abilityList) {
			ability.Apply(attack);
		}
		return attack;
	}
	void ApplyTurnAbilities(List<Ability> abilityList){
		foreach (Ability ability in abilityList) {
			this.baseUnit = ability.ApplyTurn(this);
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
		distanceMovedLastTurn = distanceMoved;
		distanceMoved = 0;
		attackedLastTurn = attacked;
		ProcessMoving (false);
		ProcessAttacking (false);
		turnEnded = false;
		//Temporay: Reset stats until a debuff/buff system is implemented
		baseUnit.ResetStats();

		ApplyTurnAbilities (onTurnStart);
	}
	public void OnTurnEnd(){
		ResetCurrentlyColoredTiles ();
		turnEnded = true;
		unitMove.gameObject.SetActive (false);
		unitAttack.gameObject.SetActive (false);
		ApplyTurnAbilities (onTurnEnd);
		//Check all buffs and debuffs and remove them if they have no duration left
		CheckAllDeBuffs();
	}

	public void DisplayUnitSelector(bool display){
		unitSelected.gameObject.SetActive (display);
	}


	public void Setup(GameObject tile){
		currentTile = tile;
		baseUnit.SetupOnBattleStart ();
	}

	//Checks
	public bool HasAdjacentAlly(){
		foreach (GameObject tile in currentTile.GetComponent<Tile>().AdjacentTiles) {
			if (tile.GetComponent<Tile>().Occupied && tile.GetComponent<Tile>().Unit!=null && tile.GetComponent<Tile>().Unit.GetComponent<Unit> ().OwnedByPlayer == this.OwnedByPlayer) {
				return true;
			}
		}
		return false;
	}
	public bool HasAdjacentEnemy(){
		foreach (GameObject tile in currentTile.GetComponent<Tile>().AdjacentTiles) {
			if (tile.GetComponent<Tile>().Occupied && tile.GetComponent<Tile>().Unit!=null && tile.GetComponent<Tile>().Unit.GetComponent<Unit> ().OwnedByPlayer != this.OwnedByPlayer) {
				return true;
			}
		}
		return false;
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
	public int DistanceMovedLastTurn {
		get {
			return distanceMovedLastTurn;
		}
		set {
			distanceMovedLastTurn = value;
		}
	}
	public int DistanceMoved {
		get {
			return distanceMoved;
		}
		set {
			distanceMoved = value;
		}
	}
	public UnitAI UnitAI {
		get {
			return unitAI;
		}
	}
}
