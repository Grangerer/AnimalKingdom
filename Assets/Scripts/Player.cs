using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player  {


	public static Player current;

	List<BaseUnit> units = new List<BaseUnit>();
	int experience;
	//Unlocked Levels


	public void SetupNewPlayer(List<GameObject> playerUnits){
		foreach (GameObject unit in playerUnits) {
			unit.GetComponent<Unit> ().baseUnit.SetupBase ();
			unit.GetComponent<Unit> ().baseUnit.upgrade.ChosenUpgrade [0] = 1;
			units.Add (unit.GetComponent<Unit> ().baseUnit);

		}
		experience = 0;
	}

	public void SpentExperience(int experienceCost){
		experience -= experienceCost;
	}

	public int Experience {
		get {
			return experience;
		}
		set {
			experience = value;
		}
	}

	public List<BaseUnit> Units {
		get {
			return units;
		}
		set {
			units = value;
		}
	}
}
