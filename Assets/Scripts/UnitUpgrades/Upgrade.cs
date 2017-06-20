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
	protected List<int> chosenUpgrade;
	protected BaseUnit baseUnit;

	public void UnlockLevel(){
		baseUnit.Level++;
	}

	public bool CanAffordUpgrade(int level, int experience){
		if (upgradeCost [level] < experience) {
			return true;
		}
		return false;
	}

	public void ChooseUpgrade(int level, bool leftSide){
		if (leftSide) {
			if (level == 0) {
				UpgradeLevelOneLeftPath ();
			} else if (level == 1) {
				UpgradeLevelTwoLeftPath ();
			} else if (level == 2) {
				UpgradeLevelThreeLeftPath ();
			} else if (level == 3) {
				UpgradeLevelFourLeftPath ();
			} else if (level == 4) {
				UpgradeLevelFiveLeftPath();
			} else if (level == 5) {
				UpgradeLevelSixLeftPath();
			}
		} else {
			if (level == 0) {
				UpgradeLevelOneRightPath ();
			} else if (level == 1) {
				UpgradeLevelTwoRightPath();
			} else if (level == 2) {
				UpgradeLevelThreeRightPath();
			} else if (level == 3) {
				UpgradeLevelFourRightPath();
			} else if (level == 4) {
				UpgradeLevelFiveRightPath();
			} else if (level == 5) {
				UpgradeLevelSixRightPath ();
			}
		}
	}
	public abstract void SetupText ();

	public abstract void UpgradeLevelOneLeftPath();
	
	public abstract void UpgradeLevelTwoLeftPath();
	
	public abstract void UpgradeLevelThreeLeftPath();
	
	public abstract void UpgradeLevelFourLeftPath();
	
	public abstract void UpgradeLevelFiveLeftPath();
	
	public abstract void UpgradeLevelSixLeftPath();
	

	public abstract void UpgradeLevelOneRightPath();
	
	public abstract void UpgradeLevelTwoRightPath();
	
	public abstract void UpgradeLevelThreeRightPath();
	
	public abstract void UpgradeLevelFourRightPath();
	
	public abstract void UpgradeLevelFiveRightPath();
	
	public abstract void UpgradeLevelSixRightPath ();

	public void UpgradeHealth(int healthUpgrade){
		baseUnit.health += healthUpgrade;
		baseUnit.Level++;
	}
	public void UpgradeMovementSpeed(int movementSpeedUpgrade){
		baseUnit.movementSpeed += movementSpeedUpgrade;
		baseUnit.Level++;
	}
	public void UpgradeAttackDamage(int attackDamageUpgrade){
		baseUnit.attackDamage += attackDamageUpgrade;
		baseUnit.Level++;
	}
	public void UpgradeAttackRange(int attackRangeUpgrade){
		baseUnit.attackRange += attackRangeUpgrade;
		baseUnit.Level++;
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
}
