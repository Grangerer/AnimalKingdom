using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		upgradeDescriptionLeft.Add ("You take 1 less damage for each adjacent ally.\n(Minimum 1)");


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

	public override void ChooseUpgrade(int upgradeLevel, int side){
		switch (upgradeLevel) {
		case 0:
			//DeApply current upgrade
			if (chosenUpgrade [upgradeLevel] == 2) {
				UpgradeAttackDamage (-1);
			}else if (chosenUpgrade [upgradeLevel] == 1) {
				UpgradeMovementSpeed (-1);
			}
			//Apply new upgrade/empty
			if (side == 1) {				
				chosenUpgrade [upgradeLevel] = 1;
				UpgradeMovementSpeed (1);
			} else if (side == 2) {				
				chosenUpgrade [upgradeLevel] = 2;
				UpgradeAttackDamage (1);
			} else {
				chosenUpgrade [upgradeLevel] = 0;
			}
			break;
		case 1:
			break;
		case 2:
			break;
		case 3:
			break;
		case 4:
			break;
		case 5:
			break;
		default:
			break;
		}
	}

}

