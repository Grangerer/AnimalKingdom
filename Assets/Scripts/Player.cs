using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player  {


	public static Player current;

	List<BaseUnit> units = new List<BaseUnit>();
	int experience;
	//Unitpriority
	List<int> priorityIDList = new List<int>(){0,1,2,3,4};
	//Unlocked Levels
	int unlockedLevel;

	public void SetupNewPlayer(List<GameObject> playerUnits){
		foreach (GameObject unit in playerUnits) {
			unit.GetComponent<Unit> ().baseUnit.SetupBase ();
			unit.GetComponent<Unit> ().baseUnit.upgrade.ChosenUpgrade [0] = 1;
			units.Add (unit.GetComponent<Unit> ().baseUnit);

		}
		experience = 0;
		//Debug.Log ("Player.Unlocked Level currently not 1!");
		unlockedLevel = 1; //Set this to 1!!
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
	public List<int> PriorityIDList {
		get {
			return priorityIDList;
		}
		set {
			priorityIDList = value;
		}
	}

	public int UnlockedLevel {
		get {
			return unlockedLevel;
		}
		set {
			unlockedLevel = value;
		}
	}
}
