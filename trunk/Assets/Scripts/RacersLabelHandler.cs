using UnityEngine;
using System.Collections;

public class RacersLabelHandler : MonoBehaviour {

//	public UILabel totalRacers;
//	public UILabel remainingRacers;
//	public GameObject skipLabel;
//	bool oneKilled = false;
//	public GameObject mapArrow,leftArrow;
//	// Use this for initialization
//	void Start () {
//		Debug.Log("+++++ Start RacersLabelHandler called");
//		totalRacers.text = "/ " + Constants.totalCars[UserPrefs.currentEpisode - 1, UserPrefs.currentLevel - 1].ToString();
//		remainingRacers.text = Constants.totalCars[UserPrefs.currentEpisode - 1, UserPrefs.currentLevel - 1].ToString();
//	}
//	
//	public void DecrementRemainingRacerCount(){
//		iTween.ScaleFrom(remainingRacers.gameObject, iTween.Hash("x",100,"y",100,"time",2,"easeType",iTween.EaseType.linear,"isLocal",true));
//		remainingRacers.text = (int.Parse(remainingRacers.text) - 1).ToString();
//		if (UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 1 && !oneKilled) {
//			oneKilled = true;
//			GAManager.Instance.LogDesignEvent("Tutorial::CarSmash1");
//			StartCoroutine(disableMessage());
//		}
//	}
//	IEnumerator disableMessage()
//	{
////		IRDSStatistics.SetCanRace (true);
//		GameObject player = GameObject.FindGameObjectWithTag ("Player2");
//		yield return new WaitForSeconds (2);
//		GameObject.FindObjectOfType<Instructions>().startInstruction.SetActive(true);
//		//mapArrow.SetActive (true);
//
//		yield return new WaitForSeconds (2f);
//		GameObject arrow = GameObject.Find("CarArrow");
//		GameObject racer = GameObject.FindGameObjectWithTag ("Player");
//		arrow.transform.parent = racer.transform;
//		arrow.transform.localPosition = new Vector3 (0, 0, 0);
//		//yield return new WaitForSeconds (2);
//		//	GameObject.FindGameObjectWithTag("Player2").GetComponent<Rigidbody>().isKinematic = true
//		//SmoothFollow.target = GameObject.Find("EmptyBody").transform;
//
//		player.GetComponent<Rigidbody>().isKinematic = true;
//		player.transform.position = new Vector3 (-92.73949f, 11.4827f, 181.1403f);
//		player.transform.eulerAngles = new Vector3 (0, -90f, 0);
//		player.GetComponent<Rigidbody>().isKinematic = false;
//	
//		leftArrow.SetActive (true);
//		yield return new WaitForSeconds (3f);
//		GameObject.FindObjectOfType<Instructions>().startInstruction.SetActive(false);
//
//
//
//	}
//

}
