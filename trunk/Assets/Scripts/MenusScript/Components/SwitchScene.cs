using UnityEngine;
using System.Collections;

public class SwitchScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (UserPrefs.isFromPauseMenu) {
			UserPrefs.isFromPauseMenu=false;
			GameManager.Instance.ChangeState (GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.MAINMENU);
			MenuManager.Instance.StartNewMenus ();
			GameManager.Instance.SetCurrentGameState (GameManager.GameState.MAINMENU);
			SoundManager.Instance.PlaySound ();
		} else {


			GameManager.Instance.ChangeState (GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLESELECTIONMENU);
			MenuManager.Instance.StartNewMenus ();
			GameManager.Instance.SetCurrentGameState (GameManager.GameState.VEHICLESELECTIONMENU);
			SoundManager.Instance.PlaySound ();
	
			/*	GameObject temp = GameObject.FindGameObjectWithTag("Background");
		
		if(temp == null){
			Instantiate(Resources.Load("SubMenus/Background"));
		}
		*/
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
