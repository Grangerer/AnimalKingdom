using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Spitsnake_6r : Ability {

	/*AbilityType: OnAttacking
Caustic:
Successful attacks deal additional damage equal to 15% of the targets current HP
	 * */
	public Ability_Spitsnake_6r(){
		name = "Caustic";
		description = "Attacks deal additional damage equal to 15% of the targets current HP";
		triggerId = (int) Trigger.OnAttack;
	}

	public override Attack Apply (Attack attack){
		attack.ModifiedDamage += attack.Defender.baseUnit.CurrentHealth * 0.15f;

		return attack;
	}

}
