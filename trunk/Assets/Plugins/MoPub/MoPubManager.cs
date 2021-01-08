using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


#if UNITY_IPHONE || UNITY_ANDROID
public class MoPubManager : MonoBehaviour
{

	public enum INTERSTITIAL_STATES {
		NONE,
		LOADING,
		LOADED,
		DISPLAYED,
		FAILED,
		EXPIRED,
		LEVELENDAD_LOADING
	};

	public enum REWARDED_VIDEO_STATES {
		NONE,
		LOADING,
		LOADED,
		DISPLAYED,
		FAILED,
		EXPIRED,
		FAILED_TO_PLAY,
		RECIEVED_REWARD,
		CLOSED,
		LEAVING_APP
	};

	public static REWARDED_VIDEO_STATES REWARDED_VIDEO_STATE = REWARDED_VIDEO_STATES.NONE;
	public static INTERSTITIAL_STATES INTERSTITIAL_AD_STATE = INTERSTITIAL_STATES.NONE;

	// Fired when an ad loads in the banner. Includes the ad height.
	public static event Action<float> onAdLoadedEvent;

	// Fired when an ad fails to load for the banner
	public static event Action onAdFailedEvent;

	// Android only. Fired when a banner ad is clicked
	public static event Action onAdClickedEvent;

	// Android only. Fired when a banner ad expands to encompass a greater portion of the screen
	public static event Action onAdExpandedEvent;

	// Android only. Fired when a banner ad collapses back to its initial size
	public static event Action onAdCollapsedEvent;

	// Fired when an interstitial ad is loaded and ready to be shown
	public static event Action onInterstitialLoadedEvent;

	// Fired when an interstitial ad fails to load
	public static event Action onInterstitialFailedEvent;

	// Fired when an interstitial ad is dismissed
	public static event Action onInterstitialDismissedEvent;

	// iOS only. Fired when an interstitial ad expires
	public static event Action onInterstitialExpiredEvent;

	// Android only. Fired when an interstitial ad is displayed
	public static event Action onInterstitialShownEvent;

	// Android only. Fired when an interstitial ad is clicked
	public static event Action onInterstitialClickedEvent;

	// Fired when a rewarded video finishes loading and is ready to be displayed
	public static event Action<string> onRewardedVideoLoadedEvent;

	// Fired when a rewarded video fails to load. Includes the error message.
	public static event Action<string> onRewardedVideoFailedEvent;

	// iOS only. Fired when a rewarded video expires
	public static event Action<string> onRewardedVideoExpiredEvent;
	
	// Fired when an rewarded video is displayed
	public static event Action<string> onRewardedVideoShownEvent;

	// Fired when a rewarded video fails to play. Includes the error message.
	public static event Action<string> onRewardedVideoFailedToPlayEvent;

	// Fired when a rewarded video completes. Includes all the data available about the reward.
	public static event Action<RewardedVideoData> onRewardedVideoReceivedRewardEvent;

	// Fired when a rewarded video closes
	public static event Action<string> onRewardedVideoClosedEvent;

	// iOS only. Fired when a rewarded video event causes another application to open
	public static event Action<string> onRewardedVideoLeavingApplicationEvent;


	void Awake() {
		gameObject.name = this.GetType().ToString();
		DontDestroyOnLoad( this );
	}


	public class RewardedVideoData
	{
		public string adUnitId;
		public string currencyType;
		public float amount;


		public RewardedVideoData( string json )
		{
			var obj = MoPubMiniJSON.Json.Deserialize( json ) as Dictionary<string,object>;
			if( obj == null )
				return;

			if( obj.ContainsKey( "adUnitId" ) )
				adUnitId = obj["adUnitId"].ToString();

			if( obj.ContainsKey( "currencyType" ) )
				currencyType = obj["currencyType"].ToString();

			if( obj.ContainsKey( "amount" ) )
				amount = float.Parse( obj["amount"].ToString() );
		}


		public override string ToString ()
		{
			return string.Format( "adUnitId: {0}, currencyType: {1}, amount: {2}", adUnitId, currencyType, amount );
		}
	}



	static MoPubManager()
	{
		var type = typeof( MoPubManager );
		try
		{
			// first we see if we already exist in the scene
			var obj = FindObjectOfType( type ) as MonoBehaviour;
			if( obj != null )
				return;

			// create a new GO for our manager
			var managerGO = new GameObject( type.ToString() );
			managerGO.AddComponent( type );
			DontDestroyOnLoad( managerGO );
		}
		catch( UnityException )
		{
			Debug.LogWarning( "It looks like you have the " + type + " on a GameObject in your scene. Please remove the script from your scene." );
		}
	}



	void onAdLoaded( string height )
	{
		if( onAdLoadedEvent != null )
			onAdLoadedEvent( float.Parse( height ) );
	}


	void onAdFailed( string empty )
	{
		if( onAdFailedEvent != null )
			onAdFailedEvent();
	}


	void onAdClicked( string empty )
	{
		if ( onAdClickedEvent != null )
			onAdClickedEvent();
	}


	void onAdExpanded( string empty )
	{
		if ( onAdExpandedEvent != null )
			onAdExpandedEvent();
	}


	void onAdCollapsed( string empty )
	{
		if ( onAdCollapsedEvent != null )
			onAdCollapsedEvent();
	}


	void onInterstitialLoaded( string empty )
	{
		if (onInterstitialLoadedEvent != null) {
			onInterstitialLoadedEvent();
			INTERSTITIAL_AD_STATE = INTERSTITIAL_STATES.LOADED;
			Debug.Log("MoPubManager::onInterstitialLoaded::INTERSTITIAL_AD_STATE::INTERSTITIAL_STATES.LOADED");
		}

	}


	void onInterstitialFailed( string adUnitId )
	{
		if (onInterstitialFailedEvent != null) {
			onInterstitialFailedEvent();
			INTERSTITIAL_AD_STATE = INTERSTITIAL_STATES.FAILED;
			Debug.Log("MoPubManager::onInterstitialFailed::INTERSTITIAL_AD_STATE::INTERSTITIAL_STATES.FAILED");
		}
			
	}


	void onInterstitialDismissed( string adUnitId )
	{
		if (onInterstitialDismissedEvent != null) {
			onInterstitialDismissedEvent();
			INTERSTITIAL_AD_STATE = INTERSTITIAL_STATES.NONE;
			Debug.Log("MoPubManager::onInterstitialDismissed::INTERSTITIAL_AD_STATE::INTERSTITIAL_STATES.NONE");
		}
			
	}


	void interstitialDidExpire( string adUnitId )
	{
		if (onInterstitialExpiredEvent != null) {
			onInterstitialExpiredEvent();
			INTERSTITIAL_AD_STATE = INTERSTITIAL_STATES.EXPIRED;
			Debug.Log("MoPubManager::interstitialDidExpire::INTERSTITIAL_AD_STATE::INTERSTITIAL_STATES.EXPIRED");
		}

	}


	void onInterstitialShown( string empty )
	{
		if (onInterstitialShownEvent != null) {
			onInterstitialShownEvent();
			INTERSTITIAL_AD_STATE = INTERSTITIAL_STATES.DISPLAYED;
			Debug.Log("MoPubManager::onInterstitialShown::INTERSTITIAL_AD_STATE::INTERSTITIAL_STATES.DISPLAYED");
		}
			
	}


	void onInterstitialClicked( string empty )
	{
		if (onInterstitialClickedEvent != null) {
			onInterstitialClickedEvent();
			INTERSTITIAL_AD_STATE = INTERSTITIAL_STATES.NONE;
			Debug.Log("MoPubManager::onInterstitialClicked::INTERSTITIAL_AD_STATE::INTERSTITIAL_STATES.NONE");
		}
			
	}


	#region Rewarded Videos

	void onRewardedVideoLoaded( string adUnitId )
	{
		if (onRewardedVideoLoadedEvent != null) {
			onRewardedVideoLoadedEvent( adUnitId );
			REWARDED_VIDEO_STATE = REWARDED_VIDEO_STATES.LOADED;
			Debug.Log("MoPubManager:: Rewarded Video Loaded");
		}
			
	}


	void onRewardedVideoFailed( string adUnitId )
	{
		if (onRewardedVideoFailedEvent != null) {
			onRewardedVideoFailedEvent( adUnitId );
			REWARDED_VIDEO_STATE = REWARDED_VIDEO_STATES.FAILED;
			Debug.Log("MoPubManager:: Rewarded Video Failed To Load");
		}
			
	}


	void onRewardedVideoExpired( string adUnitId )
	{
		if (onRewardedVideoExpiredEvent != null) {
			onRewardedVideoExpiredEvent( adUnitId );
			REWARDED_VIDEO_STATE = REWARDED_VIDEO_STATES.EXPIRED;
			Debug.Log("MoPubManager:: Rewarded Video Expired");
		}
			
	}


	void onRewardedVideoShown( string adUnitId )
	{
		if (onRewardedVideoShownEvent != null) {
			onRewardedVideoShownEvent( adUnitId );
			REWARDED_VIDEO_STATE = REWARDED_VIDEO_STATES.DISPLAYED;
			Debug.Log("MoPubManager:: Rewarded Video Displayed");
		}
			
	}


	void onRewardedVideoFailedToPlay( string adUnitId )
	{
		if (onRewardedVideoFailedToPlayEvent != null) {
			onRewardedVideoFailedToPlayEvent( adUnitId );
			REWARDED_VIDEO_STATE = REWARDED_VIDEO_STATES.FAILED_TO_PLAY;
			Debug.Log("MoPubManager:: Rewarded Video Failed To Play");
		}
			
	}


	void onRewardedVideoReceivedReward( string json )
	{
		if (onRewardedVideoReceivedRewardEvent != null) {
			onRewardedVideoReceivedRewardEvent( new RewardedVideoData( json ) );
			REWARDED_VIDEO_STATE = REWARDED_VIDEO_STATES.RECIEVED_REWARD;
			Debug.Log("MoPubManager:: Rewarded Video Recieved Reward");
		}
			
	}


	void onRewardedVideoClosed( string adUnitId )
	{
		if (onRewardedVideoClosedEvent != null) {
			onRewardedVideoClosedEvent( adUnitId );
			REWARDED_VIDEO_STATE = REWARDED_VIDEO_STATES.CLOSED;
			Debug.Log("MoPubManager:: Rewarded Video Closed");
		}
			
	}


	void onRewardedVideoLeavingApplication( string adUnitId )
	{
		if (onRewardedVideoLeavingApplicationEvent != null) {
			onRewardedVideoLeavingApplicationEvent( adUnitId );
			REWARDED_VIDEO_STATE = REWARDED_VIDEO_STATES.LEAVING_APP;
			Debug.Log("MoPubManager:: Rewarded Video Leaving App");
		}
			
	}
	
	#endregion


}
#endif
