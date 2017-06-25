﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Spitsnake_6l : Ability {

	/*AbilityType: OnAttack
Camouflage:
Ranged Attacks against you have a 12% chance to miss for every adjacent obstacle
	 * */
	public Ability_Spitsnake_6l(){
		name = "Camouflage";
		triggerId = (int) Trigger.OnAttack;
	}

	public override Attack Apply (Attack attack){
		//Insert Stuff
		bool attackerIsAdjacent = false;
		int amountOfAdjacentObstacles = 0;
		foreach (GameObject tile in attack.Defender.CurrentTile.GetComponent<Tile>().AdjacentTiles) {
			if (tile.GetComponent<Tile> ().Occupied && tile.GetComponent<Tile> ().Unit == null) { 
				amountOfAdjacentObstacles++;
			} else if (tile.GetComponent<Tile> ().Occupied && tile.GetComponent<Tile> ().Unit != null && tile.GetComponent<Tile> ().Unit.GetComponent<Unit> () == attack.Attacker) {
				attackerIsAdjacent = true;
				break;
			}
		}

		if (!attackerIsAdjacent) {
			if (Random.Range (1, 101) <= amountOfAdjacentObstacles * 12) {
				Debug.Log ("Ranged attack would miss: Camouflage");
				attack.AttackHit = false;
			}
		}

		return attack;
	}

}