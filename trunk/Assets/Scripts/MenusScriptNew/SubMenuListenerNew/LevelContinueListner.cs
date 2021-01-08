using UnityEngine;
using System.Collections;

public class LevelContinueListner : MonoBehaviour {

//	public UILabel textLabel;
//	LevelHandlerGeneric levelHandler;
//
//	// Use this for initialization
//	void Start () {
//		levelHandler = GameObject.FindObjectOfType<LevelHandlerGeneric>();
//		textLabel.text = Constants.levelType[UserPrefs.currentEpisode - 1,UserPrefs.currentLevel - 1] == 4 ? string.Format("There are {0} more items to collect",levelHandler.subLevels.Length - levelHandler.currentSubLevel) : string.Format("There are {0} more culprites to catch",levelHandler.subLevels.Length - levelHandler.currentSubLevel);
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//
//	void OnClick(){
//		if(this.gameObject.name.Equals("btnOk")){
//			levelHandler.InstantiateNextLevel();
//			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
//		}
//	}
}
