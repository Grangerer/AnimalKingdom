using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Horse_2l : Ability
{

	/*AbilityType: OnBeingAttacked
	  Hidden:
		Attacks against you have a 50% chance to miss, if you haven't attacked last turn
	 * */
	public Ability_Horse_2l ()
	{
		name = "Agitation";
	}

	public override Attack Apply (Attack attack)
	{
		if (Random.Range (1, 101) <= 20) {
			attack.AttackHit = false;
		}
		return attack;
	}

}
