using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour {

	public static UIController instance;

	public TMP_Text healthText;
	public TMP_Text movementSpeedText;
	public TMP_Text attackrangeText;
	public TMP_Text damageText;

	public GameObject battleOverMenu;


	public GameObject battleWonMenu;
	public TMP_Text expText;
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
		if (unit != null && unit.baseUnit.CurrentHealth>0) {
			BaseUnit tmpBase = unit.baseUnit;
			healthText.text = "Health: " + tmpBase.CurrentHealth + " / " + tmpBase.health;
			RecolorText (tmpBase.CurrentMovementspeed, tmpBase.movementSpeed, movementSpeedText);
			movementSpeedText.text = "Movementspeed: " + tmpBase.CurrentMovementspeed;
			RecolorText (tmpBase.CurrentAttackRange, tmpBase.attackRange, attackrangeText);
			attackrangeText.text = "Attackrange: " + tmpBase.CurrentAttackRange;
			RecolorText (tmpBase.CurrentAttackDamage, tmpBase.attackDamage, damageText);
			damageText.text = "Damage: " + tmpBase.CurrentAttackDamage;
		}
	}

	void RecolorText(int currentValue, int baseValue, TMP_Text recolorText){
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

	public void ShowBattleOverMenu(){
		battleOverMenu.SetActive (true);

	}

	public void ShowBattleWonMenu (int experience, int experienceGained){
		battleWonMenu.SetActive (true);
		StartCoroutine(CountExpUp(experience, experienceGained));
	}
	IEnumerator CountExpUp(int exp, int expGained){
		for (int i = 0; i <= expGained; i++) {
			expText.text = exp + " + " + i;
			yield return new WaitForSeconds (1f / expGained);
		}
	}
}
