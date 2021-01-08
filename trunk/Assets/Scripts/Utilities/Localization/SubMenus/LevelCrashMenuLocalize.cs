﻿using UnityEngine;
using System.Collections;

public class LevelCrashMenuLocalize : MonoBehaviour {
	public UILabel lblCrashedTitle;
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
	// Use this for initialization
	void Start () {

		GAManager.Instance.LogDesignEvent("LevelFail::"+"Episode"+UserPrefs.currentEpisode+"::Level"+UserPrefs.currentLevel);
		if(UserPrefs.PersonKilled)
		{
			lblCrashedTitle.GetComponent<UILabel>().text = Localization.instance.Get("LblKilledTitleLevelCrashMenuNew");
			UserPrefs.PersonKilled=false;		
		}
		else
			lblCrashedTitle.GetComponent<UILabel>().text = Localization.instance.Get("LblCrashedTitleLevelCrashMenuNew");



		lblEarnedCoins.GetComponent<UILabel>().text = Localization.instance.Get("LblEarnedCoinsLevelCrashMenuNew");
		lblMilesCleared.GetComponent<UILabel>().text = Localization.instance.Get("LblMilesClearedLevelCrashMenuNew");
		lblMilestext.GetComponent<UILabel>().text = Localization.instance.Get("LblMilestextLevelCrashMenuNew");
		lblMilesWithSlash.GetComponent<UILabel>().text = Localization.instance.Get("LblMilesWithSlashLevelCrashMenuNew");
		if(UserPrefs.crashCause == 2)
		{
			lblProgress.GetComponent<UILabel>().text = Localization.instance.Get("LblProgressLevelCrashMenuNew2");
	
		}
		else if(UserPrefs.crashCause == 3)
		{
			lblProgress.GetComponent<UILabel>().text = Localization.instance.Get("LblProgressLevelCrashMenuNew3");

		}
		else
			lblProgress.GetComponent<UILabel>().text = Localization.instance.Get("LblProgressLevelCrashMenuNew");

		lblSpotsPassed.GetComponent<UILabel>().text = (UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]).ToString();
		
		lblSpotsPassedText.GetComponent<UILabel>().text = Localization.instance.Get("LblSpotsPassedTextLevelCrashMenuNew");
		lblSpotsPassed2Text.GetComponent<UILabel>().text = Localization.instance.Get("LblSpotsPassed2TextLevelCrashMenuNew");
		lblTotaloutOfMiles.GetComponent<UILabel>().text = Localization.instance.Get("LblTotaloutOfMilesLevelCrashMenuNew");
	//	lblBtnContinue.GetComponent<UILabel>().text = Localization.instance.Get("LblBtnContinueLevelCrashMenuNew");
		lblCoinsText.GetComponent<UILabel>().text = Localization.instance.Get("LblCoinsTextLevelCrashMenuNew");
		
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
