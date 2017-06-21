using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Upgrade_Bear : Upgrade {


	public override void SetupText(){
		upgradeTitleLeft.Add ("Endurance");
		upgradeDescriptionLeft.Add ("+2 health");
		upgradeTitleLeft.Add ("Grip");
		upgradeDescriptionLeft.Add ("Successful attacks immobilize the target for one round");
		upgradeTitleLeft.Add ("Endurance");
		upgradeDescriptionLeft.Add ("+4 health");
		upgradeTitleLeft.Add ("Tough Hide");
		upgradeDescriptionLeft.Add ("Attacks from enemies that are not adjacent deal 25% less damage");
		upgradeTitleLeft.Add ("Endurance");
		upgradeDescriptionLeft.Add ("+6 health");
		upgradeTitleLeft.Add ("Regenerative");
		upgradeDescriptionLeft.Add ("Regenerate 10% of your maximum HP at the start of each turn");


		upgradeTitleRight.Add ("Assault");
		upgradeDescriptionRight.Add ("+1 attackdamage");
		upgradeTitleRight.Add ("Taunt");
		upgradeDescriptionRight.Add ("Successful attacks reduce the damage the target does against all other unity by 25%");
		upgradeTitleRight.Add ("Celerity");
		upgradeDescriptionRight.Add ("+1 movementspeed");
		upgradeTitleRight.Add ("Bloodthirst");
		upgradeDescriptionRight.Add ("Regenerate 25% of your maximum HP when killing an enemy unit");
		upgradeTitleRight.Add ("Assault");
		upgradeDescriptionRight.Add ("+3 attackdamage");
		upgradeTitleRight.Add ("Swipe");
		upgradeDescriptionRight.Add ("Attacks deal 25% of their damage to all adjacent enemies to the target");
	}

	public override void ApplyUpgrades(){
		for (int i = 0; i < chosenUpgrade.Count; i++) {
			if (i == 0) {
				if (chosenUpgrade [i] == 1) {
					UpgradeHealth (2);
				} else if (chosenUpgrade [i] == 2) {
					UpgradeAttackDamage (1);
				}
			} else if (i == 1) {
				
			} else if (i == 2) {
			} else if (i == 3) {
			}else if (i == 4) {
			}else if (i == 5) {
			}

		}
		baseUnit.SetupOnBattleStart ();
	}


}
