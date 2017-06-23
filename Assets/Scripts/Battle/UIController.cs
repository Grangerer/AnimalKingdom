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
		if (unit != null) {
			BaseUnit tmpBase = unit.baseUnit;
			healthText.text = "Health: " + tmpBase.CurrentHealth + " / " + tmpBase.health;
			RecolorText (tmpBase.CurrentMovementspeed, tmpBase.movementSpeed, movementSpeedText);
			movementSpeedText.text = "Movementspeed: " + tmpBase.CurrentMovementspeed;
			RecolorText (tmpBase.CurrentAttackRange, tmpBase.attackRange, attackrangeText);
			attackrangeText.text = "Attackrange: " + tmpBase.CurrentAttackRange;
			RecolorText (tmpBase.currentAttackDamage, tmpBase.attackDamage, damageText);
			damageText.text = "Damage: " + tmpBase.currentAttackDamage;
		}
	}

	void RecolorText(int currentValue, int baseValue, Text recolorText){
		if (currentValue < baseValue) {
			//Recolor damage.text red
			recolorText.color = Color.red;
		}else if(currentValue > baseValue){
			//Recolor text green
			recolorText.color = Color.green;
		}else{
			//Recolor black
			recolorText.color = new Color(50f/255f,50f/255f,50f/255f);
		}
	}

	public void UnsetUnitStatPanel(){
		healthText.text = "";
		movementSpeedText.text = "";
		attackrangeText.text = "";
		damageText.text = "";
	}
}
