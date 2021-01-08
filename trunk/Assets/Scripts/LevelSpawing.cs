using UnityEngine;
using System.Collections;

public class LevelSpawing : MonoBehaviour {
	public Transform [] levelsArray = new Transform[Constants.levelsPerEpisode];

//	IRDSLevelLoadVariables loadedStettings;
	// Use this for initialization
	void Start () {
//		loadedStettings = GameObject.FindObjectOfType(typeof(IRDSLevelLoadVariables)) as IRDSLevelLoadVariables;

		this.LoadCurrentLevel();
//		StartCoroutine (startTutorial ());
//		Debug.Log("UserPrefs.currentLevel" +UserPrefs.currentLevel);
	}
	
	// Update is called once per frame
	void Update () {
//	Debug.Log("car posti called. -----------------------" +UserPrefs.currentLevel);
	}
	IEnumerator startTutorial()
	{
		yield return new WaitForSeconds (0f);
		TutorialManager.Instance.ChangeState (TutorialManager.TutorialStates.INTRO);
	}
	private void LoadCurrentLevel(){		
				if (UserPrefs.currentEpisode == 1 || UserPrefs.currentEpisode == 2 || UserPrefs.currentEpisode == 3) {
//						Debug.Log ("LevelSpawing ================================" + UserPrefs.currentLevel);
					Instantiate (levelsArray [UserPrefs.currentLevel - 1], new Vector3 (0, 0, 0), Quaternion.identity);
						levelsArray [UserPrefs.currentLevel - 1].gameObject.SetActive(true);
				}
		}

}
