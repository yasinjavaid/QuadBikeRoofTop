using UnityEngine;
using System.Collections;

public class LevelSettingsListener : MonoBehaviour {
	GameObject btnControl1;
	GameObject btnControl2;
	GameObject btnControl3;
	GameObject btnMusic;
	GameObject btnSound;
	// Use this for initialization
	void Start () {
		
		btnControl1 = GameObject.FindGameObjectWithTag("btnControl1") ;
		btnControl2 = GameObject.FindGameObjectWithTag("btnControl2") ;
		btnControl3 =GameObject.FindGameObjectWithTag("btnControl3");
		btnMusic  =	GameObject.FindGameObjectWithTag("btnMusicSlider");
		//btnSound  =	GameObject.FindGameObjectWithTag("btnSoundSlider");
		btnSound  =	GameObject.FindGameObjectWithTag("btnSound");
		SetVeichleControls(UserPrefs.accelerometerFactor);
		
		/*if(this.gameObject.name.Equals("btnCancel")){
			SubMenusOld.Instance.EnableBackground();
		}*/
		/*if(!UserPrefs.isMusic)
		{
			btnMusic.GetComponentInChildren<UISprite>().spriteName = "slider-btn-off" ;
				
		}
		else
		{
			btnMusic.GetComponentInChildren<UISprite>().spriteName = "slider-btn-ON" ;
		}*/
		
		if(!UserPrefs.isSound)
		{
			
			btnSound.GetComponentInChildren<UISprite>().spriteName = "sound-off" ;
				
		}
		else{
		
			btnSound.GetComponentInChildren<UISprite>().spriteName = "sound-on" ;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick(){
		Debug.Log(name);
		if(this.name.Equals("btnSound")){
			SetSound();
		}/*else if (this.name.Equals("btnMusic")){
			SetMusic();
		}*/else if (this.name.Equals("btnControl1")){

			SetVeichleControls(2);
		}else if (this.name.Equals("btnControl2")){
			
			SetVeichleControls(0);
		}else if (this.name.Equals("btnControl3")){
		
			SetVeichleControls(1);
		}else if (this.name.Equals("btnCancel")){
			Close();
		}
		else if (this.name.Equals("btnOk")){
			PlayerPrefs.SetInt("isFirstTime",UserPrefs.settingsPopupVal);
			Destroy(GameObject.FindGameObjectWithTag("LevelSettings"));
		}
//		if(UserPrefs.isSound)
//			SoundManager.Instance.gamePlayEffectsSource.PlayOneShot(SoundManager.Instance.buttonClickSound);
	}
	
	public void SetSound(){
		if(UserPrefs.isSound)
		{
			UserPrefs.isSound = false;
			this.GetComponentInChildren<UISprite>().spriteName = "sound-off" ;
//			GameManager.Instance.ChangeState(GameManager.SoundState.MUTESOUND);
		}
		else
		{
			UserPrefs.isSound = true;
			this.GetComponentInChildren<UISprite>().spriteName = "sound-on" ;
		
			SoundManager.Instance.GetComponent<AudioSource>().mute = false;
//			GameManager.Instance.ChangeState(GameManager.SoundState.UNMUTESOUND);
		}
		UserPrefs.Save();
//		BackgroundSoundManager.Instance.playOrStopMusic();
	}
	
	public void SetMusic(){
		if(UserPrefs.isMusic)
		{
			UserPrefs.isMusic = false;
			this.GetComponentInChildren<UISprite>().spriteName = "Music_off" ;
			GameManager.Instance.ChangeState(GameManager.SoundState.MUTESOUND);
			AudioListener.volume = 0;
		}
		else
		{
			UserPrefs.isMusic = true;
			this.GetComponentInChildren<UISprite>().spriteName = "Music_On" ;
			GameManager.Instance.ChangeState(GameManager.SoundState.UNMUTESOUND);
			AudioListener.volume = 1;
		}
		UserPrefs.Save();
		
	}
	
	public void SetVeichleControls ( int control)
	{	
		btnControl1.GetComponentInChildren<UISprite>().spriteName = "touch" ;
		btnControl2.GetComponentInChildren<UISprite>().spriteName = "steering" ;
		btnControl3.GetComponentInChildren<UISprite>().spriteName = "tilt" ;
		
		if ( control == 0 )   // steering wheel
	 	{   
			UserPrefs.accelerometerFactor = 0;
			btnControl2.GetComponentInChildren<UISprite>().spriteName = "steering-select" ;
			GAManager.Instance.LogDesignEvent("Settings::Steering");
	  	//	GameObject.FindWithTag("Steering").renderer.enabled = true;
	  	//	GameObject.FindGameObjectWithTag("LeftTurnSteering").renderer.enabled = false;
	  	//	GameObject.FindGameObjectWithTag("RightTurnSteering").renderer.enabled = false;   
	 	}
		else if ( control == 1)  // accelarometer / tilt
		 {   
			UserPrefs.accelerometerFactor = 1;
			btnControl3.GetComponentInChildren<UISprite>().spriteName = "tilt-select" ;
			GAManager.Instance.LogDesignEvent("Settings::Tilt");
		 //	GameObject.FindWithTag("Steering").renderer.enabled = false;
		//  	GameObject.FindGameObjectWithTag("LeftTurnSteering").renderer.enabled = false;
		//  	GameObject.FindGameObjectWithTag("RightTurnSteering").renderer.enabled = false;   
		 }
		 else if ( control == 2 )  // right left buttons
		 {	
			UserPrefs.accelerometerFactor = 2;
			btnControl1.GetComponentInChildren<UISprite>().spriteName = "touch-select" ;
			GAManager.Instance.LogDesignEvent("Settings::Buttons");
		//	GameObject.FindWithTag("Steering").renderer.enabled = false;
		//  	GameObject.FindGameObjectWithTag("LeftTurnSteering").renderer.enabled = true;
		//  	GameObject.FindGameObjectWithTag("RightTurnSteering").renderer.enabled = true;   
		 }
		 UserPrefs.Save();
		 
	}
	
	public void Close(){
		
		Destroy(GameObject.FindGameObjectWithTag("LevelSettings"));
		Resources.UnloadUnusedAssets();
		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState()); 
		Debug.Log("current state is " +GameManager.Instance.GetCurrentGameState());
	}
	
}

