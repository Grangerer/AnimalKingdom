using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Tortoise_2l : Ability
{

	/*AbilityType: OnBeingAttacked
Hardened Shell:
Attacks from enemies that are not adjacent deal 35% less damage to you
	 * */
	public Ability_Tortoise_2l ()
	{
		name = "Hardened Shell";
		description = "Attacks from enemies that are not adjacent deal 35% less damage to you";
		triggerId = (int) Trigger.OnBeingAttack;
	}

	public override Attack Apply (Attack attack)
	{
		bool attackerNotAdjacent = true;
		foreach (GameObject tile in attack.Defender.CurrentTile.GetComponent<Tile>().AdjacentTiles) {
			if (tile.GetComponent<Tile>().Occupied && tile.GetComponent<Tile>().Unit!=null && tile.GetComponent<Tile>().Unit.GetComponent<Unit> ().Equals(attack.Attacker)) {
				attackerNotAdjacent = false;
				break;
			}
		}
		if (attackerNotAdjacent) {
			attack.ModifiedDamage -= attack.BaseDamage * 0.35f;
			Debug.Log ("Attack not adjacent => Hardened Shell");
		}
		return attack;
	}

}
