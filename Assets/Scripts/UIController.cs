﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public static UIController instance;

	public Text healthText;
	public Text movementSpeedText;
	public Text attackrangeText;
	public Text damageText;


	// Use this for initialization
	void Start () {
		
	}
	void Awake() {
		if (instance != null) {
			Debug.LogError("More than one UIController in scene!");
			return;
		}
		instance = this;
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void SetUnitStatPanel(Unit unit){
		healthText.text = "Health: " + unit.CurrentHealth + " / " + unit.health;
		movementSpeedText.text = "Movementspeed: " + unit.movementSpeed;
		attackrangeText.text = "Attackrange: " + unit.attackRange;
		damageText.text = "Damage: " + unit.damage;
	}

	public void UnsetUnitStatPanel(){
		healthText.text = "";
		movementSpeedText.text = "";
		attackrangeText.text = "";
		damageText.text = "";
	}
}
