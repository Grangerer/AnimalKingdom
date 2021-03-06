﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Spitsnake_4l : Ability {

	/*AbilityType: OnAttacking
Leech:
Successful attacks against adjacent enemies heal you for 20% of your maximum hp
	 * */
	public Ability_Spitsnake_4l(){
		name = "Leech";
		description = "Attacks against adjacent enemies heal you for 20% of your maximum hp";
		triggerId = (int) Trigger.OnAttack;
	}

	public override Attack Apply (Attack attack){
		foreach (GameObject tile in attack.Defender.CurrentTile.GetComponent<Tile>().AdjacentTiles) {
			if (tile.GetComponent<Tile>().Occupied && tile.GetComponent<Tile>().Unit!=null && tile.GetComponent<Tile>().Unit.GetComponent<Unit> () == attack.Defender) {
				Debug.Log ("Apply Leech");
				attack.Attacker.Heal (attack.Attacker.baseUnit.health * 0.2f);
				break;
			}
		}
		return attack;
	}

}
