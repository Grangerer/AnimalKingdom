using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Panther_2l : Ability {

	/*AbilityType: OnBeingAttacked
	  Hidden:
		Attacks against you deal 50% less damage, if you have neither moved or attacked last turn
	 * */
	public Ability_Panther_2l(){
		name = "Hidden";
		description = "Attacks against you deal 50% less damage, if you have neither moved or attacked last turn";
		triggerId = (int) Trigger.OnBeingAttack;
	}

	public override Attack Apply (Attack attack){
		//Debug.Log (name);
		if (!attack.Defender.MovedLastTurn && !attack.Defender.AttackedLastTurn) {			
			attack.ModifiedDamage -= attack.BaseDamage * 0.5f;
		}
		return attack;
	}

}
