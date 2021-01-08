using UnityEngine;
using System.Collections;

public class LevelInstructionsListenerNew : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	

	}
	
	void OnClick(){
		if(this.name.Equals("btnContinue")){
			Debug.Log("btnContinue Pressed");
			
			Destroy(GameObject.FindGameObjectWithTag("levelInstructions"));
			Resources.UnloadUnusedAssets();
			if(UserPrefs.currentEpisode==1 && UserPrefs.currentLevel==1 && !UserPrefs.isTutorialSeen)
			{
					GameManager.Instance.ChangeState(GameManager.GameState.TUTORIAL);	
					Instantiate(Resources.Load("SubMenusNew/Tutorial01"));
					UserPrefs.isTutorialSeen=true;
					UserPrefs.Save();
			}
			else
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.GAMEPLAY);

		}
		
	}
	
	
}
