using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Debuff_Taunt : De_Buff {
	/*
Taunt:
Attacks reduce the damage the target does against all other units by 25%
	*/
	// Use this for initialization
	Unit tauntingUnit;

	public Debuff_Taunt (Unit tauntingUnit, int duration)
	{
		name = "Taunt_Debuff";
		triggerId = (int)Trigger.OnAttack;
		this.tauntingUnit = tauntingUnit;
		this.duration = duration;
	}

	public override Attack Apply (Attack attack){
		if(attack.Defender != tauntingUnit){
			attack.ModifiedDamage -= attack.BaseDamage * 0.25f;
		}
		return attack;
	}
}
