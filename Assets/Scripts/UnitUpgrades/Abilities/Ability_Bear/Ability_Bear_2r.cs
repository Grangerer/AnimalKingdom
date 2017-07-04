using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Bear_2r : Ability {

	/*AbilityType: OnAttacking
Sharpened Claw:
Attacks deal 25% additional damage, if you haven't attacked last turn
	 * */
	public Ability_Bear_2r(){
		name = "Taunt";
		description = "Successful attacks reduce the damage the target does against all other units by 25%";
		triggerId = (int) Trigger.OnAttack;
	}

	public override Attack Apply (Attack attack){
		//Apply a debuff that memorizes this unit and is triggered OnAttack of the targeted unit

		return attack;
	}

}
