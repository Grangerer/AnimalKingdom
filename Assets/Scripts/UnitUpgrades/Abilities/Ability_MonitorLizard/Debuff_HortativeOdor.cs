using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Debuff_HortativeOdor : De_Buff {

	public Debuff_HortativeOdor ()
	{
		name = "HortativeOdor_Debuff";
		triggerId = (int)Trigger.OnAttack;
		this.duration = 1;
	}

	public override Attack Apply (Attack attack){
		attack.ModifiedDamage += attack.BaseDamage * 0.2f;

		return attack;
	}
}
