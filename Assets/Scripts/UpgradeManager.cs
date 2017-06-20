using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeManager : MonoBehaviour {

	public List<GameObject> displayUnits;
	private int currentUnitID = 0;
	private GameObject currentShownUnit;

	public Text experienceText;
	private string experienceBaseString = "Experience:\n";

	public GameObject ShowTile;
	public GameObject arrowLeft;
	Animation arrowLeftAnimation;
	public GameObject arrowRight;
	Animation arrowRightAnimation;

	//UpgradetreeText
	public List<Text> upgradeTitlesLeft = new List<Text>();
	public List<Text> upgradeDescriptionLeft = new List<Text>();
	public List<Text> upgradeTitlesRight = new List<Text>();
	public List<Text> upgradeDescriptionRight = new List<Text>();
	public List<Button> unlockButtons = new List<Button>();

	// Use this for initialization
	void Start () {
		arrowLeftAnimation = arrowLeft.GetComponent<Animation>();
		arrowRightAnimation = arrowRight.GetComponent<Animation> ();
		DisplayUnit (ShowTile, currentUnitID);
		experienceText.text = experienceBaseString + Player.current.Experience;
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
			}
		}
		if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
			StartCoroutine(LastUnit ());
		}else if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)){
			StartCoroutine(NextUnit ());
		}

	}
	IEnumerator NextUnit(){
		if (currentUnitID < displayUnits.Count-1) {
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
			//Display "Cannot next" animation
		}
	}


	void DisplayUnit(GameObject spawnOnTile, int unitID){
		if (currentShownUnit != null) {
			Destroy (currentShownUnit);
		}
		Vector3 position = new Vector3 (spawnOnTile.transform.position.x, displayUnits[unitID].transform.position.y, spawnOnTile.transform.position.z);
		GameObject tmpUnit = Instantiate (displayUnits[unitID], position, Quaternion.identity * Quaternion.Euler(0,25,0));
		tmpUnit.GetComponent<Unit> ().Setup (spawnOnTile);
		currentShownUnit = tmpUnit;
		DisplayTalentTree ();
	}

	public void DisplayTalentTree(){
		//Talent Tree enables spending experience points to unlock permanent powerups
		//Enable Talent Tree (Unlock buttons)
		DisplayUnlockButtons();
		//Enable Back Button
		SetAbilityText ();
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
			Player.current.Units [currentUnitID].upgrade.UnlockLevel ();
			DisplayTalentTree ();
			//unlock the next row
		}
	}

	public void Back(){
		//SaveLoad.Save();
		SceneManager.LoadScene ("MainMenu");
	}
}
