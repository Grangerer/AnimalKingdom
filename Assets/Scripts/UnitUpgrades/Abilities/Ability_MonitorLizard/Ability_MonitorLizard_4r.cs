using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_MonitorLizard_4r : Ability {

	public Ability_MonitorLizard_4r(){
		name = "Purulent Wounds";
		description = "Attacks increase all damage the target takes by 20% for one round";
		triggerId = (int) Trigger.OnTurnStart;
	}

	public override Attack Apply (Attack attack){
		attack.Attacker.AddAbility(new Debuff_PurulentWounds());
		return attack;
	}

}
