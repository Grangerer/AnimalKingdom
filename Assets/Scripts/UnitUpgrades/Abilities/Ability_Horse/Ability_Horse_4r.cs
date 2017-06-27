using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Horse_4r : Ability {

	/*AbilityType: OnAttack
Overrun:
Attacks against enemies without adjacent allies deal 25% additional damage
	 * */
	public Ability_Horse_4r(){
		name = "Overrun";
		description = "Attacks against enemies without adjacent allies deal 25% additional damage";
		triggerId = (int) Trigger.OnAttack;
	}

	public override Attack Apply (Attack attack){
		bool noAdjacentAlly = true;
		foreach (GameObject tile in attack.Defender.CurrentTile.GetComponent<Tile>().AdjacentTiles) {
			if (tile.GetComponent<Tile>().Occupied && tile.GetComponent<Tile>().Unit!=null && tile.GetComponent<Tile>().Unit.GetComponent<Unit> ().OwnedByPlayer != attack.Attacker.OwnedByPlayer) {
				noAdjacentAlly = false;
				break;
			}
		}
		if (noAdjacentAlly) {
			attack.ModifiedDamage += attack.BaseDamage * 0.25f;
			Debug.Log ("No Adjacent ally => Overrun");
		}
		return attack;
	}

}
