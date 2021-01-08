using UnityEngine;
using System.Collections;

public class FakeLoading : MonoBehaviour {
	
	// Use this for initialization
	bool soundstate;
	void Start () {
		soundstate = UserPrefs.isSound;
		UserPrefs.isSound=false;
		Destroy(this.gameObject,2.5f);
	}
	
	// Update is called once per frame
	void OnDestroy()
	{
		UserPrefs.isSound = soundstate;
	}
}
