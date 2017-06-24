using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack {

	Unit attacker;
	Unit defender;
	float baseDamage;
	float modifiedDamage;
	bool attackHit = true;
	bool cannotMiss = false;

	List<De_Buff> appliedDebuffs = new List<De_Buff>();
	List<De_Buff> appliedBuffs = new List<De_Buff>();

	public Attack(Unit attacker, Unit defender, int damage){
		this.baseDamage = damage;
		this.attacker = attacker;
		this.defender = defender;
		modifiedDamage = baseDamage;
	}

	public int GetFinalDamage(){
		return (int) Mathf.Round(modifiedDamage);
	}


	//Propertystuff
	public Unit Defender {
		get {
			return defender;
		}
		set {
			defender = value;
		}
	}

	public Unit Attacker {
		get {
			return attacker;
		}
		set {
			attacker = value;
		}
	}


	public bool AttackHit {
		get {
			return attackHit;
		}
		set {
			attackHit = value;
		}
	}

	public float BaseDamage {
		get {
			return baseDamage;
		}
		set {
			baseDamage = value;
		}
	}

	public float ModifiedDamage {
		get {
			return modifiedDamage;
		}
		set {
			modifiedDamage = value;
		}
	}

	public bool CannotMiss {
		get {
			return cannotMiss;
		}
		set {
			cannotMiss = value;
		}
	}

	public List<De_Buff> AppliedDebuffs {
		get {
			return appliedDebuffs;
		}
		set {
			appliedDebuffs = value;
		}
	}

	public List<De_Buff> AppliedBuffs {
		get {
			return appliedBuffs;
		}
		set {
			appliedBuffs = value;
		}
	}
}
