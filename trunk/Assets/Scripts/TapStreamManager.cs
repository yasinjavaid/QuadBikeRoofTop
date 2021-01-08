using UnityEngine;
using System.Collections;

public class TapStreamManager : MonoBehaviour {

	void Awake()
	{
		DontDestroyOnLoad(this);
	}
	// Use this for initialization
	void Start () {

		if(!UserPrefs.isAmazonBuild){
//			Tapstream.Config conf = new Tapstream.Config();
			//conf.Set("idfa", SystemInfo.deviceUniqueIdentifier);
			//Tapstream.Create("tapinator", "GIBgntfkSSaqsQh0XiVeQQ", conf);

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
