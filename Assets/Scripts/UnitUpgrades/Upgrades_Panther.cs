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
		upgradeTitleLeft.Add (abilityPanther2L.Name);
		upgradeDescriptionLeft.Add (abilityPanther2L.Description);
		upgradeTitleLeft.Add ("Endurance");
		upgradeDescriptionLeft.Add ("+3 health");
		upgradeTitleLeft.Add (abilityPanther4L.Name);
		upgradeDescriptionLeft.Add (abilityPanther4L.Description);
		upgradeTitleLeft.Add ("Celerity");
		upgradeDescriptionLeft.Add ("+1 movementspeed");
		upgradeTitleLeft.Add (abilityPanther6L.Name);
		upgradeDescriptionLeft.Add (abilityPanther6L.Description);


		upgradeTitleRight.Add ("Assault");
		upgradeDescriptionRight.Add ("+1 attackdamage");
		upgradeTitleRight.Add (abilityPanther2R.Name);
		upgradeDescriptionRight.Add (abilityPanther2R.Description);
		upgradeTitleRight.Add ("Assault");
		upgradeDescriptionRight.Add ("+2 attackdamage");
		upgradeTitleRight.Add (abilityPanther4R.Name);
		upgradeDescriptionRight.Add (abilityPanther4R.Description);
		upgradeTitleRight.Add ("Assault");
		upgradeDescriptionRight.Add ("+3 attackdamage");
		upgradeTitleRight.Add (abilityPanther6R.Name);
		upgradeDescriptionRight.Add (abilityPanther6R.Description);
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

