using UnityEngine;
using System.Collections;
using Prime31;
public class LevelCompleteListenerNew : MonoBehaviour {

	// Use this for initialization
	public UILabel levelCompleteCash,timeBonusCash,earnedCash,totalCash;
	public UILabel speedBonus;
	public int totalEarnecCash;
	public GameObject HummerBuyPanel;
	void Start () {
		if (this.name.Equals ("btnContinue")) {


			levelCompleteCash.text = Constants.LEVELCOMPLETEREWARD.ToString();
			//CoinsHandler c = GameObject.FindObjectOfType<CoinsHandler>();
			//timeBonusCash.text = c.timeBonus.ToString();
			int c= Random.Range(500,800);
			earnedCash.text = c.ToString();
			//c.SaveCollectedCoins();
		//	var stats = GameObject.FindObjectOfType<VehicleStats>().GetComponent<VehicleStats>();
			totalEarnecCash  = Constants.LEVELCOMPLETEREWARD+c;

		//	earnedCash.text = (Mathf.CeilToInt(stats.Distance)*50).ToString();
		//	speedBonus.text = ((int)stats.ModeMaxSpeed).ToString();
		//	totalEarnecCash = Constants.LEVELCOMPLETEREWARD+(Mathf.CeilToInt(stats.Distance)*50)+(int)stats.ModeMaxSpeed;;
			GameManager.Instance.AddCoins(totalEarnecCash);
			totalCash.text = totalEarnecCash.ToString();

			playAnimationOnLabels();
		}
	}
	
	// Update is called once per frame
	void Update () {
	

	}
	bool HummerPanelShow= false;
	void OnClick(){
		if(this.name.Equals("btnContinue")){

			SoundManager.Instance.vehicleEngineSoundSource.volume = 0.0f;
			if(UserPrefs.currentLevel==Constants.levelsPerEpisode)
			{
				if(UserPrefs.currentEpisode!=3)
				UserPrefs.isTryHummerPurchase=true;
			}
			UserPrefs.currentLevel++;
			if(UserPrefs.currentLevel > Constants.levelsPerEpisode )
			{
				if(UserPrefs.currentEpisode>3)
					UserPrefs.currentEpisode=3;
				UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]=1;
				UserPrefs.episodeCompletedArray[UserPrefs.currentEpisode-1] = true;
				if(UserPrefs.currentEpisode!=3)
				UserPrefs.episodeUnlockArray[UserPrefs.currentEpisode++] = true;
			}
			else
			{
				if(UserPrefs.currentLevel - 1 == UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode - 1])
				{

					UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]++;
				}
				}




			GameManager.Instance.ChangeState(GameManager.GameState.SHOWAD);
			Time.timeScale=1;
			NextLevel();
		}
		if(this.name.Equals("btnTweet")){
			SocialManager socialManager = GameObject.FindGameObjectWithTag("SocialManager").GetComponent<SocialManager>();
			if(socialManager.TwitterIsLogedIn()){
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.TWEETDAILOG);
			}
			else{
				socialManager.TwitterLogin();
			}
			Time.timeScale=1;
		}

		//btnTweet
//		if(UserPrefs.isSound)
//			SoundManager.Instance.gamePlayEffectsSource.PlayOneShot(SoundManager.Instance.buttonClickSound);
	}

	void NextLevel(){
		// called in start.
	//	UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]++;
	//	UserPrefs.Save();
		
		if(UserPrefs.currentLevel+1 > Constants.levelsPerEpisode  ){   // 12 >= 12
//			if( UserPrefs.currentEpisode < UserPrefs.unlockLevelsArrays.Length){
//				//Instantiate(Resources.Load("SubMenus/EpisodeUnlockMenu"));
//				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.GameState.EPISODEUNLOCK);
//				UserPrefs.episodeUnlockArray[UserPrefs.currentEpisode] = true ;
//				UserPrefs.Save();
//			}else{
				Destroy(GameObject.FindGameObjectWithTag("LevelComplete"));
				Destroy(GameObject.FindGameObjectWithTag("Hud"));
				Resources.UnloadUnusedAssets();
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLESELECTIONMENU);

				Application.LoadLevel("MenusScene");                   
//			}
		}
		else{
			UserPrefs.currentLevel++;
			UserPrefs.adCounter++;
			//UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]++;
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
//				//GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.GAMEPLAY);
//				StartCoroutine(MenuManager.Instance.LoadScene(0));
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLEUPGRADEMENU);
				Application.LoadLevel("MenusScene");
			}
		}
	}

	void playAnimationOnLabels(){
		iTween.MoveFrom(levelCompleteCash.gameObject, iTween.Hash(  "x",  levelCompleteCash.gameObject.transform.position.x + 10f,  "time", 0.5, "ignoretimescale", true, "easetype",iTween.EaseType.easeInOutCubic  )  ); 
		iTween.MoveFrom(timeBonusCash.gameObject, iTween.Hash(  "x",  timeBonusCash.gameObject.transform.position.x + 10f,  "time", 0.7, "ignoretimescale", true, "easetype",iTween.EaseType.easeInOutCubic  )  ); 
		iTween.MoveFrom(earnedCash.gameObject, iTween.Hash(  "x",  earnedCash.gameObject.transform.position.x + 10f,  "time", 1.2, "ignoretimescale", true, "easetype",iTween.EaseType.easeInOutCubic  )  ); 
		iTween.MoveFrom(totalCash.gameObject, iTween.Hash(  "x",  earnedCash.gameObject.transform.position.x + 10f,  "time", 1.5, "ignoretimescale", true, "easetype",iTween.EaseType.easeInOutCubic  )  ); 

	}
}
