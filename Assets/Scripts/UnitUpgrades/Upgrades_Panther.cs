using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Upgrades_Panther : Upgrade {

	Ability_Panther_2l abilityPanther2L = new Ability_Panther_2l();
	Ability_Panther_2r abilityPanther2R = new Ability_Panther_2r();
	Ability_Panther_4l abilityPanther4L = new Ability_Panther_4l();
	Ability_Panther_4r abilityPanther4R = new Ability_Panther_4r();
	Ability_Panther_6l abilityPanther6L = new Ability_Panther_6l();
	Ability_Panther_6r abilityPanther6R = new Ability_Panther_6r();

	public override void SetupText(){
		upgradeTitleLeft.Add ("Endurance");
		upgradeDescriptionLeft.Add ("+2 health");
		upgradeTitleLeft.Add ("Hidden");
		upgradeDescriptionLeft.Add ("Attacks against you have a 50% chance to miss, if you haven't attacked last turn");
		upgradeTitleLeft.Add ("Endurance");
		upgradeDescriptionLeft.Add ("+3 health");
		upgradeTitleLeft.Add ("Precise Claw");
		upgradeDescriptionLeft.Add ("Attacks cannot miss, if you haven't attacked last turn");
		upgradeTitleLeft.Add ("Celerity");
		upgradeDescriptionLeft.Add ("+1 movementspeed");
		upgradeTitleLeft.Add ("Pounce");
		upgradeDescriptionLeft.Add ("Attacks against enemies without adjacent allies deal 50% additional damage");


		upgradeTitleRight.Add ("Assault");
		upgradeDescriptionRight.Add ("+1 attackdamage");
		upgradeTitleRight.Add ("Sharpened Claw");
		upgradeDescriptionRight.Add ("Attacks deal 25% additional damage, if you haven't attacked last turn");
		upgradeTitleRight.Add ("Assault");
		upgradeDescriptionRight.Add ("+2 attackdamage");
		upgradeTitleRight.Add ("Sprint");
		upgradeDescriptionRight.Add ("Gain 50% increased movementspeed, if you haven't moved last turn");
		upgradeTitleRight.Add ("Assault");
		upgradeDescriptionRight.Add ("+3 attackdamage");
		upgradeTitleRight.Add ("Finisher");
		upgradeDescriptionRight.Add ("Attacks deal 50% additional damage against enemies that are below 50% health");
	}

	public override void ApplyUpgrades(Unit unit){
		for (int i = 0; i < chosenUpgrade.Count; i++) {
			if (i == 0) {
				if (chosenUpgrade [i] == 1) {
					UpgradeHealth (2, unit.baseUnit);
				} else if (chosenUpgrade [i] == 2) {
					UpgradeAttackDamage (1, unit.baseUnit);
				}
			} else if (i == 1) {
				if (chosenUpgrade [i] == 1) {
					unit.AddAbility (abilityPanther2L);
				} else if (chosenUpgrade [i] == 2) {
					unit.AddAbility (abilityPanther2R);
				}
			} else if (i == 2) {
				if (chosenUpgrade [i] == 1) {
					UpgradeHealth (3, unit.baseUnit);
				} else if (chosenUpgrade [i] == 2) {
					UpgradeAttackDamage (2, unit.baseUnit);
				}
			} else if (i == 3) {
				if (chosenUpgrade [i] == 1) {
					unit.AddAbility (abilityPanther4L);
				} else if (chosenUpgrade [i] == 2) {
					unit.AddAbility (abilityPanther4R);
				}
			}else if (i == 4) {
				if (chosenUpgrade [i] == 1) {
					UpgradeMovementSpeed (1, unit.baseUnit);
				} else if (chosenUpgrade [i] == 2) {
					UpgradeAttackDamage (3, unit.baseUnit);
				}
			}else if (i == 5) {
				if (chosenUpgrade [i] == 1) {
					unit.AddAbility (abilityPanther6L);
				} else if (chosenUpgrade [i] == 2) {
					unit.AddAbility (abilityPanther6R);
				}
			}

		}

	}

}

