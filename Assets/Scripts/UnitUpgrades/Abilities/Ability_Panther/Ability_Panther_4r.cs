using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Panther_4r : Ability {

	/*AbilityType: OnTurnstart
Sprint:
Gain 50% increased movementspeed, if you haven't moved last turn
	 * */
	public Ability_Panther_4r(){
		name = "Sprint";
		triggerId = (int) Trigger.OnTurnStart;
	}

	public override BaseUnit ApplyTurn (Unit unit){
//		Debug.Log (name);
		if (!unit.MovedLastTurn) {
//			Debug.Log (name + " applied");
			unit.baseUnit.CurrentMovementspeed += (int) Mathf.Round(unit.baseUnit.movementSpeed * 0.5f);
		}
		return unit.baseUnit;
	}

}
