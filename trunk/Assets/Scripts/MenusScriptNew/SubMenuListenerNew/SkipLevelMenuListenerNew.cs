﻿using UnityEngine;
using System.Collections;

public class SkipLevelMenuListenerNew : MonoBehaviour {
//// Use this for initialization
	void Start () {
	
		if(this.gameObject.name.Equals("btnClose")){
			SubMenusOld.Instance.EnableBackground();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	 void OnClick(){
		 if (this.name.Equals("btnClose"))
		{
			Destroy(GameObject.FindGameObjectWithTag("LevelSkip"));
			Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
		}
		else if (this.name.Equals("btnUnlock"))
		{
			SkipLevel();
		}	
		
	}
	
	void SkipLevel(){
		if(UserPrefs.totalCoins>= Constants.COINSTOSKIPLEVEL){
			UserPrefs.totalCoins -= Constants.COINSTOSKIPLEVEL;
			if(UserPrefs.currentLevel+1 > Constants.levelsPerEpisode  ){
				if( UserPrefs.currentEpisode < UserPrefs.unlockLevelsArrays.Length  &&  !UserPrefs.episodeUnlockArray[UserPrefs.currentEpisode] ){
				//	Instantiate(Resources.Load("SubMenus/EpisodeUnlockMenu"));
					GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.EPISODEUNLOCK);
					UserPrefs.episodeUnlockArray[UserPrefs.currentEpisode] = true ;
					UserPrefs.Save();
				}else{
					GameManager.Instance.ChangeState(GameManager.GameState.EPISODEMENU);
					Application.LoadLevel("MenusScene");
				}
			}else{
				NextLevel();
			}
		}
		else
		{
			//Destroy(GameObject.FindGameObjectWithTag("LevelSkip"));
			//Instantiate(Resources.Load("SubMenus/LevelOutofCandies"));
			GameManager.GameState previous=GameManager.Instance.GetPreviousGameState();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.STORE);
			GameManager.Instance.SetPreviousGameState(previous);
		}
		UserPrefs.Save();
		
		
	}
	
	void NextLevel(){
	//	UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]++;
	//	UserPrefs.Save();
		if( UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1] == UserPrefs.currentLevel){
				UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]++;
		}
		if(UserPrefs.currentLevel+1 > Constants.levelsPerEpisode  ){   // 12 >= 12
			if( UserPrefs.currentEpisode < UserPrefs.unlockLevelsArrays.Length){
				//Instantiate(Resources.Load("SubMenus/EpisodeUnlockMenu"));
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.EPISODEUNLOCK);
				UserPrefs.episodeUnlockArray[UserPrefs.currentEpisode] = true ;
				UserPrefs.Save();
			}else{
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.MAINMENU);
				Application.LoadLevel(Constants.SCENE_MENU);                     
			}
		}
		else{
			UserPrefs.currentLevel++;
			UserPrefs.adCounter++;
			if(MenuManager.Instance.isVehicleMenuPresent)
			{
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLESELECTIONMENU);
				Application.LoadLevel(Constants.SCENE_MENU);
			}
			else
			{
				Destroy(GameObject.FindGameObjectWithTag("LevelSkip"));
				Destroy(GameObject.FindGameObjectWithTag("Hud"));
				Resources.UnloadUnusedAssets();
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.GAMEPLAY);
				StartCoroutine(MenuManager.Instance.LoadScene(0));
			};
		}
	}
}
