using UnityEngine;
using System.Collections;

public class Constants {
	
	public const float SCREEN_WIDTH = 1024f;
	public const float SCREEN_HEIGHT = 768f;
	public static float XSCALE = 0f;
	#region InApp

	# if UNITY_IPHONE
	string purchasedProductId;
	string [] productIdentifiers = {ConstantsNew.PACKAGE_1,ConstantsNew.PACKAGE_2,ConstantsNew.PACKAGE_3,ConstantsNew.PACKAGE_4,ConstantsNew.PACKAGE_5,ConstantsNew.PACKAGE_VGP,ConstantsNew.UNLOCKALLEPISODE, ConstantsNew.UNLOCKALLVEHICLE, ConstantsNew.UNLOCKALL };
	bool canMakePayments = false;	
	# endif
	# if UNITY_ANDROID
	string [] productIdentifiers = {ConstantsNew.PACKAGE_1,ConstantsNew.PACKAGE_2,ConstantsNew.PACKAGE_3,ConstantsNew.PACKAGE_4,ConstantsNew.PACKAGE_5,ConstantsNew.PACKAGE_VGP };
	string [] managedProductIdentifiers = {Constants.REMOVEADS,Constants.UNLOCKALLEPISODE, Constants.UNLOCKALLVEHICLE, Constants.UNLOCKALL  };  	
	//		bool isRestoreTransaction = false;
	# endif



	public const string INAPP_KEY = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAygiAa+q4ubJX8a/+3n8/Dt5oF7KkZRvaFIgLH23uzKANyQt0fFufyM4MLh8Fm8YFzoruyHV5Gg0grFHfe1nEdSzg4/YntMYuDVjUKR1U2PltoHNsuTeka2R8bxSnvgxMe7CbK8l6uQpSsjXrM1SRDpDzK03HsaGFVSBl2i09w1am4o9nRQmehxRZKtO/XazdhK5pfB0rlOccUBqC5aqF95xLDbhrtPtFkbNAGvOKjH90v6Ofqb+zZTgqXw3/OaB1bgsaUTNKeoYGEUvx+ypYhvuQpuo+JvlCiGsK4leTqyb18Mf1mTbYTV0H5qaUIWf4BVsBWrQWbkuIyqfTHr77DwIDAQAB";
	// Consumable In-apps. GN stand for Game Name
	
	public const string INAPP_CURRENCY = "USD";

//	public const string PACKAGE_1  = "com.tapinator.ait.coins500"; 
//	public const string PACKAGE_2 = "com.tapinator.ait.coins1100";
//	public const string PACKAGE_3 = "com.tapinator.ait.coins1800";
//	public const string PACKAGE_4 = "com.tapinator.ait.coins3500";

	public const string PACKAGE_1  = "com.tapinator.copsmash.coins210000"; 
	public const string PACKAGE_2 = "com.tapinator.copsmash.coins66000";
	public const string PACKAGE_3 = "com.tapinator.copsmash.coins30000";
	public const string PACKAGE_4 = "com.tapinator.copsmash.coins16000";
	public const string PACKAGE_5 = "android.test.purchased";//"com.tapinator.cds.coins5000"; //"com.tapinator.cds.coins5000";
	
	public const int PACKAGE_1_AMOUNT = 500;
	public const int PACKAGE_2_AMOUNT = 1100;
	public const int PACKAGE_3_AMOUNT = 1800;
	public const int PACKAGE_4_AMOUNT = 3500;
	
	//Non Consumables In-apps. GN stand for Game Name
	public const string REMOVEADS = "com.tapinator.ait.removeads";
	public const string UNLOCKALLEPISODE = "com.tapinator.ait.unlockepi";
	public const string UNLOCKALLVEHICLE = "com.tapinator.ait.unlockveh";
	public const string UNLOCKALL = "com.tapinator.ait.unlockall";
	public const string  Bundle_ID ="com.tapinator.rooftop.derby3d";
	#endregion
	
	#region Achievements
	//ACID stand for Achievement ID
	
	//Social Achievements
	public const string ACIDFBFAN = "CgkIzNDu_-kQEAIQDA";
	public const string ACIDSUPPORTER = "CgkIzNDu_-kQEAIQDQ";
	public const string ACIDTWITTERANNOUNCER = "CgkIzNDu_-kQEAIQDg";
	public const bool isMarketReadyBuild = true;
	
	//Parking Achievements
	public const string ACIDRIDER = "CgkIzNDu_-kQEAIQAQ";
	public const string ACIDDRIVER = "CgkIzNDu_-kQEAIQAg";
	public const string ACIDPARKER = "CgkIzNDu_-kQEAIQAw";
	public const string ACIDBUSMAN = "CgkIzNDu_-kQEAIQBA";
	
	//Levels Achievements
	public const string ACIDHONKER = "CgkIzNDu_-kQEAIQBQ";
	public const string ACIDLASHER = "CgkIzNDu_-kQEAIQBg";
	
	public const string ACIDCHAUFFEUR = "CgkIzNDu_-kQEAIQBw";
	public const string ACIDCABBY = "CgkIzNDu_-kQEAIQCA";
	
	//Vehicles Achievements
	public const string ACIDTHIRLLLOVER = "CgkIzNDu_-kQEAIQCg";
	public const string ACIDMASTERBLASTER = "";
	public const string ACIDTURNKEY  = "";
	
	//Environment Achievements
	public const string ACIDEXPLORER = "CgkIzNDu_-kQEAIQCQ";
	public const string ACIDSHOPPINGKING = "";
	public const string ACIDALLOUT = "";
	
	//Coins Achievement
	public const string ACIDMANOFMEANS  = "CgkIzNDu_-kQEAIQCw";
	
	#endregion
	
	#region Leaderboards
	
	//LID stands for Leaderboard ID.
	public const string LIDTHEBENEFACTOR  = "CgkIzNDu_-kQEAIQDw";
	public const string LIDMASTERBLASTER = "CgkIzNDu_-kQEAIQEA";
	
	#endregion
	
	
	#region AdNetworks
	
	public const string INTERSTITIAL_ID_IOS = "f09b2afccb5848698e3e5998c78cef93";  // Mobup ID
	public const string INTERSTITIAL_ID_IOS_VIDEO = "6ad74dbdfbb941389d4a5ff1f1b38030";
	public const string INTERSTITIAL_ID_ANDROID ="ae056c36519f44f7998559c6c2f7c691";  // Mobup ID
	public const string INTERSTITIAL_ID_ANDROID_VIDEO ="72ebeaf18f804c1a9f29190f2fbacefa";

	#endregion
	
	#region MenuConstants
	// menus Constants
	public const string	GAME_NAME ="RoofTop Demolition Derby 3D";
	public const string FACEBOOK_LINK = "http://www.facebook.com/549519761779384" ;
	public const string TWITTER_LINK = "http://www.twitter.com/Tapinator" ;
	public const string AMAZON_RATEUS_LINK ="amzn://apps/android?p=com.tapinator.rooftop.derby3d";
	public const string IOS_RATEUS_LINK ="";
	public const string ANDROID_RATEUS_LINK ="market://details?id=com.tapinator.rooftop.derby3d";
	public const int    COINSTOSKIPLEVEL = 50;            // 50 coins to skip level.
	public const int 	LEVELCOMPLETEREWARD = 300;    // 30 coins
	public const string SCENE_EPISODE1 = "Rooftop";
	public const string SCENE_EPISODE2 = "Lava";
	public const string SCENE_EPISODE3 = "Island";
	public const string SCENE_MENU ="MenusScene";
	public const int levelsPerEpisode = 8;
	
	public const int totalLevels = 24;
	public const float thiefSpeed = 100f;
	public const float thiefChaseTime = 100f;
//	public const float TIMEPERLEVEL = 100.0f;
	public static string [ ] vehicleNameArray = { "kkkkV" , "kkkk","vehicle", "vehiclea" ,"vehicle " , "monster vehicle" } ;
	public static int	[ ] vehicleSpeedArray 		= {1, 5 ,	15  } ;			// 1 - 15
	public static int	[ ] vehicleHandlingArray	= { 4, 8 ,	15   } ;			// 1 - 15
	public static int	[ ] vehicleBrakingArray 	= {3, 8 ,	15  } ;			// 1 - 15
	public static int	[ ] vehicleResistanceArray	= { 2, 9 ,	15  } ;			// 1 - 15
	public static int [ ] vehicleAccelerationArray  =  {3, 12 , 15 } ;   // 1 s- 15
	public static float [ ] vehicleSelectionArray   = {0.441f, 0.583f,1f };   //  {0.17f, 0.37f, 0.50f,  0.68f, 0.85f , 1f}
 	public static int [ ] vehicleFuelArray    = {3, 3 , 7 , 9 , 15,15 } ;   // 1 - 15
 	public static int [ ] vehicleStrengthArray  = { 5, 5 , 7 , 8 , 15,15 } ;   // 1 - 15
 	public static int [ ] vehiclePriceArray   = { 0 ,  1000 , 1400 , 2500, 4000 , 6000 } ;
	public static int [ ] episodePriceArray   = { 0 ,  1000 , 1400 , 2400 } ;
	public static string [ ] episodeNameArray =       { "Episode 1" , "Episode 2","Episode 3", "Episode 4" } ;
	public static int[,] totalParkingLot = new int[3,levelsPerEpisode]{{1,1,1,1,1,1,1,1},{1,1,1,1,1,1,1,1}, {1,1,1,1,1,1,1,1}};
	public static float[,] timePerLevel = new float[3,levelsPerEpisode]{{200f,200f,200f,300.0f,250.0f,300.0f,300.0f,300.0f}, {300.0f,300.0f,300.0f,400.0f,400.0f,400.0f,400.0f,400.0f}, {300.0f,300.0f,400.0f,400.0f,400.0f,400f,400.0f,400.0f}};
	public static int[,] totalLaps = new int[3,levelsPerEpisode]{{1,1,2,1,1,1,3,1},{3,3,2,3,4,4,3,3}, {4,4,3,4,3,3,3,3}};
	public static float[,] totalHits = new float[3,levelsPerEpisode]{{1,3,3,3,3,3,4,4},{2,3,3,3,4,4,4,5}, {2,3,3,4,4,5,5,5}};
	public static float[,] levelType = new float[3,levelsPerEpisode]{{2,1,3,2,1,4,3,4},{3,3,4,4,2,2,1,1}, {1,1,2,2,3,3,4,4}};
	//public static float[,] totalCars = new float[3,levelsPerEpisode]{{2,2,2,3,3,3,3,4},{3,3,3,4,4,4,4,5}, {3,3,4,4,4,5,5,5}};
	//public static float[,] totalMagnitude = new float[3,levelsPerEpisode]{{10,10,15,15,15,20,20,20},{15,20,20,20,25,25,30,30}, {20,25,25,30,30,40,40,45}};
	public static float[,] totalCars = new float[3,levelsPerEpisode]{{1,1,1,1,1,1,1,1},{1,1,1,1,1,1,1,1}, {1,1,1,1,1,1,1,1}};
	public static float[,] totalMagnitude = new float[3,levelsPerEpisode]{{10,10,15,15,15,20,20,30},{15,20,30,30,35,35,35,40}, {20,25,30,35,40,45,50,55}};
	public static int[,] RequiredCashPerLevel = new int[3,levelsPerEpisode]{{200,200,200,200,200,200,200,200}, {180,180,180,180,180,180,180,180}, {160,160,160,160,160,160,160,160}};


	//health  for the enemy car per level in Car Demolition Game
	public static float[,] EnemyCarsHealth= new float[3,8]{ {0.8f,0.2f,0.22f,0.23f,0.4f,0.4f,0.45f,0.48f}, {0.4f,0.45f,0.48f,0.48f,0.5f,0.52f,0.55f,0.56f}, {0.6f,0.6f,0.62f,0.63f,0.64f,0.66f,0.68f,0.7f}};
	//public static float[,] EnemyCarsHealth= new float[3,8]{ {0.9f,0.9f,0.9f,0.9f,0.9f,0.9f,0.9f,0.9f}, {0.8f,0.8f,0.8f,0.8f,0.8f,0.8f,0.8f,0.8f}, {0.8f,0.8f,0.8f,0.8f,0.8f,0.8f,0.8f,0.8f}};

	//health for the player car per level in Car Demolition Game 
//	public static float[,] PlayerCarHealth= new float[3,8]{ {0.4f,0.4f,0.4f,0.4f,0.25f,0.25f,0.25f,0.25f}, {0.25f,0.25f,0.25f,0.25f,0.25f,0.25f,0.25f,0.25f}, {0.3f,0.3f,0.3f,0.3f,0.3f,0.3f,0.3f,0.3f}};
	//the probability at player will be folllowed
	public static float[,] PlayerCarHealth= new float[3,8]{ {0.5f,0.5f,0.5f,0.5f,0.5f,0.5f,0.5f,0.5f}, {0.3f,0.3f,0.3f,0.3f,0.3f,0.3f,0.3f,0.3f}, {0.25f,0.25f,0.25f,0.25f,0.25f,0.25f,0.25f,0.25f}};
	//public static float[,] EnemyMass= new float[3,8]{ {600f,600f,600f,0.9f,0.9f,0.9f,0.8f,0.8f}, {0.9f,0.9f,0.9f,0.9f,0.9f,0.9f,0.8f,0.8f}, {0.9f,0.9f,0.9f,0.9f,0.9f,0.9f,0.8f,0.8f}};

	public static int[,] PlayerFollowingProbablity = new int[3,8]{ {90,90,90,90,90,90,90,90}, {90,90,90,90,90,90,90,90}, {90,90,90,90,90,90,90,90}};
	//the probability at which wayPoint will be followed
	public static int[,] WaypointProbablity=new int[3,8]{ {5,5,5,5,5,5,5,5}, {5,5,5,5,5,5,5,5}, {5,5,5,5,5,5,5,5}};

	public static int NumberOfEnemies=0;
	public static int NumberofHelipEnemies=0;
	public static float PlayerCarThreshold=0.1f;
	public static bool isResetAvailable=true;
	public static float EnemyCarThreshold=0.08f;
	public static bool isBossMode = false;
	public static int levelfailcounter = 0;
	public static float playerMass=0;
	public static float enemyMass=0;

#endregion
	
	#region AchievementsRewards
	
	//Social Achievements Rewards
	public const int ACIDFBFANCOMPLETEDREWARD = 10;
	public const int ACIDSUPPORTERCOMPLETEDREWARD =10;
	public const int ACIDTWITTERANNOUNCERCOMPLETEDREWARD = 10;
	
	//Parking Achievements Rewards
	public const int ACIDRIDERCOMPLETEDREWARD = 5;
	public const int ACIDDRIVERCOMPLETEDREWARD = 10;
	public const int ACIDPARKERCOMPLETEDREWARD = 20;
	public const int ACIDBUSMANCOMPLETEDREWARD = 40;
	
	//Levels Achievements Rewards
	public const int ACIDHONKERCOMPLETEDREWARD = 5;
	public const int ACIDLASHERCOMPLETEDREWARD = 10;
	public const int ACIDCHAUFFEURCOMPLETEDREWARD = 15;
	public const int ACIDCABBYCOMPLETEDREWARD = 20;
	
	//Vehicles Achievements Rewards
	public const int ACIDTHIRLLLOVERCOMPLETEDREWARD = 25;
	public const int ACIDMASTERBLASTERCOMPLETEDREWARD = 50;
	public const int ACIDTURNKEYCOMPLETEDREWARD  = 75;
	
	//Environment Achievements Rewards
	public const int ACIDEXPLORERCOMPLETEDREWARD = 25;
	public const int ACIDSHOPPINGKINGCOMPLETEDREWARD = 50;
	public const int ACIDALLOUTCOMPLETEDREWARD = 75;

	//Coins Achievement Rewards
	public const int ACIDMANOFMEANSCOMPLETEDREWARD  = 25;
	
	#endregion

	public const string AndroidAppTokenPlayHaven = "e5357b51a3e04eeaaa28cee5bbae03a1";
	public const string AndroidAppSecretPlayHaven = "1277c35f3840406989b8eb93d8c4866f";
	public const string iOSAppTokenPlayHaven = "128384ff565e4538a7496e826ae79ed6";
	public const string iOSAppSecretPlayHaven = "37f268fe15dc43aca17244bceb43ae08";
	public const string adMOBCrossPromotion = "ca-app-pub-8370919864033934/5090926806" ;
	public const float KMHtoKMS = 0.000277777778f;
	public const float LEVEL_DIFFICULTY_INCREASE_RATIO = 0.2f;
	//more the damageIntensity value less the car will damage
	public const float DamageIntensity=100;
	public const string receiptVerifyLiveURL ="http://validation.tapinator.com/inapp/index.php/api/inapp/verify2";
	public const string   IAP_secret_key = "EYI7YSU2BOMH94A";
	public const string tweet = "Loving this #mobile #game from @tapinator {0} $tapm";
	public const string bitlyLink = " http://amzn.to/1IDJ8Dn";



}
