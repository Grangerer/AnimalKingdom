using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

	public List<GameObject> units;
	private int currentUnitID = 0;
	private GameObject currentShownUnit;

	public Text experienceText;

	public GameObject ShowTile;
	public GameObject arrowLeft;
	Animation arrowLeftAnimation;
	public GameObject arrowRight;
	Animation arrowRightAnimation;
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
			ShowTalentTree();
		}

	}
	IEnumerator NextUnit(){
		if (currentUnitID < units.Count-1) {
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
		Vector3 position = new Vector3 (spawnOnTile.transform.position.x, units[unitID].transform.position.y, spawnOnTile.transform.position.z);
		GameObject tmpUnit = Instantiate (units[unitID], position, Quaternion.identity * Quaternion.Euler(0,25,0));
		tmpUnit.GetComponent<Unit> ().Setup (spawnOnTile);
		currentShownUnit = tmpUnit;
	}

	public void ShowTalentTree(){
		//Display Talent Tree
		Debug.Log("Show Talent Tree");
		//Talent Tree enables spending experience points to unlock permanent powerups
		//Disable Arrows
		arrowLeft.SetActive(false);
		arrowRight.SetActive (false);
		//Enable Talent Tree (Unlock buttons)
		//Enable Back Button

	}
		
}
