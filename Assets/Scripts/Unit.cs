using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {


	public int movementSpeed;
	public int attackRange;
	public int damage;
	public int health;

	private bool ownedByPlayer;
	private GameObject currentTile;

	private bool moved = false;
	private bool attacked = false;
	private bool turnEnded = false;


	List<GameObject> currentlyColoredTiles = new List<GameObject>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Movement
	public void FindAllMovableTiles (Material movableMaterial)
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
		for (int i = 1; i < this.movementSpeed; i++) {
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
		foreach (GameObject tileGO in toColorTiles) {
			tileGO.GetComponent<Tile> ().Recolor (movableMaterial);
			tileGO.GetComponent<Tile> ().CurrentlyMovable = true;
		}
		currentlyColoredTiles = toColorTiles;
	}
	public void MoveToTile(GameObject tile){
		//Move
		Vector3 newPosition = new Vector3 (tile.transform.position.x, 0.75f, tile.transform.position.z);
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

		currentlyColoredTiles = null;
	}

	//Attack
	public void FindAllAttackableTiles(Material attackableMaterial){
		ResetCurrentlyColoredTiles ();

		Tile baseTile = this.CurrentTile.GetComponent<Tile> ();
		List<GameObject> toColorTiles = new List<GameObject> ();
		//Add all adjacentTiles to recolor list

		foreach (GameObject tile in baseTile.AdjacentTiles) {
			toColorTiles.Add(tile);
		}
		//add adjacent tiles of all added tiles, excluding already added tiles => repeat equal to attackrange
		for (int i = 1; i < this.attackRange; i++) {
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
			if (tileGO.GetComponent<Tile> ().Occupied && !tileGO.GetComponent<Tile> ().Unit.GetComponent<Unit> ().OwnedByPlayer) {				
				tileGO.GetComponent<Tile> ().Recolor (attackableMaterial);
				tileGO.GetComponent<Tile> ().CurrentlyAttackable = true;
			}
		}
		currentlyColoredTiles = toColorTiles;
	}
	public void AttackTile(GameObject tile){
		tile.GetComponent<Tile> ().Unit.GetComponent<Unit> ().Damage (this.damage);
		this.Moved = true;
		this.Attacked = true;
		this.TurnEnded = true;
		//Uncolor tiles after attack
		foreach (GameObject tileGO in currentlyColoredTiles) {
			tileGO.GetComponent<Tile> ().ResetColor ();			
		}
		currentlyColoredTiles = null;
	}
	public void Damage(int damage){
		this.health -= damage;
		//Do all relevant checks regarding death and abilities
		if (health <= 0) {
			Destroy (this.gameObject);
		}
	}

	public void ResetCurrentlyColoredTiles(){
		if (currentlyColoredTiles != null) {
			foreach (GameObject tile in currentlyColoredTiles) {
				tile.GetComponent<Tile> ().ResetColor ();
			}
		}
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
