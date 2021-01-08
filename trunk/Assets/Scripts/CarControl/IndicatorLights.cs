using UnityEngine;
using System.Collections;

public class IndicatorLights : MonoBehaviour {

	public GameObject light;
	bool isEnabled = false;

	void OnEnable(){
		isEnabled = true;
		StartCoroutine (AnimateLight());
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDisable(){
		isEnabled = false;
		StopCoroutine (AnimateLight ());
	}

	IEnumerator AnimateLight(){
		while (isEnabled) {
			yield return new WaitForSeconds (1);
			light.SetActive (true);
			yield return new WaitForSeconds (1);
			light.SetActive (false);
		}
	}
}
