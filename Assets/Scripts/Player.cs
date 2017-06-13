using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	List<GameObject> units;
	int experience;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void SpentExperience(int experienceCost){
		experience -= experienceCost;
	}
}
