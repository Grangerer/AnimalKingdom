using UnityEngine;
using UnityEngine.UI;

public class LevelSelecter : MonoBehaviour {

    public Button[] levelButtons;

    void Start() {

		int levelReached = Player.current.UnlockedLevel;

		Color32 lockedColor = new Color32 (100, 100, 100,100);
        for (int i = levelReached; i < levelButtons.Length; i++) {
            levelButtons[i].interactable = false;
			levelButtons[i].GetComponent<Image>().color = lockedColor;
        }
		
    }

    public void Select(int levelID) {
		Data.currentData.ChosenLevel.LoadLevel (levelID);
		Data.currentData.LoadScene ("UnitSelectScene");
    }
}
