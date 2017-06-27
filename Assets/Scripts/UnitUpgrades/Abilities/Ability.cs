using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Ability {

	/*Possible Triggers:
	 * OnTurnStart
	 * OnTurnEnd
	 * OnAttack
	 * OnBeingAttacked
	 * OnMove
	 */

	protected string name;
	protected string description;
	protected int triggerId;

	public virtual Attack Apply (Attack attack){
		Debug.Log ("You are trying to use public virtual Attack Apply (Attack attack), but the childScript does not contain an implementation of it");
		return attack;
	}

	public virtual BaseUnit ApplyTurn(Unit unit){
		Debug.Log ("You are trying to use public virtual void ApplyOnturnStart(Unit unit), but the childScript does not contain an implementation of it");
		return unit.baseUnit;
	}


	//Propertystuff
	public int TriggerId {
		get {
			return triggerId;
		}
	}

	public string Name {
		get {
			return name;
		}
	}

	public string Description {
		get {
			return description;
		}
	}
}


public enum Trigger {OnTurnStart, OnTurnEnd, OnAttack, OnBeingAttack, OnMove}

