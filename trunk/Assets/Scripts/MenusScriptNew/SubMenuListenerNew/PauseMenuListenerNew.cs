using UnityEngine;
using System.Collections;

public class PauseMenuListenerNew : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnClick(){
		if(UserPrefs.isSound){
			GameObject.Find("gamePlayEffects").GetComponent<AudioSource>().mute = false;
			GameObject.Find("SoundManager").GetComponent<AudioSource>().mute = false;
		}

		try{
//			GameObject.FindObjectOfType<CounterAnimation>().EnableAudio();
		}catch(UnityException e){
				}
		if(this.name.Equals("btnExit")){
			Time.timeScale = 1;
			SoundManager.Instance.vehicleEngineSoundSource.volume = 0.0f;
			Destroy(GameObject.FindGameObjectWithTag("levelPause"));
			Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.GameState.GAMEPLAYEXIT);
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.MAINMENU);
//			MenuManager.Instance.StartNewMenus();
			Application.LoadLevel("MenusScene");
		}
		
		if(this.name.Equals("btnRestart")){
			Time.timeScale = 1;
			SoundManager.Instance.vehicleEngineSoundSource.volume = 0.0f;
			//Uncomment during final integration
			if(MenuManager.Instance.isVehicleMenuPresent)
			{
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLESELECTIONMENU);
				Application.LoadLevel(Constants.SCENE_MENU);
			}
			else
			{
				Destroy(GameObject.FindGameObjectWithTag("levelPause"));
				Destroy(GameObject.FindGameObjectWithTag("Hud"));
				Resources.UnloadUnusedAssets();
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.LOADING);
				StartCoroutine(MenuManager.Instance.LoadScene(1));
			}
			
		}
			
		if(this.name.Equals("btnResume")){
			Debug.Log("btnResume Pressed");
			Destroy(GameObject.FindGameObjectWithTag("levelPause"));
			Time.timeScale = 1;
			Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
			//Uncomment during final integration
						
		}
//		if(UserPrefs.isSound)
//			SoundManager.Instance.gamePlayEffectsSource.PlayOneShot(SoundManager.Instance.buttonClickSound);
	}
}
