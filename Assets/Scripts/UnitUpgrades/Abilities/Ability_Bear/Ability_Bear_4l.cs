using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Bear_4l : Ability {

	/*AbilityType: OnAttacking
Replenish:
Regenerate 20% of your maximum hp at the start of your turn if you haven't attacked last turn
	 * */
	public Ability_Bear_4l(){
		name = "Tough Hide";
		description = "Attacks from enemies that are not adjacent deal 25% less damage";
		triggerId = (int) Trigger.OnBeingAttack;
	}
		
	public override Attack Apply (Attack attack){
		bool attackerNotAdjacent = true;
		foreach (GameObject tile in attack.Defender.CurrentTile.GetComponent<Tile>().AdjacentTiles) {
			if (tile.GetComponent<Tile>().Occupied && tile.GetComponent<Tile>().Unit!=null && tile.GetComponent<Tile>().Unit.GetComponent<Unit> ().Equals(attack.Attacker)) {
				attackerNotAdjacent = false;
				break;
			}
		}
		if (attackerNotAdjacent) {
			attack.ModifiedDamage -= attack.BaseDamage * 0.25f;
			Debug.Log ("Attack not adjacent => Tough Hide");
		}
		return attack;
	}

}
