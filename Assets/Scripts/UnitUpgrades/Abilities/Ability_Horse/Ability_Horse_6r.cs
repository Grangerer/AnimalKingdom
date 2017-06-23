using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Horse_6r : Ability {

	/*AbilityType: OnTurnStart
Agility:
You can move through allies
	 * */
	public Ability_Horse_6r(){
		name = "Agility";
		triggerId = (int) Trigger.OnTurnStart;
	}

	public override Attack Apply (Attack attack){
		//strange stuff
		return attack;
	}

}
