using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour {

	public GameObject tile;
	private float spaceBetweenTiles;

	private GameObject tileParent;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	public List<GameObject> SpawnTiles(int width, int height){
		tileParent = new GameObject ("Tiles");
		spaceBetweenTiles = tile.transform.lossyScale.x + 0.2f;
		List<GameObject> tileList = new List<GameObject>();
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				GameObject tmpTile = Instantiate(tile, new Vector3(0 + spaceBetweenTiles*i,0,0 + spaceBetweenTiles*j),Quaternion.identity);
				tmpTile.GetComponent<Tile> ().Setup (i,j);
				tmpTile.transform.parent = tileParent.transform;
				tileList.Add (tmpTile);
			}
		}
		foreach (var item in tileList) {
			item.GetComponent<Tile> ().SetAllAdjacentTiles ();
		}
		return tileList;
	}
}
