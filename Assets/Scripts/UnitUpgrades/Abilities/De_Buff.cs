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
}
