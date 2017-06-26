using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {


	int gridHeight;
	int gridWidth;
	//ObstaclePositions
	HashSet<KeyValuePair<int,int>> obstaclePositions = new HashSet<KeyValuePair<int, int>>();
	//EnemyPositions + enemy
	List<LevelEnemies> enemyPositionsAndType = new List<LevelEnemies>();

	/*Improved Version:
	  Textfile containing a "grid":
	  X = empty
	  O = Obstacle
	  S = Playerspawn
	  Numbers = Id of spawned enemy

Example:

XXO4XO1
XXX3XOX
XXOXO3X
XXOXXXX
OXXXXXX
SSXXOXO
SSXXXXX
 
	 */

	public void LoadLevel(int id){
		if(id == 0){
			gridHeight = 8;
			gridWidth = 8;
			//Enemies
			enemyPositionsAndType.Add(new LevelEnemies(0,3,6));
			enemyPositionsAndType.Add(new LevelEnemies(1,7,5));
			enemyPositionsAndType.Add(new LevelEnemies(3,7,3));
			//Obstacles
			obstaclePositions.Add (new KeyValuePair<int,int>(0,2));
			obstaclePositions.Add (new KeyValuePair<int,int>(1,2));
			obstaclePositions.Add (new KeyValuePair<int,int>(2,3));
			obstaclePositions.Add (new KeyValuePair<int,int>(2,5));
			obstaclePositions.Add (new KeyValuePair<int,int>(2,6));
			obstaclePositions.Add (new KeyValuePair<int,int>(3,5));
			obstaclePositions.Add (new KeyValuePair<int,int>(4,5));
			obstaclePositions.Add (new KeyValuePair<int,int>(4,6));
			obstaclePositions.Add (new KeyValuePair<int,int>(4,0));
			obstaclePositions.Add (new KeyValuePair<int,int>(4,1));
			obstaclePositions.Add (new KeyValuePair<int,int>(5,2));
			obstaclePositions.Add (new KeyValuePair<int,int>(7,4));
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
}
