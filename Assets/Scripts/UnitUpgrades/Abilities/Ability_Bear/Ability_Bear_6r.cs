using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Bear_6r : Ability {

	/*AbilityType: OnAttacking
Finisher:
Attacks deal 30% additional damage against enemies that are below 50% health
	 * */
	public Ability_Bear_6r(){
		name = "Swipe";
		description = "Attacks deal 25% damage to all adjacent enemies of the target";
		triggerId = (int) Trigger.OnAttack;
	}

	public override Attack Apply (Attack attack){
		foreach (GameObject tile in attack.Defender.CurrentTile.GetComponent<Tile>().AdjacentTiles) {
			if (tile.GetComponent<Tile>().Occupied && tile.GetComponent<Tile>().Unit!=null && tile.GetComponent<Tile>().Unit.GetComponent<Unit> ().OwnedByPlayer != attack.Attacker.OwnedByPlayer) {
				//Damage
				break;
			}
		}

		return attack;
	}

}
