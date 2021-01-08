using UnityEngine;
using System.Collections;

public class LevelOutofFuelNew : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		if (this.name.Equals("btnSkip"))
		{
				if(UserPrefs.currentLevel+1 > Constants.levelsPerEpisode  ){
					NGUITools.SetActive(this.gameObject,false);
				}
		}
		if(this.gameObject.name.Equals("btnHome")){
			SubMenusOld.Instance.EnableBackground();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnClick(){
		
		if (this.name.Equals("btnFuel25"))
		{
			purchaseFuel(ConstantsNew.outOfFuelPackageOneCoins,ConstantsNew.outOfFuelPackageOneFuel);
		}
		else if (this.name.Equals("btnFuel50"))
		{
			purchaseFuel(ConstantsNew.outOfFuelPackageTwoCoins,ConstantsNew.outOfFuelPackageTwoFuel);
		}
		else if (this.name.Equals("btnFuel75"))
		{
			purchaseFuel(ConstantsNew.outOfFuelPackageThreeCoins,ConstantsNew.outOfFuelPackageThreeFuel);
		}	
		else if(this.name.Equals("btnHome"))
		{
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.MAINMENU);
			Application.LoadLevel("MenusScene");
		}
		else if(this.name.Equals("btnRestart"))
		{
			if(MenuManager.Instance.isVehicleMenuPresent)
			{
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLESELECTIONMENU);
				Application.LoadLevel(Constants.SCENE_MENU);
			}
			else
			{
				Destroy(GameObject.FindGameObjectWithTag("LevelCrash"));
				Destroy(GameObject.FindGameObjectWithTag("Hud"));
				Resources.UnloadUnusedAssets();
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.GAMEPLAY);
				StartCoroutine(MenuManager.Instance.LoadScene(0));
			}

		}
		else if (this.name.Equals("btnSkip"))
		{
			ShowSkipMenu();
		}
//		if(UserPrefs.isSound)
//			SoundManager.Instance.gamePlayEffectsSource.PlayOneShot(SoundManager.Instance.buttonClickSound);
	}
	
	public void purchaseFuel(int price, int fuel){		
		if(UserPrefs.totalCoins > price)
		{			
			GAManager.Instance.LogDesignEvent("CoinCons:LevelTimeUp:Boost:tb"+price+":Lvl#"+UserPrefs.currentLevel);
			
		//	UserPrefs.totalCoins -= price;
			GameManager.Instance.SubtractCoins(price);
			GameManager.Instance.AddTime(fuel);
			GameManager.Instance.ShowTime(price);
			UserPrefs.Save();
			Destroy(GameObject.FindGameObjectWithTag("LevelOutOfFuel"));
		//	Destroy(GameObject.FindGameObjectWithTag("Hud"));
		//	Resources.UnloadUnusedAssets();
			Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.GAMEPLAY);
		//	StartCoroutine(MenuManager.Instance.LoadScene(0));
		}
		else
		{
	
			GameManager.Instance.PurchasePackage(ConstantsNew.PACKAGE_5);
			//GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.STORE);
		}
	}
	
	void ShowSkipMenu(){
		
		if(UserPrefs.currentLevel+1 > Constants.levelsPerEpisode  ){
			// next episode will unlock
			if( UserPrefs.currentEpisode < UserPrefs.unlockLevelsArrays.Length  &&  !UserPrefs.episodeUnlockArray[UserPrefs.currentEpisode] ){
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.LEVELSKIP);
				//Instantiate(Resources.Load("SubMenus/LevelSkip"));
			}else{
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.MAINMENU);
				Application.LoadLevel(Constants.SCENE_MENU);                     
			}
		}
		else 	
		{
			if( UserPrefs.currentLevel+1 <=   UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]         )  // checking whether next level is unlock or not
				NextLevel();
			else
			{
				Destroy(GameObject.FindGameObjectWithTag("LevelOutOfFuel"));
				Resources.UnloadUnusedAssets();
				
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.LEVELSKIP);
				
			}
		}
			
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
				Destroy(GameObject.FindGameObjectWithTag("LevelComplete"));
				Destroy(GameObject.FindGameObjectWithTag("Hud"));
				Resources.UnloadUnusedAssets();
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.GAMEPLAY);
				StartCoroutine(MenuManager.Instance.LoadScene(0));
			}
		}
	}
}

