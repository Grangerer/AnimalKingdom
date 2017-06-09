using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour {

	public GameObject tile;
	public List<GameObject> obstacles;
	private float spaceBetweenTiles;

	private GameObject tileParent;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	public List<GameObject> SpawnTiles(int width, int height, ArrayList[][] obstacles = null){
		tileParent = new GameObject ("Tiles");
		spaceBetweenTiles = tile.transform.lossyScale.x + 0.2f;
		List<GameObject> tileList = new List<GameObject>();
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				Vector3 position = new Vector3 (0 + spaceBetweenTiles * i, tile.transform.position.y, 0 + spaceBetweenTiles * j);
				GameObject tmpTile = Instantiate(tile, position, Quaternion.identity);
				tmpTile.GetComponent<Tile> ().Setup (i,j);
				tmpTile.transform.parent = tileParent.transform;
				//Spawn Obstacle if this tile shoudl contain an obstacle
				SpawnObstacle(position);
				tileList.Add (tmpTile);
			}
		}
		foreach (var item in tileList) {
			item.GetComponent<Tile> ().SetAllAdjacentTiles ();
		}
		return tileList;
	}
	void SpawnObstacle(Vector3 position){
		int chosenObstacleIndex = Random.Range(0,obstacles.Count);

		position.y = obstacles [chosenObstacleIndex].transform.position.y;
		GameObject obstacle = Instantiate(obstacles[chosenObstacleIndex], position, Quaternion.identity);
	}



}
