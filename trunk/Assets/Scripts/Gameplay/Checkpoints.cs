using UnityEngine;
using System.Collections;

public class Checkpoints : MonoBehaviour {

	public GameObject [] checkPoints;
	public float timeToCollect = 50;
	public UILabel lblCheckpointsCount;
	public UILabel lblTimeToCollect;

	bool isLevelFailedOrCompleted = false;
	int currentCheckpoint = 0;
	public UIFilledSprite checkPointsBar;
	public UIFilledSprite timeBar;
	float tempTime;
	// Use this for initialization
	void Start () {
		lblTimeToCollect.text = string.Format("Remaining time: {0:00.00} sec",timeToCollect);
		lblCheckpointsCount.text = string.Format ("Checkpoints: {0}/{1}", currentCheckpoint, checkPoints.Length);
		tempTime = timeToCollect;
		checkPoints [currentCheckpoint].SetActive (true);
		checkPoints [currentCheckpoint].GetComponentInChildren<RotateGameObject> ().enabled = true;
		checkPoints [currentCheckpoint + 1].SetActive (true);
		GAManager.Instance.LogDesignEvent("ModeStart::Episode"+UserPrefs.currentEpisode+"::Checkpoints");
		StartCoroutine (DelayForCheckpoints ());
	}
	
	// Update is called once per frame
	void Update () {
		if (isLevelFailedOrCompleted)
			return;

		checkPointsBar.fillAmount =(float)currentCheckpoint/(float)checkPoints.Length;
		timeBar.fillAmount = timeToCollect/tempTime;
		timeToCollect -= Time.deltaTime;
		lblTimeToCollect.text = string.Format("Remaining time: {0:00.00} sec",timeToCollect);
		if (timeToCollect <= 0) {
			lblTimeToCollect.text = string.Format("Remaining time: {0:00.00} sec",0);
			isLevelFailedOrCompleted = true;
			GameObject.FindObjectOfType<WheelControllerGenericNew>().levelFailed(1);
		}
	}

	public void NextCheckpoint(){
		currentCheckpoint++;
		lblCheckpointsCount.text = string.Format ("Checkpoints: {0}/{1}", currentCheckpoint, checkPoints.Length);
		if (currentCheckpoint >= checkPoints.Length) {
			isLevelFailedOrCompleted = true;
			GAManager.Instance.LogDesignEvent("ModeComplete::Episode"+UserPrefs.currentEpisode+"::Checkpoints");
			GameObject.FindObjectOfType<WheelControllerGenericNew>().levelCompleted(1);
			return;
		}

		GameObject.FindObjectOfType<WheelControllerGenericNew>().SetArrowTarget(checkPoints[currentCheckpoint].transform);
		checkPoints [currentCheckpoint - 1].SetActive (false);
		checkPoints [currentCheckpoint].GetComponentInChildren<RotateGameObject> ().enabled = true;

		if (currentCheckpoint == checkPoints.Length - 1)
			return;
		checkPoints [currentCheckpoint + 1].SetActive (true);
	}

	IEnumerator DelayForCheckpoints(){
		yield return new WaitForSeconds (1f);
		yield return new WaitForEndOfFrame ();
		var checkpoints = GameObject.FindGameObjectWithTag ("Checkpoints");
		if (checkpoints) {
			GameObject.FindObjectOfType<WheelControllerGenericNew>().SetArrowTarget(checkPoints[currentCheckpoint].transform);
		}
	}
}
