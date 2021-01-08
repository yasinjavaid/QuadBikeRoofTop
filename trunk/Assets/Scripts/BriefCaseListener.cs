using UnityEngine;
using System.Collections;

public class BriefCaseListener : MonoBehaviour {
//	bool levelFinished = false;
//	// Use this for initialization
//	void Start () {
//		if(!UserPrefs.isTutorial)
//			TutorialManager.Instance.ChangeState(TutorialManager.TutorialStates.LOCATEBRIEFCASE);
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		if(CalculateDistance() < 10 && !UserPrefs.isTutorial && !ArrestController.isInstructionShown)
//		{
//			ArrestController.isInstructionShown = true;
////			TutorialManagerNew.Instance.ChangeState(TutorialManagerNew.TutorialState.GETOUTOFCAR);
//			UserPrefs.isTutorial = true;
//		}
//		if(CalculateDistanceThief() < 2.5f )
//		{
//			UserPrefs.crashCause = 2;
//			GameObject.FindGameObjectWithTag("Player2").GetComponent<WheelControllerGeneric>().LevelFailed();
//			levelFinished = true;
//			GameObject.FindGameObjectWithTag("Thief").SetActive(false);
//			this.gameObject.SetActive(false);
//		}
//	
//	}
//	float CalculateDistance()
//	{
//		float minDist= Vector3.Distance(GameObject.FindGameObjectWithTag("Police").gameObject.transform.position,this.gameObject.transform.position);
//		return minDist;
//	}
//	float CalculateDistanceThief()
//	{
//		float minDist= Vector3.Distance(GameObject.FindGameObjectWithTag("Thief").gameObject.transform.position,this.gameObject.transform.position);
//		return minDist;
//	}
//	void OnTriggerEnter (Collider collision) {
//		//Debug.LogError ("Collided With "+ collision.gameObject.tag);
//		if(!levelFinished)
//		{
//			if (collision.gameObject.tag == "Police") {
//				Instantiate(Resources.Load("CoinsAnimation"),this.transform.position,collision.transform.rotation);
//				this.gameObject.SetActive(false);
//				this.transform.root.GetComponent<LevelHandlerGeneric>().NextLevel();
//				GameManager.Instance.ChangeState(GameManager.SoundState.PICKaTHING);
//				levelFinished = true;
//			}
//			else if(collision.gameObject.tag == "Player2")
//			{
//				//GameObject.FindGameObjectWithTag("Player2").GetComponent<WheelControllerGeneric>().LevelCompleted();
//				//thiefPose = ThiefPose.HIT;
//				TutorialManagerNew.Instance.ShowInfoPanel("Get out of the car and pick item.");
//			}
//			else if(collision.gameObject.tag == "Thief")
//			{
//				Instantiate(Resources.Load("CoinsAnimation"),this.transform.position,collision.transform.rotation);
//				collision.gameObject.SetActive(false);
//				this.gameObject.SetActive(false);
//				GameObject.FindGameObjectWithTag("Player2").GetComponent<WheelControllerGeneric>().LevelFailed();
//				levelFinished = true;
//
//			}
//		}
//	}
}
