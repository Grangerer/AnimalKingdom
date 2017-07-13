using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Debuff_Bloodthirst : De_Buff {
	/*
Taunt:
Attacks reduce the damage the target does against all other units by 25%
	*/
	// Use this for initialization
	Unit applyingUnit;

	public Debuff_Bloodthirst (Unit applyingUnit)
	{
		name = "Bloodthirst_Debuff";
		triggerId = (int)Trigger.OnAttack;
		this.applyingUnit = applyingUnit;
	}

	public override void ApplyOnDeath (){
		applyingUnit.Heal (applyingUnit.baseUnit.health * 0.25f);
	}
}
