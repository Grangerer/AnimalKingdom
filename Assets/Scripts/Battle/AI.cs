using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

	public static AI instance;

	BattleManager battleManager;

	List<GameObject> units = new List<GameObject> ();
	List<GameObject> turnUnits;
	public float waitTime = 0.2f;

	GameObject activeUnit = null;
	// Use this for initialization
	void Start () {
		battleManager = BattleManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Awake() {
		if (instance != null) {
			Debug.LogError("More than one AI in scene!");
			return;
		}
		instance = this;
	}

	public IEnumerator StartTurn(){
		Debug.Log ("AiStartTurn! Amount of Units: "+units.Count);
		turnUnits = new List<GameObject>(units);
		//Activate all units
		foreach (GameObject unit in turnUnits) {
			unit.GetComponent<Unit>().OnTurnStart();
		}
		do {
			//Choose random unit
			int unitChooser = Random.Range(0,turnUnits.Count-1);
			activeUnit = turnUnits[unitChooser];
			turnUnits.RemoveAt(unitChooser);
			//Find all enemy units in move+attackrange=>choose (1.The one you can kill 2.The one with the least hp)
			activeUnit.GetComponent<Unit>().UnitAI.TakeTurn();
			//wait 
			yield return new WaitForSeconds(waitTime);
		} while(turnUnits.Count > 0);//Repeat until all units acted
		//End turn
	}

	//Unit
	public void AddUnit(GameObject unit){
		units.Add (unit);
	}
	public bool OwnsUnit(GameObject checkUnit){
		return units.Contains (checkUnit);
	}
	public void RemoveUnit(GameObject unit){
		units.Remove (unit);
		//Check if any units are left
		if (units.Count == 0) {
			//Player wins match
			battleManager.WinMatch();
		}
	
	}

	public List<GameObject> Units {
		get {
			return units;
		}
	}
}
