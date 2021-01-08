using UnityEngine;
using System.Collections;

public class TutorialLevel : MonoBehaviour {

	// Use this for initialization
	public GameObject accelArrow;
	GameObject enemy;

	void Start () {

	
	//	Camera.main.GetComponent<SteerNew> ().steerBtns [0].SetActive (false);
	//	Camera.main.GetComponent<SteerNew> ().steerBtns [1].SetActive (false);
	
		accelArrow.SetActive (true);
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}

}
