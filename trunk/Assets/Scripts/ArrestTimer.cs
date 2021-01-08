using UnityEngine;
using System.Collections;

public class ArrestTimer : MonoBehaviour {

	// Use this for initialization
//	public GameObject timerPanel;
//	bool isTimer = false;
//	float timer;
//	void Start () {
//		timerPanel.SetActive (false);
//		if(Constants.levelType[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1] == 1)
//		{
//			timerPanel.SetActive(true);
//			timer = Constants.thiefChaseTime;
//			isTimer = true;
//		}
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		if(isTimer)
//		{
//			timerPanel.GetComponentInChildren<UILabel>().text = Mathf.RoundToInt(timer).ToString();
//			timer = timer-Time.deltaTime;
//			if(timer <  0)
//			{
//				isTimer = false;
//				GameObject.FindGameObjectWithTag("Player2").GetComponent<WheelControllerGeneric>().LevelFailed();
//			}
//		}
//	}
}
