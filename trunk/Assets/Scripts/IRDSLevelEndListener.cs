using UnityEngine;
using System.Collections;

public class IRDSLevelEndListener : MonoBehaviour {
	bool levelFailLaps = false;
	public static bool isLevelFinished = false;
//	IRDSLevelLoadVariables loadedStettings;
	public GameObject body;
	// Use this for initialization
	void Start () {
//		loadedStettings = GameObject.FindObjectOfType(typeof(IRDSLevelLoadVariables)) as IRDSLevelLoadVariables;
//		IRDSStatistics.SetCanRace (true);
		isLevelFinished = false;
		var levelLoad = GameObject.Find ("LevelLoad").GetComponent<ThiefCarColorHandler>();
		int index = Random.Range (0,levelLoad.vehicleTextures.Length);
		body.GetComponent<Renderer>().materials[1].mainTexture = levelLoad.vehicleTextures [index];

	}
	
	// Update is called once per frame
	void FixedUpdate (){
//		IRDSStatistics.SetCanRace (true);
		if(UserPrefs.isTutorialFinished){
//			Debug.LogError(GameObject.FindGameObjectWithTag("Player").GetComponent<IRDSCarControllerAI>().GetLap());

//			if(!isLevelFinished && !levelFailLaps && GameObject.FindGameObjectWithTag("Player").GetComponent<IRDSCarControllerAI>().GetLap() > Constants.totalLaps[UserPrefs.currentEpisode-1 , UserPrefs.currentLevel-1])
//			{
//				//GameObject.Find("HudMenuNew").SetActive(false);
////				CarMain.accellPressedValue=0f;
////				CarMain.revValue=0f;
////				CarMain.brakeValue=1;
////				CarMain.SendInput(this.GetComponent<CarControl>(),false,false);
//				GameManager.Instance.ChangeState(GameManager.SoundState.MUTESOUND);
//				UserPrefs.crashCause = 1;
//				GameObject.FindGameObjectWithTag("Player2").GetComponent<WheelControllerGeneric>().LevelFailed();
//				levelFailLaps = true;
//			}
		}
	}
}
