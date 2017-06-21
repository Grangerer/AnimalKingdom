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
	protected BaseUnit baseUnit;

	public void UnlockLevel(){
		baseUnit.Level++;
	}
		
	public abstract void ApplyUpgrades ();

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

	public void UpgradeHealth(int healthUpgrade){
		baseUnit.health += healthUpgrade;
	}
	public void UpgradeMovementSpeed(int movementSpeedUpgrade){
		baseUnit.movementSpeed += movementSpeedUpgrade;
	}
	public void UpgradeAttackDamage(int attackDamageUpgrade){
		baseUnit.attackDamage += attackDamageUpgrade;
	}
	public void UpgradeAttackRange(int attackRangeUpgrade){
		baseUnit.attackRange += attackRangeUpgrade;
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

	public BaseUnit BaseUnit {
		get {
			return baseUnit;
		}
		set {
			baseUnit = value;
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
