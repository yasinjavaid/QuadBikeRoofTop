using UnityEngine;
using System.Collections;

public class hummerText : MonoBehaviour {

	// Use this for initialization
	public GameObject labl;
	void Start () {
		if (this.gameObject.name == "tap") {
			Time.timeScale = 0f;

		}
		else if (UserPrefs.islevel4) {
//			GAManager.Instance.LogDesignEvent("Try::Jeep::LevelStart");
						StartCoroutine (msg ());

				}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator msg()
	{
		yield return new WaitForSeconds (2f);
		labl.SetActive (true);
		yield return new WaitForSeconds (4f);
	//	labl.SetActive (false);
		UserPrefs.islevel4 = false;
	}
	void OnClick()
	{
		if (this.gameObject.name == "tap") {

			Time.timeScale = 1f;
			labl.SetActive(false);
		}
	}

}
