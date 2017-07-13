using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_MonitorLizard_6l : Ability {

	/*AbilityType: OnAttack
Pounce:
Attacks against enemies without adjacent allies deal 40% additional damage
	 * */
	public Ability_MonitorLizard_6l(){
		name = "Walk it Off";
		description = "When moving, you heal equal to the distance moved";
		triggerId = (int) Trigger.OnMove;
	}

	public override BaseUnit ApplyTurn (Unit unit){
		//		Debug.Log (name);
		unit.Heal(unit.DistanceMoved);

		return unit.baseUnit;
	}

}
