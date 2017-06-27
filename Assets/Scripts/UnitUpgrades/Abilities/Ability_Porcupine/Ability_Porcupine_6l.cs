using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Porcupine_6l : Ability {

	/*AbilityType: OnTurnStart
Engage:
Gain +1 movementspeed, while no enemy is within attackrange
	 * */
	public Ability_Porcupine_6l(){
		name = "Engage";
		description = "Gain +1 movementspeed, while no enemy is within attackrange";
		triggerId = (int) Trigger.OnTurnStart;
	}

	public override BaseUnit ApplyTurn (Unit unit){
		//		Debug.Log (name);
		if (!unit.HasEnemiesWithinAttackrange()) {
			unit.baseUnit.CurrentMovementspeed += 1;
		}
		return unit.baseUnit;
	}

}
