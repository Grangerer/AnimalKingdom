using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Horse_2r : Ability
{

	/*AbilityType: OnAttack
	 * Charge:
	 * Attacks deal 5% additional damage for each square you have moved this turn
	 * */
	public Ability_Horse_2r ()
	{
		name = "Charge";
		description = "Attacks deal 5% additional damage for each square you have moved this turn";
		triggerId = (int)Trigger.OnAttack;
	}

	public override Attack Apply (Attack attack)
	{
		attack.ModifiedDamage += attack.BaseDamage * 0.05f * attack.Attacker.DistanceMoved;

		return attack;
	}

}
