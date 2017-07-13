using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Porcupine_2l : Ability
{

	/*AbilityType: OnBeingAttacked
Rest:
Regenerate 15% of your maximum hp at the end of your turn if you haven't moved this turn
	 * */
	public Ability_Porcupine_2l ()
	{
		name = "Rest";
		description = "Regenerate 15% of your maximum hp at the end of your turn if you haven't moved this turn";
		triggerId = (int) Trigger.OnTurnEnd;
	}

	public override BaseUnit ApplyTurn (Unit unit){
		//		Debug.Log (name);
		if (!unit.Moved) {
			//			Debug.Log (name + " applied");
			unit.Heal(unit.baseUnit.health * 0.2f);
		}
		return unit.baseUnit;
	}

}
