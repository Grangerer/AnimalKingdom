using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Upgrades_MonitorLizard : Upgrade {

	Ability_MonitorLizard_2l abilityMonitorLizard2L = new Ability_MonitorLizard_2l();
	Ability_MonitorLizard_2r abilityMonitorLizard2R = new Ability_MonitorLizard_2r();
	Ability_MonitorLizard_4l abilityMonitorLizard4L = new Ability_MonitorLizard_4l();
	Ability_MonitorLizard_4r abilityMonitorLizard4R = new Ability_MonitorLizard_4r();
	Ability_MonitorLizard_6l abilityMonitorLizard6L = new Ability_MonitorLizard_6l();
	Ability_MonitorLizard_6r abilityMonitorLizard6R = new Ability_MonitorLizard_6r();

	public override void SetupText(){
		upgradeTitleLeft.Add ("Endurance");
		upgradeDescriptionLeft.Add ("+2 health");
		upgradeTitleLeft.Add (abilityMonitorLizard2L.Name);
		upgradeDescriptionLeft.Add (abilityMonitorLizard2L.Description);
		upgradeTitleLeft.Add ("Endurance");
		upgradeDescriptionLeft.Add ("+3 health");
		upgradeTitleLeft.Add (abilityMonitorLizard4L.Name);
		upgradeDescriptionLeft.Add (abilityMonitorLizard4L.Description);
		upgradeTitleLeft.Add ("Endurance");
		upgradeDescriptionLeft.Add ("+4 health");
		upgradeTitleLeft.Add (abilityMonitorLizard6L.Name);
		upgradeDescriptionLeft.Add (abilityMonitorLizard6L.Description);


		upgradeTitleRight.Add ("Assault");
		upgradeDescriptionRight.Add ("+1 attackdamage");
		upgradeTitleRight.Add (abilityMonitorLizard2R.Name);
		upgradeDescriptionRight.Add (abilityMonitorLizard2R.Description);
		upgradeTitleRight.Add ("Celerity");
		upgradeDescriptionRight.Add ("+1 movementspeed");
		upgradeTitleRight.Add (abilityMonitorLizard4R.Name);
		upgradeDescriptionRight.Add (abilityMonitorLizard4R.Description);
		upgradeTitleRight.Add ("Assault");
		upgradeDescriptionRight.Add ("+3 attackdamage");
		upgradeTitleRight.Add (abilityMonitorLizard6R.Name);
		upgradeDescriptionRight.Add (abilityMonitorLizard6R.Description);
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
					unit.AddAbility (abilityMonitorLizard2L);
				} else if (chosenUpgrade [i] == 2) {
					unit.AddAbility (abilityMonitorLizard2R);
				}
			} else if (i == 2) {
				if (chosenUpgrade [i] == 1) {
					UpgradeHealth (3, unit.baseUnit);
				} else if (chosenUpgrade [i] == 2) {
					UpgradeMovementSpeed (1, unit.baseUnit);
				}
			} else if (i == 3) {
				if (chosenUpgrade [i] == 1) {
					unit.AddAbility (abilityMonitorLizard4L);
				} else if (chosenUpgrade [i] == 2) {
					unit.AddAbility (abilityMonitorLizard4R);
				}
			}else if (i == 4) {
				if (chosenUpgrade [i] == 1) {
					UpgradeHealth (4, unit.baseUnit);
				} else if (chosenUpgrade [i] == 2) {
					UpgradeAttackDamage (3, unit.baseUnit);
				}
			}else if (i == 5) {
				if (chosenUpgrade [i] == 1) {
					unit.AddAbility (abilityMonitorLizard6L);
				} else if (chosenUpgrade [i] == 2) {
					unit.AddAbility (abilityMonitorLizard6R);
				}
			}

		}

	}

}

