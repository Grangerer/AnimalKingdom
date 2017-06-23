using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff_Kick : De_Buff {
	/*
	Kick:
	Successful attacks reduce the targets movementspeed by 1. 
	(Cannot reduce below 1)
	*/
	// Use this for initialization
	public Debuff_Kick ()
	{
		name = "Kick";
		triggerId = (int)Trigger.OnTurnStart;
		duration = 1;
	}

	public override BaseUnit ApplyTurn(Unit unit){
		if (unit.baseUnit.CurrentMovementspeed > 1) {
			unit.baseUnit.CurrentMovementspeed -= 1;
		}
		duration--;
		return unit.baseUnit;
	}
}
