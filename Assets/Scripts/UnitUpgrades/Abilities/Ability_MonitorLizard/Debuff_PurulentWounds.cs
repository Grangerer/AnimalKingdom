using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Debuff_PurulentWounds : De_Buff {

	public Debuff_PurulentWounds ()
	{
		name = "PurulentWounds_Debuff";
		triggerId = (int)Trigger.OnBeingAttack;
		this.duration = 1;
	}

	public override Attack Apply (Attack attack){
		attack.ModifiedDamage += attack.BaseDamage * 0.2f;

		return attack;
	}
}
