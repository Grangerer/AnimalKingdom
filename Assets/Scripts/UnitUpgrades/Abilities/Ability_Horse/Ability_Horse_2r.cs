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
		triggerId = (int)Trigger.OnAttack;
	}

	public override Attack Apply (Attack attack)
	{
		//Insert stuff
		return attack;
	}

}
