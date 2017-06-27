using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Tortoise_4l : Ability {

	/*AbilityType: OnTurnStart
Lone Survivor:
Regenerate 20% of your maximum hp at the start of your turn if you have no adjacent ally
	 * */
	public Ability_Tortoise_4l(){
		name = "Lone Survivor";
		description = "Regenerate 20% of your maximum hp at the start of your turn for each ally that died last turn";
		triggerId = (int) Trigger.OnTurnStart;
	}

	public override Attack Apply (Attack attack){

		//Insert abiliy
		//Needs the game to track unit death

		return attack;
	}

}
