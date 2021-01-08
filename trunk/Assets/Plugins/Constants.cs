using UnityEngine;
using System.Collections;

public class Constants {
	public static int rewardedCashAmount  = 400;

	public static string POPUP_MESSAGE = "";
	public static string CURRENCY_TYPE_COIN = "Coins";

	public static int TIME_TO_SHOW_AD = 3;

	public const float SCREEN_WIDTH = 1024f;
	public const float SCREEN_HEIGHT = 768f;
	public static float XSCALE = 0f;

	public static float indiXP = 25;
	public static float beltXP = 25;
	public static float signalXP = 25;
	public static float nocrossingXP = 25;
	public static float speedXP = 25;
	public static float collisionXP = 25;

	public static string msgIndiError = "InCorrect Use of Indicator! ";
	public static string msgnoIndiError = "No Indicator Used! ";
	public static string msgIndiCor = "Correct Use of Indicator! ";
	public static string msgNoCrossingError = "Illegal Crossing! ";
	public static string msgBeltError = "No Seat Belt! ";
	public static string msgBeltCor = "Correct Use of Seat Belt! ";
	public static string msgSignalError = "Red Light Crossing! ";
	public static string msgSignalCor = "Green Light Crossing! ";
	public static string msgSpeedError = "Exceeded Speed Limit! ";
	public static string msgCollision = "Collision! ";
	public static string xp = "XP";

	#region InApp

	public const string BundleID = "com.tapinator.driving.academy.reloaded";

	public const string INAPP_KEY = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAsF5hSHY/gp/XLHC62IA8UZmMUjEsXTxv4e+FbQ/KP+5hzoAL2AWJlaAJZjPAi9NJELgATdH33IwqZnyr4N08NIDekvgTvPVlKdDVeE3UdR0I6aP59AYF8mMDbxk0znFJPAD0bzchGzokWP/4nVx6TvRVZamj01sIRhIzoDIKHmm2vuLEvH/6kyJmgcbVPXPYZXwqtPs6XqbPP19BLuH3eT0psKlAoG7h5N6FsTNh4Rs3kfyvrLphMo/NFoxnNlfwEcOtKj5BElF2Pmhmyl2e28i4B2/uWzamikyQtIqWsYe58hqRs72Q0pvp7lTpDvlGs+yOFgWttdTL+bMQ/x1kRwIDAQAB";
	// Consumable In-apps. GN stand for Game Name

	public const string INAPP_CURRENCY = "USD";
	public const string Coins_Package1Price = "19.99";
	public const string Coins_Package2Price = "9.99";
	public const string Coins_Package3Price = "4.99";
	public const string Coins_Package4Price = "1.99";
	public const string Coins_Package5Price = "0.99";

	public const string PACKAGE_1  = "com.tapinator.driving.academy.reloaded.300000coins";
	public const string PACKAGE_2 = "com.tapinator.driving.academy.reloaded.125000coins";
	public const string PACKAGE_3 = "com.tapinator.driving.academy.reloaded.50000coins";
	public const string PACKAGE_4 = "com.tapinator.driving.academy.reloaded.20000coins"; //
	public const string PACKAGE_5 = "com.tapinator.driving.academy.reloaded.5000coins";//"android.test.purchased";

	public const string PACKAGE_1_AMOUNT = "300,000";
	public const string PACKAGE_2_AMOUNT = "125,000";
	public const string PACKAGE_3_AMOUNT = "50,000";
	public const string PACKAGE_4_AMOUNT = "20,000";
	public const string PACKAGE_5_AMOUNT = "5,000";

	public const int PACKAGE_1_Coins = 300000;
	public const int PACKAGE_2_Coins = 125000;
	public const int PACKAGE_3_Coins = 50000;
	public const int PACKAGE_4_Coins = 20000;
	public const int PACKAGE_5_Coins = 5000;

	#endregion

	#region Twitter
	public const string Twitter_ConsumerKey = "t8UPqkNoDxFFS0vqGLjNU3GXi";
	public const string Twitter_ConsumerSecret = "HyX07I3Y5TsBoWd1i36GLFHFl3tK8J8QlVD765MDTIm1eNHChf";
	public const int iOS_IAP_Verification_ID = 105;

	public const string tweet = "Loving this #mobile #game from @tapinator {0} $tapm";
	public const string bitlyLink = "http://bit.ly/1OYuFDC";

	#endregion

	public const string receiptVerifySandboxURL = "http://52.7.151.190/inapp/receipt/Verification";
	public const string receiptVerifyLiveURL = "http://52.7.151.190/inapp/index.php/api/inapp/verify2";
	public const string IAP_secret_key = "HS0FM3MOBLXF9KO";

	#region AdNetworks

	public const string INTERSTITIAL_ID_IOS = "c076fe553f1540d2af746d56b753bfa1";  // Mobup ID
	public const string INTERSTITIAL_ID_IOS_VIDEO = "9bde8e4b64224f8cb1c6ee074f00aa16";

	public const string INTERSTITIAL_ID_ANDROID ="4fe4386039c247fa98682634b826412a";  // Mobup ID ba81db9b97c743618ace07d90df96b9c
	public const string INTERSTITIAL_ID_ANDROID_VIDEO = "3049c1e19610421397f798fdd8c9b39c"; //"fc8c70f8b5bd4a008198a4f19edb8aab"

	public const string AndroidAppTokenPlayHaven = "000d44374e1b4c5e8785c2859b753641"; //
	public const string AndroidAppSecretPlayHaven = "d44c723746424655846af86fa4e75678"; //
	public const string iOSAppTokenPlayHaven = "30d818e4aa5048c88b66cde3097ae10b";
	public const string iOSAppSecretPlayHaven = "a72b66ea430d49a893ce5c069a88fa37";

	#endregion

	#region MenuConstants
	// menus Constants
	public const bool isMarketReadyBuild = false;
	public const string	GAME_NAME ="Driving Academy Reloaded";
	public const string FACEBOOK_LINK = "http://www.facebook.com/549519761779384" ;
	public const string TWITTER_LINK = "http://www.twitter.com/Tapinator" ;
	public const string AMAZON_RATEUS_LINK ="amzn://apps/android?p=com.tapinator.driving.academy.reloaded";
	public const string IOS_RATEUS_LINK ="itms-apps://itunes.apple.com/WebObjects/MZStore.woa/wa/viewContentsUserReviews?type=Purple+Software&id=983903899?at=10l6dK";
	public const string IOS7_RATEUS_LINK ="itms-apps://itunes.apple.com/app/id983903899?at=10l6dK";
	public const string ANDROID_RATEUS_LINK ="market://details?id=com.tapinator.driving.academy.reloaded";
	public const string ANDROID_MOREGAMES_LINK = "market://search?q=tapinator";

	public const int    COINSTOSKIPLEVEL = 500;            // 50 coins to skip level.
	public static int []	LEVELCOMPLETEREWARD = {300, 400, 500};    // 30 coins
	public const string SCENE_EPISODE1 = "FiremanSim2016Old";
	public const string SCENE_EPISODE2 = "DrivingSchool-Env2";
	public const string SCENE_EPISODE3 = "Env";
	public const string SCENE_MENU ="MenusScene";

	public const int levelsPerEpisode = 12;
	public const int totalEpisodes = 2;
	public const int totalLevels = 24;
	public static string [ ] episodeNameArray =       { "Episode 1" , "Episode 2","Episode 3", "Episode 4" } ;

	public static float[,] timePerLevel = new float[2,levelsPerEpisode]{{50,50,50,50,50,
			60,60,60,60,60,
			60,60},
		{100.0f, 80.0f, 80.0f, 80.0f, 80.0f,
			80.0f,80.0f,80.0f,180.0f,100.0f,
			180.0f,100.0f}};
	/*###Unused values - ZI - TODO*/
	public static float[] timeSlabForStars = {80,60,40};

	public enum GAME_MODE {
		NORMAL, INVINCIBLE, FUN, KIDS, FREE
	}

	public static GAME_MODE GameMode = GAME_MODE.NORMAL;

	public const string VIDEO_AD_ZONE = "defaultZone";
	public const string REWARDED_AD_ZONE = "rewardedVideoZone";

	#endregion

	#region OutOFFuel
	public const int outOfFuelPackageOneCoins = 150;
	public const int outOfFuelPackageTwoCoins = 300;
	public const int outOfFuelPackageThreeCoins = 500;

	public const int outOfFuelPackageOneFuel = 20;
	public const int outOfFuelPackageTwoFuel = 50;
	public const int outOfFuelPackageThreeFuel = 90;

	#endregion

	#region Episode coins

	public const int SecondEpisode_Unlock_Coins = 5200;
	public const int ThirdEpisode_Unlock_Coins =  3000;
	public static int [ ] episodePriceArray   = { 0 ,  5200 , 3000 , 0 } ;

	#endregion


	//	public static string [ ] VehiclePrefabNames = { "mercedez", "MustangNew", "L200", "Fit", "lamborgin", "Fit", "Dodge", "FantasticFitCar", "RangeRover" };


	public const float KMHtoKMS = 0.000277777778f;
	public const float LEVEL_DIFFICULTY_INCREASE_RATIO = 0.2f;

}