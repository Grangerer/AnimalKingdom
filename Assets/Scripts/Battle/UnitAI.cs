using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAI : MonoBehaviour {


	private Unit unit;
	private List<Unit> attackableUnits = new List<Unit>();
	private Unit target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeTurn(){
		//Find all possible targets
		attackableUnits = FindAllPossibleTargets ();
		if (attackableUnits.Count != 0) {
			//Choose Target
			target = ChooseTarget (attackableUnits);
			//Move
			FindMoveTarget();
			//Attack target;
			unit.AttackTile(target.CurrentTile);
			//target.Damage(unit.damage);
		}//Move towards closest enemy
		else {
			Debug.Log ("No Enemy Found!");
			//Move to a free adjacent square, if possible
			MoveToRandomAdjacentTile();
		}
	}
	//Enemy Found
	//Find all possible targets
	List<Unit> FindAllPossibleTargets(){
		List<Tile> movableTiles = FindAllMovableTiles();
		return FindAllAttackableTargets (movableTiles);
	}
	List<Tile> FindAllMovableTiles(){
		List<Tile> movableTiles = new List<Tile>();
		movableTiles.Add (unit.CurrentTile.GetComponent<Tile> ());
		//Add adjacent tiles
		foreach (GameObject tile in unit.CurrentTile.GetComponent<Tile>().AdjacentTiles) {
			if(!tile.GetComponent<Tile>().Occupied){
				movableTiles.Add(tile.GetComponent<Tile>());
			}
		}
		//add adjacent tiles of all added tiles, excluding already added tiles => repeat equal to movementspeed
		for (int i = 1; i < unit.baseUnit.movementSpeed; i++) {
			List<Tile> tmpTiles = new List<Tile> ();
			foreach (Tile tile in movableTiles) {
				foreach (GameObject checkTile in tile.GetComponent<Tile>().AdjacentTiles) {
					if (!checkTile.GetComponent<Tile> ().Occupied && checkTile.name != unit.CurrentTile.name) {
						tmpTiles.Add (checkTile.GetComponent<Tile>());
					}
				}
			}
			foreach (Tile tile in tmpTiles) {
				if (!movableTiles.Exists (t => t.name == tile.name)) {
					movableTiles.Add (tile);
				}							
			}
		}
		return movableTiles;
	}
	List<Unit> FindAllAttackableTargets(List<Tile> movableTiles){
		List<Unit> attackableTargets = new List<Unit>();
		//Go through each tile and find any attackable targets within attackrange
		foreach (Tile attackCheckTile in movableTiles) {
			List<Tile> attackableTiles = new List<Tile> ();
			List<Tile> tmpTiles = new List<Tile> ();
			//add adjacent tiles
			foreach (GameObject tile in attackCheckTile.AdjacentTiles) {
					tmpTiles.Add(tile.GetComponent<Tile>());
			}
			//go through each adjacent tiles of tile within attackrange
			for (int i = 1; i <= unit.baseUnit.CurrentAttackRange; i++) {
				List<Tile> tmpSecondaryTiles = new List<Tile> ();				
				foreach (Tile tile in tmpTiles) {
					foreach (GameObject checkTile in tile.AdjacentTiles) {
						if (!tmpSecondaryTiles.Exists (t => t.name == tile.name)) {
							tmpSecondaryTiles.Add (checkTile.GetComponent<Tile>());
						}
					}
				}

				foreach (Tile tile in tmpTiles) {
					if (!attackableTiles.Exists (t => t.name == tile.name)) {
						attackableTiles.Add (tile);
					}
				}
				tmpTiles = new List<Tile> ();
				foreach (Tile tile in tmpSecondaryTiles) {
					tmpTiles.Add(tile);
				}
			}

			foreach (Tile tile in attackableTiles) {
				//Check if tile contains a unit owned by player
				if (tile.Occupied && tile.Unit!= null && tile.Unit.GetComponent<Unit> ().OwnedByPlayer) {
					if (!attackableTargets.Exists (t => t.name == tile.gameObject.name)) {
						attackableTargets.Add (tile.Unit.GetComponent<Unit>());
					}
				}
			}
		}
		return attackableTargets;
	}
	//Choose Target
	Unit ChooseTarget(List<Unit> possibleTargets){
		Unit chosenTarget = possibleTargets[0];
		foreach (Unit unit in possibleTargets) {
			if (unit.baseUnit.CurrentHealth < chosenTarget.baseUnit.CurrentHealth) {
				chosenTarget = unit;
			}
		}
		return chosenTarget;
	}
	//Move
	//Move to the tile with the most adjacent obstacles within attackrange and attack
	void FindMoveTarget(){
		//1. Find all tiles around target, that are within attackrange of this unit
		List<Tile> attackTargetTiles = FindTilesWithinAttackrangeOfTarget();
		//2. Find all tiles around this unit, that are within moverange of this unit
		List<Tile> moveableTiles = FindAllMovableTiles();
		//3. Find intersection between 1. and 2.
		List<Tile> possibleFinalTiles = FindIntersection(attackTargetTiles, moveableTiles);
		//4. Find Tile within 3. with most obstacles/allies adjacent
		Tile finalTile = FindOptimalMoveTile(possibleFinalTiles);
		//5. Move to 4.
		if (finalTile != null) {
			unit.MoveToTile (finalTile.gameObject);
		}
	}
	//1.
	List<Tile> FindTilesWithinAttackrangeOfTarget(){
		Tile baseTile = target.CurrentTile.GetComponent<Tile> ();

		List<Tile> attackTiles = new List<Tile> ();
		List<Tile> possibleAttackTiles = new List<Tile> ();

		foreach (GameObject tile in baseTile.AdjacentTiles) {
			possibleAttackTiles.Add (tile.GetComponent<Tile> ());
		}
		//add adjacent tiles of all added tiles, excluding already added tiles => repeat equal to attackrange
		for (int i = 1; i < unit.baseUnit.attackRange; i++) {
			List<Tile> tmpTiles = new List<Tile> ();
			foreach (Tile tile in possibleAttackTiles) {
				foreach (GameObject checkTile in tile.AdjacentTiles) {
					tmpTiles.Add (checkTile.GetComponent<Tile>());
				}
			}
			foreach (Tile tile in tmpTiles) {
				if (!possibleAttackTiles.Exists (t => t.name == tile.name)) {
					possibleAttackTiles.Add (tile);
				}
			}							
		}

		foreach (Tile tile in possibleAttackTiles) {
			if (!tile.Occupied) {	
				attackTiles.Add (tile);
			}else if (tile.Occupied && tile.Unit != null) {
				attackTiles.Add (tile);
			}
		}
		return attackTiles;
	}
	//2.
	List<Tile> FindMovableTiles(){
		Tile baseTile = unit.CurrentTile.GetComponent<Tile> ();
		List<Tile> movableTiles = new List<Tile> ();
		//Add all adjacentTiles to recolor list

		foreach (GameObject tile in baseTile.AdjacentTiles) {
			if(!tile.GetComponent<Tile>().Occupied){
				movableTiles.Add(tile.GetComponent<Tile>());
			}
		}
		//add adjacent tiles of all added tiles, excluding already added tiles => repeat equal to movementspeed
		for (int i = 1; i < unit.baseUnit.CurrentMovementspeed; i++) {
			List<GameObject> tmpTiles = new List<GameObject> ();
			foreach (Tile tile in movableTiles) {
				foreach (GameObject checkTile in tile.AdjacentTiles) {
					if (!checkTile.GetComponent<Tile> ().Occupied && checkTile.name != baseTile.name) {
						tmpTiles.Add (checkTile);
					}
				}
			}
			foreach (GameObject tile in tmpTiles) {
				if (!movableTiles.Exists (t => t.name == tile.name)) {
					movableTiles.Add (tile.GetComponent<Tile>());
				}
			}							
		}

		return movableTiles;
	}
	//3.
	List<Tile> FindIntersection(List<Tile> list1, List<Tile> list2){
		List<Tile> intersection = new List<Tile> ();
		foreach (Tile tile in list1) {
			if (list2.Exists (t => t.name == tile.name)) {
				intersection.Add (tile);
			}
		}
		return intersection;
	}
  	//4.
	Tile FindOptimalMoveTile(List<Tile> tileOptions){
		Tile finalTile = null;
		float currentHighestScore = -10f;
		foreach (Tile possibleTile in tileOptions) {
			float adjacentScore = 0f; //Add 1 for each adjacent Obstacle, Add 1.1 for each adjacent ally, substract 1 for each adjacent enemy
			foreach (GameObject adjacentTiles in possibleTile.AdjacentTiles) {
				if (adjacentTiles.GetComponent<Tile> ().Occupied) {
					if (adjacentTiles.GetComponent<Tile> ().Unit != null && !adjacentTiles.GetComponent<Tile> ().Unit.GetComponent<Unit> ().OwnedByPlayer) {
						adjacentScore += 1.1f;
					} else if (adjacentTiles.GetComponent<Tile> ().Unit != null) {
						adjacentScore -= 1;
					} else {
						adjacentScore += 1;
					}
				}
			}
			if (adjacentScore > currentHighestScore) {
				currentHighestScore = adjacentScore;
				finalTile = possibleTile;
			}
		}
		return finalTile;
	}

	//No Enemy found
	void MoveToRandomAdjacentTile(){
		List<Tile> possibleTiles = new List<Tile> ();
		foreach (GameObject tile in unit.CurrentTile.GetComponent<Tile>().AdjacentTiles) {
			if(!tile.GetComponent<Tile>().Occupied){
				possibleTiles.Add(tile.GetComponent<Tile>());
			}
		}
		if (possibleTiles.Count != 0) {
			unit.MoveToTile (possibleTiles [(int)(Random.value * possibleTiles.Count)].gameObject);
		}
	}


	//Propertystuff
	public Unit Unit {
		get {
			return unit;
		}
		set {
			unit = value;
		}
	}
}
