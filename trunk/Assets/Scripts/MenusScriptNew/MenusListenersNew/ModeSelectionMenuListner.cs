using UnityEngine;
using System.Collections;

public class ModeSelectionMenuListner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		if (this.name.Equals ("nextBtn")) {
			UserPrefs.currentLevel = this.transform.root.GetComponent<ModeSelectionMenuStatus>().currentMode + 1;
			logGaEvent();
			if (UserPrefs.currentLevel - 1 >= UserPrefs.unlockLevelsArrays [UserPrefs.currentEpisode - 1]) {
				return;
			}

			if(PlayerPrefs.GetInt("isFirstTime",0) != 1){
				Instantiate(Resources.Load("SubMenusNew/LevelSettingsPopup"));
				GameManager.Instance.ChangeState(GameManager.GameState.INTRO);
			}
			else
				MenuManager.Instance.SwitchNextMenu();	
		}else if (this.name.Equals ("btnPrevious")) {
			this.transform.root.GetComponent<ModeSelectionMenuStatus>().PreviousMode();
		}else if (this.name.Equals ("btnNext")) {
			this.transform.root.GetComponent<ModeSelectionMenuStatus>().NextMode();
		}else if (this.name.Equals ("backBtn")) {
			MenuManager.Instance.SwitchPreviousMenu();
		}
	}
	void logGaEvent()
	{
		switch (UserPrefs.currentLevel) {
		case 10:
			GAManager.Instance.LogDesignEvent("ModeSelectionMenu::Episode"+UserPrefs.currentEpisode+"::AvoidObstaclesSelected");
			break;
		case 1:
			GAManager.Instance.LogDesignEvent("ModeSelectionMenu::Episode"+UserPrefs.currentEpisode+"::FreeRideSelected");
			break;
		case 2:
			GAManager.Instance.LogDesignEvent("ModeSelectionMenu::Episode"+UserPrefs.currentEpisode+"::HighSpeedDrivingSelected");
			break;
		case 3:
			GAManager.Instance.LogDesignEvent("ModeSelectionMenu::Episode"+UserPrefs.currentEpisode+"::ECODriveSelected");
			break;
		case 4:
			GAManager.Instance.LogDesignEvent("ModeSelectionMenu::Episode"+UserPrefs.currentEpisode+"::CheckpointsSelected");
			break;
		case 5:
			GAManager.Instance.LogDesignEvent("ModeSelectionMenu::Episode"+UserPrefs.currentEpisode+"::NoDamageSelected");
			break;
		case 6:
			GAManager.Instance.LogDesignEvent("ModeSelectionMenu::Episode"+UserPrefs.currentEpisode+"::ReflexTestSelected");
			break;
		case 7:
			GAManager.Instance.LogDesignEvent("ModeSelectionMenu::Episode"+UserPrefs.currentEpisode+"::SpeedCamerasSelected");
			break;
		case 8:
			GAManager.Instance.LogDesignEvent("ModeSelectionMenu::Episode"+UserPrefs.currentEpisode+"::TopSpeedSelected");
			break;
		case 9:
			GAManager.Instance.LogDesignEvent("ModeSelectionMenu::Episode"+UserPrefs.currentEpisode+"::SprintSelected");
			break;
			
		}
	}

}
