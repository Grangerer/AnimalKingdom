using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Horse_2l : Ability
{

	/*AbilityType: OnBeingAttacked
Agitation:
Attacks against you have a 20% chance to miss
	 * */
	public Ability_Horse_2l ()
	{
		name = "Agitation";
		triggerId = (int) Trigger.OnBeingAttack;
	}

	public override Attack Apply (Attack attack)
	{
		if (Random.Range (1, 101) <= 20) {
			attack.AttackHit = false;
		}
		return attack;
	}

}
