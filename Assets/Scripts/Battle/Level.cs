using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level {


	int gridHeight;
	int gridWidth;
	//Playunitpositions
	HashSet<KeyValuePair<int,int>> playerUnitPositions = new HashSet<KeyValuePair<int, int>>();
	//ObstaclePositions
	HashSet<KeyValuePair<int,int>> obstaclePositions = new HashSet<KeyValuePair<int, int>>();
	//EnemyPositions + enemy
	List<LevelEnemies> enemyPositionsAndType = new List<LevelEnemies>();

	public void LoadLevel(int id){
		switch (id) {
		case 0:
			gridWidth = 8;
			gridHeight = 8;
			//Playerunits
			playerUnitPositions.Add (new KeyValuePair<int, int>(0,0));
			playerUnitPositions.Add (new KeyValuePair<int, int>(0,1));
			playerUnitPositions.Add (new KeyValuePair<int, int>(1,0));
			//Enemies
			enemyPositionsAndType.Add (new LevelEnemies (0, 3, 6));
			enemyPositionsAndType.Add (new LevelEnemies (1, 7, 5));
			enemyPositionsAndType.Add (new LevelEnemies (3, 7, 3));
			//Obstacles
			obstaclePositions.Add (new KeyValuePair<int,int> (0, 2));
			obstaclePositions.Add (new KeyValuePair<int,int> (1, 2));
			obstaclePositions.Add (new KeyValuePair<int,int> (2, 3));
			obstaclePositions.Add (new KeyValuePair<int,int> (2, 5));
			obstaclePositions.Add (new KeyValuePair<int,int> (2, 6));
			obstaclePositions.Add (new KeyValuePair<int,int> (3, 5));
			obstaclePositions.Add (new KeyValuePair<int,int> (4, 5));
			obstaclePositions.Add (new KeyValuePair<int,int> (4, 6));
			obstaclePositions.Add (new KeyValuePair<int,int> (4, 0));
			obstaclePositions.Add (new KeyValuePair<int,int> (4, 1));
			obstaclePositions.Add (new KeyValuePair<int,int> (5, 2));
			obstaclePositions.Add (new KeyValuePair<int,int> (7, 4));
			break;
		case 1:
			gridWidth = 8;
			gridHeight = 14;
			//Playerunits
			playerUnitPositions.Add (new KeyValuePair<int, int>(0,0));
			playerUnitPositions.Add (new KeyValuePair<int, int>(0,1));
			playerUnitPositions.Add (new KeyValuePair<int, int>(1,0));
			//Enemies
			enemyPositionsAndType.Add (new LevelEnemies (0, 3, 6));
			enemyPositionsAndType.Add (new LevelEnemies (1, 7, 5));
			enemyPositionsAndType.Add (new LevelEnemies (3, 7, 3));
			enemyPositionsAndType.Add (new LevelEnemies (3, 7, 13));
			enemyPositionsAndType.Add (new LevelEnemies (3, 0, 13));
			//Obstacles
			obstaclePositions.Add (new KeyValuePair<int,int> (0, 2));
			obstaclePositions.Add (new KeyValuePair<int,int> (0, 3));
			obstaclePositions.Add (new KeyValuePair<int,int> (0, 4));
			obstaclePositions.Add (new KeyValuePair<int,int> (1, 3));
			obstaclePositions.Add (new KeyValuePair<int,int> (4, 4));
			obstaclePositions.Add (new KeyValuePair<int,int> (5, 6));
			obstaclePositions.Add (new KeyValuePair<int,int> (4, 5));
			obstaclePositions.Add (new KeyValuePair<int,int> (4, 6));

			obstaclePositions.Add (new KeyValuePair<int,int> (0, 12));
			obstaclePositions.Add (new KeyValuePair<int,int> (1, 12));
			obstaclePositions.Add (new KeyValuePair<int,int> (6, 13));
			obstaclePositions.Add (new KeyValuePair<int,int> (6, 12));

			obstaclePositions.Add (new KeyValuePair<int,int> (3, 8));
			obstaclePositions.Add (new KeyValuePair<int,int> (4, 8));
			obstaclePositions.Add (new KeyValuePair<int,int> (3, 9));
			obstaclePositions.Add (new KeyValuePair<int,int> (4, 9));
			obstaclePositions.Add (new KeyValuePair<int,int> (2, 9));
			obstaclePositions.Add (new KeyValuePair<int,int> (5, 9));
			break;
		default:
			break;
		
		}
	}

	//Propertystuff
	public int GridHeight {
		get {
			return gridHeight;
		}
	}

	public int GridWidth {
		get {
			return gridWidth;
		}
	}

	public HashSet<KeyValuePair<int, int>> ObstaclePositions {
		get {
			return obstaclePositions;
		}
	}

	public List<LevelEnemies> EnemyPositionsAndType {
		get {
			return enemyPositionsAndType;
		}
	}

	public HashSet<KeyValuePair<int, int>> PlayerUnitPositions {
		get {
			return playerUnitPositions;
		}
		set {
			playerUnitPositions = value;
		}
	}
}
