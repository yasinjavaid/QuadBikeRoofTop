using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using System;
public class AdsManager : SingeltonBase<AdsManager> {
	
	// Use this for initialization
	public int displayAdAfterLvl = 1;
	private int localCount = 0;
	private int adsCount = 0;
	private bool gameLaunch = true;
	private double pauseTime;
	private double timeLimit;
	private double timeDifference;
	
	void Start () {		
		
		pauseTime = 0.0f;
		timeLimit = 180.0f; // enter timeLimit in seconds => 1800.0f = 30 mins
		timeDifference = 0.0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//	public void LoadAd()
	//	{
	//
	//	}
	InterstitialAd interstitial;
	void ShowGoogleAd()
	{
		Debug.Log ("AdsManagerGoogle:: Sending AdRequest for Admob");
		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(Constants.adMOBCrossPromotion);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		interstitial.OnAdLoaded+=HandleOnAdLoaded;
		interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
		
		// Load the interstitial with the request.
		interstitial.LoadAd(request);
	}
	
	public void HandleOnAdLoaded(object sender, EventArgs args)
	{
		Debug.Log ("AdsManagerGoogle:: OnAdLoaded event received. ");
		// Handle the ad loaded event.
		
		if(interstitial.IsLoaded())
		{
			Debug.Log ("AdsManagerGoogle:: Ad Loaded");
			interstitial.Show();
		}
		else{
			Debug.Log ("AdsManagerGoogle:: Ad not Loaded");
		}
	}
	
	public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		Debug.Log ("AdsManagerGoogle:: Interstitial Failed to load: " + args.Message);
		// Handle the ad failed to load event.
	}
	
	public void HandleOnAdOpening(object sender, EventArgs args)
	{
		Debug.Log ("AdsManagerGoogle:: Ad opening: ");
	}
	
	public void HandleOnAdClosed(object sender, EventArgs args)
	{
		Debug.Log ("AdsManagerGoogle:: Ad closed: ");
		interstitial.Destroy ();
	}
	public void DisplayAd()
	{
		
		if(UserPrefs.isAmazonBuild){
			if(gameLaunch){
				gameLaunch = false;
				UserPrefs.Load();
			}
			return;
		}
		
		switch(GameManager.Instance.GetCurrentGameState())
		{
		case GameManager.GameState.MAINMENU:
			this.AdMobCrossPromotion();
			this.hideBannerAds();
			break;
		case GameManager.GameState.GAMEPLAY:
			StartCoroutine(LoadAdwithDelay());
			//			this.showBannnerAds();
			break;
		case GameManager.GameState.SHOWAD:
			//			DebugNew.LogError("ShowAD on level end.");
			this.ShowMopubAdOnLevelEnd();
			break;
			
		}
	}
	
	IEnumerator LoadAdwithDelay()
	{
		yield return new WaitForSeconds(2.0f);
		//		DebugNew.LogError("Loading Ad on Gameplay with delay.");
		
		this.RequestForMopubAd();
		
	}
	
	
	private void RequestForMopubAd()
	{
		localCount ++;
		if(localCount == displayAdAfterLvl && !UserPrefs.isIgnoreAds)
		{
			#if UNITY_ANDROID
			if (MoPubManager.INTERSTITIAL_AD_STATE != MoPubManager.INTERSTITIAL_STATES.LOADED
			    && MoPubManager.INTERSTITIAL_AD_STATE != MoPubManager.INTERSTITIAL_STATES.LEVELENDAD_LOADING){
				
				adsCount ++;
				
				DebugNew.Log("++++++++++ send RequestForMopubAd +++++");
				if(adsCount % 3 == 0)
					MoPubAndroid.requestInterstitialAd(Constants.INTERSTITIAL_ID_ANDROID_VIDEO);
				else
					MoPubAndroid.requestInterstitialAd(Constants.INTERSTITIAL_ID_ANDROID);
				MoPubManager.INTERSTITIAL_AD_STATE = MoPubManager.INTERSTITIAL_STATES.LEVELENDAD_LOADING;
			}
			#endif
			#if UNITY_IPHONE
			if(MoPubManager.INTERSTITIAL_AD_STATE != MoPubManager.INTERSTITIAL_STATES.LOADED
			   && MoPubManager.INTERSTITIAL_AD_STATE != MoPubManager.INTERSTITIAL_STATES.LOADING){	
				
				adsCount ++;
				
				MoPubBinding.requestInterstitialAd(Constants.INTERSTITIAL_ID_IOS,null);
				MoPubManager.INTERSTITIAL_AD_STATE = MoPubManager.INTERSTITIAL_STATES.LOADING;
			}
			
			#endif
			localCount = 0;
		}
	}
	
	IEnumerator WaitForMopubAddOnMainMenu(float wait)
	{	
		DebugNew.Log("----------- before :: " + MoPubManager.INTERSTITIAL_AD_STATE);
		yield return new WaitForSeconds(wait);
		
		#if UNITY_ANDROID			
		if(MoPubManager.INTERSTITIAL_AD_STATE != MoPubManager.INTERSTITIAL_STATES.DISPLAYED
		   && GameManager.Instance.GetCurrentGameState() == GameManager.GameState.MAINMENU){								
			ShowMopubAdOnMainMenu();							
		} 
		#endif
		#if UNITY_IPHONE
		if(MoPubManager.INTERSTITIAL_AD_STATE != MoPubManager.INTERSTITIAL_STATES.DISPLAYED
		   && GameManager.Instance.GetCurrentGameState() == GameManager.GameState.MAINMENU){				
			ShowMopubAdOnMainMenu();							
		} 
		#endif
	}
	private void ShowMopubAdOnMainMenu()
	{
		
		ShowMopubAdOnMainMenuScreen();
		StartCoroutine(WaitForMopubAddOnMainMenu(1.0f));
		
		
	}
	private void AdMobCrossPromotion()
	{
		if(gameLaunch)
		{
			
			UserPrefs.Load();
			ShowGoogleAd();
			if(!UserPrefs.isIgnoreAds){			
				DebugNew.Log("++++ AdsManagerStart +++++");
				#if UNITY_ANDROID
				
				MoPubAndroid.reportApplicationOpen();
				//				MoPubAndroid.initAppLovinSDK();
				//				MoPubAndroid.initHeyzapSDK(Constants.PUBLISHER_ID);
				//				MoPubAndroid.initPlayhavenSession();
				
				//	Playhaven.init( Constants.AndroidAppTokenPlayHaven, Constants.AndroidAppSecretPlayHaven );
				#else
				Playhaven.init( Constants.iOSAppTokenPlayHaven, Constants.iOSAppSecretPlayHaven );
				#endif			
				
				// Make an open request at every app launch
				//	Playhaven.requestAppOpen();
				
				
				//				UpsightManager.makePurchaseEvent += myMakePurchaseMethod;
				//				UpsightManager.unlockedRewardEvent += myUnlockedRewardMethod;
				//				
				///	Playhaven.sendContentRequest( "game_launch", true );
				
				if(!UserPrefs.isAmazonBuild){
					#if UNITY_EDITOR
					//
					#else
					//					Tapstream.Config conf = new Tapstream.Config();
					//					//conf.Set("idfa", SystemInfo.deviceUniqueIdentifier);
					//					Tapstream.Create("tapinator", "GIBgntfkSSaqsQh0XiVeQQ", conf);
					#endif
				}
				
				//				if (MoPubAndroidManager.INTERSTITIAL_AD_STATE != 
				//				    MoPubAndroidManager.INTERSTITIAL_STATES.LOADED || 
				//				    MoPubAndroidManager.INTERSTITIAL_AD_STATE != 
				//				    MoPubAndroidManager.INTERSTITIAL_STATES.MAINMENUAD_LOADING){
				//					DebugNew.Log("Loading Interstitial. Ad State: "+MoPubAndroidManager.INTERSTITIAL_AD_STATE);
				//					MoPubAndroid.requestInterstitalAd(Constants.MopubAndroidCrossPromotionID);//take this from rafi for this game
				//					MoPubAndroidManager.INTERSTITIAL_AD_STATE = MoPubAndroidManager.INTERSTITIAL_STATES.MAINMENUAD_LOADING;
				//				}else{
				//					DebugNew.Log("Interstitial is already laoded. Ad State: "+MoPubAndroidManager.INTERSTITIAL_AD_STATE);
				//				}
				
				
			}
			
			
			
			gameLaunch = false;
			
			
		}
		//		else
		//		{
		//			if(!UserPrefs.isIgnoreAds)
		//			{
		//				#if UNITY_ANDROID
		//				if (MoPubAndroidManager.INTERSTITIAL_AD_STATE != MoPubAndroidManager.INTERSTITIAL_STATES.LOADED
		//				    && MoPubAndroidManager.INTERSTITIAL_AD_STATE != MoPubAndroidManager.INTERSTITIAL_STATES.LOADING){
		//					
		//					if(GameManager.Instance.GetPreviousGameState() != GameManager.GameState.LEVELSETTINGS){
		//						MoPubAndroid.requestInterstitalAd(Constants.INTERSTITIAL_ID_ANDROID);
		//						MoPubAndroidManager.INTERSTITIAL_AD_STATE = MoPubAndroidManager.INTERSTITIAL_STATES.LOADING;
		//						DebugNew.Log(" ++++ MoPub Ads Start Loading ++++");
		//					}
		//					
		//					
		//				}
		//				DebugNew.Log(" ++++ MoPub Ads State :"+MoPubAndroidManager.INTERSTITIAL_AD_STATE+" ++++");
		//				
		//				#endif
		//				#if UNITY_IPHONE
		//				if(MoPubManager.INTERSTITIAL_AD_STATE != MoPubManager.INTERSTITIAL_STATES.LOADED
		//				   && MoPubManager.INTERSTITIAL_AD_STATE != MoPubManager.INTERSTITIAL_STATES.LOADING){	
		//					if(GameManager.Instance.GetPreviousGameState() != GameManager.GameState.LEVELSETTINGS){
		//						MoPubBinding.requestInterstitialAd(Constants.INTERSTITIAL_ID_IOS,null);
		//						MoPubManager.INTERSTITIAL_AD_STATE = MoPubManager.INTERSTITIAL_STATES.LOADING;
		//					}
		//				}
		//				#endif
		//				ShowMopubAdOnMainMenu();
		//			}
		//		}
		
	}
	
	private void ShowMopubAdOnMainMenuScreen(){		
		#if UNITY_ANDROID
		DebugNew.Log("----------- Show MoPub Ad State: " + MoPubManager.INTERSTITIAL_AD_STATE);
		if(MoPubManager.INTERSTITIAL_AD_STATE == MoPubManager.INTERSTITIAL_STATES.LOADED){
			if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.MAINMENU)
				MoPubAndroid.showInterstitialAd(Constants.INTERSTITIAL_ID_ANDROID);	
		} 
		#endif
		#if UNITY_IPHONE
		if(MoPubManager.INTERSTITIAL_AD_STATE == MoPubManager.INTERSTITIAL_STATES.LOADED){
			if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.MAINMENU)
				MoPubBinding.showInterstitialAd(Constants.INTERSTITIAL_ID_IOS);
		}
		
		#endif	
	}
	
	private void ShowMopubAdOnLevelEnd(){		
		#if UNITY_ANDROID
		DebugNew.Log("----------- Show MoPub Ad State: " + MoPubManager.INTERSTITIAL_AD_STATE);
		
		if(MoPubManager.INTERSTITIAL_AD_STATE == MoPubManager.INTERSTITIAL_STATES.LOADED)
		{				
			if(adsCount % 3 == 0){
				MoPubAndroid.showInterstitialAd(Constants.INTERSTITIAL_ID_ANDROID_VIDEO);
			}
			else
				MoPubAndroid.showInterstitialAd(Constants.INTERSTITIAL_ID_ANDROID);
		} 
		#endif
		#if UNITY_IPHONE
		if(MoPubManager.INTERSTITIAL_AD_STATE == MoPubManager.INTERSTITIAL_STATES.LOADED){
			MoPubBinding.showInterstitialAd(Constants.INTERSTITIAL_ID_IOS);
		}
		
		#endif
	}
	
	public void PlayHavenOnMoreGames()
	{
		//Playhaven.sendContentRequest( "more_games", true );
	}
	
	void OnApplicationPause(bool status)
	{
		if(status)
		{
			pauseTime = Time.realtimeSinceStartup;
		}
		else
		{
			#if UNITY_ANDROID
			if(!UserPrefs.isIgnoreAds && !UserPrefs.isAmazonBuild)
				//		Playhaven.requestAppOpen();
				#endif
				timeDifference = Time.realtimeSinceStartup - pauseTime;
			if(timeDifference >= timeLimit)
			{
				DebugNew.Log("Change the state");
				if(!UserPrefs.isIgnoreAds && !UserPrefs.isAmazonBuild)
					ShowGoogleAd();
				//		Playhaven.sendContentRequest( "game_resume", true );
			}
			
		}
		
	}
	
	public void removeAds(){
		if(!UserPrefs.isIgnoreAds){
			UserPrefs.isIgnoreAds = true;
			UserPrefs.Save();
		}
	}
	
	//	void myMakePurchaseMethod( UpsightPurchase purchase )
	//	{
	//		if(purchase != null){
	//			# if UNITY_IPHONE
	//			if(StoreKitBinding.canMakePayments())
	//			{						
	//				StoreKitBinding.purchaseProduct(purchase.productIdentifier,purchase.quantity);
	//			}
	//			# endif
	//			
	//			# if UNITY_ANDROID		
	//			GoogleIAB.purchaseProduct(purchase.productIdentifier);
	//			# endif
	//		}			
	//	}
	//	
	//	void myUnlockedRewardMethod( UpsightReward reward )
	//	{
	//		if(reward != null){
	//			UserPrefs.totalCoins += reward.quantity;
	//			UserPrefs.Save();
	//		}
	//	}
	
	void CreateBannerAds(){
		//		if(!UserPrefs.isIgnoreAds){
		//			#if UNITY_ANDROID
		//				MoPubAndroid.createBanner( Constants.BANNER_ID_ANDROID, MoPubAdPlacement.TopCenter );
		//			#endif
		//			#if UNITY_IPHONE
		//				//MoPubAndroid.createBanner( Constants.BANNER_ID_IOS, MoPubAdPlacement.TopCenter );
		//			#endif
		//		}
	}
	
	public void DestroyBannerAds(){
		//		if(!UserPrefs.isIgnoreAds){
		//			#if UNITY_ANDROID
		//				MoPubAndroid.destroyBanner();
		//			#endif
		//			#if UNITY_IPHONE
		//				// Write here for destroy Banner ads code
		//			#endif
		//		}
	}
	
	void hideBannerAds(){
		//		if(!UserPrefs.isIgnoreAds){
		//			#if UNITY_ANDROID
		//				MoPubAndroid.hideBanner(true);
		//			#endif
		//			#if UNITY_IPHONE
		//				// Write here for hide banner ads code
		//			#endif
		//		}
	}
	
	void showBannnerAds(){
		//		if(!UserPrefs.isIgnoreAds){
		//			if(!UserPrefs.isBannerAdsCreated){
		//				UserPrefs.isBannerAdsCreated = true;
		//				CreateBannerAds();
		//				return;
		//			}
		//			#if UNITY_ANDROID
		//				MoPubAndroid.hideBanner(false);
		//			#endif
		//			#if UNITY_IPHONE
		//			// Write here for show banner ads code
		//			#endif
		//		}
	}
	
}


