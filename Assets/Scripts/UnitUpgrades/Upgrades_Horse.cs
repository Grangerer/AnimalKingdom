using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Upgrades_Horse : Upgrade {


	public override void SetupText(){
		upgradeTitleLeft.Add ("Celerity");
		upgradeDescriptionLeft.Add ("+1 movementspeed");
		upgradeTitleLeft.Add ("Agitation");
		upgradeDescriptionLeft.Add ("Attacks against you have a 20% chance to miss");
		upgradeTitleLeft.Add ("Endurance");
		upgradeDescriptionLeft.Add ("+2 health");
		upgradeTitleLeft.Add ("Kick");
		upgradeDescriptionLeft.Add ("Successful attacks reduce the targets movementspeed by 1. \n(Cannot reduce below 1)");
		upgradeTitleLeft.Add ("Endurance");
		upgradeDescriptionLeft.Add ("+4 health");
		upgradeTitleLeft.Add ("Pack");
		upgradeDescriptionLeft.Add ("You take 7.5% less damage for each adjacent ally");


		upgradeTitleRight.Add ("Assault");
		upgradeDescriptionRight.Add ("+1 attackdamage");
		upgradeTitleRight.Add ("Charge");
		upgradeDescriptionRight.Add ("Attacks deal 5% additional damage for each square you have moved this turn");
		upgradeTitleRight.Add ("Assault");
		upgradeDescriptionRight.Add ("+2 attackdamage");
		upgradeTitleRight.Add ("Overrun");
		upgradeDescriptionRight.Add ("Attacks against enemies without adjacent allies deal 25% additional damage");
		upgradeTitleRight.Add ("Celerity");
		upgradeDescriptionRight.Add ("+1 movementspeed");
		upgradeTitleRight.Add ("Agility");
		upgradeDescriptionRight.Add ("You can move through allies");
	}

	public override void ApplyUpgrades(Unit unit){
		for (int i = 0; i < chosenUpgrade.Count; i++) {
			if (i == 0) {
				if (chosenUpgrade [i] == 1) {
					UpgradeMovementSpeed (2, unit.baseUnit);
				} else if (chosenUpgrade [i] == 2) {
					UpgradeAttackDamage (1, unit.baseUnit);
				}
			} else if (i == 1) {

			} else if (i == 2) {
			} else if (i == 3) {
			}else if (i == 4) {
			}else if (i == 5) {
			}

		}

	}

}

