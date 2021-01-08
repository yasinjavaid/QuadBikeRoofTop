using UnityEngine;
using System.Collections;

public class DummyJoystick : MonoBehaviour {

	int count = 0;

	// Use this for initialization
	void Start () {
		if(!(UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 1))
			this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){
			count++;
			if(count >= 2)
				this.gameObject.SetActive(false);
		}
	}
}
