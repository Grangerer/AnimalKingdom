using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour {

	protected List<int> upgradeCost;
	protected Unit unit;

	void Start(){
		unit = this.GetComponent<Unit> ();

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
		unit.health += healthUpgrade;
		unit.Level++;
	}
	public void UpgradeMovementSpeed(int movementSpeedUpgrade){
		unit.movementSpeed += movementSpeedUpgrade;
		unit.Level++;
	}
	public void UpgradeAttackDamage(int attackDamageUpgrade){
		unit.attackDamage += attackDamageUpgrade;
		unit.Level++;
	}
	public void UpgradeAttackRange(int attackRangeUpgrade){
		unit.attackRange += attackRangeUpgrade;
		unit.Level++;
	}
	
}
