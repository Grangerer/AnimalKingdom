using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Bear_4r : Ability {

	/*AbilityType: OnTurnstart
Sprint:
Gain 50% increased movementspeed, if you haven't moved last turn
	 * */
	public Ability_Bear_4r(){
		name = "Bloodthirst";
		description = "Regenerate 25% of your maximum HP when killing an enemy unit";
		triggerId = (int) Trigger.OnAttack;
	}

	public override Attack Apply (Attack attack){
		//Apply a Debuff, that is triggered if the target dies and removed if the target does not die due to this attack
		return unit.baseUnit;
	}

}
