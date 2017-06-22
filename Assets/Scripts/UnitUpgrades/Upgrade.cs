using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Upgrade {


	protected List<string> upgradeTitleLeft = new List<string>();
	protected List<string> upgradeTitleRight = new List<string>();
	protected List<string> upgradeDescriptionLeft = new List<string>();
	protected List<string> upgradeDescriptionRight = new List<string>();

	protected static List<int> upgradeCost = new List<int> (){100,175,275,400,550};
	protected List<int> chosenUpgrade = new List<int>(){0,0,0,0,0,0};

	public void UnlockLevel(BaseUnit unit){
		unit.Level++;
	}
		
	public abstract void ApplyUpgrades (Unit unit);

	public abstract void SetupText ();

	public void ChooseUpgrade (int upgradeLevel, int side){		
		if (side == 1) {		
			chosenUpgrade [upgradeLevel] = side;
		} else if (side == 2) {				
			chosenUpgrade [upgradeLevel] = side;
		} else {
			chosenUpgrade [upgradeLevel] = 0;
		}	
	}

	public void UpgradeHealth(int healthUpgrade, BaseUnit unit){
		unit.health += healthUpgrade;
	}
	public void UpgradeMovementSpeed(int movementSpeedUpgrade, BaseUnit unit){
		unit.movementSpeed += movementSpeedUpgrade;
	}
	public void UpgradeAttackDamage(int attackDamageUpgrade, BaseUnit unit){
		unit.attackDamage += attackDamageUpgrade;
	}
	public void UpgradeAttackRange(int attackRangeUpgrade, BaseUnit unit){
		unit.attackRange += attackRangeUpgrade;
	}

	public List<string> UpgradeTitleLeft {
		get {
			return upgradeTitleLeft;
		}
	}

	public List<string> UpgradeTitleRight {
		get {
			return upgradeTitleRight;
		}
	}

	public List<string> UpgradeDescriptionLeft {
		get {
			return upgradeDescriptionLeft;
		}
	}

	public List<string> UpgradeDescriptionRight {
		get {
			return upgradeDescriptionRight;
		}
	}
		

	public List<int> UpgradeCost {
		get {
			return upgradeCost;
		}
		set {
			upgradeCost = value;
		}
	}

	public List<int> ChosenUpgrade {
		get {
			return chosenUpgrade;
		}
		set {
			chosenUpgrade = value;
		}
	}
}
