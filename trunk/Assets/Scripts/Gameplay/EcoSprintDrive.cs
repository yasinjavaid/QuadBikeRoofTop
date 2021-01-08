using UnityEngine;
using System.Collections;

public class EcoSprintDrive : MonoBehaviour {

	public enum LevelType
	{
		SPRINT,
		ECO
	}
	public LevelType levelType;
	public float reqTime;
	public float reqFuel;
	public float reqDistance;
	private bool islevelFinished = false;
	public UILabel distanceLbl;
	public UILabel fuelTimelbl;
	private float fuelRatio = 5;
	private GameObject player;
	private VehicleStats stats;
	float timer;
	public UISlider fuelBar;
	public UIFilledSprite distanceBar;
	public UIFilledSprite timeBar;
	float fuel;

	void Awake(){

		if (!UserPrefs.isIncreaseDifficulty [UserPrefs.currentLevel - 1])
			return;

		if (levelType == LevelType.ECO) {
			reqDistance = UserPrefs.currentEcoDriveDistance + (UserPrefs.currentEcoDriveDistance * Constants.LEVEL_DIFFICULTY_INCREASE_RATIO);
			reqFuel = UserPrefs.currentEcoDriveFuel + (UserPrefs.currentEcoDriveFuel * Constants.LEVEL_DIFFICULTY_INCREASE_RATIO);
			UserPrefs.currentEcoDriveDistance = reqDistance;
			UserPrefs.currentEcoDriveFuel = reqFuel;
//			fuelBar.gameObject.SetActive(true);
		} else {
			reqDistance = UserPrefs.currentSprintDriveDistance + (UserPrefs.currentSprintDriveDistance * Constants.LEVEL_DIFFICULTY_INCREASE_RATIO);
			reqTime = UserPrefs.currentSprintDriveTime + (UserPrefs.currentSprintDriveTime * Constants.LEVEL_DIFFICULTY_INCREASE_RATIO);
			UserPrefs.currentSprintDriveDistance = reqDistance;
			UserPrefs.currentSprintDriveTime = reqTime;
//			timeBar.gameObject.SetActive(true);
		}

		UserPrefs.isIncreaseDifficulty [UserPrefs.currentLevel - 1] = false;
	}

	// Use this for initialization
	void Start () {
		timer = Time.time;
		fuel = reqFuel;

		if(levelType == LevelType.ECO)
			GAManager.Instance.LogDesignEvent("ModeStart::Episode"+UserPrefs.currentEpisode+"::ECODrive");
		else
			GAManager.Instance.LogDesignEvent("ModeStart::Episode"+UserPrefs.currentEpisode+"::Sprint");
		if (levelType == LevelType.ECO) {
//			fuelBar.gameObject.SetActive(true);
		} else {
//			timeBar.gameObject.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (player == null)
			player = GameObject.FindGameObjectWithTag ("Player2");
		if (!islevelFinished && GameManager.Instance.GetCurrentGameState() == GameManager.GameState.GAMEPLAY) {
			if (stats == null){
				stats = GameObject.FindObjectOfType<VehicleStats> ();
				if(stats == null)
					return;
			}
			distanceBar.fillAmount =  1 - (reqDistance - stats.Distance)/reqDistance;
//			if(stats.Distance < reqDistance)
//			{
//				distanceLbl.text =  string.Format("Remaining Distance {0:00.00} KM",(reqDistance - stats.Distance));
//			}
//			else
//			{
//				distanceLbl.text =  string.Format("Remaining Distance {0:00.00} KM",0);
//			}
			if(stats.Distance >= reqDistance)
			{
				islevelFinished = true;
				player.GetComponent<WheelControllerGenericNew> ().levelCompleted (1);
				if(levelType == LevelType.ECO)
					GAManager.Instance.LogDesignEvent("ModeComplete::Episode"+UserPrefs.currentEpisode+"::ECODrive");
				else
					GAManager.Instance.LogDesignEvent("ModeComplete::Episode"+UserPrefs.currentEpisode+"::Sprint");
			}
			else
			{
				if(levelType == LevelType.ECO)
				{
					fuelBar.sliderValue = 1 - (fuel-reqFuel)/fuel;
					reqFuel = reqFuel - Time.deltaTime/fuelRatio;
					if(UserPrefs.currentFuel % 360 >= 76 && UserPrefs.currentFuel % 360 <= 77)
					{
						islevelFinished = true;
						player.GetComponent<WheelControllerGenericNew> ().levelFailed (1);
						fuelTimelbl.text = "Failed";
					}
//					else
//					{
//						fuelTimelbl.text = string.Format("Remaining Fuel {0:00.0} Litres" , reqFuel);
//					}
				}
				else if(levelType == LevelType.SPRINT)
				{
					timeBar.fillAmount = ((timer + reqTime)-Time.time)/reqTime;
					if(Time.time >= timer + reqTime)
					{
						islevelFinished = true;
						player.GetComponent<WheelControllerGenericNew> ().levelFailed (1);
						fuelTimelbl.text = "Failed";
					}
					else
					{
						fuelTimelbl.text = string.Format("Remaining Time {0:00.0} sec" , (timer + reqTime)-Time.time);
					}
				}
			}
		}
	
	}
}
