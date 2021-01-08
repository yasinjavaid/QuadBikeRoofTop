using UnityEngine;
using System.Collections;

public class HighSpeedDriving : MonoBehaviour {
	public float speedThreshold = 30;
	public float speedGainTime = 10;
	public float retrieveSpeedTime = 5;
	public float reqDistance;
	private bool islevelFinished = false;
	public UILabel distanceLbl;
	public UILabel speedLimitlbl;
	public UILabel timeLimitlbl;
	private float timer;
	private GameObject player;
	private bool isFirstTime = true;
	private GameObject Hud;
	private bool isSpeedAchieved=false;
	private VehicleStats stats;
	public UIFilledSprite distBar;
	void Awake(){
		if (!UserPrefs.isIncreaseDifficulty [UserPrefs.currentLevel - 1])
			return;
		
		reqDistance = UserPrefs.currentHighSpeedDrivingRequiredDistance + (UserPrefs.currentHighSpeedDrivingRequiredDistance * Constants.LEVEL_DIFFICULTY_INCREASE_RATIO);
		speedThreshold = UserPrefs.currentHighSpeedDrivingTargetSpeed + (UserPrefs.currentHighSpeedDrivingTargetSpeed * Constants.LEVEL_DIFFICULTY_INCREASE_RATIO);
		UserPrefs.currentHighSpeedDrivingTargetSpeed = speedThreshold;
		UserPrefs.currentHighSpeedDrivingRequiredDistance = reqDistance;
		UserPrefs.isIncreaseDifficulty [UserPrefs.currentLevel - 1] = false;
	}

	// Use this for initialization
	void Start () {
		timer = Time.time;
		speedLimitlbl.text = string.Format ("{0:00.0} KM/H", speedThreshold);
		player = GameObject.FindGameObjectWithTag ("Player2");
		Hud = GameObject.FindGameObjectWithTag ("Hud");
		Hud.GetComponent<HudStatus> ().Green.SetActive (true);
		Hud.GetComponent<HudStatus>().Green.GetComponent<UITexture>().color=Color.yellow;
		GAManager.Instance.LogDesignEvent("ModeStart::Episode"+UserPrefs.currentEpisode+"::HighSpeedDriving");
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player2");
			if(player == null)
				return;
		}

		if (!islevelFinished && GameManager.Instance.GetCurrentGameState () == GameManager.GameState.GAMEPLAY) {

			if (stats == null){
				stats = GameObject.FindObjectOfType<VehicleStats> ();
				if(stats == null)
					return;
			}
			//Hud.GetComponent<HudMenuLocalize>().DisableLowSpeedWarning();
//			if(isSpeedAchieved){
//			if(stats.Speed<speedThreshold)
//			{
//				if(!Hud.GetComponent<HudMenuLocalize>().speedThresholdless)
//					Hud.GetComponent<HudMenuLocalize>().ShowLowSpeedWarning();
//
//				if(Hud.GetComponent<HudMenuLocalize>().islevelFail)
//				{
//					player.GetComponent<WheelControllerGenericNew>().levelFailed(1);
//				}
//
//			}
//			else
//			{
//				if(Hud.GetComponent<HudMenuLocalize>().speedThresholdless)
//					Hud.GetComponent<HudMenuLocalize>().DisableLowSpeedWarning();
//			}
//			}
		
			distBar.fillAmount = 1 - (reqDistance - stats.Distance)/reqDistance;
			if (stats.Distance >= reqDistance) {
				islevelFinished = true;
				player.GetComponent<WheelControllerGenericNew> ().levelCompleted (1);
				distanceLbl.text = string.Format ("Remaining Distance {0:00.00} KM", 0);
				GAManager.Instance.LogDesignEvent("ModeComplete::Episode"+UserPrefs.currentEpisode+"::HighSpeedDriving");
			}
			else
			{
				distanceLbl.text = string.Format ("Remaining Distance {0:00.00} KM", (reqDistance - stats.Distance));
				if(stats.Speed >= speedThreshold)
				{
					timer = Time.time;
					isFirstTime = false;
					isSpeedAchieved=true;
					Hud.GetComponent<HudStatus>().DisableLowSpeedWarning();
					Hud.GetComponent<HudStatus>().Green.GetComponent<UITexture>().color=Color.green;
				}
				else
				{
					if(isFirstTime)
					{
						if(Time.time > timer + speedGainTime)
						{
							islevelFinished = true;
							if(player)
							player.GetComponent<WheelControllerGenericNew> ().levelFailed (1);
							distanceLbl.text =  string.Format("Remaining Distance {0:00.00} KM",0);
						}
						else
							//Hud.GetComponent<HudMenuLocalize>().ShowLowSpeedWarning();
							timeLimitlbl.text = string.Format("Gain Speed in {0:00.00} sec",(timer + speedGainTime)-Time.time);
					}
					else
					{
						if(Time.time > timer + retrieveSpeedTime)
						{
							islevelFinished = true;
							if(player)
							player.GetComponent<WheelControllerGenericNew> ().levelFailed (1);
							distanceLbl.text =  string.Format("Remaining Distance {0:00.00} KM",0);
						}
						else
						{
							Hud.GetComponent<HudStatus>().ShowLowSpeedWarning();
							Hud.GetComponent<HudStatus>().Green.GetComponent<UITexture>().color=Color.red;



							//iTween.ScaleFrom (Hud.GetComponent<HudMenuLocalize>().Red, iTween.Hash ("x", 160, "y", 160, "time", 1f, "isLocal", true, "easeType", iTween.EaseType.linear));

						}
						//	timeLimitlbl.text = string.Format("Gain Speed in {0:00.00} sec",(timer + retrieveSpeedTime)-Time.time);
					}
				}

			}
		}
	}

}
