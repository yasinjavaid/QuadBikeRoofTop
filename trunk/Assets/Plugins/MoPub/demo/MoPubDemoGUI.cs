using UnityEngine;
using System.Collections.Generic;


public class MoPubDemoGUI : MonoBehaviour
{
#if UNITY_IPHONE || UNITY_ANDROID
//	private string _bannerAdUnit = "23b49916add211e281c11231392559e4";
	private string _interstitialAdUnit = "6719d970a18d44b1bd77aee205259663";
	private string _interstitialVideoAdUnit = "f01892b624694443a6c3fdf30a1c3aa9";

#if UNITY_IPHONE
	private string _rewardedVideoAdUnit = "fdd35fb5d55b4ccf9ceb27c7a3926b7d";
#else
	private string _rewardedVideoAdUnit = "56e3e9058ea64682a5000ce063c00d69";
#endif

	void Start()
	{
		MoPub.initializeRewardedVideo();
		Debug.Log("Rewarded Video Initialized");
	}

	void OnGUI()
	{
		GUI.skin.button.margin = new RectOffset( 0, 0, 10, 0 );
		GUI.skin.button.stretchWidth = true;
		GUI.skin.button.fixedHeight = ( Screen.width >= 1024 || Screen.height >= 768 ) ? 50 : 20;

		var halfWidth = Screen.width / 2;
		GUILayout.BeginArea( new Rect( 0, 0, halfWidth, Screen.height ) );
		GUILayout.BeginVertical();

		GUILayout.Space( 300 );
//		if( GUILayout.Button( "Create Banner (bottom center)" ) )
//		{
//			MoPub.createBanner( _bannerAdUnit, MoPubAdPosition.BottomCenter );
//		}


//		if( GUILayout.Button( "Create Banner (top center)" ) )
//		{
//			MoPub.createBanner( _bannerAdUnit, MoPubAdPosition.TopCenter );
//		}


//		if( GUILayout.Button( "Destroy Banner" ) )
//		{
//			MoPub.destroyBanner();
//		}


//		if( GUILayout.Button( "Show Banner" ) )
//		{
//			MoPub.showBanner( true );
//		}


//		if( GUILayout.Button( "Hide Banner" ) )
//		{
//			MoPub.showBanner( false );
//		}

		if( GUILayout.Button( "Request Video Ad" ,GUILayout.Height(100)) )
		{

			if (MoPubManager.INTERSTITIAL_AD_STATE != MoPubManager.INTERSTITIAL_STATES.LOADED && 
			    MoPubManager.INTERSTITIAL_AD_STATE != MoPubManager.INTERSTITIAL_STATES.LOADING) {
				
				MoPub.requestInterstitialAd( _interstitialVideoAdUnit );

				MoPubManager.INTERSTITIAL_AD_STATE = MoPubManager.INTERSTITIAL_STATES.LOADING;
				Debug.Log("Loading Interstitial Video Ads. Ad State: "+MoPubManager.INTERSTITIAL_AD_STATE);
				
			} else{
				Debug.Log("Interstitial Video Ad is already loaded. Ad State: "+MoPubManager.INTERSTITIAL_AD_STATE);
			}
		}

		if( GUILayout.Button( "Show Video Ad", GUILayout.Height(100) ) )
		{
			if (MoPubManager.INTERSTITIAL_AD_STATE == MoPubManager.INTERSTITIAL_STATES.LOADED) {
				
				MoPub.showInterstitialAd( _interstitialVideoAdUnit );

				MoPubManager.INTERSTITIAL_AD_STATE = MoPubManager.INTERSTITIAL_STATES.DISPLAYED;
				Debug.Log("Show Interstitial Video Ad. Ad State: "+MoPubManager.INTERSTITIAL_AD_STATE);
				
			} else {
				Debug.Log("Interstitial Video Ad is not ready. Ad State: "+MoPubManager.INTERSTITIAL_AD_STATE);
			}
		}

//		if( GUILayout.Button( "Test Button:: 3" ) )
//		{
//
//		}


//		if( GUILayout.Button( "Test Button:: 4" ) )
//		{
//
//		}

		GUILayout.EndVertical();
		GUILayout.EndArea();

		GUILayout.BeginArea( new Rect( Screen.width - halfWidth, 0, halfWidth, Screen.height ) );
		GUILayout.BeginVertical();

		GUILayout.Space( 300 );

		if( GUILayout.Button( "Request Interstitial Ads",GUILayout.Height(100) ))
		{

			if (MoPubManager.INTERSTITIAL_AD_STATE != MoPubManager.INTERSTITIAL_STATES.LOADED && 
			    MoPubManager.INTERSTITIAL_AD_STATE != MoPubManager.INTERSTITIAL_STATES.LOADING){

				MoPub.requestInterstitialAd( _interstitialAdUnit );

				MoPubManager.INTERSTITIAL_AD_STATE = MoPubManager.INTERSTITIAL_STATES.LOADING;
				Debug.Log("Loading Interstitial. Ad State: "+MoPubManager.INTERSTITIAL_AD_STATE);

			} else{
				Debug.Log("Interstitial is already loaded. Ad State: "+MoPubManager.INTERSTITIAL_AD_STATE);
			}
		}


		if( GUILayout.Button( "Show Interstitial Ads",GUILayout.Height(100) ) )
		{

			if (MoPubManager.INTERSTITIAL_AD_STATE == MoPubManager.INTERSTITIAL_STATES.LOADED) {

				MoPub.showInterstitialAd( _interstitialAdUnit );

				MoPubManager.INTERSTITIAL_AD_STATE = MoPubManager.INTERSTITIAL_STATES.DISPLAYED;
				Debug.Log("Show Interstitial. Ad State: "+MoPubManager.INTERSTITIAL_AD_STATE);

			} else {
				Debug.Log("Ad is not ready. Ad State: "+MoPubManager.INTERSTITIAL_AD_STATE);
			}
		}


		GUILayout.Space( 100 );
		if( GUILayout.Button( "Report App Open", GUILayout.Height(100) ) )
		{
			MoPub.reportApplicationOpen();
		}

		GUILayout.Space( 100 );
//		if( GUILayout.Button( "Enable Location Support" ) )
//		{
//			MoPub.enableLocationSupport( true );
//		}


//		GUILayout.Space( 20 );
		if( GUILayout.Button( "Request Rewarded Video", GUILayout.Height(100)) )
		{
			MoPub.requestRewardedVideo( _rewardedVideoAdUnit );
			Debug.Log( "requesting rewarded video with ad unit: " + _rewardedVideoAdUnit );
		}


		if( GUILayout.Button( "Request Rewarded Video with Options", GUILayout.Height(100)) )
		{
			MoPub.requestRewardedVideo( _rewardedVideoAdUnit, getMediationSettings() );
			Debug.Log( "requesting rewarded video with ad unit: " + _rewardedVideoAdUnit );
		}

		if( GUILayout.Button( "Show Rewarded Video", GUILayout.Height(100)) )
		{
			MoPub.showRewardedVideo( _rewardedVideoAdUnit );
		}

		if( GUILayout.Button( "Request MPX Rewarded Video", GUILayout.Height(100)) )
		{
			MoPub.requestRewardedVideo( _rewardedVideoAdUnit, null, "rewarded, video, mopub", 37.7833, 122.4167 );
			Debug.Log( "requesting mpx rewarded video with ad unit: " + _rewardedVideoAdUnit );
		}

		if( GUILayout.Button( "Show MPX Rewarded Video", GUILayout.Height(100)) )
		{
			MoPub.showRewardedVideo( _rewardedVideoAdUnit );
		}


		GUILayout.EndVertical();
		GUILayout.EndArea();
	}


#if UNITY_IPHONE
	// mediation settings vary based on platform so we use a simple helper method to generate them here
	List<MoPubMediationSetting> getMediationSettings()
	{
		var adColonySettings = new MoPubMediationSetting( "AdColony" );
		adColonySettings.Add( "showPrePopup", true );
		adColonySettings.Add( "showPostPopup", true );

		var vungleSettings = new MoPubMediationSetting( "Vungle" );
		vungleSettings.Add( "userIdentifier", "the-user-id" );

		var mediationSettings = new List<MoPubMediationSetting>();
		mediationSettings.Add( adColonySettings );
		mediationSettings.Add( vungleSettings );

		return mediationSettings;
	}
#else
	List<MoPubMediationSetting> getMediationSettings()
	{
		var adColonySettings = new MoPubMediationSetting( "AdColony" );
		adColonySettings.Add( "withConfirmationDialog", true );
		adColonySettings.Add( "withResultsDialog", true );

		var chartboostSettings = new MoPubMediationSetting( "Chartboost" );
		chartboostSettings.Add( "customId", "the-user-id" );

		var vungleSettings = new MoPubMediationSetting( "Vungle" );
		vungleSettings.Add( "userId", "the-user-id" );
		vungleSettings.Add( "cancelDialogBody", "Cancel Body" );
		vungleSettings.Add( "cancelDialogCloseButton", "Shut it Down" );
		vungleSettings.Add( "cancelDialogKeepWatchingButton", "Watch On" );
		vungleSettings.Add( "cancelDialogTitle", "Cancel Title" );

		var mediationSettings = new List<MoPubMediationSetting>();
		mediationSettings.Add( adColonySettings );
		mediationSettings.Add( chartboostSettings );
		mediationSettings.Add( vungleSettings );

		return mediationSettings;
	}
#endif

#endif
}
