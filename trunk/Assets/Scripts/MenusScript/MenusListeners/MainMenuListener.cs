using UnityEngine;
using System.Collections;
using Prime31;
public class MainMenuListener : MonoBehaviour {
	
	GameObject btnLeaderboard;
	GameObject btnAchievemnt;
	GameObject btnGooglePlay;
	private static bool isDisable = false;
	UILabel moregameIndex;


	bool isSharePanelOpen = false;

	void Start () {
			btnLeaderboard = GameObject.FindGameObjectWithTag("Leaderboard");
			btnAchievemnt = GameObject.FindGameObjectWithTag("Achievement");
			//btnGooglePlay = GameObject.FindGameObjectWithTag("GooglePlay");
			btnGooglePlay = GameObject.Find("btnGooglePlay");
			if(this.gameObject.name == "lblMoreGameIndex")
			{
			this.gameObject.GetComponent<UILabel>().text = Mathf.Floor(Random.Range(1,6)).ToString();
		}
		#if UNITY_IPHONE	
		if(this.gameObject.name == "btnGooglePlay"){
			this.gameObject.SetActive(false);
		}

		
		#endif
		
		#if UNITY_ANDROID
		
		if(this.gameObject.name.Equals("btnPlay")){
			
			Debug.Log("-------------  :: " + UserPrefs.isGoogleSignedIn);
			if(UserPrefs.isGoogleSignedIn){
				btnAchievemnt.SetActive(true);
				btnLeaderboard.SetActive(true);
				btnGooglePlay.SetActive(false);
			}
			else
			{
				btnAchievemnt.SetActive(false);
				btnLeaderboard.SetActive(false);
				btnGooglePlay.SetActive(true);
			}
		}
		else if(this.name.Equals("btnRestore"))
		{
			if(UserPrefs.isAmazonBuild){
				this.gameObject.SetActive(false);
			}
		}
		
		#endif
			
	}

	void Update () {
		if (this.name.Equals ("ShareBtn") && isSharePanelOpen && Input.GetMouseButton (0)) {
			MainMenuLocalize mainMenuLocalize = GameObject.FindGameObjectWithTag ("MainMenu").GetComponent<MainMenuLocalize> ();
			isSharePanelOpen = !isSharePanelOpen;
			if (!isSharePanelOpen)
				this.gameObject.GetComponent<BoxCollider> ().enabled = true;
			mainMenuLocalize.socialBtnAction (isSharePanelOpen);
		}

#if UNITY_ANDROID
		if(!UserPrefs.isAmazonBuild && UserPrefs.isGoogleSignedIn && !isDisable)
		{
			DisableSignInButton();
			isDisable = true;
		}
#endif
	/*	#if UNITY_ANDROID
			if (Input.GetKeyDown(KeyCode.Escape)) 
			{	
				GameObject settingMenuObject = GameObject.FindGameObjectWithTag("LevelSettings");
				if(settingMenuObject!= null){
					Destroy(settingMenuObject);
					Resources.UnloadUnusedAssets();
				} else {
					Application.Quit(); 
				}
			}
			
		#endif
		
		*/
	}
	
	void OnClick(){
		//GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND);
	//	GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND);
		//Debug.Log(this);
//		if(UserPrefs.isSound)
//			SoundManager.Instance.gamePlayEffectsSource.PlayOneShot(SoundManager.Instance.buttonClickSound);
		if(this.name.Equals("btnPlay"))
		{
//			GAManager.Instance.LogDesignEvent("MainMenu:Play");
			MenuManager.Instance.SwitchNextMenu();
		}
		/*else if(this.name.Equals("RaceBtn"))
		{
			GAManager.Instance.LogDesignEvent("MainMenu:Race");
			//UserPrefs.currentVehicle = 1;
			GameConstants.GamePathProperties.CURRENT_WAY = GameConstants.GamePathProperties.ONE_WAY;
			GameConstants.GameProperties.CURRENT_MODE = GameConstants.GameProperties.ENDLESS;
			UserPrefs.currentEpisode = 2;
			UserPrefs.Save ( ) ;

			MenuManager.Instance.SwitchNextMenuRace();

		}*/
		else if(this.name.Equals("backBtn")){
			GameObject settingsMenu = GameObject.FindGameObjectWithTag("LevelSettings");
			GameObject shopMenu = GameObject.FindGameObjectWithTag("LevelShop");
			if(settingsMenu || shopMenu){

				if(settingsMenu)
					Destroy(settingsMenu);
				if(shopMenu)
					Destroy(shopMenu);

				try{
					//GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());

					//MainMenuLocalize mainMenuLocalize = GameObject.FindGameObjectWithTag("TopBar").GetComponent<MainMenuLocalize>();
					//mainMenuLocalize.setState();
				}catch(UnityException e){
				}
			}
			else{
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND);
				MenuManager.Instance.SwitchPreviousMenu();
			}
		}
		else if(name.Equals("nextBtn"))//Play Button
		{
			/*VehicleSelectionMenuLocalize vehicleSelectMenu = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>();
			if(vehicleSelectMenu){
				vehicleSelectMenu.switchToBikeSelectMenuAnchors();
			}*/
			GameObject.FindObjectOfType<RandomEnvironment>().deactivate();

			GAManager.Instance.LogDesignEvent("MainMenu::Play");
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLESELECTIONMENU);
			MenuManager.Instance.SwitchNextMenu();
			//GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLESELECTIONMENU);
//			if(UserPrefs.isSound)
//				SoundManager.Instance.gamePlayEffectsSource.PlayOneShot(SoundManager.Instance.buttonClickSound);
		}
		else if(this.name.Equals("btnMoreGames"))
		{
			GAManager.Instance.LogDesignEvent("MainMenu::MoreGames");
			//Application.OpenURL(ConstantsNew.MOREGAMES_LINK);			
			MoreGames();
		}

		/*else if(this.name.Equals("btnAchievement"))
		{
			GAManager.Instance.LogDesignEvent("MainMenu:Achievements");			
			GameManager.Instance.ShowAchievements();
		}*/
		/*else if(this.name.Equals("btnLeaderboard"))
		{
			GAManager.Instance.LogDesignEvent("MainMenu:LeaderBoard");
			GameManager.Instance.ShowLeaderBoard();
		}*/
		else if(this.name.Equals("btnGooglePlay"))
		{
//			GAManager.Instance.LogDesignEvent("MainMenu:Glogin");
#if UNITY_ANDROID
//			UserPrefs.googleGameCenter = new GoogleGameCenter();
//			UserPrefs.googleGameCenter.Initialize();
#endif
			GameManager.Instance.GoogleSignIn();
		}
		else if(this.name.Equals("btnRestore"))
		{
//			GAManager.Instance.LogDesignEvent("MainMenu:Restore");
			GameManager.Instance.Restore();
		}
		else if(this.name.Equals("NoAds"))
		{
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND);
//			GAManager.Instance.LogDesignEvent("Store::RemoveAds::Pressed");
			GameManager.Instance.PurchasePackage(Constants.REMOVEADS);
		}else if(this.name.Equals("Shop"))
		{
			GAManager.Instance.LogDesignEvent("MainMenu::Shop");
			ShowShopMenu();
//			if(UserPrefs.isSound)
//				SoundManager.Instance.gamePlayEffectsSource.PlayOneShot(SoundManager.Instance.buttonClickSound);
			/*GameObject menuGameObj = GameObject.FindGameObjectWithTag("LevelShop");
			if(menuGameObj){
				// shop already open
			} 
			else{
				GAManager.Instance.LogDesignEvent("MainMenu:Shop");
				ShowShopMenu();
			}*/


			//GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND);
			//GameManager.Instance.PurchasePackage(Constants.TEST_ID);
		}
		/*else if(name.Equals("Achievements"))
		{
			if(UserPrefs.IS_LOGED_IN){
				LeaderBoardPlayServicesManager.SubmitScore(UserPrefs.GetHighScore(),LeaderBoardPlayServicesManager.LEADERBOARD_ID_XP);

				LeaderBoardPlayServicesManager.ShowLeaderboard();
			}else{
				
				GameObject ldObj = GameObject.Find("Leaderbaord");
				if(ldObj){
					LeaderBoardManager leaderBoardManager = ldObj.GetComponent<LeaderBoardManager>();
					leaderBoardManager.loginUserAndShowLeaderBoard();
				}
			}
		}*/
		else if ( this.gameObject.name.Equals ("settingsBtn") )
		{
			//Debug.Log("settingsBtn" );
			GAManager.Instance.LogDesignEvent("MainMenu::Settings");
			ShowSettingMenu();
//			if(UserPrefs.isSound)
//				SoundManager.Instance.gamePlayEffectsSource.PlayOneShot(SoundManager.Instance.buttonClickSound);
		}

		else if(this.name.Equals("ShareBtn")){
			MainMenuLocalize mainMenuLocalize = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<MainMenuLocalize>();
			isSharePanelOpen = !isSharePanelOpen;
			if(isSharePanelOpen)
				this.gameObject.GetComponent<BoxCollider>().enabled = false;
			mainMenuLocalize.socialBtnAction(isSharePanelOpen);
			//GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND);
		}
		else if(this.name.Equals("btnFacebook")){
			GAManager.Instance.LogDesignEvent("MainMenu::Facebook");
			ShowFacebook();
		}
		else if(this.name.Equals("GoogleBtn")){
//			GAManager.Instance.LogDesignEvent("SettingsMenu:GooglePlus");
			ShowGooglePlus();
		}
		else if(this.name.Equals("btnTwitter")){
			GAManager.Instance.LogDesignEvent("MainMenu::Twitter");
//			ShowTwitter();	
			SocialManager socialManager = GameObject.FindGameObjectWithTag("SocialManager").GetComponent<SocialManager>();
			if(socialManager.TwitterIsLogedIn()){
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.TWEETDAILOG);
			}
			else{
				socialManager.TwitterLogin();
			}
		}
	
	}
	
	public void ShowFacebook(){
		UserPrefs.isFbFan = true;
		GameManager.Instance.SubmitAchievement();
		Application.OpenURL(ConstantsNew.FACEBOOK_LINK);	
	}
	public void ShowGooglePlus(){
		//UserPrefs.isGooglePlusFan = true;
		//GameManager.Instance.SubmitAchievement();
		//Application.OpenURL(ConstantsNew.GOOGLEPLUS_LINK);	
	}
	public void ShowTwitter(){
		UserPrefs.isTwitterAnnouncer = true;
		GameManager.Instance.SubmitAchievement();
		Application.OpenURL(ConstantsNew.TWITTER_LINK);	
	}

	public void ShowSettingMenu(){
		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.LEVELSETTINGS); 
//		Instantiate(Resources.Load("SubMenusNew/LevelSettings"));
//		MainMenuLocalize mainMenuLocalize = GameObject.FindGameObjectWithTag("TopBar").GetComponent<MainMenuLocalize>();
//		mainMenuLocalize.setStateForSubMenu();
	}
	public void ShowShopMenu(){
		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.STORE); 
		//Instantiate(Resources.Load("SubMenusNew/LevelShop"));
		//MainMenuLocalize mainMenuLocalize = GameObject.FindGameObjectWithTag("TopBar").GetComponent<MainMenuLocalize>();
		//mainMenuLocalize.setStateForSubMenu();
	}

	public void MoreGames()
	{
		if(UserPrefs.isAmazonBuild){
			Application.OpenURL("amzn://apps/android?s=com.tapinator");	
		} else {
			AdsManager.Instance.PlayHavenOnMoreGames();
		}
	}
	public void DisableSignInButton()
	{
		if(UserPrefs.isGoogleSignedIn){
				btnAchievemnt.SetActive(true);
				btnLeaderboard.SetActive(true);
				btnGooglePlay.SetActive(false);
			}
	}
	
}
	
		
		