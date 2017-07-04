using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Bear_6l : Ability {

	/*AbilityType: OnAttack
Pounce:
Attacks against enemies without adjacent allies deal 40% additional damage
	 * */
	public Ability_Bear_6l(){
		name = "Regenerative";
		description = "Regenerate 10% of your maximum HP at the start of each turn";
		triggerId = (int) Trigger.OnTurnStart;
	}

	public override BaseUnit ApplyTurn (Unit unit){
		//		Debug.Log (name);
		unit.baseUnit.Heal(unit.baseUnit.health*0.1f);

		return unit.baseUnit;
	}

}
