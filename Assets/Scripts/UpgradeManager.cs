using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UpgradeManager : MonoBehaviour {

	private int currentUnitID = 0;
	private GameObject currentShownUnit;

	public TMP_Text experienceText;
	private string experienceBaseString = "Experience:\n";
	public TMP_Text unitNameText;

	public GameObject ShowTile;
	public GameObject arrowLeft;
	Animation arrowLeftAnimation;
	public GameObject arrowRight;
	Animation arrowRightAnimation;

	//UpgradetreeText
	public List<TMP_Text> upgradeTitlesLeft = new List<TMP_Text>();
	public List<TMP_Text> upgradeDescriptionLeft = new List<TMP_Text>();
	public List<TMP_Text> upgradeTitlesRight = new List<TMP_Text>();
	public List<TMP_Text> upgradeDescriptionRight = new List<TMP_Text>();
	public List<Button> unlockButtons = new List<Button>();
	public List<GameObject> talentTier;

	public Color unlockedTierColor;
	public Color lockedTierColor;
	// Use this for initialization
	void Start () {
		arrowLeftAnimation = arrowLeft.GetComponent<Animation>();
		arrowRightAnimation = arrowRight.GetComponent<Animation> ();
		DisplayUnit (ShowTile, currentUnitID);
		experienceText.text = experienceBaseString + Player.current.Experience;
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100)) {
				if (hit.transform.root.name == "ArrowLeft") {
					StartCoroutine(LastUnit ());
				} else if (hit.transform.root.name == "ArrowRight") {
					StartCoroutine(NextUnit ());
				}
				//Check all Talentoptions
				CheckAllTalentOptions(hit);
			}
		}
		if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
			StartCoroutine(LastUnit ());
		}else if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)){
			StartCoroutine(NextUnit ());
		}

	}

	void CheckAllTalentOptions(RaycastHit hit){
		if (hit.transform.name.Equals("Talent1L")) {
			LockUpdate (0, 1);
		}else if (hit.transform.name.Equals("Talent1R")) {
			LockUpdate (0, 2);
		}else if (hit.transform.name.Equals("Talent2L")) {
			LockUpdate (1, 1);
		}else if (hit.transform.name.Equals("Talent2R")) {
			LockUpdate (1, 2);
		}else if (hit.transform.name.Equals("Talent3L")) {
			LockUpdate (2, 1);
		}else if (hit.transform.name.Equals("Talent3R")) {
			LockUpdate (2, 2);
		}else if (hit.transform.name.Equals("Talent4L")) {
			LockUpdate (3, 1);
		}else if (hit.transform.name.Equals("Talent4R")) {
			LockUpdate (3, 2);
		}else if (hit.transform.name.Equals("Talent5L")) {
			LockUpdate (4, 1);
		}else if (hit.transform.name.Equals("Talent5R")) {
			LockUpdate (4, 2);
		}else if (hit.transform.name.Equals("Talent6L")) {
			LockUpdate (5, 1);
		}else if (hit.transform.name.Equals("Talent6R")) {
			LockUpdate (5, 2);
		}
	}

	IEnumerator NextUnit(){
		if (currentUnitID < Data.currentData.units.Count-1) {
			//Debug.Log ("Next unit");
			currentUnitID++;
			//Display Arrow Right animation
			arrowRightAnimation.Stop ();
			arrowRightAnimation.Play ();
			yield return new WaitForSeconds (arrowRightAnimation.clip.length/4*3);
			//Display next Unit
			DisplayUnit(ShowTile,currentUnitID);
		} else {
			//Display "Cannot next" animation
		}
	}
	IEnumerator LastUnit(){
		if (currentUnitID > 0) {
			currentUnitID--;
			//Display Arrow Left animation
			arrowLeftAnimation.Stop ();
			arrowLeftAnimation.Play ();
			yield return new WaitForSeconds (arrowLeftAnimation.clip.length/4*3);
			//Display next Unit
			DisplayUnit(ShowTile,currentUnitID);
		} else {
			//Display "Cannot last" animation
		}
	}


	void DisplayUnit(GameObject spawnOnTile, int unitID){
		if (currentShownUnit != null) {
			Destroy (currentShownUnit);
		}
		Vector3 position = new Vector3 (spawnOnTile.transform.position.x, Data.currentData.units[unitID].transform.position.y, spawnOnTile.transform.position.z);
		GameObject tmpUnit = Instantiate (Data.currentData.units[unitID], position, Quaternion.identity * Quaternion.Euler(0,25,0));
		tmpUnit.GetComponent<Unit> ().Setup (spawnOnTile);
		currentShownUnit = tmpUnit;
		unitNameText.text = currentShownUnit.GetComponent<Unit>().baseUnit.name;
		DisplayTalentTree ();
	}

	public void DisplayTalentTree(){
		//Talent Tree enables spending experience points to unlock permanent powerups
		//Color locked and unlocked Talenttiers
		ColorTalentTiers();
		//Color chosen Upgrade of unlocked TalentTiers
		ColorChosenUpgrades();
		//Enable Talent Tree (Unlock buttons)
		DisplayUnlockButtons();
		SetAbilityText ();
	}
	void ColorTalentTiers(){
		for (int i = 0; i <= BaseUnit.MaxLevel; i++) {
			if (i <= Player.current.Units [currentUnitID].Level) {
				talentTier [i].GetComponent<Image> ().color = unlockedTierColor;
			} else {
				talentTier [i].GetComponent<Image> ().color = lockedTierColor;			
			}
		}
	}
	void ColorChosenUpgrades(){
		for (int i = 0; i <= BaseUnit.MaxLevel; i++) {
			if (Player.current.Units [currentUnitID].upgrade.ChosenUpgrade [i] == 1) {
				ColorUpgrade (i, true);
			} else if (Player.current.Units [currentUnitID].upgrade.ChosenUpgrade [i] == 2) {
				ColorUpgrade (i, false);
			} else {
				UncolorUpgrade (i);
			}
		}
	}
	void ColorUpgrade(int tier, bool leftSide){
		if (leftSide)
		{
		    upgradeTitlesLeft[tier].GetComponentInParent<Image>().enabled = true;
			upgradeTitlesRight [tier].GetComponentInParent<Image>().enabled = false;
		} else {
		    upgradeTitlesLeft[tier].GetComponentInParent<Image>().enabled = false;
		    upgradeTitlesRight[tier].GetComponentInParent<Image>().enabled = true;
        }
	}
	void UncolorUpgrade(int tier){
	    upgradeTitlesLeft[tier].GetComponentInParent<Image>().enabled = false;
        upgradeTitlesRight[tier].GetComponentInParent<Image>().enabled = false;
    }

	void DisplayUnlockButtons(){
		int unlockLevel = Player.current.Units [currentUnitID].Level;
		for (int i = 0; i < BaseUnit.MaxLevel; i++) {
			if (i != unlockLevel) {
				unlockButtons [i].gameObject.SetActive (false);
			} else {
				unlockButtons [i].gameObject.SetActive (true);
			}
		}
	}

	void SetAbilityText(){
		for (int i = 0; i < upgradeTitlesLeft.Count; i++) {
			upgradeTitlesLeft[i].text = Player.current.Units[currentUnitID].upgrade.UpgradeTitleLeft [i];
			upgradeDescriptionLeft[i].text = Player.current.Units[currentUnitID].upgrade.UpgradeDescriptionLeft [i];
			upgradeTitlesRight[i].text = Player.current.Units[currentUnitID].upgrade.UpgradeTitleRight [i];
			upgradeDescriptionRight[i].text = Player.current.Units[currentUnitID].upgrade.UpgradeDescriptionRight [i];
		}

	}

	public void Unlock(){
		int currentUnlockCost = Player.current.Units [currentUnitID].upgrade.UpgradeCost [Player.current.Units [currentUnitID].Level];
		if (Player.current.Experience < currentUnlockCost) {
			//Display Can't buy animation
		} else {
			Player.current.SpentExperience (currentUnlockCost);
			experienceText.text = experienceBaseString + Player.current.Experience;
			Player.current.Units [currentUnitID].upgrade.UnlockLevel (Player.current.Units [currentUnitID]);
			//Lock left side upgrade
			LockUpdate(Player.current.Units[currentUnitID].Level,1);
			DisplayTalentTree ();
		}
	}

	void LockUpdate(int upgradeLevel, int side){
		if (Player.current.Units [currentUnitID].Level >= upgradeLevel) {
			Player.current.Units [currentUnitID].upgrade.ChooseUpgrade (upgradeLevel, side);
			DisplayTalentTree ();
		}
	}

	public void Back(){
		SaveLoad.SavePlayer();
		Data.currentData.LoadScene (Data.currentData.previousLevelName);
	}
}
