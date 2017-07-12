using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_MonitorLizard_2r : Ability {

	public Ability_MonitorLizard_2r(){
		name = "Hortative Odor";
		description = "At the end of your movement, grant adjacent allies 20% increased damage for one turn";
		triggerId = (int) Trigger.OnAttack;
	}

	public override BaseUnit ApplyTurn (Unit unit){
		//		Debug.Log (name);
		foreach (GameObject tile in unit.CurrentTile.GetComponent<Tile>().AdjacentTiles) {
			Tile checkTile = tile.GetComponent<Tile> ();
			if(checkTile.Occupied && checkTile.Unit !=null && checkTile.Unit.GetComponent<Unit>().OwnedByPlayer != unit.OwnedByPlayer){
				checkTile.Unit.GetComponent<Unit> ().AddAbility (new Debuff_HortativeOdor ());
				//			Debug.Log (name + " applied");
			}
		}
		return unit.baseUnit;
	}

}
