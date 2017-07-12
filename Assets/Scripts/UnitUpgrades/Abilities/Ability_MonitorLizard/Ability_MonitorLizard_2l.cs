using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_MonitorLizard_2l : Ability {

	public Ability_MonitorLizard_2l(){
		name = "Soothing Odor";
		description = "At the end of your movement, apply a 20% damage penalty to adjacent enemies for one turn";
		triggerId = (int) Trigger.OnMove;
	}

	public override BaseUnit ApplyTurn (Unit unit){
		//		Debug.Log (name);
		foreach (GameObject tile in unit.CurrentTile.GetComponent<Tile>().AdjacentTiles) {
			Tile checkTile = tile.GetComponent<Tile> ();
			if(checkTile.Occupied && checkTile.Unit !=null && checkTile.Unit.GetComponent<Unit>().OwnedByPlayer != unit.OwnedByPlayer){
				checkTile.Unit.GetComponent<Unit> ().AddAbility (new Debuff_SoothingOdor ());
				//			Debug.Log (name + " applied");
			}
		}
		return unit.baseUnit;
	}

}
