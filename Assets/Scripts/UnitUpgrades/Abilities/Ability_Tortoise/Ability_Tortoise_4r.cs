using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Tortoise_4r : Ability {

	/*AbilityType: OnAttack
Lone Agressor:
Attacks deal 20% additional damage, if you have no adjacent ally
	 * */
	public Ability_Tortoise_4r(){
		name = "Lone Agressor:";
		description = "Attacks deal 20% additional damage, if you have no adjacent ally";
		triggerId = (int) Trigger.OnTurnStart;
	}

	public override Attack Apply (Attack attack){		
		if (attack.Attacker.HasAdjacentAlly()) {
			attack.ModifiedDamage += attack.BaseDamage * 0.25f;
			Debug.Log ("No Adjacent ally => Lone Agressor");
		}
		return attack;
	}

}
