using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Panther_4l : Ability {

	/*AbilityType: OnBeingAttacked
Precise Claw:
Attacks cannot miss, if you haven't attacked last turn
	 * */
	public Ability_Panther_4l(){
		name = "Precise Claw";
	}

	public override Attack Apply (Attack attack){
		if (!attack.Attacker.AttackedLastTurn) {
			attack.CannotMiss = true;
		}
		return attack;
	}

}
