using UnityEngine;
using System.Collections;

public class ThiefEscapedLocalize : MonoBehaviour {

	public UILabel lblCrashedTitle;
	public UILabel lblDescription;
	
	/*
	public UILabel lblEarnedCoins;
	public UILabel lblMilesCleared;
	public UILabel lblMilestext;
	public UILabel lblMilesWithSlash;
	public UILabel lblProgress;
	public UILabel lblSpotsPassed;
	public UILabel lblSpotsPassed2Text;
	public UILabel lblSpotsPassedText;
	public UILabel lblTotaloutOfMiles;
	public UILabel lblBtnContinue;
	public UILabel lblCoinsText;
	*/
	// Use this for initialization
	void Start () {
			
//		GAManager.Instance.LogDesignEvent("thiefescaped:"+"Level"+UserPrefs.currentLevel+"Episode"+UserPrefs.currentEpisode);
		
		if (GameObject.FindGameObjectWithTag("Thief")!=null && GameObject.FindGameObjectWithTag("Player")!=null){				  	
			float distance = Vector3.Distance(GameObject.FindGameObjectWithTag("Thief").transform.position,GameObject.FindGameObjectWithTag("Player").transform.position);
			if(distance<15){
				lblDescription.GetComponent<UILabel>().text = Localization.instance.Get("LblEscapedCloseDescription");	
			}
			else{
				lblDescription.GetComponent<UILabel>().text = Localization.instance.Get("LblEscapedFarDescription");
			}	
		/*
		lblCrashedTitle.GetComponent<UILabel>().text = Localization.instance.Get("LblEscapedTitleLevelEscapeMenuNew");
		lblEarnedCoins.GetComponent<UILabel>().text = Localization.instance.Get("LblEarnedCoinsLevelCrashMenuNew");
		lblMilesCleared.GetComponent<UILabel>().text = Localization.instance.Get("LblMilesClearedLevelCrashMenuNew");
		lblMilestext.GetComponent<UILabel>().text = Localization.instance.Get("LblMilestextLevelCrashMenuNew");
		lblMilesWithSlash.GetComponent<UILabel>().text = Localization.instance.Get("LblMilesWithSlashLevelCrashMenuNew");
		lblProgress.GetComponent<UILabel>().text = Localization.instance.Get("LblProgressLevelCrashMenuNew");
		lblSpotsPassed.GetComponent<UILabel>().text = (UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]).ToString();
		
		lblSpotsPassedText.GetComponent<UILabel>().text = Localization.instance.Get("LblSpotsPassedTextLevelCrashMenuNew");
		lblSpotsPassed2Text.GetComponent<UILabel>().text = Localization.instance.Get("LblSpotsPassed2TextLevelCrashMenuNew");
		lblTotaloutOfMiles.GetComponent<UILabel>().text = Localization.instance.Get("LblTotaloutOfMilesLevelCrashMenuNew");
		lblBtnContinue.GetComponent<UILabel>().text = Localization.instance.Get("LblBtnContinueLevelCrashMenuNew");
		lblCoinsText.GetComponent<UILabel>().text = Localization.instance.Get("LblCoinsTextLevelCrashMenuNew");
		*/
	}
}
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
