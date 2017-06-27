using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Upgrades_Porcupine : Upgrade {

	Ability_Porcupine_2l abilityPorcupine2L = new Ability_Porcupine_2l();
	Ability_Porcupine_2r abilityPorcupine2R = new Ability_Porcupine_2r();
	Ability_Porcupine_4l abilityPorcupine4L = new Ability_Porcupine_4l();
	Ability_Porcupine_4r abilityPorcupine4R = new Ability_Porcupine_4r();
	Ability_Porcupine_6l abilityPorcupine6L = new Ability_Porcupine_6l();
	Ability_Porcupine_6r abilityPorcupine6R = new Ability_Porcupine_6r();

	public override void SetupText(){
		upgradeTitleLeft.Add ("Endurance");
		upgradeDescriptionLeft.Add ("+1 health");
		upgradeTitleLeft.Add (abilityPorcupine2L.Name);
		upgradeDescriptionLeft.Add (abilityPorcupine2L.Description);
		upgradeTitleLeft.Add ("Endurance");
		upgradeDescriptionLeft.Add ("+3 health");
		upgradeTitleLeft.Add (abilityPorcupine4L.Name);
		upgradeDescriptionLeft.Add (abilityPorcupine4L.Description);
		upgradeTitleLeft.Add ("Endurance");
		upgradeDescriptionLeft.Add ("+6 health");
		upgradeTitleLeft.Add (abilityPorcupine6L.Name);
		upgradeDescriptionLeft.Add (abilityPorcupine6L.Description);


		upgradeTitleRight.Add ("Assault");
		upgradeDescriptionRight.Add ("+1 attackdamage");
		upgradeTitleRight.Add (abilityPorcupine2R.Name);
		upgradeDescriptionRight.Add (abilityPorcupine2R.Description);
		upgradeTitleRight.Add ("Assault");
		upgradeDescriptionRight.Add ("+2 attackdamage");
		upgradeTitleRight.Add (abilityPorcupine4R.Name);
		upgradeDescriptionRight.Add (abilityPorcupine4R.Description);
		upgradeTitleRight.Add ("Reach");
		upgradeDescriptionRight.Add ("+1 attackrange");
		upgradeTitleRight.Add (abilityPorcupine6R.Name);
		upgradeDescriptionRight.Add (abilityPorcupine6R.Description);
	}

	public override void ApplyUpgrades(Unit unit){
		for (int i = 0; i < chosenUpgrade.Count; i++) {
			if (i == 0) {
				if (chosenUpgrade [i] == 1) {
					UpgradeHealth (1, unit.baseUnit);
				} else if (chosenUpgrade [i] == 2) {
					UpgradeAttackDamage (1, unit.baseUnit);
				}
			} else if (i == 1) {
				if (chosenUpgrade [i] == 1) {
					unit.AddAbility (abilityPorcupine2L);
				} else if (chosenUpgrade [i] == 2) {
					unit.AddAbility (abilityPorcupine2R);
				}
			} else if (i == 2) {
				if (chosenUpgrade [i] == 1) {
					UpgradeHealth (3, unit.baseUnit);
				} else if (chosenUpgrade [i] == 2) {
					UpgradeAttackDamage (2, unit.baseUnit);
				}
			} else if (i == 3) {
				if (chosenUpgrade [i] == 1) {
					unit.AddAbility (abilityPorcupine4L);
				} else if (chosenUpgrade [i] == 2) {
					unit.AddAbility (abilityPorcupine4R);
				}
			}else if (i == 4) {
				if (chosenUpgrade [i] == 1) {
					UpgradeHealth (6, unit.baseUnit);
				} else if (chosenUpgrade [i] == 2) {
					UpgradeAttackRange (1, unit.baseUnit);
				}
			}else if (i == 5) {
				if (chosenUpgrade [i] == 1) {
					unit.AddAbility (abilityPorcupine6L);
				} else if (chosenUpgrade [i] == 2) {
					unit.AddAbility (abilityPorcupine6R);
				}
			}

		}

	}

}

