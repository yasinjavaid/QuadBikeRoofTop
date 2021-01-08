using UnityEngine;
using System.Collections;

public class BoundaryCheck : MonoBehaviour {

	// Use this for initialization
	public GameObject brakeArrow;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerExit(Collider other)
	{

		if (other.gameObject.tag == "Player2"&&UserPrefs.PersonKilled&&UserPrefs.currentEpisode==1&&UserPrefs.currentLevel==1) {
			UserPrefs.islevel4=true;
			UserPrefs.isTutorial=false;
			UserPrefs.PersonKilled=false;
			brakeArrow.SetActive(true);
			Time.timeScale=0;
			
		}

	}
}
