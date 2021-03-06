using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Tortoise_2r : Ability
{

	/*AbilityType: OnAttack
Tearing Bite:
Attacks against enemies on full life deal 20% additional damage
	 * */
	public Ability_Tortoise_2r ()
	{
		name = "Tearing Bite";
		description = "Attacks against enemies on full life deal 20% additional damage";
		triggerId = (int)Trigger.OnAttack;
	}

	public override Attack Apply (Attack attack)
	{
		if (attack.Defender.baseUnit.CurrentHealth == attack.Defender.baseUnit.health) {
			attack.ModifiedDamage += attack.BaseDamage * 0.2f;
		}

		return attack;
	}

}
