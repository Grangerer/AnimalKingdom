using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Tortoise_6r : Ability {

	/*AbilityType: OnAttack
Patient Attacker:
Attacks deal 20% additional damage, if you haven't attacked last turn
	 * */
	public Ability_Tortoise_6r(){
		name = "Patient Attacker";
		description = "Attacks deal 20% additional damage, if you haven't attacked last turn";
		triggerId = (int) Trigger.OnAttack;
	}

	public override Attack Apply (Attack attack){		
		if (attack.Attacker.AttackedLastTurn) {
			attack.ModifiedDamage += attack.BaseDamage * 0.2f;
		}
		return attack;
	}


}
