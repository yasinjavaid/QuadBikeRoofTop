using UnityEngine;
using System.Collections;

public class ModeSelectionMenuStatus : MonoBehaviour {

	public GameObject modeSelectionPanel;
	public UILabel modeNameLabel;
	public UILabel modeDescriptionLabel;
	public UISprite modeSprite;
	public UISprite lockedSprite;
	public GameObject newModeUnlockedLabel;
	public UILabel coinsLabel;
	public GameObject nextBtn;
	public GameObject previosBtn;

	string [] modeNames = {"FREE RIDE", "HIGH SPEED DRIVE", "ECO DRIVE", "CHECKPOINTS","NO DAMAGE","SPEED CAMERA","TOP SPEED","SPRINT","REFLEX TEST","AVOID OBSTACLES"};
	string [] modeDescroptions = {"DRIVE AS FAR AS YOU CAN !","DONT GO BELOW {0:00.0}KM/H","DRIVE FOR {0:00.00}KM WITH GIVEN FUEL","COLLECT CHECKPOINTS IN GIVEN TIME","DRIVE FOR {0:00.00}KM WITHOUT CRASHING!","PASS TRHOUGH SPEED CAMERA WITH SPEED OF {0:00.0}KM/H","BEAT YOUR TOP SPEED, BEST {0:00.0}KM/H","COVER {0:00.00}KM IN GIVEN TIME","TEST YOUR BRAKING REFLEX, BEST {0:00.0}SECONDS","AVOID THE OBSTABLCES FOR {0:00.00}KM"};
	string[] spriteNames = {"free-ride","high-speed-driving","ECO-Driving","check-point","No-damage","speed-cameras","top-speed","sprint","reflex-test","avoid-obstacles"};

	[HideInInspector]
	public int currentMode = 0;
	int totalModes = 8;

	// Use this for initialization
	void Start () {
		if (UserPrefs.isModeUnlocked) {
			newModeUnlockedLabel.SetActive(true);
			UserPrefs.isModeUnlocked = false;
			currentMode = UserPrefs.unlockLevelsArrays [UserPrefs.currentEpisode - 1] - 1;
		}
		SetMenuStatus ();
	}
	
	// Update is called once per frame
	void Update () {
		coinsLabel.GetComponent<UILabel>().text = string.Format("{0:#,###0}", UserPrefs.totalCoins);
	}

	public void NextMode(){
		if (currentMode == totalModes - 1) {
			return;
		}
		currentMode++;
		SetMenuStatus ();
		modeSelectionPanel.transform.localPosition = new Vector3 (0, 0, 0);
		iTween.MoveFrom(modeSelectionPanel,iTween.Hash("x",900,"time",1,"isLocal",true));
	}

	public void PreviousMode(){
		if (currentMode == 0) {
			return;
		}
		currentMode--;
		SetMenuStatus ();
		modeSelectionPanel.transform.localPosition = new Vector3 (0, 0, 0);
		iTween.MoveFrom(modeSelectionPanel,iTween.Hash("x",-900,"time",1,"isLocal",true));
	}

	void SetMenuStatus(){
		if (currentMode == 0) {
			previosBtn.SetActive (false);
		} else {
			previosBtn.SetActive(true);
		}

		if (currentMode == totalModes - 1) {
			nextBtn.SetActive (false);
		} else {
			nextBtn.SetActive(true);
		}

		modeNameLabel.text = modeNames [currentMode];
		SetModeStatus ();
		modeSprite.spriteName = spriteNames [currentMode];
		if (currentMode >= UserPrefs.unlockLevelsArrays [UserPrefs.currentEpisode - 1]) {
			lockedSprite.gameObject.SetActive (true);
		} else {
			lockedSprite.gameObject.SetActive (false);
		}
	}

	void SetModeStatus(){
		switch (currentMode) {
		case 0:
			modeDescriptionLabel.text = modeDescroptions[currentMode];
			break;
		case 4:
			modeDescriptionLabel.text = string.Format(modeDescroptions[currentMode],UserPrefs.isIncreaseDifficulty[currentMode] ? UserPrefs.currentNoDamageRequiredDistance + (UserPrefs.currentNoDamageRequiredDistance * Constants.LEVEL_DIFFICULTY_INCREASE_RATIO) : UserPrefs.currentNoDamageRequiredDistance);
			break;
		case 2:
			modeDescriptionLabel.text = string.Format(modeDescroptions[currentMode],UserPrefs.isIncreaseDifficulty[currentMode] ? UserPrefs.currentEcoDriveDistance + (UserPrefs.currentEcoDriveDistance * Constants.LEVEL_DIFFICULTY_INCREASE_RATIO) : UserPrefs.currentEcoDriveDistance);
			break;
		case 3:
			modeDescriptionLabel.text = modeDescroptions[currentMode];
			break;
		case 1:
			modeDescriptionLabel.text = string.Format(modeDescroptions[currentMode],UserPrefs.isIncreaseDifficulty[currentMode] ? UserPrefs.currentHighSpeedDrivingTargetSpeed + (UserPrefs.currentHighSpeedDrivingTargetSpeed * Constants.LEVEL_DIFFICULTY_INCREASE_RATIO) : UserPrefs.currentHighSpeedDrivingTargetSpeed);
			break;
		case 5:
			modeDescriptionLabel.text = string.Format(modeDescroptions[currentMode],UserPrefs.bestReflexTime);
			break;
		case 6:
			modeDescriptionLabel.text = string.Format(modeDescroptions[currentMode],UserPrefs.isIncreaseDifficulty[currentMode] ? UserPrefs.currentSpeedCameraTargetSpeed + (UserPrefs.currentSpeedCameraTargetSpeed * Constants.LEVEL_DIFFICULTY_INCREASE_RATIO) : UserPrefs.currentSpeedCameraTargetSpeed);
			break;
		case 7:
			modeDescriptionLabel.text = string.Format(modeDescroptions[currentMode],UserPrefs.topSpeed);
			break;
		case 8:
			modeDescriptionLabel.text = string.Format(modeDescroptions[currentMode],UserPrefs.isIncreaseDifficulty[currentMode] ? UserPrefs.currentSprintDriveDistance + (UserPrefs.currentSprintDriveDistance * Constants.LEVEL_DIFFICULTY_INCREASE_RATIO) : UserPrefs.currentSprintDriveDistance);
			break;
		case 9:
			modeDescriptionLabel.text = string.Format(modeDescroptions[currentMode],UserPrefs.isIncreaseDifficulty[currentMode] ? UserPrefs.currentNoDamageRequiredDistance + (UserPrefs.currentNoDamageRequiredDistance * Constants.LEVEL_DIFFICULTY_INCREASE_RATIO) : UserPrefs.currentNoDamageRequiredDistance);
			break;
		}
	}

	void OnCompleteScaleAnimation(){
		newModeUnlockedLabel.SetActive (false);
	}
}
