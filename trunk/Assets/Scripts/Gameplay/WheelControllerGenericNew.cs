using UnityEngine;
using System.Collections;

public class WheelControllerGenericNew : MonoBehaviour {
	private bool isLevelFinished = false;
	public GameObject arrow;
	public GameObject Sparks;
	private GameObject Freemode; 
	private UIFilledSprite DamageBar;
	Vector3 lastPosition;

	public float distanceTravelled= 0;
	public GameObject engineSound;
	// Use this for initialization
	void Start () {
		StartCoroutine (DelayForCheckpoints ());

	}
	void OnTriggerEnter(Collider col)
	{
		Debug.Log("HURDLE " + col.name);
	}
	// Update is called once per frame
	void LateUpdate () {
		distanceTravelled += Vector3.Distance(transform.position, lastPosition);
		lastPosition = transform.position;
	}
	void OnCollisionEnter(Collision collision) {

		var damage = GameObject.FindGameObjectWithTag ("NoDemage");
		if (damage && GameManager.Instance.GetCurrentGameState() == GameManager.GameState.GAMEPLAY) {
			if(collision.gameObject.tag != "MainBase" && !isLevelFinished)
			{
				isLevelFinished = true;
				levelFailed(1);
			}
		}
		var isProp = GameObject.FindGameObjectWithTag ("Prop");
		if (isProp && GameManager.Instance.GetCurrentGameState() == GameManager.GameState.GAMEPLAY) {
			if(collision.gameObject.tag == "Prop" && !isLevelFinished)
			{
				isLevelFinished = true;
				levelFailed(1);
			}
		}
		if (Freemode && GameManager.Instance.GetCurrentGameState () == GameManager.GameState.GAMEPLAY) {
			if(collision.gameObject.tag != "MainBase" && !isLevelFinished)
			{
				if(DamageBar.fillAmount<1)
				DamageBar.fillAmount+=this.gameObject.GetComponent<Rigidbody>().velocity.magnitude/Constants.DamageIntensity;
				else
				{
					isLevelFinished=true;
					levelCompleted(1);
				}
			}

		}

	}
	private void levelFail()
	{
		QualitySettings.vSyncCount = 1;
		Application.targetFrameRate = 300;
		Time.timeScale = 1;
		removePhysics ();
		GameObject.FindGameObjectWithTag ("Hud").GetComponentInChildren<Camera> ().enabled = false;
		GameObject.FindGameObjectWithTag ("Hud").GetComponent<BoxCollider> ().enabled = true;
		GameObject.FindObjectOfType<LevelFailAnimation>().LevelFail();
		GAManager.Instance.LogDesignEvent("LevelFail::Episode"+UserPrefs.currentEpisode+"::Level"+UserPrefs.currentLevel);

		//GameManager.Instance.ChangeState(GameManager.SoundState.LEVELFAILSOUND ,GameManager.GameState.CRASHED);	
	}
	public void levelFailed(float time)
	{
		//removePhysics ();

		Invoke ("levelFail",time);
	}
	private void levelComplete()
	{
		GAManager.Instance.LogDesignEvent("LevelSuccess::Episode"+UserPrefs.currentEpisode+"::Level"+UserPrefs.currentLevel);
		GameObject.FindGameObjectWithTag ("Hud").GetComponentInChildren<Camera> ().enabled = false;
		GameObject.FindGameObjectWithTag ("Hud").GetComponent<BoxCollider> ().enabled = true;
		QualitySettings.vSyncCount = 1;
		Application.targetFrameRate = 300;
		Time.timeScale = 1;
		removePhysics ();
		GameObject.FindObjectOfType<LevelSuccessAnimation>().LevelComplete();
		UserPrefs.currentLevel++;
		if(UserPrefs.currentLevel > Constants.levelsPerEpisode )
		{
			UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]=1;
			UserPrefs.episodeCompletedArray[UserPrefs.currentEpisode-1] = true;
			UserPrefs.episodeUnlockArray[1] = true;
		}
		else
		{
			if(UserPrefs.currentLevel - 1 == UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode - 1])
				UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]++;
		}
		UserPrefs.Save ();
//		UserPrefs.isIncreaseDifficulty [UserPrefs.currentLevel - 1] = true;
//		if (UserPrefs.currentLevel == UserPrefs.unlockLevelsArrays [UserPrefs.currentEpisode - 1]) {
//			for(int i = 0; i < UserPrefs.unlockLevelsArrays.Length ; i++)
//				UserPrefs.unlockLevelsArrays[i]++;
//			UserPrefs.isModeUnlocked = true;
//		}

		GameManager.Instance.ChangeState(GameManager.SoundState.LEVELSUCCESSSOUND ,GameManager.GameState.LEVELCOMPLETE);

	}
	public void levelCompleted(float time)
	{
	//	removePhysics ();

		Invoke ("levelComplete",time);
	}
	public void removePhysics()
	{
		this.gameObject.GetComponent<Rigidbody> ().isKinematic = true;
	}

	IEnumerator DelayForCheckpoints(){
		yield return new WaitForSeconds (1f);
		var checkpoints = GameObject.FindGameObjectWithTag ("Checkpoints");
		if (checkpoints) {
			arrow.SetActive(true);
		}
	}

	public void SetArrowTarget(Transform target){
		arrow.GetComponent<LookAtTarget> ().SetTarget (target);
	}

}
