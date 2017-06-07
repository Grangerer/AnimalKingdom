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

	private bool usedThisRound = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Movement
	public void FindAllMovableTiles (Material movableMaterial)
	{
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
		}
	}


	//Attack




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

	public bool UsedThisRound {
		get {
			return usedThisRound;
		}
		set {
			usedThisRound = value;
		}
	}

}
