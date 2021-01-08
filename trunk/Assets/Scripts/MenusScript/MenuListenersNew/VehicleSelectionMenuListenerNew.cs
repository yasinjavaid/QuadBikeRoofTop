using UnityEngine;
using System.Collections;
using System;
public class VehicleSelectionMenuListenerNew : MonoBehaviour {
	
	public UIPanel secondVehicleCoinsPanel;
	public UIPanel thirdVehicleCoinsPanel;
//	public GameObject inAppFuelPanel;

	public static int selectedVehicleIndex = 0;
	public GameObject SocialBG;

	void Start () {
		#if UNITY_ANDROID
		//	NGUITools.SetActive(inAppFuelPanel,false);
		#endif
		updateCoins();
	//	Debug.Log("-------------------- " + UserPrefs.isAllEpisdoesUnlock );
		if(this.gameObject.name.Equals("getCoins")){
			
			this.playHavenIAPTracker(ConstantsNew.PACKAGE_VGP);
			/*
			if(UserPrefs.isAllEpisdoesUnlock){
				GameObject episodeUnlockButton = GameObject.FindGameObjectWithTag("UnlockAllEpisodes");
				if(episodeUnlockButton != null)
				{Debug.Log("-------------------- " );
					episodeUnlockButton.SetActive(false);
				}
			}
			*/
		}
		if(this.name.Equals("Vehicle1")){
			setVehicleCoinsPanel();	
		}
		;

		//inAppFuelPanel = new GameObject();
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnClick ( )
	{

		//Debug.Log(this);
		if ( this.gameObject.name.Equals ("settingsBtn") )
		{
			//Debug.Log("settingsBtn" );
//			GAManager.Instance.LogDesignEvent("SettingsMenu");
			ShowSettingMenu();

		}
		else if(this.gameObject.name.Equals("getCoins"))
		{
			// Get Coins Button
		//	GAManager.Instance.LogDesignEvent("Episode:CoinsStore");
			//Destroy(GameObject.FindGameObjectWithTag("VehicleSelectionMenu"));
			//Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.STORE);
		}
		else if(name.Equals("nextBtn"))//Play Button
		{

//			GAManager.Instance.LogDesignEvent("VehicleSelection::Car Selected"+UserPrefs.currentVehicle.ToString());

			MenuManager.Instance.SwitchNextMenu();
		}/*else if(name.Equals("Achievements"))//Play Button
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
		else if(name.Equals("BigLockBtn"))//Play Button
		{
			Debug.Log("BigLockBtn clicked" );
			if(!UserPrefs.vehicleUnlockArray[VehicleSelectionMenuListenerNew.selectedVehicleIndex]){
				Instantiate(Resources.Load("SubMenus/LevelThankyou"));
			}
		}

		else if(name.Equals("nextBtnFromSelection"))//Play Button
		{

			// Next called
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND);
//			Debug.Log("nextBtn Vehilce selection" );
			GAManager.Instance.LogDesignEvent("VehicleSelectionMenu::Play");
			if(UserPrefs.vehicleUnlockArray[VehicleSelectionMenuListenerNew.selectedVehicleIndex]){

				switch(VehicleSelectionMenuListenerNew.selectedVehicleIndex){
				case 0:
					UserPrefs.currentVehicle = 1; 
					GAManager.Instance.LogDesignEvent("VehicleSelectionMenu::Vehicle1::Selected");
					break;
				case 1:
					UserPrefs.currentVehicle = 2; 
					GAManager.Instance.LogDesignEvent("VehicleSelectionMenu::Vehicle2::Selected");
				
					break;
				case 2:
					UserPrefs.currentVehicle = 3; 
					GAManager.Instance.LogDesignEvent("VehicleSelectionMenu::Vehicle3::Selected");
				
					break;
				case 3:
					UserPrefs.currentVehicle = 4; 
					GAManager.Instance.LogDesignEvent("VehicleSelectionMenu::Vehicle4::Selected");
				
					break;
				case 4:
					UserPrefs.currentVehicle = 5; 
					GAManager.Instance.LogDesignEvent("VehicleSelectionMenu::Vehicle5::Selected");
				
					break;
				case 5://Hummer_police
					UserPrefs.currentVehicle = 6;
					GAManager.Instance.LogDesignEvent("VehicleSelectionMenu::Vehicle6::Selected");
					break;
				default:
					break;

				}
				
				if(true ){
					VehicleSelectionMenuListenerNew.selectedVehicleIndex = 0;
					MenuManager.Instance.SwitchNextMenu();
				}
				else{
//					showArrow();
				}
				
			}else {
				buyCarHelper();
			}

			//unlockorSwitchToEpisodes();			
		}
		/*if (this.name.Equals("Vehicle1"))
		{
			GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().ChecktThePositionSprite1();
		}
		else if (this.name.Equals("Vehicle2"))
		{
			GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().ChecktThePositionSprite2();
		}
		else if (this.name.Equals("Vehicle3"))
		{
			Debug.Log("vehile3" );
			GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().ChecktThePositionSprite3();
		}
		else if (this.name.Equals("vehicle4"))
		{
//			GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListener>().ChecktThePositionSprite4();
		}
		else if (this.name.Equals("vehicleBtn"))
		{
			//Vehicle Button tapped
			Debug.Log("vehicleBtn" );
		}*/
		else if (this.name.Equals("scratchBtn"))
		{
			//Vehicle Button tapped
		//	 InAppFuel.showZone("144", "lCy9LJgDYI",SystemInfo.deviceUniqueIdentifier, 1, "Vehicle1");
			 Debug.Log("scratchBtn"+SystemInfo.deviceUniqueIdentifier);
		}
		else if (this.name.Equals("SlotsBtn"))
		{
			//Vehicle Button tapped
			 Debug.Log("SlotsBtn"+SystemInfo.deviceUniqueIdentifier);
		//	InAppFuel.showZone("144", "lCy9LJgDYI", SystemInfo.deviceUniqueIdentifier, 2, "Vehicle1");
			//getUnawardedCurrency("22");
		}
		
		else if (this.name.Equals("btnCoinsUpLeft"))
		{
			Debug.Log("btnCoinsUpLeft" );
			
			// Get Coins Button
			///GAManager.Instance.LogDesignEvent("Episode:CoinsStore");
			//Destroy(GameObject.FindGameObjectWithTag("VehicleSelectionMenu"));
			//Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.STORE);
		}

		else if(this.name.Equals("CarControl"))
		{
			if(UserPrefs.accelerometerFactor == 2)//If buttons, switch to accelerometer
			{
				UserPrefs.accelerometerFactor = 1;
				this.gameObject.transform.Find("Label").GetComponent<UILabel>().text = "Car Control: Accelerometer";
			}
			else if(UserPrefs.accelerometerFactor == 1)//if accelerometer, switch to buttons
			{
				UserPrefs.accelerometerFactor = 2;
				this.gameObject.transform.Find("Label").GetComponent<UILabel>().text = "Car Control: Buttons";
			}
		}

		//Ijaz - Cars shelf scroll
		else if(this.name.Equals("Car-1"))
		{
			VehicleSelectionMenuListenerNew.selectedVehicleIndex = 0;

			CarStandController carStandController = GameObject.FindGameObjectWithTag("CarStand").GetComponent<CarStandController>();
			carStandController.enableCarAt(0);
			VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>() as VehicleSelectionMenuLocalize;	
			vehicleLocalize.updateSpecsWindow(1, transform); // 1 bcoz Car-1
			vehicleLocalize.updateNames();

		}
		else if(this.name.Equals("Car-2"))
		{
			VehicleSelectionMenuListenerNew.selectedVehicleIndex = 1;

			CarStandController carStandController = GameObject.FindGameObjectWithTag("CarStand").GetComponent<CarStandController>();
			carStandController.enableCarAt(1);
			VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>() as VehicleSelectionMenuLocalize;	
			vehicleLocalize.updateSpecsWindow(2, transform);
			vehicleLocalize.updateNames();
		//	GAManager.Instance.LogDesignEvent("VehicleSelectionMenu::Main Menu");
		}
		else if(this.name.Equals("Car-3"))
		{
			VehicleSelectionMenuListenerNew.selectedVehicleIndex = 2;
			
			CarStandController carStandController = GameObject.FindGameObjectWithTag("CarStand").GetComponent<CarStandController>();
			carStandController.enableCarAt(4);
			VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>() as VehicleSelectionMenuLocalize;	
			vehicleLocalize.updateSpecsWindow(3, transform);
			vehicleLocalize.updateNames();
		}
		else if(this.name.Equals("Car-4"))
		{
			VehicleSelectionMenuListenerNew.selectedVehicleIndex = 3;
			
			CarStandController carStandController = GameObject.FindGameObjectWithTag("CarStand").GetComponent<CarStandController>();
			carStandController.enableCarAt(2);
			VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>() as VehicleSelectionMenuLocalize;	
			vehicleLocalize.updateSpecsWindow(4, transform);
			vehicleLocalize.updateNames();

		}
		else if(this.name.Equals("Car-5"))
		{
			VehicleSelectionMenuListenerNew.selectedVehicleIndex = 4;	
			
			CarStandController carStandController = GameObject.FindGameObjectWithTag("CarStand").GetComponent<CarStandController>();
			carStandController.enableCarAt(3);
			VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>() as VehicleSelectionMenuLocalize;	
			vehicleLocalize.updateSpecsWindow(5, transform);
			vehicleLocalize.updateNames();

		}
		else if(this.name.Equals("Car-6"))
		{
			VehicleSelectionMenuListenerNew.selectedVehicleIndex = 5;	

			CarStandController carStandController = GameObject.FindGameObjectWithTag("CarStand").GetComponent<CarStandController>();
			carStandController.enableCarAt(5);
			VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>() as VehicleSelectionMenuLocalize;	
			vehicleLocalize.updateSpecsWindow(6, transform);
			vehicleLocalize.updateNames();
		}
		else if(this.name.Equals("Car-7"))
		{
			VehicleSelectionMenuListenerNew.selectedVehicleIndex = 6;	

			CarStandController carStandController = GameObject.FindGameObjectWithTag("CarStand").GetComponent<CarStandController>();
			carStandController.enableCarAt(6);
			VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>() as VehicleSelectionMenuLocalize;	
			vehicleLocalize.updateSpecsWindow(7, transform);
			vehicleLocalize.updateNames();
		}
		else if(this.name.Equals("backBtn")){
			/*VehicleSelectionMenuLocalize vehicleSelectMenu = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>();
			if(vehicleSelectMenu){
				vehicleSelectMenu.switchToMainMenuAnchors();
			}*/


			GameObject.FindGameObjectWithTag("StartAnim").GetComponent<RandomEnvironment>().activate();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND);
			//VehicleSelectionMenuListenerNew.selectedVehicleIndex = 0;
			MenuManager.Instance.SwitchPreviousMenu();

		}
		else if(this.name.Equals("btnFacebook")){
//			GAManager.Instance.LogDesignEvent("SettingsMenu:Facebook");
			ShowFacebook();
		}
		else if(this.name.Equals("GoogleBtn")){
//			GAManager.Instance.LogDesignEvent("SettingsMenu:Google");
			ShowGooglePlus();
		}
		else if(this.name.Equals("btnTwitter")){
//			GAManager.Instance.LogDesignEvent("SettingsMenu:Twitter");
			ShowTwitter();	
		}
		else if(this.name.Equals("UnlockAll")){
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND);
//			GAManager.Instance.LogDesignEvent("Store::UnlockAll::Pressed");
			GameManager.Instance.PurchasePackage(Constants.UNLOCKALL);	
		}
		else if(this.name.Equals("car_buy")){
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND);
			buyCarHelper();

		}


		else if(this.name.Equals("RightBtn")){ 
			if(VehicleSelectionMenuListenerNew.selectedVehicleIndex < 4){ // 2 mean maximum cars are 3
				VehicleSelectionMenuListenerNew.selectedVehicleIndex++;	
			}
			else{
				VehicleSelectionMenuListenerNew.selectedVehicleIndex = 0;
			}
			IterateVehicles();
		}
		else if(this.name.Equals("LeftBtn")){

			if(VehicleSelectionMenuListenerNew.selectedVehicleIndex > 0){
				VehicleSelectionMenuListenerNew.selectedVehicleIndex--;
			}
			else{
				VehicleSelectionMenuListenerNew.selectedVehicleIndex = 4;
			}
			IterateVehicles();
		}
		else if(this.name.Equals("UpgradeBtn")){
			Debug.Log("UpgradeBtn clicked");
			if(UserPrefs.isColorUpateDone || UserPrefs.currentLevel < 2 || VehicleManager.vehicleArray[0].colorUnlocked[1] == true || VehicleManager.vehicleArray[0].colorUnlocked[2] == true){
				VehicleUpgradeMenuLocalize vehicleUpgradeLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleUpgradeMenuLocalize>();
				vehicleUpgradeLocalize.setUpgradesOverlays(VehicleSelectionMenuListenerNew.selectedVehicleIndex);
				VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>();
				vehicleLocalize.VehicleCustomBtnAction(0); // 0 for Upgrades
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND);
			}
			else{
				showArrow();
			}
		}
		else if(this.name.Equals("PaintBtn")){
			paintBtnHelper();
		}
		else if(this.name.Equals("WheelsBtn")){
			Debug.Log("WheelsBtn clicked");
		//	if(UserPrefs.isColorUpateDone || UserPrefs.currentLevel < 2 || VehicleManager.vehicleArray[0].colorUnlocked[1] == true || VehicleManager.vehicleArray[0].colorUnlocked[2] == true)
			{
				VehicleUpgradeMenuLocalize vehicleUpgradeLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleUpgradeMenuLocalize>();
				vehicleUpgradeLocalize.setWheelsOverlays(VehicleSelectionMenuListenerNew.selectedVehicleIndex);
				VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>();
				vehicleLocalize.VehicleCustomBtnAction(2); // 2 for Wheels
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND);
			}
//			else{
//				showArrow();
//			}
		}


		//VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>() as VehicleSelectionMenuLocalize;	

//		if(UserPrefs.isSound)
//			SoundManager.Instance.gamePlayEffectsSource.PlayOneShot(SoundManager.Instance.buttonClickSound);
		UserPrefs.Save ( ) ;
	}

	void OnHover (bool isOver){
		//Debug.Log("OnHover called :" + this.name);
		if(isOver && (this.name.Equals("btnFacebook") || this.name.Equals("GoogleBtn") || this.name.Equals("btnTwitter"))){
			SocialBG.GetComponentInChildren<UISprite>().spriteName = "social_btn_pressed" ;
		}
		else if(!isOver && (this.name.Equals("btnFacebook") || this.name.Equals("GoogleBtn") || this.name.Equals("btnTwitter"))){
			SocialBG.GetComponentInChildren<UISprite>().spriteName = "social_btn_unpressed" ;
		}
	}
	void paintBtnHelper(){
		Debug.Log("PaintBtn clicked");
		VehicleUpgradeMenuLocalize vehicleUpgradeLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleUpgradeMenuLocalize>();
		vehicleUpgradeLocalize.setPaintOverlays(VehicleSelectionMenuListenerNew.selectedVehicleIndex);
		VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>();
		vehicleLocalize.VehicleCustomBtnAction(1); // 1 for paint
		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND);
	}
	
	void showArrow(){
//		paintBtnHelper();
//		GameConstants.POPUP_MESSAGE = "Have you tried Different Paints?" ;
//		Instantiate(Resources.Load("SubMenusNew/PaintTutorialUpgrade"));
//		VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>() as VehicleSelectionMenuLocalize;	
//		vehicleLocalize.paintArrow.SetActive(true);
	}
	void buyCarHelper(){
		int coinsRequire = VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].price;

		Debug.LogError("Current V Buybtn "+ UserPrefs.currentVehicle);
		
		if(UserPrefs.totalCoins >= coinsRequire)
		{
			GameConstants.POPUP_MESSAGE = "Do you want to Unlock \n this in "+coinsRequire +" ?" ;
			GameManager.Instance.ChangeState(GameManager.GameState.VEHICLEUNLOCK);
		}
		else{

			VehicleUpgradeMenuListener.CoinsNeeded = coinsRequire - UserPrefs.totalCoins;
			GameConstants.POPUP_MESSAGE = string.Format("You need {0} more coins to unlock. \n Buy more?",VehicleUpgradeMenuListener.CoinsNeeded) ;
			Instantiate (Resources.Load ("SubMenusNew/LevelBuyCoin"));
		}
	}

	void IterateVehicles(){
		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND);
		
		CarStandController carStandController = GameObject.FindGameObjectWithTag("CarStand").GetComponent<CarStandController>();
		carStandController.enableCarAt(VehicleSelectionMenuListenerNew.selectedVehicleIndex);
		
		VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>() as VehicleSelectionMenuLocalize;	
		
		vehicleLocalize.updateSpecsWindow(VehicleSelectionMenuListenerNew.selectedVehicleIndex+1, transform);
		//vehicleLocalize.updateNames();
		UserPrefs.currentVehicle = VehicleSelectionMenuListenerNew.selectedVehicleIndex+1;
		
		VehicleUpgradeMenuLocalize vehicleUpgradeLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleUpgradeMenuLocalize>();
		vehicleUpgradeLocalize.setPaintOverlays(VehicleSelectionMenuListenerNew.selectedVehicleIndex);
		vehicleUpgradeLocalize.setWheelsOverlays(VehicleSelectionMenuListenerNew.selectedVehicleIndex);
		vehicleUpgradeLocalize.setUpgradesOverlays(VehicleSelectionMenuListenerNew.selectedVehicleIndex);
		vehicleUpgradeLocalize.setCarColor(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].currentColor);
		vehicleUpgradeLocalize.setTruckWheels(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].currentWheel);
		
		vehicleLocalize.updateLockPanel();
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
	void updateCoins ( )
	{
//		try{
//			VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>() as VehicleSelectionMenuLocalize;	
//			vehicleLocalize.updateCoions();
//		}
//		catch(Exception e){
//
//		}
	
	}
	public void PurchaseEpisode(){
		if ( UserPrefs.totalCoins >= Constants.episodePriceArray[UserPrefs.currentEpisode-1] )
		{
			//UserPrefs.totalCoins -= Constants.episodePriceArray[UserPrefs.currentEpisode-1] ;
			GameManager.Instance.SubtractCoins(Constants.episodePriceArray[UserPrefs.currentEpisode-1]);
			UserPrefs.episodeUnlockArray[UserPrefs.currentEpisode-1] = true ;
			updateCoins ( ) ;
		}
		else
		{
//				Instantiate ( Resources.Load ( "Menus/OutOfCoinsMenu" ) ) ;

		}
	}
	public void ShowSettingMenu(){
		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.LEVELSETTINGS); 
	}
	void unlockorSwitchToEpisodes(){
			Debug.Log("I val "+ GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().i);
			int frontVehicle = GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().i;
			if(frontVehicle == 0){
				GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().ChecktThePositionSprite1();
			}
			else if(frontVehicle == 1){
				//GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().ChecktThePositionSprite2();
				GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().ChecktThePositionSprite3();
			}
			else if (frontVehicle == 2){
				GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().ChecktThePositionSprite2();
				//GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<VehicleCarouselEventListenerNew>().ChecktThePositionSprite3();
			}
			else{
				//GameObject.FindGameObjectWithTag("CarouselMenu").GetComponent<CarouselEventListener>().ChecktThePositionSprite4();
			}
	}
	
	public void setVehicleCoinsPanel(){
		if(UserPrefs.vehicleUnlockArray[1]==true){
			secondVehicleCoinsPanel.alpha = 0;	
		}
		else{
			secondVehicleCoinsPanel.alpha = 1;
		}
		if(UserPrefs.vehicleUnlockArray[2] == true){
			thirdVehicleCoinsPanel.alpha = 0;
		}
		else{
			thirdVehicleCoinsPanel.alpha = 1;
		}
	}
	
#region InAppFuel
	
	public void onGameClosed(string message) {

	//	InAppFuel.getUnawardedCurrency("144", "lCy9LJgDYI",SystemInfo.deviceUniqueIdentifier, "Vehicle1");
	}
	public void onZoneAlreadyFulfilled(string message)
	{
		Debug.LogError(message);
	}
	public void onError(string message)
	{
		Debug.LogError(message);
	}
	public void getUnawardedCurrency(string message){
		float coinsWon;
		//GameManager.Instance.AddCoins(Convert.ToInt32(message.ToString()));
		if(float.TryParse(message, out coinsWon))
		GameManager.Instance.AddCoins((int)Math.Ceiling(coinsWon));
		VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>() as VehicleSelectionMenuLocalize;	
		vehicleLocalize.updateCoions();
	}
#endregion

#region VGP
	
	public void playHavenIAPTracker(string productId) // Added by Majid
 	{
		Debug.Log("Tracking vgp");

	//	Upsight.trackInAppPurchase(productId,1,UpsightAndroidPurchaseResolution.Bought,0,null,null);

//			PlayHaven.Purchase purchase = new PlayHaven.Purchase();
//  		purchase.productIdentifier = productId;
//  		purchase.receipt = "Purchased 1 item of id " + productId;
//  		purchase.quantity = 1;
  		
//  		PlayHavenManager.Instance.ProductPurchaseTrackingRequest(purchase,PlayHaven.PurchaseResolution.Buy);
 }
	
#endregion
}
