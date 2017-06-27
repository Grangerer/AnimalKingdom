using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Porcupine_6r : Ability {

	/*AbilityType: OnTurnStart
Disengage:
Gain +1 movementspeed while adjacent to an enemy
	 * */
	public Ability_Porcupine_6r(){
		name = "Disengage";
		description = "Gain +1 movementspeed while adjacent to an enemy";
		triggerId = (int) Trigger.OnTurnStart;
	}

	public override BaseUnit ApplyTurn (Unit unit){
		//		Debug.Log (name);
		if (unit.HasAdjacentEnemy()) {
			unit.baseUnit.CurrentMovementspeed += 1;
		}
		return unit.baseUnit;
	}

}
