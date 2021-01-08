using UnityEngine;
using System.Collections;

public class DisableArow : MonoBehaviour {

	// Use this for initialization
	public bool autoDisable ;
	void OnEnable () {
		if (autoDisable) {
			Invoke("disableArow",6f);		
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
//	void OnPress (bool isDown)
//	{
//		this.gameObject.SetActive (false);
//	}
	public void disableArow()
	{
		this.gameObject.SetActive (false);
	}
}
