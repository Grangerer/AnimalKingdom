using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Bear_2l : Ability {

	public Ability_Bear_2l(){
		name = "Grip";
		description = "Successful attacks immobilize the target for one round";
		triggerId = (int) Trigger.OnAttack;
	}

	public override Attack Apply (Attack attack){
		//Apply a debuff that sets the immobilize flag onTurnStart of target
		return attack;
	}

}
