using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Bear : Upgrade {

	//Level 1
	public override void UpgradeLevelOneLeftPath(){
		UpgradeHealth (2);
		chosenUpgrade.Add (0);
	}
	public override void UpgradeLevelOneRightPath(){
		UpgradeAttackDamage (1);
		chosenUpgrade.Add (0);
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
