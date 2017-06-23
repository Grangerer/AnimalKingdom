using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Panther_2r : Ability {

	/*AbilityType: OnAttacking
Sharpened Claw:
Attacks deal 25% additional damage, if you haven't attacked last turn
	 * */
	public Ability_Panther_2r(){
		name = "Sharpened Claw";
		triggerId = (int) Trigger.OnAttack;
	}

	public override Attack Apply (Attack attack){
		if (!attack.Attacker.AttackedLastTurn) {
			attack.ModifiedDamage += attack.BaseDamage * 0.25f;
		}
		return attack;
	}

}
