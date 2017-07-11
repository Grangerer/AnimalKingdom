using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Spitsnake_2l : Ability {

	/*AbilityType: OnTurnStart
Slither:
Gain 100% increased movementspeed while below 50% health
	 * */
	public Ability_Spitsnake_2l(){
		name = "Slither";
		description = "Gain 100% increased movementspeed while below 50% health";
		triggerId = (int) Trigger.OnTurnStart;
	}

	public override BaseUnit ApplyTurn (Unit unit){
		//		Debug.Log (name);
		if (unit.baseUnit.CurrentHealth<unit.baseUnit.health*0.5f) {
			//			Debug.Log (name + " applied");
			unit.baseUnit.CurrentMovementspeed += (int) Mathf.Round(unit.baseUnit.movementSpeed * 1f);
		}
		return unit.baseUnit;
	}

}
