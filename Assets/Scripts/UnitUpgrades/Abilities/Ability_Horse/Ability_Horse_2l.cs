using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Horse_2l : Ability
{

	/*AbilityType: OnBeingAttacked
Agitation:
Attacks against you deal 2.5% less damage for each square you moved last turn
	 * */
	public Ability_Horse_2l ()
	{
		name = "Agitation";
		description = "Attacks against you deal 2.5% less damage for each square you moved last turn";
		triggerId = (int) Trigger.OnBeingAttack;
	}

	public override Attack Apply (Attack attack)
	{
		attack.ModifiedDamage -= attack.BaseDamage * 0.025f * attack.Defender.DistanceMovedLastTurn;
		return attack;
	}

}
