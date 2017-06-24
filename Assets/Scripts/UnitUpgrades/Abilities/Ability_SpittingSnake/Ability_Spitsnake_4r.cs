using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Spitsnake_4r : Ability {

	/*AbilityType: OnAttacking
Bite:
Successful attacks against adjacent enemies deal 25% additional damage 
	 * */
	public Ability_Spitsnake_4r(){
		name = "Bite";
		triggerId = (int) Trigger.OnAttack;
	}

	public override Attack Apply (Attack attack){
		foreach (GameObject tile in attack.Defender.CurrentTile.GetComponent<Tile>().AdjacentTiles) {
			if (tile.GetComponent<Tile>().Occupied && tile.GetComponent<Tile>().Unit!=null && tile.GetComponent<Tile>().Unit.GetComponent<Unit> () == attack.Defender) {
				Debug.Log ("Apply Bite");
				attack.ModifiedDamage += attack.BaseDamage * 0.25f;
				break;
			}
		}
		return attack;
	}

}
