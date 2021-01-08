using UnityEngine;
using System.Collections;

public class UnlockAllLevelsListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(this.gameObject.name.Equals("btnCancel")){
			SubMenusOld.Instance.EnableBackground();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick(){
		 if(this.name.Equals("btnCancel"))
		{
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.MODESELECTIONMENU);
			
		}
		else if (this.name.Equals("btnOk"))
		{
			UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1] = 12;
			GameManager.Instance.SubtractCoins(499);
			
			Destroy(GameObject.FindGameObjectWithTag("LevelSelectionMenu"));
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.MODESELECTIONMENU);
			
			MenuManager.Instance.StartMenu();	
			
		}	
	}
}
