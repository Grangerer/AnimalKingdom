using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Horse_6l : Ability {

	/*AbilityType: OnBeingAttacked
Pack:
You take 7.5% less damage for each adjacent ally
	 * */
	public Ability_Horse_6l(){
		name = "Pack";
		triggerId = (int) Trigger.OnBeingAttack;
	}

	public override Attack Apply (Attack attack){
		//Insert Stuff
		int amountOfAdjacentAllies = 0;
		foreach (GameObject tile in attack.Defender.CurrentTile.GetComponent<Tile>().AdjacentTiles) {
			if (tile.GetComponent<Tile>().Occupied && tile.GetComponent<Tile>().Unit!=null && tile.GetComponent<Tile>().Unit.GetComponent<Unit> ().OwnedByPlayer == attack.Attacker.OwnedByPlayer) {
				amountOfAdjacentAllies++;
			}
		}
		attack.ModifiedDamage -= attack.BaseDamage * 0.075f *amountOfAdjacentAllies;

		return attack;
	}

}
