using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	//This class needs to loadData, saveData, go to upgrade Screen, go to battleselect screen, goToOptions, Endgame
	//Display a looping animation of tiles, obstacles and units in the background

	Player player = null;

	// Use this for initialization
	void Start () {
		LoadData ();
		Time.timeScale = 1;
		//SaveData ();

		/*Display some cool stuff in the background
		Vector3 position = new Vector3 (0f, Data.currentData.units[0].transform.position.y, 0f);
		GameObject tmpUnit = Instantiate (Data.currentData.units[0], position, Quaternion.identity * Quaternion.Euler(0,25,0));
		StartCoroutine (MoveBackground (tmpUnit));
		*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadData(){
		Data.currentData = this.gameObject.GetComponent<Data> ();
		Debug.Log ("Load");
		SaveLoad.LoadPlayer ();
		if (SaveLoad.savedPlayers.Count != 0) {
			//Insert a way to specify, which player should be loaded
			player = SaveLoad.savedPlayers [0];
		} else {
			Debug.Log ("No saved player found");
			player = new Player ();
			player.SetupNewPlayer (Data.currentData.units);
			player.Experience = 20000;
		}
		Player.current = player;
	}
	void SaveData(){
		Debug.Log ("Save");
		SaveLoad.SavePlayer ();
	}
	public void GoToUpgradeScreen(){
		SceneManager.LoadScene ("UpgradeScene");
	}
	public void GoToBattleSelectScreen(){
		SceneManager.LoadScene ("UnitSelectScene");
	}
	public void GoToOptions(){
		
	}

	IEnumerator MoveBackground(GameObject go){
		do {
			go.transform.Translate(new Vector3(0.3f * Time.deltaTime,0f, 0.1f*Time.deltaTime));
			yield return new WaitForSeconds (Time.deltaTime);
		} while(go.transform.position.x < 100);

	}
}
