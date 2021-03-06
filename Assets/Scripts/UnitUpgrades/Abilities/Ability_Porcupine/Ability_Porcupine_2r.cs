using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_Porcupine_2r : Ability
{

	/*AbilityType: OnAttack
Quill:
When attacking, adjacent enemies take damage equal to 20% of your attackdamage
(Excluding your target)
	 * */
	public Ability_Porcupine_2r ()
	{
		name = "Quill";
		description = "When attacking, adjacent enemies take damage equal to 20% of your attackdamage\n(Excluding your target)";
		triggerId = (int)Trigger.OnAttack;
	}

	public override Attack Apply (Attack attack)
	{
		foreach (GameObject tile in attack.Attacker.CurrentTile.GetComponent<Tile>().AdjacentTiles) {
			if (tile.GetComponent<Tile> ().Occupied && tile.GetComponent<Tile> ().Unit != null && tile.GetComponent<Tile> ().Unit.GetComponent<Unit> ().OwnedByPlayer != attack.Attacker.OwnedByPlayer) {
				tile.GetComponent<Tile> ().Unit.GetComponent<Unit> ().Damage (attack.BaseDamage * 0.2f);
			}
		}

		return attack;
	}

}
