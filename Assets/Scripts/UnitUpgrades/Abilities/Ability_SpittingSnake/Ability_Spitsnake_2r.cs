using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Spitsnake_2r : Ability {

	/*AbilityType: OnAttacking
Venom:
Successful attacks deal 2 additional damage at the end of their next turn
	 * */
	public Ability_Spitsnake_2r(){
		name = "Venom";
		description = "Attacks deal 2 additional damage at the end of the targets next turn";
		triggerId = (int) Trigger.OnAttack;
	}

	public override Attack Apply (Attack attack){
		Debug.Log ("Applying Venom");
		attack.Defender.AddAbility (new Debuff_Venom ());
		return attack;
	}

}
