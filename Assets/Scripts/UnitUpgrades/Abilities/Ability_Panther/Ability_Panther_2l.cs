using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Panther_2l : Ability {

	/*AbilityType: OnBeingAttacked
	  Hidden:
		Attacks against you have a 50% chance to miss, if you haven't attacked last turn
	 * */
	public Ability_Panther_2l(){
		name = "Hidden";
	}

	public override Attack Apply (Attack attack){
		if (!attack.Defender.MovedLastTurn) {
			if (Random.Range(1,101) < 50) {
				attack.AttackHit = false;
			}
		}
		return attack;
	}

}
