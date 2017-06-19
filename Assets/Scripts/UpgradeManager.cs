using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

	private int currentUnitID = 0;
	private GameObject currentShownUnit;

	public Text experienceText;

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
		//experienceText.text = "Experience: " + Player.current.Experience;
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
		}//Upgrade
		else if(Input.GetKeyDown(KeyCode.U)){
			DisplayTalentTree();
		}

	}
	IEnumerator NextUnit(){
		if (currentUnitID < Player.current.Units.Count-1) {
			Debug.Log ("Next unit");
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
			Debug.Log ("Last unit");
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
		Vector3 position = new Vector3 (spawnOnTile.transform.position.x, Player.current.Units[unitID].transform.position.y, spawnOnTile.transform.position.z);
		GameObject tmpUnit = Instantiate (Player.current.Units[unitID], position, Quaternion.identity * Quaternion.Euler(0,25,0));
		tmpUnit.GetComponent<Unit> ().Setup (spawnOnTile);
		currentShownUnit = tmpUnit;
	}

	public void DisplayTalentTree(){
		//Display Talent Tree
		Debug.Log("Show Talent Tree");
		//Talent Tree enables spending experience points to unlock permanent powerups

		//Enable Talent Tree (Unlock buttons)
		DisplayUnlockButtons();
		//Enable Back Button

	}

	void DisplayUnlockButtons(){
		int unlockLevel = Player.current.Units [currentUnitID].UnlockLevel;
		unlockButtons [unlockLevel].gameObject.SetActive (true);
	}
}
