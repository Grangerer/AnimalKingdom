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

	public abstract Attack Apply (Attack attack);
}
