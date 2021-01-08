using UnityEngine;
using System.Collections;

public class LevelSelectionMenuStatus : MonoBehaviour {

	int myLevelNo;

	// Use this for initialization
	void Start () {
		myLevelNo = int.Parse(this.transform.parent.name);
		if(myLevelNo <= UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode - 1])
			this.gameObject.SetActive(false);
		else
			this.transform.parent.GetComponent<Collider>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
