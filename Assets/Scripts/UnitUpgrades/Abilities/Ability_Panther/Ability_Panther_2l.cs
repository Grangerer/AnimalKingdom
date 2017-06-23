using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Panther_2l : Ability {

	/*AbilityType: OnBeingAttacked
	  Hidden:
		Attacks against you have a 50% chance to miss, if you have neither moved or attacked last turn
	 * */
	public Ability_Panther_2l(){
		name = "Hidden";
		triggerId = (int) Trigger.OnBeingAttack;
	}

	public override Attack Apply (Attack attack){
		//Debug.Log (name);
		if (!attack.Defender.MovedLastTurn && !attack.Defender.AttackedLastTurn) {			
			if (Random.Range(1,101) < 50) {
				//Debug.Log (name + "Panther dodged");
				attack.AttackHit = false;
			}
		}
		return attack;
	}

}
