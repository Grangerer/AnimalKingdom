using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Debuff_Slow : De_Buff {
	/*Slow:
	Successful attacks reduce the targets movementspeed by 1. 
	(Cannot reduce below 1)
	*/
	int slowAmount;
	// Use this for initialization
	public Debuff_Slow (int slowAmount, int duration)
	{
		name = "Slow_Debuff";
		triggerId = (int)Trigger.OnTurnStart;
		this.duration = duration;
		this.slowAmount = slowAmount;
	}

	public override BaseUnit ApplyTurn(Unit unit){
		if (unit.baseUnit.CurrentMovementspeed > 1) {
			unit.baseUnit.CurrentMovementspeed -= slowAmount;
		}

		duration--;

		return unit.baseUnit;
	}
}
