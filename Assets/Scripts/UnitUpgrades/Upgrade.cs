using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Upgrade : MonoBehaviour {


	protected List<string> upgradeTitleLeft = new List<string>();
	protected List<string> upgradeTitleRight = new List<string>();
	protected List<string> upgradeDescriptionLeft = new List<string>();
	protected List<string> upgradeDescriptionRight = new List<string>();

	protected List<int> upgradeCost;
	protected List<int> chosenUpgrade;
	protected BaseUnit baseUnit;

	void Start(){
		baseUnit = this.GetComponent<Unit> ().baseUnit;

		upgradeCost = new List<int> ();
		upgradeCost.Add (100);
		upgradeCost.Add (175);
		upgradeCost.Add (275);
		upgradeCost.Add (400);
		upgradeCost.Add (550);
	}

	public bool CanAffordUpgrade(int level, int experience){
		if (upgradeCost [level] < experience) {
			return true;
		}
		return false;
	}

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
	
}
