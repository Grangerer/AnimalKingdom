using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Debuff_Immobilize : De_Buff {

	// Use this for initialization
	public Debuff_Immobilize ( int duration)
	{
		name = "Immobilize_Debuff";
		triggerId = (int)Trigger.OnTurnStart;
		this.duration = duration;
	}

	public override BaseUnit ApplyTurn(Unit unit){
		unit.baseUnit.Immobilize ();

		duration--;

		return unit.baseUnit;
	}
}
