using UnityEngine;
using System.Collections;

public class LevelSelectionMenuListnerNew : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		if(this.gameObject.name.Equals("btnBack")){
			MenuManager.Instance.SwitchPreviousMenu();
		}else if(this.gameObject.name.Equals("btnCoinsUpLeft")){
			Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.STORE);
		}else if(this.gameObject.CompareTag("btnLevel")){
			UserPrefs.currentLevel = int.Parse(this.gameObject.name);
			GAManager.Instance.LogDesignEvent("LevelSelectionMenu::Episode"+UserPrefs.currentEpisode+"::Level"+UserPrefs.currentLevel);
			if(PlayerPrefs.GetInt("isFirstTime",0) != 1)
				Instantiate(Resources.Load("SubMenusNew/LevelSettingsPopup"));
			else
				MenuManager.Instance.SwitchNextMenu();	
		}
	}
}
