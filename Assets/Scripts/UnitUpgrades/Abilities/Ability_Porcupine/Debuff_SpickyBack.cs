using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Debuff_SpickyBack : De_Buff {
	/*
Spiky Back:
Attackers that attack you from withins your attackrange take damage equal to 20% of your attackdamage
	*/

	float damage;
	// Use this for initialization
	public Debuff_SpickyBack (float damage)
	{
		name = "SpikyBack_Debuff";
		triggerId = (int)Trigger.OnTurnEnd;
		duration = 1;
		this.damage = damage;
	}

	public override BaseUnit ApplyTurn(Unit unit){
		unit.Damage (damage);
		duration--;

		return unit.baseUnit;
	}
}
