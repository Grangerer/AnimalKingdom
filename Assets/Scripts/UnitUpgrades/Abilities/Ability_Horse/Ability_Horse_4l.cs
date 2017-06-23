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
	public Ability_Horse_4l ()
	{
		name = "Kick";
		triggerId = (int)Trigger.OnAttack;
	}

	public override Attack Apply (Attack attack)
	{
		//Include Ability
		return attack;
	}

}
