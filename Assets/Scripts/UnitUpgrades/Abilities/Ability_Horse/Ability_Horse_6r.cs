using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Horse_6r : Ability {

	/*AbilityType: OnTurnStart
Frenzy:
You gain +1 movementspeed and attackdamage if you moved and attacked last turn
	 * */
	public Ability_Horse_6r(){
		name = "Frenzy";
		description = "You gain +1 movementspeed and attackdamage if you moved and attacked last turn";
		triggerId = (int) Trigger.OnTurnStart;
	}

	public override BaseUnit ApplyTurn (Unit unit){
		//		Debug.Log (name);
		if (unit.MovedLastTurn && unit.AttackedLastTurn) {
			//			Debug.Log (name + " applied");
			unit.baseUnit.CurrentMovementspeed += 1;
			unit.baseUnit.CurrentAttackDamage += 1;
		}
		return unit.baseUnit;
	}

}
