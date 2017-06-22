using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Panther_6r : Ability {

	/*AbilityType: OnBeingAttacked
Finisher:
Attacks deal 50% additional damage against enemies that are below 50% health
	 * */
	public Ability_Panther_6r(){
		name = "Pounce";
	}

	public override Attack Apply (Attack attack){
		if (attack.Defender.baseUnit.CurrentHealth < attack.Defender.baseUnit.health * 0.5f) {
			attack.ModifiedDamage += attack.BaseDamage * 0.5f;
		}
		return attack;
	}

}
