using UnityEngine;
using System.Collections;

public class SoundManager : SingeltonBase<SoundManager>{

	// Use this for initialization
	public AudioClip levelFailSound;
	public AudioClip levelSuccessSound;
	public AudioClip buttonClickSound;
	public AudioClip popupsSound;
	public AudioClip vehicleCrashSound;
	public AudioClip vehicleStartSound;
	public AudioClip menuBGSound;
	public AudioClip gamePlayBGSound;
	public AudioClip policeSiren;
	public AudioClip vehicleEngineSound;
	public AudioSource gamePlayEffectsSource;
	public AudioSource vehicleEngineSoundSource;
	public AudioClip applauseSound;
	public AudioClip waterSplashSound;
	public AudioClip shoutSound;
	public AudioClip explosion;
	public AudioClip thiefFall;
	public AudioClip thiefCry;
	public AudioClip pickAThing;
	public AudioClip carHorn;
	public AudioClip carExplosion;
	public bool isDualSound = false;
	private bool isGamePlaySound = false;
	public AudioClip EnginSound;

	public AudioClip countSound,goSound;
	public AudioClip [] policeWireless;
	void Start () {

//		DontDestroyOnLoad(this);
		vehicleEngineSoundSource.clip = vehicleEngineSound;
		if(isDualSound)
		{
			this.GetComponent<AudioSource>().clip = menuBGSound;
			this.GetComponent<AudioSource>().volume = 1;
			isGamePlaySound = false;
		}
		else
		{
			this.GetComponent<AudioSource>().clip = gamePlayBGSound;
			this.GetComponent<AudioSource>().volume = 0.1f;
			isGamePlaySound = true;
		}
		if(!UserPrefs.isSound)
		{
			this.GetComponent<AudioSource>().mute = true;
			gamePlayEffectsSource.mute = true;
			vehicleEngineSoundSource.mute = true;
		}
		if(!this.GetComponent<AudioSource>().isPlaying)
		{
			this.GetComponent<AudioSource>().Play();
		}
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		AudioListener.pause = !UserPrefs.isSound;
		if(Time.timeScale==0 || !UserPrefs.isSound)
		{
			AudioListener.volume = 0;
		}
		else
		{
			AudioListener.volume = 1;
		}
	}
	
	public void PlaySound()
	{
	  switch(GameManager.Instance.GetSoundState())
	  {
	   case GameManager.SoundState.VEHICLECRASHSOUND:
			this.VehicleCrashSound();
	    	break;
	   case GameManager.SoundState.WATERSPLASHSOUND:
			this.WaterSplashSound();
			break;
	   case GameManager.SoundState.LEVELFAILSOUND:
			this.LevelFailSound();
	    	break;
	   case GameManager.SoundState.LEVELSUCCESSSOUND:
			this.GetComponent<AudioSource>().Stop();
			this.LevelSuccessSound();
	    	break;
	   case GameManager.SoundState.POPUPSOUND:
			this.PopupsSound();
	   		break;
	   case GameManager.SoundState.BUTTONCLICKSOUND:
			this.ButtonClickSound();
	    	break;
	   case GameManager.SoundState.VEHICLESTARTSOUND:
			this.VehicleStartAndEngineSound();
	    	break;
	   case GameManager.SoundState.APPLAUSESOUND:
			this.ApplauseSound();
	    	break;
	   case GameManager.SoundState.MUTESOUND:
			this.MuteSound();
	    	break;
	    case GameManager.SoundState.UNMUTESOUND:
			this.UnMuteSound();
	    	break;
		case GameManager.SoundState.POLICESIREN:
			this.PlayPoliceSiren();
			break;
		case GameManager.SoundState.SHOUTSOUND:
			this.PlayShoutSound();
			break;
		case GameManager.SoundState.EXPLODE:
			this.ExplosionSound();
			break;
		case GameManager.SoundState.THIEFFALL:
			this.ThiefFallDown();
			break;
		case GameManager.SoundState.THIEFCRYING:
			this.thiefCrying();
			break;
		case GameManager.SoundState.PICKaTHING:
			this.pickThings();
			break;


		}
		if(isDualSound)
		{
//			Debug.Log("%%%%%% " +GameManager.Instance.GetCurrentGameState());
			if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.TWEETDAILOG ||GameManager.Instance.GetCurrentGameState() == GameManager.GameState.MAINMENU || GameManager.Instance.GetCurrentGameState() == GameManager.GameState.EPISODEMENU || GameManager.Instance.GetCurrentGameState() == GameManager.GameState.VEHICLESELECTIONMENU || GameManager.Instance.GetCurrentGameState() == GameManager.GameState.MODESELECTIONMENU || GameManager.Instance.GetCurrentGameState() == GameManager.GameState.INTRO|| GameManager.Instance.GetCurrentGameState() == GameManager.GameState.STORE|| GameManager.Instance.GetCurrentGameState() == GameManager.GameState.LEVELSETTINGS|| GameManager.Instance.GetCurrentGameState() == GameManager.GameState.VEHICLEUPGRADEMENU|| GameManager.Instance.GetCurrentGameState() == GameManager.GameState.CONFIRMWHEELUPGRADE|| GameManager.Instance.GetCurrentGameState() == GameManager.GameState.CONFIRMCOLORUPGRADE|| GameManager.Instance.GetCurrentGameState() == GameManager.GameState.CONFIRMENGINEUPGRADE|| GameManager.Instance.GetCurrentGameState() == GameManager.GameState.CONFIRMHANDLINGUPGRADE|| GameManager.Instance.GetCurrentGameState() == GameManager.GameState.CONFIRMSTEERINGUPGRADE|| GameManager.Instance.GetCurrentGameState() == GameManager.GameState.CONFIRMBRAKESUPGRADE || GameManager.Instance.GetCurrentGameState() == GameManager.GameState.EPISODEUNLOCK || GameManager.Instance.GetCurrentGameState() == GameManager.GameState.VEHICLEUNLOCK || GameManager.Instance.GetCurrentGameState() == GameManager.GameState.OUTOFCOINSWHEELUPGRADE || GameManager.Instance.GetCurrentGameState() == GameManager.GameState.SHOWAD)
			//if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.MAINMENU)
			{
//				this.audio.Stop();
				if(vehicleEngineSoundSource.isPlaying)
					vehicleEngineSoundSource.Stop();
				if(isGamePlaySound)
				{
					this.GetComponent<AudioSource>().clip = menuBGSound;
					this.GetComponent<AudioSource>().volume = 1;
					isGamePlaySound = false;
					this.GetComponent<AudioSource>().Play();
				}
//				else
//					this.audio.Play();
			}
			else if(!isGamePlaySound)
			{
				this.GetComponent<AudioSource>().clip = gamePlayBGSound;
				this.GetComponent<AudioSource>().volume = 0.1f;
				isGamePlaySound = true;
				this.GetComponent<AudioSource>().Play();
			}
		}
		else
		{
			if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.MAINMENU || GameManager.Instance.GetCurrentGameState() == GameManager.GameState.EPISODEMENU || GameManager.Instance.GetCurrentGameState() == GameManager.GameState.VEHICLESELECTIONMENU || GameManager.Instance.GetCurrentGameState() == GameManager.GameState.MODESELECTIONMENU || GameManager.Instance.GetCurrentGameState() == GameManager.GameState.INTRO || GameManager.Instance.GetCurrentGameState() == GameManager.GameState.VEHICLEUPGRADEMENU )
			{
//				BackgroundSoundManager.Instance.playOrStopMusic();
				this.GetComponent<AudioSource>().Stop();
				gamePlayEffectsSource.Stop();
				if(vehicleEngineSoundSource.isPlaying)
					vehicleEngineSoundSource.Stop();
			}
			else if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.GAMEPLAY)
			{
//				BackgroundSoundManager.Instance.stopBGSound();

			}
		}
		
 	 }
	private void ApplauseSound()
	{
		gamePlayEffectsSource.PlayOneShot(applauseSound);
	}
	
	private void VehicleCrashSound()
	{
		if(vehicleEngineSoundSource.isPlaying)
			vehicleEngineSoundSource.Stop();
		gamePlayEffectsSource.PlayOneShot(vehicleCrashSound);
		//StartCoroutine(WaitForEngineSound(levelFailSound.length));
		//gamePlayEffectsSource.PlayOneShot(levelFailSound);
	}
	private void WaterSplashSound()
	{
		if(vehicleEngineSoundSource.isPlaying)
			vehicleEngineSoundSource.Stop();
		gamePlayEffectsSource.PlayOneShot(waterSplashSound);
		//StartCoroutine(WaitForEngineSound(levelFailSound.length));
		//gamePlayEffectsSource.PlayOneShot(levelFailSound);
	}
	private void LevelFailSound()
	{
		gamePlayEffectsSource.PlayOneShot(levelFailSound);
	}

	private void LevelSuccessSound()
	{
		if(vehicleEngineSoundSource.isPlaying)
			vehicleEngineSoundSource.Stop();
		gamePlayEffectsSource.PlayOneShot(levelSuccessSound);
	}
	private void ButtonClickSound()
	{
		gamePlayEffectsSource.PlayOneShot(buttonClickSound);
	}
	private void ExplosionSound()
	{
		gamePlayEffectsSource.PlayOneShot(explosion);
	}
	private void ThiefFallDown()
	{
		gamePlayEffectsSource.PlayOneShot(thiefFall);
	}
	private void thiefCrying()
	{
		gamePlayEffectsSource.PlayOneShot(thiefCry);
	}
	private void pickThings()
	{
		gamePlayEffectsSource.PlayOneShot(pickAThing);
	}
	public void CarHorn()
	{
		gamePlayEffectsSource.PlayOneShot(carHorn);
	}
	private void PopupsSound()
	{
		gamePlayEffectsSource.PlayOneShot(popupsSound);
	}
	private void VehicleStartAndEngineSound()
	{
//		Debug.Log(">>>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<");
		//gamePlayEffectsSource.PlayOneShot(vehicleStartSound);
		StartCoroutine(WaitForEngineSound(vehicleStartSound.length));
		//vehicleEngineSoundSource.Play();
	}
	private void MuteSound()
	{
		GetComponent<AudioSource>().mute = true;
		vehicleEngineSoundSource.mute = true;
		gamePlayEffectsSource.mute = true;
	}
	private void UnMuteSound()
	{
		GetComponent<AudioSource>().mute = false;
		vehicleEngineSoundSource.mute = false;
		gamePlayEffectsSource.mute = false;
	}
	IEnumerator WaitForEngineSound(float clipLength)
	{
		yield return new WaitForSeconds(clipLength);
	}

	public void WaterSplash()
	{


	}

	void PlayPoliceSiren(){
		gamePlayEffectsSource.PlayOneShot(policeWireless[Random.Range(0,policeWireless.Length)]);
		this.GetComponent<AudioSource>().clip = policeSiren;
		this.GetComponent<AudioSource>().Play();
	}

	void PlayShoutSound(){
		gamePlayEffectsSource.PlayOneShot(shoutSound);
	}

	public void StopAudio(){
		this.GetComponent<AudioSource>().Stop();
	}
}
