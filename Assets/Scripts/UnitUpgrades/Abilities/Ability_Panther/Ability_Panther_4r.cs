using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Panther_4r : Ability {

	/*AbilityType: OnBeingAttacked
Sprint:
Gain 50% increased movementspeed, if you haven't moved last turn
	 * */
	public Ability_Panther_4r(){
		name = "Sprint";
	}

	public override Attack Apply (Attack attack){
		if (!attack.Attacker.MovedLastTurn) {
			attack.Attacker.baseUnit.CurrentMovementspeed += attack.Attacker.baseUnit.movementSpeed * 0.5f;
		}
		return attack;
	}

}
