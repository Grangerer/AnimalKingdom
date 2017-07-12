using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class De_Buff : Ability {

	protected int duration;

	public int Duration {
		get {
			return duration;
		}
	}

	public virtual void ApplyOnDeath(){
		Debug.Log ("You are trying to use public virtual void Apply (), but the childScript does not contain an implementation of it");
	}

}
