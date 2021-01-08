using UnityEngine;
using System.Collections;

public class ConstantsNew : MonoBehaviour {
	
	#region InApp



	public const string Coins_Package1Price = "19.99";
	public const string Coins_Package2Price = "9.99";
	public const string Coins_Package3Price = "4.99";
	public const string Coins_Package4Price = "2.99";
	public const string Coins_Package5Price = "0.99";
	

	public const string PACKAGE_1_AMOUNT = "160,000";
	public const string PACKAGE_2_AMOUNT = "66,000";
	public const string PACKAGE_3_AMOUNT = "30,000";
	public const string PACKAGE_4_AMOUNT = "16,000";
	public const string PACKAGE_5_AMOUNT = "5,000";
	
	public const int PACKAGE_1_Coins = 160000;
	public const int PACKAGE_2_Coins = 66000;
	public const int PACKAGE_3_Coins = 30000;
	public const int PACKAGE_4_Coins = 16000;
	public const int PACKAGE_5_Coins = 5000;

	
	public const string PACKAGE_1_Detail = "( 150,000 + 60,000 FREE )";
	public const string PACKAGE_2_Detail = "( 50,000  + 16,000 FREE )";
	public const string PACKAGE_3_Detail = "( 25,000  + 5,000 FREE )";
	public const string PACKAGE_4_Detail = "( 15,000  + 1,000 FREE )";


			
	//Packages
	public const string receiptVerifySandboxURL = "http://54.197.239.209/inapp/receipt/Verification";
	public const string receiptVerifyLiveURL = "http://54.197.239.209/inapp/receipt/Verification";
	public const string PACKAGE_1 = "com.tapinator.rooftop.derby3d.160000coins"; 
	public const string PACKAGE_2 = "com.tapinator.rooftop.derby3d.66000coins";
	public const string PACKAGE_3 = "com.tapinator.rooftop.derby3d.30000coins";
	public const string PACKAGE_4 = "com.tapinator.rooftop.derby3d.16000coins";
	public const string PACKAGE_5 = "com.tapinator.rooftop.derby3d.5000coins"; 			//"android.test.purchased";
	public const string PACKAGE_VGP = "com.tapinator.rooftop.derby3d.vgp160000coins";

	public const string BundleID = "com.tapinator.rooftop.derby3d";
	public const string bundleVersion = "1.0";

	
	public const string REMOVEADS = "com.tapinator.ait.removeads"; 
	
	public const string UNLOCKALLEPISODE = "com.tapinator.ait.unlockepi";
	public const string UNLOCKALLVEHICLE = "com.tapinator.ait.unlockveh";
	public const string UNLOCKALL = "com.tapinator.ait.unlockall";
	#endregion
	
	
	#region upgradeMenu
	
	public const int UPGRADE_LEVELS = 10;
	public const int CURRENT_VEHICLE = 1;
	
	
	#endregion
	
	#region Game play
	public const float BRAKE_UPGRADE_FACTOR = 0.25f;
	public const float ENGINE_UPGRADE_FACTOR = 5f;
	public const float ENGINE_UPGRADE_PERFORMANCE_FACTOR = 1f;
	public const float STEERING_UPGRADE_FACTOR = 0.002f;
	public const float MAX_STEERING_UPGRADE_FACTOR = 5f;
	public const int FUEL_UPGRADE_FACTOR = 20;
	public const int Coins_Level_Success = 200;
	#endregion
	
	#region Episode coins
	
	public const int SecondEpisode_Unlock_Coins = 10000;
	public const int ThirdEpisode_Unlock_Coins =  15000;
	
	#endregion
	
	public const int SecondVehicle_Unlock_Coins = 6000;
	public const int ThirdVehicle_Unlock_Coins = 14000;
	
	
	public const string FACEBOOK_LINK = "http://www.facebook.com/549519761779384" ;
	public const string TWITTER_LINK = "http://www.twitter.com/Tapinator" ;
	public const string EmailID = "mailto:info@tapinator.com"; 
	public const string EmailSubject = "RoofTop Demolition Derby 3D"; 
	public const string EmailBody = "RoofTop Demolition Derby 3D"; 
	public const string AMAZON_RATEUS_LINK ="amzn://apps/android?p=com.tapinator.rooftop.derby3d";
	public const string IOS_RATEUS_LINK ="itms-apps://itunes.apple.com/WebObjects/MZStore.woa/wa/viewContentsUserReviews?type=Purple+Software&id=983903899?at=10l6dK";
	public const string IOS7_RATEUS_LINK ="itms-apps://itunes.apple.com/app/id983903899?at=10l6dK";
	public const string ANDROID_RATEUS_LINK ="market://details?id=com.tapinator.rooftop.derby3d";

	#region OutOFFuel
	public const int outOfFuelPackageOneCoins = 150;
	public const int outOfFuelPackageTwoCoins = 300;
	public const int outOfFuelPackageThreeCoins = 500;
	
	public const int outOfFuelPackageOneFuel = 20;	
	public const int outOfFuelPackageTwoFuel = 50;
	public const int outOfFuelPackageThreeFuel = 90;
	
	#endregion
	
	public const string space = " ";
	
	
	public const int SKIP_LEVEL_COINS = 400;
	
	public static int [ ] episodePriceArray   = { 0 ,  10000 , 15000 , 0 } ;
	public static int [ ] vehiclePriceArray   = { 0 ,  6000 , 14000 , 0 } ;

}
