using UnityEngine;
using System.Collections;

public class GameConstants : MonoBehaviour {

	public static float MAX_DISTANCE_CHANGE_PROBALITY = 1500;
	public static int TOTAL_COINS = 0;

	public static bool IS_COLLIDED = false;
	public static bool IS_COLLIDED_TO_VEHICLE = false;
	public static bool IS_WRONG_WAY_RESPAWN = false;

	public static bool IS_RESPAWN_TOOLS_DISABLE_MODE = false;

	public static bool IS_GAME_OVER = false;

	public static bool IS_INNVINCIBLE_MODE = false;
	public static bool IS_MULTIPLAYER_MODE = false;
	public static int MULTIPLIER_FACTOR = 2;
	public static float TOATL_BOOST = 20;
	public static int BOOST_INCREAMENT = 25;
	public static float BOOST_DECREMENT = 0.2f;

	public static bool IS_BOOST_MOOD = false;
	public static float BOOST_INCREAMENT_FACTOR =2f ;
	public static float BOOST_SPEED_FACTOR =20f ;

	public static float BOOST_TIME =10f ;
	public static float INVISIBLE_TIME =10f ;
	public static float MULTIPLIEE_TIME =10f ;

	public static float MULTIPLIER_SCORE =0 ;

	public static string POPUP_MESSAGE ="";
	public static float ACEL_FACTOR =1f ;
	public static class GameVariable{

		public static float TIME = 0;
		public static float DISTANCE = 0;
		public static float MULTIPLAYER_DISTANCE=0;

		public static float SCORE = 0;
		public static float MAX_SPEED_TIME = 0;
		public static float TOTAL_WRONG_WAY_TIME = 0;

		public static float STARTING_POSITION_Z = 0;
		public static float MAX_SPEED_LIMIT=55;
		public static bool IS_AT_MAX_SPEED_LIMIT=false;
		public static bool IS_AT_WRONG_WAY=false;

		public static bool IS_NEAR_HIT_OCCURED=false;

		public static float NEAR_MISS_COUNT = 0;

		public static float SPEED_LIMIT_FOR_GAME_OVER=20;

		public static float WRONG_DISTANCE_THRESH_HOLD =30 ;

		public static float WRONG_DISTANCE_WARNING = 20;

		
	}

	public static class GamePathProperties{
		public static int ONE_WAY = 1;
		public static int TWO_WAY = 2;
		public static int CURRENT_WAY = 1;
		
	}

	public static int getCoinsToUnlock(int vehicleID){
		switch(vehicleID){
		case 0:
			return 10;
		case 1:
			return 20;
		case 2:
			return 30;	
		default:
			return 30;
		}	
	
	}
	public static void StopCarSounds(){
		if(GameObject.FindGameObjectWithTag("Player")){
//			CarManager 	carAudioManager = GameObject.FindGameObjectWithTag("Player").GetComponent<CarManager>();
//			carAudioManager.audioManager.SetActive(false);
			AudioSource audioSource =  GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
			if(audioSource){
				audioSource.enabled = false;
			}
		}

	}

	public static void StartCarSounds(){
		try{
		
			if(GameObject.FindGameObjectWithTag("Player")){
//				CarManager 	carAudioManager = GameObject.FindGameObjectWithTag("Player").GetComponent<CarManager>();
//				carAudioManager.audioManager.SetActive(true);
//				
				AudioSource audioSource =  GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
				if(audioSource){
					audioSource.enabled = true;
				}
			}


		}
		catch(System.Exception ex)
		{
			Debug.Log("Exception caught in GameConstants.StartCarSounds()" + ex.ToString());
		}
	}

	public static class GameProperties{
			public static int TIME_TRIAL = 1;
			public static int ENDLESS = 2;
			public static int FREE = 3;
			public static int CURRENT_MODE = 3;
			public static bool IS_AUTO_ACCELRATION_MODE = false;
			public static bool IS_TILT_MODE = false;

	}

	public static void disableBoostMode(){
		/*SmoothFollowCSharp smoothFollowCSharp = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SmoothFollowCSharp>();
		smoothFollowCSharp.motionBlur.enabled = false;
		GameConstants.IS_BOOST_MOOD= false;
		*/
	}

}
