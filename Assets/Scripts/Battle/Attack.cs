using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack {

	Unit attacker;
	Unit defender;
	float baseDamage;
	float modifiedDamage;
	int attackDistance;

	List<De_Buff> appliedDebuffs = new List<De_Buff>();
	List<De_Buff> appliedBuffs = new List<De_Buff>();

	public Attack(Unit attacker, Unit defender, int damage){
		this.baseDamage = damage;
		this.attacker = attacker;
		this.defender = defender;
		modifiedDamage = baseDamage;
		attackDistance = CalculateAttackdistance (attacker.CurrentTile.GetComponent<Tile> (), defender.CurrentTile.GetComponent<Tile> ());
	}
	int CalculateAttackdistance(Tile attackerTile, Tile defenderTile){

		int distance = Mathf.Abs (attackerTile.XGridPosition - defenderTile.XGridPosition) + Mathf.Abs (attackerTile.ZGridPosition - defenderTile.ZGridPosition);
		return distance;
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

	public int AttackDistance {
		get {
			return attackDistance;
		}
		set {
			attackDistance = value;
		}
	}
}
