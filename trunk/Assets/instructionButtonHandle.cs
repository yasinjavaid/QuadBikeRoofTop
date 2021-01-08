using UnityEngine;
using System.Collections;

public class instructionButtonHandle : MonoBehaviour {

	// Use this for initialization
	public GameObject instPanel;
	public Transform arrow;
	public GameObject tutorialScript;
	public GameObject ColliderScript;
	void Start () {
		arrow.localPosition = new Vector3(418.2f,142f,0f);
		arrow.localEulerAngles = new Vector3(0,0,0);
		arrow.localScale = new Vector3(100f,100f,100f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick(){
		if (this.gameObject.name.Equals ("InstructionBtn")) {
			instPanel.SetActive (false);
			if (UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 1) {
				Invoke("waitForCamera",1.0f);
			}

			Time.timeScale = 1;

		} else
			if (this.gameObject.name.Equals ("btncancel")) {

			Destroy (GameObject.FindGameObjectWithTag ("Hud"));
			Resources.UnloadUnusedAssets ();
			GameManager.Instance.ChangeState (GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLESELECTIONMENU);
			//UserPrefs.isSound = GameObject.FindObjectOfType<HudStatus> ().soundState;
			Application.LoadLevel ("MenusScene");          
		
			Time.timeScale = 1;
		} else
			if (this.gameObject.name.Equals ("update")) {
			instPanel.SetActive (false);
			//UserPrefs.isSound = GameObject.FindObjectOfType<HudStatus> ().soundState;

			Time.timeScale = 1;
			GameObject.FindObjectOfType<LevelsData> ().Fail ();
		} else if (this.gameObject.name.Equals ("EpisodeBtn")) {

			Destroy (this.gameObject.transform.root.gameObject);
		} else
		if (this.gameObject.name.Equals ("reset")) {
			instPanel.SetActive (false);
			//UserPrefs.isSound = GameObject.FindObjectOfType<HudStatus> ().soundState;
			GameObject.FindGameObjectWithTag("Player2").GetComponent<CarBlast>().DestroyParts();
			//GameObject.FindObjectOfType<CarBlast>().DestroyParts();
			Camera.main.GetComponent<SmoothFollow>().InitiateCar();
			GameObject player=Camera.main.GetComponent<SmoothFollow>().player();
			GameObject.FindObjectOfType<SetCarPosition>().setCarPosition(player);

			Camera.main.GetComponent<SmoothFollow>().target=player.GetComponent<CarBlast>().parts[0].transform.FindChild("COM").gameObject.transform;
			Invoke("findEnemies",2.0f);
			Time.timeScale = 1;
			GameObject.FindObjectOfType<ObjectIndicator>().init();
		}
	}
	void waitForCamera()
	{

		tutorialScript.SetActive (true);
		ColliderScript.SetActive (true);
	}
	void findEnemies()
	{
		EnemyCar [] en = GameObject.FindObjectsOfType<EnemyCar>();
		foreach(EnemyCar e in en)
		{
			e.FindTargets();
		}

	}


}
