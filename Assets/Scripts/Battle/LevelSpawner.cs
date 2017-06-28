using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour {

	private AI ai;

	public GameObject tile;
	private float spaceBetweenTiles;

	private GameObject tileParent;
	// Use this for initialization
	void Start () {
		ai = AI.instance;

		tileParent = new GameObject ("Tiles");
	}

	public List<GameObject> SpawnLevel(Level level){
		List<GameObject> tileList = new List<GameObject>();

		tileList = SpawnTiles (level);

		return tileList;
	}

	private List<GameObject> SpawnTiles(Level level){
		int width = level.GridWidth;
		int height = level.GridHeight;
		HashSet<KeyValuePair<int,int>> obstacles = level.ObstaclePositions; 
		List<LevelEnemies> levelEnemies = level.EnemyPositionsAndType;

		spaceBetweenTiles = tile.transform.lossyScale.x + 0.2f;
		List<GameObject> tileList = new List<GameObject>();
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				Vector3 position = new Vector3 (0 + spaceBetweenTiles * i, tile.transform.position.y, 0 + spaceBetweenTiles * j);
				GameObject tmpTile = Instantiate(tile, position, Quaternion.identity);
				tmpTile.GetComponent<Tile> ().Setup (i,j);
				tmpTile.transform.parent = tileParent.transform;
				//Spawn Enemy if this tile should contain an enemy
				foreach (LevelEnemies enemy in levelEnemies) {
					if (enemy.GridWidth == i && enemy.GridHeight == j) {
						SpawnEnemy (tmpTile, enemy.UnitId);
					}
				}
				//Spawn Obstacle if this tile should contain an obstacle
				if (obstacles.Contains(new KeyValuePair<int, int>(i,j))){
					tmpTile.GetComponent<Tile> ().Occupied = true;
					SpawnObstacle (position, tmpTile);
				}
				tileList.Add (tmpTile);
			}
		}
		foreach (var item in tileList) {
			item.GetComponent<Tile> ().SetAllAdjacentTiles ();
		}
		return tileList;
	}
	void SpawnObstacle(Vector3 position, GameObject tile){
		int chosenObstacleIndex = Random.Range(0, Data.currentData.obstacles.Count);

		position.y = Data.currentData.obstacles [chosenObstacleIndex].transform.position.y;
		GameObject obstacle = Instantiate(Data.currentData.obstacles[chosenObstacleIndex], position, Quaternion.identity);
		obstacle.transform.parent = tile.transform;
	}
	void SpawnEnemy(GameObject spawnOnTile, int unitID){
		Vector3 position = new Vector3 (spawnOnTile.transform.position.x, Data.currentData.units[unitID].transform.position.y, spawnOnTile.transform.position.z);
		GameObject tmpUnit = Instantiate (Data.currentData.units[unitID], position, Quaternion.identity);
		tmpUnit.GetComponent<Unit> ().Setup (spawnOnTile);
		tmpUnit.GetComponent<Unit> ().OwnedByPlayer = false;
		spawnOnTile.GetComponent<Tile> ().ReferenceUnit(tmpUnit);
		ai.AddUnit (tmpUnit);
	}


	public void SpawnLevelFromFile(int levelID){
		
	}


}
