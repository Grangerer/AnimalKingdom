using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Upgrade_Bear : Upgrade {

	Ability_Bear_2l abilityBear2L = new Ability_Bear_2l();
	Ability_Bear_2r abilityBear2R = new Ability_Bear_2r();
	Ability_Bear_4l abilityBear4L = new Ability_Bear_4l();
	Ability_Bear_4r abilityBear4R = new Ability_Bear_4r();
	Ability_Bear_6l abilityBear6L = new Ability_Bear_6l();
	Ability_Bear_6r abilityBear6R = new Ability_Bear_6r();

	public override void SetupText(){
		upgradeTitleLeft.Add ("Endurance");
		upgradeDescriptionLeft.Add ("+2 health");
		upgradeTitleLeft.Add (abilityBear2L.Name);
		upgradeDescriptionLeft.Add (abilityBear2L.Description);
		upgradeTitleLeft.Add ("Endurance");
		upgradeDescriptionLeft.Add ("+4 health");
		upgradeTitleLeft.Add (abilityBear4L.Name);
		upgradeDescriptionLeft.Add (abilityBear4L.Description);
		upgradeTitleLeft.Add ("Endurance");
		upgradeDescriptionLeft.Add ("+6 health");
		upgradeTitleLeft.Add (abilityBear6L.Name);
		upgradeDescriptionLeft.Add (abilityBear6L.Description);


		upgradeTitleRight.Add ("Assault");
		upgradeDescriptionRight.Add ("+1 attackdamage");
		upgradeTitleRight.Add (abilityBear2R.Name);
		upgradeDescriptionRight.Add(abilityBear2R.Description);
		upgradeTitleRight.Add ("Celerity");
		upgradeDescriptionRight.Add ("+1 movementspeed");
		upgradeTitleRight.Add (abilityBear4R.Name);
		upgradeDescriptionRight.Add (abilityBear4R.Description);
		upgradeTitleRight.Add ("Assault");
		upgradeDescriptionRight.Add ("+3 attackdamage");
		upgradeTitleRight.Add (abilityBear6R.Name);
		upgradeDescriptionRight.Add (abilityBear6R.Description);
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
					unit.AddAbility (abilityBear2L);
				} else if (chosenUpgrade [i] == 2) {
					unit.AddAbility (abilityBear2R);
				}
			} else if (i == 2) {
				if (chosenUpgrade [i] == 1) {
					UpgradeHealth (4, unit.baseUnit);
				} else if (chosenUpgrade [i] == 2) {
					UpgradeMovementSpeed (1, unit.baseUnit);
				}
			} else if (i == 3) {
				if (chosenUpgrade [i] == 1) {
					unit.AddAbility (abilityBear4L);
				} else if (chosenUpgrade [i] == 2) {
					unit.AddAbility (abilityBear4R);
				}
			}else if (i == 4) {
				if (chosenUpgrade [i] == 1) {
					UpgradeHealth (4, unit.baseUnit);
				} else if (chosenUpgrade [i] == 2) {
					UpgradeAttackDamage (3, unit.baseUnit);
				}
			}else if (i == 5) {
				if (chosenUpgrade [i] == 1) {
					unit.AddAbility (abilityBear6L);
				} else if (chosenUpgrade [i] == 2) {
					unit.AddAbility (abilityBear6R);
				}
			}

		}
	}


}
