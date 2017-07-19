using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level {


	int gridHeight;
	int gridWidth;
	int levelID;
	//Playunitpositions
	HashSet<KeyValuePair<int,int>> playerUnitPositions = new HashSet<KeyValuePair<int, int>>();
	//ObstaclePositions
	HashSet<KeyValuePair<int,int>> obstaclePositions = new HashSet<KeyValuePair<int, int>>();
	//EnemyPositions + enemy
	List<LevelEnemies> enemyPositionsAndType = new List<LevelEnemies>();

	public void LoadLevel(int id){
		//Playunitpositions
		playerUnitPositions = new HashSet<KeyValuePair<int, int>>();
		//ObstaclePositions
		obstaclePositions = new HashSet<KeyValuePair<int, int>>();
		//EnemyPositions + enemy
		enemyPositionsAndType = new List<LevelEnemies>();

		switch (id) {
		case 0:
			SetLevel1 ();
			break;
		case 1:
			SetLevel2 ();
			break;
		case 2:
			SetLevel3 ();
			break;
		case 3:
			SetLevel4 ();
			break;
		default:
			Debug.Log ("Error. Selected Level doesn't exist");
			break;
		
		}
	}

	void SetLevel1(){
		levelID = 0;
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
	}
	void SetLevel2(){
		levelID = 1;
		gridWidth = 8;
		gridHeight = 10;
		//Playerunits
		playerUnitPositions.Add (new KeyValuePair<int, int>(1,1));
		playerUnitPositions.Add (new KeyValuePair<int, int>(0,1));
		playerUnitPositions.Add (new KeyValuePair<int, int>(1,0));
		//Enemies
		enemyPositionsAndType.Add (new LevelEnemies (1, 6, 9));
		enemyPositionsAndType.Add (new LevelEnemies (1, 7, 8));
		enemyPositionsAndType.Add (new LevelEnemies (5, 0, 6));
		enemyPositionsAndType.Add (new LevelEnemies (3, 6, 3));
		enemyPositionsAndType.Add (new LevelEnemies (3, 5, 2));
		enemyPositionsAndType.Add (new LevelEnemies (3, 6, 2));
		enemyPositionsAndType.Add (new LevelEnemies (0, 4, 4));
		//Obstacles
		obstaclePositions.Add (new KeyValuePair<int,int> (0, 0));
		obstaclePositions.Add (new KeyValuePair<int,int> (2, 3));
		obstaclePositions.Add (new KeyValuePair<int,int> (2, 4));
		obstaclePositions.Add (new KeyValuePair<int,int> (5, 3));
		obstaclePositions.Add (new KeyValuePair<int,int> (6, 4));
		obstaclePositions.Add (new KeyValuePair<int,int> (5, 6));
		obstaclePositions.Add (new KeyValuePair<int,int> (4, 1));
		obstaclePositions.Add (new KeyValuePair<int,int> (4, 2));

		obstaclePositions.Add (new KeyValuePair<int,int> (3, 8));
		obstaclePositions.Add (new KeyValuePair<int,int> (4, 8));
		obstaclePositions.Add (new KeyValuePair<int,int> (3, 9));
		obstaclePositions.Add (new KeyValuePair<int,int> (4, 9));
		obstaclePositions.Add (new KeyValuePair<int,int> (2, 9));
		obstaclePositions.Add (new KeyValuePair<int,int> (5, 9));
	}
	void SetLevel3(){
		levelID = 2;
		gridWidth = 11;
		gridHeight = 11;
		//Playerunits
		playerUnitPositions.Add (new KeyValuePair<int, int>(5,4));
		playerUnitPositions.Add (new KeyValuePair<int, int>(6,5));
		playerUnitPositions.Add (new KeyValuePair<int, int>(5,6));
		playerUnitPositions.Add (new KeyValuePair<int, int>(4,5));
		//Enemies
		enemyPositionsAndType.Add (new LevelEnemies (0, 0, 0));
		enemyPositionsAndType.Add (new LevelEnemies (1, 10, 10));
		enemyPositionsAndType.Add (new LevelEnemies (3, 0, 10));
		enemyPositionsAndType.Add (new LevelEnemies (3, 10, 0));
		enemyPositionsAndType.Add (new LevelEnemies (3, 5, 0));
		enemyPositionsAndType.Add (new LevelEnemies (3, 0, 5));
		enemyPositionsAndType.Add (new LevelEnemies (3, 5, 10));
		enemyPositionsAndType.Add (new LevelEnemies (3, 10, 5));
		//Obstacles
		obstaclePositions.Add (new KeyValuePair<int,int> (1, 1));
		obstaclePositions.Add (new KeyValuePair<int,int> (9, 1));
		obstaclePositions.Add (new KeyValuePair<int,int> (9, 9));
		obstaclePositions.Add (new KeyValuePair<int,int> (1, 9));

		obstaclePositions.Add (new KeyValuePair<int,int> (1, 5));
		obstaclePositions.Add (new KeyValuePair<int,int> (2, 5));
		obstaclePositions.Add (new KeyValuePair<int,int> (3, 5));
		obstaclePositions.Add (new KeyValuePair<int,int> (4, 6));

		obstaclePositions.Add (new KeyValuePair<int,int> (4, 9));

		obstaclePositions.Add (new KeyValuePair<int,int> (5, 2));
		obstaclePositions.Add (new KeyValuePair<int,int> (5, 3));
		obstaclePositions.Add (new KeyValuePair<int,int> (6, 4));
		obstaclePositions.Add (new KeyValuePair<int,int> (7, 5));
	}
	void SetLevel4(){
		levelID = 2;
		gridWidth = 5;
		gridHeight = 5;
		//Playerunits
		playerUnitPositions.Add (new KeyValuePair<int, int>(4,4));
		playerUnitPositions.Add (new KeyValuePair<int, int>(4,3));
		playerUnitPositions.Add (new KeyValuePair<int, int>(4,2));
		playerUnitPositions.Add (new KeyValuePair<int, int>(4,1));
		//Enemies
		enemyPositionsAndType.Add (new LevelEnemies (0, 0, 0));
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

	public int LevelID {
		get {
			return levelID;
		}
	}
}
