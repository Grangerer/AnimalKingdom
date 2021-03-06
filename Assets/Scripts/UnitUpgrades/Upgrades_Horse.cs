﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Upgrades_Horse : Upgrade {

	Ability_Horse_2l abilityHorse2L = new Ability_Horse_2l();
	Ability_Horse_2r abilityHorse2R = new Ability_Horse_2r();
	Ability_Horse_4l abilityHorse4L = new Ability_Horse_4l();
	Ability_Horse_4r abilityHorse4R = new Ability_Horse_4r();
	Ability_Horse_6l abilityHorse6L = new Ability_Horse_6l();
	Ability_Horse_6r abilityHorse6R = new Ability_Horse_6r();

	public override void SetupText(){
		upgradeTitleLeft.Add ("Celerity");
		upgradeDescriptionLeft.Add ("+1 movementspeed");
		upgradeTitleLeft.Add (abilityHorse2L.Name);
		upgradeDescriptionLeft.Add (abilityHorse2L.Description);
		upgradeTitleLeft.Add ("Endurance");
		upgradeDescriptionLeft.Add ("+2 health");
		upgradeTitleLeft.Add (abilityHorse4L.Name);
		upgradeDescriptionLeft.Add (abilityHorse4L.Description);
		upgradeTitleLeft.Add ("Endurance");
		upgradeDescriptionLeft.Add ("+4 health");
		upgradeTitleLeft.Add (abilityHorse6L.Name);
		upgradeDescriptionLeft.Add (abilityHorse6L.Description);


		upgradeTitleRight.Add ("Assault");
		upgradeDescriptionRight.Add ("+1 attackdamage");
		upgradeTitleRight.Add (abilityHorse2R.Name);
		upgradeDescriptionRight.Add (abilityHorse2R.Description);
		upgradeTitleRight.Add ("Assault");
		upgradeDescriptionRight.Add ("+2 attackdamage");
		upgradeTitleRight.Add (abilityHorse4R.Name);
		upgradeDescriptionRight.Add (abilityHorse4R.Description);
		upgradeTitleRight.Add ("Celerity");
		upgradeDescriptionRight.Add ("+1 movementspeed");
		upgradeTitleRight.Add (abilityHorse6R.Name);
		upgradeDescriptionRight.Add (abilityHorse6R.Description);
	}

	public override void ApplyUpgrades(Unit unit){
		for (int i = 0; i < chosenUpgrade.Count; i++) {
			if (i == 0) {
				if (chosenUpgrade [i] == 1) {
					UpgradeMovementSpeed (1, unit.baseUnit);
				} else if (chosenUpgrade [i] == 2) {
					UpgradeAttackDamage (1, unit.baseUnit);
				}
			} else if (i == 1) {
				if (chosenUpgrade [i] == 1) {
					unit.AddAbility (abilityHorse2L);
				} else if (chosenUpgrade [i] == 2) {
					unit.AddAbility (abilityHorse2R);
				}
			} else if (i == 2) {
				if (chosenUpgrade [i] == 1) {
					UpgradeHealth (2, unit.baseUnit);
				} else if (chosenUpgrade [i] == 2) {
					UpgradeAttackDamage (2, unit.baseUnit);
				}
			} else if (i == 3) {
				if (chosenUpgrade [i] == 1) {
					unit.AddAbility (abilityHorse4L);
				} else if (chosenUpgrade [i] == 2) {
					unit.AddAbility (abilityHorse4R);
				}
			}else if (i == 4) {
				if (chosenUpgrade [i] == 1) {
					UpgradeHealth (4, unit.baseUnit);
				} else if (chosenUpgrade [i] == 2) {
					UpgradeMovementSpeed (1, unit.baseUnit);
				}
			}else if (i == 5) {
				if (chosenUpgrade [i] == 1) {
					unit.AddAbility (abilityHorse6L);
				} else if (chosenUpgrade [i] == 2) {
					unit.AddAbility (abilityHorse6R);
				}
			}

		}

	}

}

