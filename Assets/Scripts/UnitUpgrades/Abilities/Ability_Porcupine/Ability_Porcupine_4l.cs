using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Porcupine_4l : Ability {

	/*AbilityType: OnAttack
Spiky Back:
Attackers that attack you from withins your attackrange take damage equal to 20% of your attackdamage at the end of their turn
	 * */
	public Ability_Porcupine_4l(){
		name = "Spiky Back";
		description = "Attackers that attack you from withins your attackrange take damage equal to 20% of your attackdamage at the end of their turn";
		triggerId = (int) Trigger.OnBeingAttack;
	}

	public override Attack Apply (Attack attack){
		if (attack.AttackDistance < attack.Defender.baseUnit.CurrentAttackRange) {
			attack.Defender.AddAbility (new Debuff_SpickyBack (attack.Defender.baseUnit.CurrentAttackDamage * 0.2f));
		}

		return attack;
	}

}
