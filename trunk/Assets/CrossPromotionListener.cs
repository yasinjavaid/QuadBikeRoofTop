using UnityEngine;
using System.Collections;

public class CrossPromotionListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick(){
		if (this.name.Equals ("Prom1")) {
			Debug.LogError( PreviewLabs.CustomPlayerPrefs.GetString ("promotion" + 0 + "_" + "click_url"));
			Application.OpenURL( PreviewLabs.CustomPlayerPrefs.GetString ("promotion" + 0 + "_" + "click_url"));
		}
	}
}
