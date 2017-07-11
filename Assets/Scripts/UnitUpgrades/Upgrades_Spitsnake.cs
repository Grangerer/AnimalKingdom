using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Upgrades_Spitsnake : Upgrade {

	Ability_Spitsnake_2l abilitySpitsnake2L = new Ability_Spitsnake_2l();
	Ability_Spitsnake_2r abilitySpitsnake2R = new Ability_Spitsnake_2r();
	Ability_Spitsnake_4l abilitySpitsnake4L = new Ability_Spitsnake_4l();
	Ability_Spitsnake_4r abilitySpitsnake4R = new Ability_Spitsnake_4r();
	Ability_Spitsnake_6l abilitySpitsnake6L = new Ability_Spitsnake_6l();
	Ability_Spitsnake_6r abilitySpitsnake6R = new Ability_Spitsnake_6r();

	public override void SetupText(){
		upgradeTitleLeft.Add ("Endurance");
		upgradeDescriptionLeft.Add ("+1 health");
		upgradeTitleLeft.Add (abilitySpitsnake2L.Name);
		upgradeDescriptionLeft.Add (abilitySpitsnake2L.Description);
		upgradeTitleLeft.Add ("Celerity");
		upgradeDescriptionLeft.Add ("+1 movementspeed");
		upgradeTitleLeft.Add (abilitySpitsnake4L.Name);
		upgradeDescriptionLeft.Add (abilitySpitsnake4L.Description);
		upgradeTitleLeft.Add ("Endurance");
		upgradeDescriptionLeft.Add ("+3 health");
		upgradeTitleLeft.Add (abilitySpitsnake6L.Name);
		upgradeDescriptionLeft.Add (abilitySpitsnake6L.Description);


		upgradeTitleRight.Add ("Assault");
		upgradeDescriptionRight.Add ("+1 attackdamage");
		upgradeTitleRight.Add (abilitySpitsnake2R.Name);
		upgradeDescriptionRight.Add (abilitySpitsnake2R.Description);
		upgradeTitleRight.Add ("Reach");
		upgradeDescriptionRight.Add ("+1 attackrange");
		upgradeTitleRight.Add (abilitySpitsnake4R.Name);
		upgradeDescriptionRight.Add (abilitySpitsnake4R.Description);
		upgradeTitleRight.Add ("Assault");
		upgradeDescriptionRight.Add ("+2 attackdamage");
		upgradeTitleRight.Add (abilitySpitsnake6R.Name);
		upgradeDescriptionRight.Add (abilitySpitsnake6R.Description);
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
					unit.AddAbility (abilitySpitsnake2L);
				} else if (chosenUpgrade [i] == 2) {
					unit.AddAbility (abilitySpitsnake2R);
				}
			} else if (i == 2) {
				if (chosenUpgrade [i] == 1) {
					UpgradeMovementSpeed (1, unit.baseUnit);
				} else if (chosenUpgrade [i] == 2) {
					UpgradeAttackRange (1, unit.baseUnit);
				}
			} else if (i == 3) {
				if (chosenUpgrade [i] == 1) {
					unit.AddAbility (abilitySpitsnake4L);
				} else if (chosenUpgrade [i] == 2) {
					unit.AddAbility (abilitySpitsnake4R);
				}
			}else if (i == 4) {
				if (chosenUpgrade [i] == 1) {
					UpgradeHealth (3, unit.baseUnit);
				} else if (chosenUpgrade [i] == 2) {
					UpgradeAttackDamage (2, unit.baseUnit);
				}
			}else if (i == 5) {
				if (chosenUpgrade [i] == 1) {
					unit.AddAbility (abilitySpitsnake6L);
				} else if (chosenUpgrade [i] == 2) {
					unit.AddAbility (abilitySpitsnake6R);
				}
			}

		}

	}

}

