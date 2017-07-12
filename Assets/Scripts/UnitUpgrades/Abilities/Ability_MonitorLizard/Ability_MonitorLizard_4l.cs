using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability_MonitorLizard_4l : Ability {

	public Ability_MonitorLizard_4l(){
		name = "Curative Saliva";
		description = "At the end of your turn, one ally within your attackrange regenerates 15% of its maximum hp\n(Favors low HP allies)";
		triggerId = (int) Trigger.OnTurnEnd;
	}
		
	public override BaseUnit ApplyTurn (Unit unit){
		//		Debug.Log (name);
		Unit toHealUnit = unit;
		//Find all allies within attackrange
		foreach (GameObject checkUnitGO in PlayerController.instance.Units) {
			Unit checkUnit = checkUnitGO.GetComponent<Unit> ();
			int distance =(Mathf.Abs (unit.CurrentTile.GetComponent<Tile>().XGridPosition - checkUnit.CurrentTile.GetComponent<Tile>().XGridPosition) + Mathf.Abs (unit.CurrentTile.GetComponent<Tile>().ZGridPosition -  checkUnit.CurrentTile.GetComponent<Tile>().ZGridPosition));
			if(distance <= unit.baseUnit.CurrentAttackRange && toHealUnit.baseUnit.CurrentHealth > checkUnit.baseUnit.CurrentHealth){
				toHealUnit = checkUnit;
			}
		}
		toHealUnit.baseUnit.Heal (toHealUnit.baseUnit.health * 0.15f);

		return unit.baseUnit;
	}

}
