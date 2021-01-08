using UnityEngine;
using System.Collections;

public class PauseMenuListner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		if(this.name.Equals("car_buy")){
//			int coinsRequire = VehicleManager.vehicleArray[UserPrefs.currentVehicle].price;
//			GameConstants.POPUP_MESSAGE = "Do you want to Unlock Car \n in $ "+coinsRequire +" ?" ;
//			Debug.LogError("Current V Buybtn "+ UserPrefs.currentVehicle+1);
//			
//			if(UserPrefs.totalCoins >= coinsRequire)
//			{
//				UserPrefs.currentVehicle++;
//				GameManager.Instance.ChangeState(GameManager.GameState.VEHICLEUNLOCK);
//			}
//			else{
//				VehicleUpgradeMenuListener.CoinsNeeded = coinsRequire - UserPrefs.totalCoins;
//				Instantiate (Resources.Load ("SubMenusNew/LevelBuyCoin"));
//			}
//			
		}
		if(this.gameObject.name.Equals("btnButtons")){
			UserPrefs.accelerometerFactor = 2;
			this.transform.root.GetComponent<PauseMenuStatus>().SetPauseMenuStatus();
			Camera.main.GetComponent<SteerNew>().SetControlsOnRuntime();
			GAManager.Instance.LogDesignEvent("Design::Control::Buttons");
		}else if(this.gameObject.name.Equals("btnTilt")){
			UserPrefs.accelerometerFactor = 1;
			this.transform.root.GetComponent<PauseMenuStatus>().SetPauseMenuStatus();
			Camera.main.GetComponent<SteerNew>().SetControlsOnRuntime();
			GAManager.Instance.LogDesignEvent("Design::Control::Tilt");
		}else if(this.gameObject.name.Equals("btnSteer")){
			UserPrefs.accelerometerFactor = 0;
			this.transform.root.GetComponent<PauseMenuStatus>().SetPauseMenuStatus();
			Camera.main.GetComponent<SteerNew>().SetControlsOnRuntime();
			GAManager.Instance.LogDesignEvent("Design::Control::Steering");
		}else if(this.gameObject.name.Equals("btnSound")){

			UserPrefs.soundState = !UserPrefs.soundState;
			this.transform.root.GetComponent<PauseMenuStatus>().SetPauseMenuStatus();
		}else if(this.gameObject.name.Equals("btnHome")){
			SoundManager.Instance.GetComponent<AudioSource>().mute = false;

			UserPrefs.isFromPauseMenu=true;
			GameManager.Instance.ChangeState(GameManager.GameState.SHOWAD);
			UserPrefs.isSound = UserPrefs.soundState;

			UserPrefs.Save();

			Time.timeScale = 1;
			Resources.UnloadUnusedAssets();
//			GameManager.Instance.ChangeState(GameManager.GameState.SHOWAD);
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLESELECTIONMENU);
			Application.LoadLevel("MenusScene");
		}else if(this.gameObject.name.Equals("btnRestart")){
			SoundManager.Instance.GetComponent<AudioSource>().mute = false;

			UserPrefs.isSound = UserPrefs.soundState;
			GameManager.Instance.ChangeState(GameManager.GameState.SHOWAD);
			UserPrefs.Save();
			Time.timeScale = 1;
			Resources.UnloadUnusedAssets();
			Destroy(GameObject.FindGameObjectWithTag("levelPause"));
			Destroy(GameObject.FindGameObjectWithTag("Hud"));
			Resources.UnloadUnusedAssets();
//			GameManager.Instance.ChangeState(GameManager.GameState.SHOWAD);
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.LOADING);
			StartCoroutine(MenuManager.Instance.LoadScene(1));
		}else if(this.gameObject.name.Equals("vehicleSprite")){
			UserPrefs.Save();
			Time.timeScale = 1;
			Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.LOADING);
			Application.LoadLevel("MenusScene");
		}else if(this.gameObject.name.Equals("btnContinue")){
			SoundManager.Instance.GetComponent<AudioSource>().mute = false;

			UserPrefs.Save();
			Time.timeScale = 1;
			Debug.LogError(GameManager.Instance.GetPreviousGameState());
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND,GameManager.Instance.GetPreviousGameState());
			Destroy(GameObject.FindGameObjectWithTag("levelPause"));
			Debug.LogError(GameManager.Instance.GetCurrentGameState());
			UserPrefs.isSound = UserPrefs.soundState;

			if(UserPrefs.isSound){
			WheelControllerGeneric carAudio = GameObject.FindObjectOfType<WheelControllerGeneric>();

			if(carAudio!=null)
			{
//					if(carAudio.CarAudio)
//				carAudio.CarAudio.SetActive(true);
			}
			}
		}else if(this.gameObject.name.Equals("btnKPH")){
//			UserPrefs.isKPH = true;
			this.transform.root.GetComponent<PauseMenuStatus>().SetPauseMenuStatus();
		}else if(this.gameObject.name.Equals("btnMPH")){
//			UserPrefs.isKPH = false;
			this.transform.root.GetComponent<PauseMenuStatus>().SetPauseMenuStatus();
		}
	}
}
