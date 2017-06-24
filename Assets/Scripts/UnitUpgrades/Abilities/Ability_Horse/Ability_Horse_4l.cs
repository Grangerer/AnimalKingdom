using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Horse_4l : Ability
{

	/*AbilityType: OnAttack
Kick:
Successful attacks reduce the targets movementspeed by 1. 
(Cannot reduce below 1)
	 * */
	De_Buff debuffKick = new Debuff_Kick();

	public Ability_Horse_4l ()
	{
		name = "Kick";
		triggerId = (int)Trigger.OnAttack;

	}

	public override Attack Apply (Attack attack)
	{
		attack.AppliedDebuffs.Add (debuffKick);
		Debug.Log ("Added kick" + attack.AppliedDebuffs.Count);
		return attack;
	}

}
