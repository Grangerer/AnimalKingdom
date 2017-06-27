using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Tortoise_6l : Ability {

	/*AbilityType: OnTurnStart
Retreat:
At the start of your turn, regenerate 30% of your maximum hp if you have neither moved or attacked last turn
	 * */
	public Ability_Tortoise_6l(){
		name = "Retreat";
		description = "At the start of your turn, regenerate 30% of your maximum hp if you have neither moved or attacked last turn";
		triggerId = (int) Trigger.OnTurnStart;
	}

	public override BaseUnit ApplyTurn (Unit unit){
		//		Debug.Log (name);
		if (!unit.AttackedLastTurn && !unit.MovedLastTurn) {
			//			Debug.Log (name + " applied");
			unit.baseUnit.Heal(unit.baseUnit.health*0.3f);
		}
		return unit.baseUnit;
	}

}
