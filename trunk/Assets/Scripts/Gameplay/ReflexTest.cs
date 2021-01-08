using UnityEngine;
using System.Collections;

public class ReflexTest : MonoBehaviour {
	
	[HideInInspector]
	public bool isTriggerEntered = false;
	float timeBeforeBrakePressed = 0;

	public UILabel bestReflexTime;
	public UILabel currentReflexTime;

	// Use this for initialization
	void Start () {
		bestReflexTime.text = string.Format("{0:00.00} sec",UserPrefs.bestReflexTime);
		currentReflexTime.gameObject.SetActive (false);
	
		GAManager.Instance.LogDesignEvent("ModeStart::Episode"+UserPrefs.currentEpisode+"::ReflexTest");
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (isTriggerEntered) {
			currentReflexTime.gameObject.SetActive (true);
			timeBeforeBrakePressed += Time.deltaTime;
			currentReflexTime.text = string.Format("{0:00.00} sec",timeBeforeBrakePressed);
			if(HudListener.isBrakePressed){
				isTriggerEntered = false;
				if(timeBeforeBrakePressed < UserPrefs.bestReflexTime){
					UserPrefs.bestReflexTime = timeBeforeBrakePressed;
					UserPrefs.SaveTopSpeed();
					bestReflexTime.text = string.Format("{0:00.00} sec",UserPrefs.bestReflexTime);
				}
				GAManager.Instance.LogDesignEvent("ModeComplete::Episode"+UserPrefs.currentEpisode+"::ReflexTest");
				GameObject.FindObjectOfType<WheelControllerGenericNew> ().levelCompleted (4);
			}
		}
	}
}
