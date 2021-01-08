using UnityEngine;
using System.Collections;

public class LevelFailAnimation : MonoBehaviour {

	// Use this for initialization;
	public Transform campos;
	public GameObject levelFailobj;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void LevelFail()
	{
		GameObject.FindGameObjectWithTag("Player2").SetActive(false);
		Camera.main.GetComponent<SmoothFollow>().enabled = false;
		Camera.main.GetComponent<SmoothFollowForCamView>().enabled = false;
		Camera.main.transform.position = campos.transform.position;
		Camera.main.transform.rotation =  campos.transform.rotation;
		levelFailobj.SetActive(true);
	}
}
