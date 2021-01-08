using UnityEngine;
using System.Collections;

public class DisableAudio : MonoBehaviour {

	// Use this for initialization
	public GameObject panel;
	bool soundstate;
	void Awake () {
		if(this.gameObject.name == "Loading")
		{
			soundstate = UserPrefs.isSound;
			UserPrefs.isSound=false;
			UserPrefs.isLoaded = false;

		}
		if(UserPrefs.isIgnoreAds)
		{
			panel.SetActive(false);
		}
	
		//DontDestroyOnLoad(this.gameObject);
//		if (UserPrefs.isSound) {
//			UserPrefs.isSound = false;
//			UserPrefs.isAudioDisabled = true;
//		}
		//AudioListener.volume = 0;
	}
	
	// Update is called once per frame
	void Update () {
	//	AudioListener.volume = 0;
	}
	void OnDestroy()
	{
		if(this.gameObject.name == "Loading")
		UserPrefs.isSound = soundstate;
	}
}
