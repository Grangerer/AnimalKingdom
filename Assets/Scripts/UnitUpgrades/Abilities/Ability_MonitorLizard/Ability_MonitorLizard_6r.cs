using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_MonitorLizard_6r : Ability {

	public Ability_MonitorLizard_6r(){
		name = "Vengeance";
		description = "Attacks deal 50% additional damage, for each adjacent ally that is below 25% health";
		triggerId = (int) Trigger.OnAttack;
	}

	public override Attack Apply (Attack attack){
		int amountOfEligibleAllies = 0;
		foreach (GameObject tile in attack.Defender.CurrentTile.GetComponent<Tile>().AdjacentTiles) {
			if (tile.GetComponent<Tile>().Occupied && tile.GetComponent<Tile>().Unit!=null && tile.GetComponent<Tile>().Unit.GetComponent<Unit> ().OwnedByPlayer == attack.Attacker.OwnedByPlayer) {
				if (tile.GetComponent<Tile> ().Unit.GetComponent<Unit> ().baseUnit.CurrentHealth / tile.GetComponent<Tile> ().Unit.GetComponent<Unit> ().baseUnit.health <= 0.25f) {
					amountOfEligibleAllies++;
				}
			}
		}
		attack.ModifiedDamage += attack.BaseDamage * amountOfEligibleAllies * 0.5f;
		return attack;
	}

}
