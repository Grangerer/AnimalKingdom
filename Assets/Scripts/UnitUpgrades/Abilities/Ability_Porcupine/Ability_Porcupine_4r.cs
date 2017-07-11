using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Porcupine_4r : Ability {

	/*AbilityType: OnAttack
Restraining Quills:
Successful attacks reduce the targets movementspeed by 1. 
(Cannot reduce below 1)
	 * */
	public Ability_Porcupine_4r(){
		name = "Restraining Quills";
		description = "Attacks reduce the targets movementspeed by 1. \n(Cannot reduce below 1)";
		triggerId = (int) Trigger.OnAttack;
	}

	public override Attack Apply (Attack attack){
		attack.Defender.AddAbility (new Debuff_Slow(1,1));

		return attack;
	}

}
