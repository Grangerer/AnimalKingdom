using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseUnit {

	//Upgrades
	public int id;
	private int level =0;
	readonly static int maxLevel = 5;
	public Upgrade upgrade;

	public int health;
	private int currentHealth;
	public int movementSpeed;
	private int currentMovementspeed;
	public int attackRange;
	private int currentAttackRange;
	public int attackDamage;
	private int currentAttackDamage;

	public BaseUnit(BaseUnit toCopy){
		this.id = toCopy.id;
		this.level = toCopy.level;
		this.upgrade = toCopy.upgrade;
		this.health = toCopy.health;
		this.currentHealth = toCopy.currentHealth;
		this.movementSpeed = toCopy.movementSpeed;
		this.currentMovementspeed = toCopy.currentMovementspeed;
		this.attackRange = toCopy.attackRange;
		this.currentAttackRange = toCopy.currentAttackRange;
		this.attackDamage = toCopy.attackDamage;
		this.currentAttackDamage = toCopy.currentAttackDamage;
	}

	public void SetupBase(){
		switch (id) {
		case 0: //Bear
			upgrade = new Upgrade_Bear ();
			break;
		case 1: //Horse
			upgrade = new Upgrades_Horse ();
			break;
		case 5: //Panther
			upgrade = new Upgrades_Panther ();
			break;
		default:
			break;
		}	
		level = 0;
		upgrade.SetupText ();
	}

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
		
	public static int MaxLevel {
		get {
			return maxLevel;
		}
	}
}
