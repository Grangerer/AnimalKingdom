using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Panther_6l : Ability {

	/*AbilityType: OnBeingAttacked
Pounce:
Attacks against enemies without adjacent allies deal 50% additional damage
	 * */
	public Ability_Panther_6l(){
		name = "Pounce";
	}

	public override Attack Apply (Attack attack){
		//Insert Stuff
		return attack;
	}

}
