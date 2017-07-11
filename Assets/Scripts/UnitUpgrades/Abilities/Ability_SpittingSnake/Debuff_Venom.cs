using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Debuff_Venom : De_Buff {
	/*
Venom:
Successful attacks deal 2 additional damage at the end of their next turn
	*/
	// Use this for initialization
	public Debuff_Venom ()
	{
		name = "Venom_Debuff";
		triggerId = (int)Trigger.OnTurnEnd;
		duration = 1;
	}

	public override BaseUnit ApplyTurn(Unit unit){
		Debug.Log ("This could be a gamebreaking bug @Venom_Debuff");
		unit.Damage (2f);
		duration--;

		return unit.baseUnit;
	}
}
