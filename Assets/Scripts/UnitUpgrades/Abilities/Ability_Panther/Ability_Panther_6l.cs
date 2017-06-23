using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Panther_6l : Ability {

	/*AbilityType: OnAttack
Pounce:
Attacks against enemies without adjacent allies deal 50% additional damage
	 * */
	public Ability_Panther_6l(){
		name = "Pounce";
		triggerId = (int) Trigger.OnAttack;
	}

	public override Attack Apply (Attack attack){
		//Insert Stuff
		bool noAdjacentAlly = true;
		foreach (GameObject tile in attack.Defender.CurrentTile.GetComponent<Tile>().AdjacentTiles) {
			if (tile.GetComponent<Tile>().Occupied && tile.GetComponent<Tile>().Unit!=null && tile.GetComponent<Tile>().Unit.GetComponent<Unit> ().OwnedByPlayer != attack.Attacker.OwnedByPlayer) {
				noAdjacentAlly = false;
				break;
			}
		}
		if (noAdjacentAlly) {
			attack.ModifiedDamage += attack.BaseDamage * 0.4f;
			Debug.Log ("No Adjacent ally => Pounce");
		}
		return attack;
	}

}
