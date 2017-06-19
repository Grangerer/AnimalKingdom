using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player  {


	public static Player current;

	List<BaseUnit> units;
	int experience;
	//Unlocked Levels


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void PrintOut(){
		//foreach (int unit in units) {
		//	Debug.Log(unit.GetComponent<Unit> ().health);
		//}
		Debug.Log ("Current Experience: " + experience);
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
}
