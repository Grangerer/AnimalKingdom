using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Panther_4l : Ability {

	/*AbilityType: OnAttacking
Replenish:
Regenerate 20% of your maximum hp at the start of your turn if you haven't attacked last turn
	 * */
	public Ability_Panther_4l(){
		name = "Replenish";
		description = "Regenerate 30% of your maximum hp at the start of your turn if you haven't attacked last turn";
		triggerId = (int) Trigger.OnTurnStart;
	}
		
	public override BaseUnit ApplyTurn (Unit unit){
		//		Debug.Log (name);
		if (!unit.AttackedLastTurn) {
			//			Debug.Log (name + " applied");
			unit.baseUnit.Heal(unit.baseUnit.health*0.3f);
		}
		return unit.baseUnit;
	}

}
