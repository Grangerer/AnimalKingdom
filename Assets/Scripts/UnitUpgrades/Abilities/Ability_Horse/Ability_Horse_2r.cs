using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Horse_2r : Ability
{

	/*AbilityType: OnBeingAttacked
	 * Charge:
	 * Attacks deal 5% additional damage for each square you have moved this turn
	 * */
	public Ability_Horse_2r ()
	{
		name = "Charge";
	}

	public override Attack Apply (Attack attack)
	{
		//Insert stuff
		return attack;
	}

}
