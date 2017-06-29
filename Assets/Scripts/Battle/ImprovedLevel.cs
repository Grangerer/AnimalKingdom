using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedLevel {
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
	int id;
	string name;
	string structure;
	BattleObjective objective;
	int numberOfPlayerUnits;
	int experienceReward;

	public ImprovedLevel(int id){
		this.id = id;

	}
}

public enum BattleObjective{
	DestroyAll,
	DestroySpecific,
	EnterArea
}