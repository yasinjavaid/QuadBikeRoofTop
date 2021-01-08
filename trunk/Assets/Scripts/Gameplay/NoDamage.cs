using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class NoDamage : MonoBehaviour {
	public float requiredDistance;
	static float timer;
	public UILabel remainingDistancelbl;
	private bool isLevelFinished = false;
	private GameObject player;
	private VehicleStats stats;
	public UIFilledSprite distanceBar;

	void Awake(){
		if (!UserPrefs.isIncreaseDifficulty [UserPrefs.currentLevel - 1])
			return;

		requiredDistance = UserPrefs.currentNoDamageRequiredDistance + (UserPrefs.currentNoDamageRequiredDistance * Constants.LEVEL_DIFFICULTY_INCREASE_RATIO);
		UserPrefs.currentNoDamageRequiredDistance = requiredDistance;
		UserPrefs.isIncreaseDifficulty [UserPrefs.currentLevel - 1] = false;
	}

	// Use this for initialization
	void Start () {
		if(GameObject.FindGameObjectWithTag ("NoDemage"))
			GAManager.Instance.LogDesignEvent("ModeStart::Episode"+UserPrefs.currentEpisode+"::NoDamage");
		else
			GAManager.Instance.LogDesignEvent("ModeStart::Episode"+UserPrefs.currentEpisode+"::AvoidObstacles");
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (!player)
			player = GameObject.FindGameObjectWithTag ("Player2");
		if (stats == null){
			stats = GameObject.FindObjectOfType<VehicleStats> ();
			if(stats == null)
				return;
		}
		distanceBar.fillAmount = 1 - (requiredDistance - stats.Distance)/requiredDistance;
		if (stats.Distance >= requiredDistance && GameManager.Instance.GetCurrentGameState () == GameManager.GameState.GAMEPLAY && !isLevelFinished) {
			isLevelFinished = true;
			if(GameObject.FindGameObjectWithTag ("NoDemage"))
				GAManager.Instance.LogDesignEvent("ModeComplete::Episode"+UserPrefs.currentEpisode+"::NoDamage");
			else
				GAManager.Instance.LogDesignEvent("ModeComplete::Episode"+UserPrefs.currentEpisode+"::AvoidObstacles");
			player.GetComponent<WheelControllerGenericNew> ().levelCompleted (1);

		} else if (GameManager.Instance.GetCurrentGameState () == GameManager.GameState.GAMEPLAY && !isLevelFinished) {
			remainingDistancelbl.text = string.Format("Remaining Distance {0:00.00} KM",(requiredDistance - stats.Distance));
		} else
			remainingDistancelbl.text = " ";
	
	}
}
