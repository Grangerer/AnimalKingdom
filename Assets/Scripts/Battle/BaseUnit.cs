using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseUnit {

	//Upgrades
	private int level = 0;
	public Upgrade upgrade;

	public int health;
	private int currentHealth;
	public int movementSpeed;
	private int currentMovementspeed;
	public int attackRange;
	private int currentAttackRange;
	public int attackDamage;
	private int currentAttackDamage;

	public void SetupOnBattleStart(){
		currentHealth = health;
		currentMovementspeed = movementSpeed;
		currentAttackRange = attackRange;
		currentAttackDamage = attackDamage;
	}


	public int CurrentHealth {
		get {
			return currentHealth;
		}
		set {
			currentHealth = value;
		}
	}

	public int CurrentMovementspeed {
		get {
			return currentMovementspeed;
		}
		set {
			currentMovementspeed = value;
		}
	}

	public int CurrentAttackRange {
		get {
			return currentAttackRange;
		}
		set {
			currentAttackRange = value;
		}
	}


	public int CurrentAttackDamage {
		get {
			return currentAttackDamage;
		}
		set {
			currentAttackDamage = value;
		}
	}

	public int Level {
		get {
			return level;
		}
		set {
			level = value;
		}
	}
}
