using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnemies {

	int unitId; //0=Horse, 1=Bear
	int gridHeight;
	int gridWidth;

	public LevelEnemies (int enemyId,int gridWidth, int gridHeight){
		this.unitId = enemyId;
		this.gridHeight = gridHeight;
		this.gridWidth = gridWidth;
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
	public int UnitId {
		get {
			return unitId;
		}
	}
}
