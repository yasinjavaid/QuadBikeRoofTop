using UnityEngine;
using System.Collections;

public class TopSpeed : MonoBehaviour {

	public float timeToBeatTopSpeed = 50;
	public UILabel lblTopSpeed;
	public UILabel lblRemainingTime;
	public UIFilledSprite timeBar;
	float tempTime;
	VehicleStats stats;
	bool isTopSpeedAchieved = false;
	bool isLevelFailedOrCompleted = false;

	void Awake(){
		if (!UserPrefs.isIncreaseDifficulty [UserPrefs.currentLevel - 1])
			return;
		
		timeToBeatTopSpeed = UserPrefs.currentTimeToBeatTopSpeed - (UserPrefs.currentTimeToBeatTopSpeed * Constants.LEVEL_DIFFICULTY_INCREASE_RATIO);
		timeToBeatTopSpeed = timeToBeatTopSpeed < 20 ? 20 : timeToBeatTopSpeed;
		UserPrefs.currentTimeToBeatTopSpeed = timeToBeatTopSpeed;
		UserPrefs.isIncreaseDifficulty [UserPrefs.currentLevel - 1] = false;
	}

	// Use this for initialization
	void Start () {
		stats = GameObject.FindObjectOfType<VehicleStats> ();
		lblRemainingTime.text = string.Format("Remaining time: {0:00.00} sec",timeToBeatTopSpeed);
		lblTopSpeed.text = string.Format ("{0:00.0} KM/H", UserPrefs.topSpeed);
		GAManager.Instance.LogDesignEvent("ModeStart::Episode"+UserPrefs.currentEpisode+"::TopSpeed");
		tempTime = timeToBeatTopSpeed;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (isLevelFailedOrCompleted)
			return;
		timeBar.fillAmount = timeToBeatTopSpeed /tempTime;

		timeToBeatTopSpeed -= Time.deltaTime;
		lblRemainingTime.text = string.Format("Remaining time: {0:00.00} sec",timeToBeatTopSpeed);
		if (stats == null) {
			stats = GameObject.FindObjectOfType<VehicleStats> ();
			if(stats == null)
				return;
		}
		if (stats.Speed >= UserPrefs.topSpeed) {
			UserPrefs.topSpeed = stats.Speed;
			UserPrefs.SaveTopSpeed();
			isTopSpeedAchieved = true;
			isLevelFailedOrCompleted = true;
			GameObject.FindObjectOfType<WheelControllerGenericNew>().levelCompleted(1);
		}

		if (timeToBeatTopSpeed <= 0) {
			lblRemainingTime.text = string.Format("Remaining time: {0:00.00} sec",0);
			isLevelFailedOrCompleted = true;
			if(isTopSpeedAchieved){
				GAManager.Instance.LogDesignEvent("ModeComplete::Episode"+UserPrefs.currentEpisode+"::TopSpeed");
				GameObject.FindObjectOfType<WheelControllerGenericNew>().levelCompleted(1);

			}else{
				GameObject.FindObjectOfType<WheelControllerGenericNew>().levelFailed(1);
			}
		}
	}
}
