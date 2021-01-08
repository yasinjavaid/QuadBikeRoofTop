using UnityEngine;
using System.Collections;

public class CarLightsControl : MonoBehaviour {

	public GameObject leftIndicator;
	public GameObject rightIndicator;
	public GameObject brakeLights;
	public GameObject reverseLights;

	bool indicatorEnabled;
	int state;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (HudListener.isBrakePressed) {
			brakeLights.SetActive (true);
		} else {
			brakeLights.SetActive (false);
		}

		if (HudListener.isReverse) {
			reverseLights.SetActive (true);
		} else {
			reverseLights.SetActive (false);
		}

		switch (state) {
		case 0: 
			leftIndicator.SetActive(false);
			rightIndicator.SetActive(false);
			break;
		case 1: leftIndicator.SetActive(true);
			rightIndicator.SetActive(false);
			break;
		case 2: rightIndicator.SetActive(true);
			leftIndicator.SetActive(false);
			break;
		case 3: 
			leftIndicator.SetActive(true);
			rightIndicator.SetActive(true);
			break;
		}
	}

	public void ChangeIndicatorState(int state){
		if (state == 3) {
			leftIndicator.SetActive (false);
			rightIndicator.SetActive (false);
		}
		this.state = state;
	}

	public void EnableIndicator(int state,bool enable,GameObject [] indicatorSprites){
		indicatorEnabled = enable;
		if (!indicatorEnabled)
			return;

		switch (state) {
		case 1: GameObject [] indicators = {leftIndicator}; 
			StartCoroutine(AnimateIndicators(indicators,indicatorSprites));
			break;
		case 2: GameObject [] indicators2 = {rightIndicator}; 
			StartCoroutine(AnimateIndicators(indicators2,indicatorSprites));
			break;
		case 3: GameObject [] indicators3 = {rightIndicator,leftIndicator}; 
			StartCoroutine(AnimateIndicators(indicators3,indicatorSprites));
			break;
		}
	}

	public void DisableIndicator(int state){
		switch (state) {
		case 1: leftIndicator.SetActive(false);
				indicatorEnabled = false;
			break;
		case 2: rightIndicator.SetActive(false);
				indicatorEnabled = false;
			break;
		case 3: rightIndicator.SetActive(false);
			leftIndicator.SetActive(false);
			indicatorEnabled = false;
			break;
		}
	}

	IEnumerator AnimateIndicators(GameObject[] indicators,GameObject [] indicatorSprites){
		while(indicatorEnabled) {
			yield return new WaitForSeconds (1);
			foreach (var indicator in indicators) {
				indicator.SetActive (true);
			}
			foreach (var indicator2 in indicatorSprites) {
				indicator2.SetActive (true);
			}
			yield return new WaitForSeconds (1);
			foreach (var indicator2 in indicatorSprites) {
				indicator2.SetActive (false);
			}
			foreach (var indicator in indicators) {
				indicator.SetActive (false);
			}
		}
	}
}
