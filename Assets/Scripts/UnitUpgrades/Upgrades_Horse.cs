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



	//Level 1
	public override void UpgradeLevelOneLeftPath(){
		UpgradeHealth (2);
		chosenUpgrade.Add (0);
	}
	public override void UpgradeLevelOneRightPath(){
		UpgradeAttackDamage (1);
		chosenUpgrade.Add (1);
	}
	//Level 2
	public override void UpgradeLevelTwoLeftPath(){}
	public override void UpgradeLevelTwoRightPath(){}
	//Level 3
	public override void UpgradeLevelThreeLeftPath(){
		UpgradeHealth (4);
	}
	public override void UpgradeLevelThreeRightPath(){
		UpgradeMovementSpeed (1);
	}
	//Level 4
	public override void UpgradeLevelFourLeftPath(){}
	public override void UpgradeLevelFourRightPath(){}
	//Level 5
	public override void UpgradeLevelFiveLeftPath(){
		UpgradeHealth (6);
	}
	public override void UpgradeLevelFiveRightPath(){
		UpgradeAttackDamage (3);
	}
	//Level 6
	public override void UpgradeLevelSixLeftPath(){}
	public override void UpgradeLevelSixRightPath (){}
}
