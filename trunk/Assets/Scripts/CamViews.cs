using UnityEngine;
using System.Collections;

public class CamViews : MonoBehaviour {

	// Use this for initialization
	public bool leftView = false,rightView = false, backView = false, frontView = false, defaultView = true;
	public float timeToDefaultView = 1f;
	public bool setAutoDefault = true;
	public bool ChangeSmoothFollow = false;
	public float heightFactor = 0;
	public float distanceFactor = 0;
	public bool changeValues = false;
	public float newTimeScale = 1;
	public int syncCount = 0;
	public int frams = 25;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//void OnCollisionEnter(Collision col)
	public void EnableCamView()
	{				
		setValues();
		//if(col.gameObject.tag == "Player2")
//		{
//			if(defaultView)
//			{
//				setDefaultValues();
//				SmoothFollowForCamView.defaultView = true;
//				SmoothFollowForCamView.leftView = false;
//				SmoothFollowForCamView.rightView = false;
//				SmoothFollowForCamView.backView = false;
//				SmoothFollowForCamView.frontView = false;
//			}
//			else if(backView)
//			{
//				setValues();
//				SmoothFollowForCamView.defaultView = false;
//				SmoothFollowForCamView.leftView = false;
//				SmoothFollowForCamView.rightView = false;
//				SmoothFollowForCamView.backView = true;
//				SmoothFollowForCamView.frontView = false;
//			}
//			else if(frontView)
//			{
//				setValues();
//				SmoothFollowForCamView.defaultView = false;
//				SmoothFollowForCamView.leftView = false;
//				SmoothFollowForCamView.rightView = false;
//				SmoothFollowForCamView.backView = false;
//				SmoothFollowForCamView.frontView = true;
//			}
//			else if(leftView)
//			{
//				setValues();
//				SmoothFollowForCamView.defaultView = false;
//				SmoothFollowForCamView.leftView = true;
//				SmoothFollowForCamView.rightView = false;
//				SmoothFollowForCamView.backView = false;
//				SmoothFollowForCamView.frontView = false;
//			}
//			else if(rightView)
//			{
//				setValues();
//				SmoothFollowForCamView.defaultView = false;
//				SmoothFollowForCamView.leftView = false;
//				SmoothFollowForCamView.rightView = true;
//				SmoothFollowForCamView.backView = false;
//				SmoothFollowForCamView.frontView = false;
//			}
//			else
//			{
//				setDefaultValues();
//				SmoothFollowForCamView.defaultView = true;
//				SmoothFollowForCamView.leftView = false;
//				SmoothFollowForCamView.rightView = false;
//				SmoothFollowForCamView.backView = false;
//				SmoothFollowForCamView.frontView = false;
//			}
//		}
		if(setAutoDefault)
		{
			Invoke("SetDefaultView",timeToDefaultView);
		}

	}
	void setValues()
	{
		if(changeValues)
		{
			if(ChangeSmoothFollow)
			{
				changeSmoothFollow();
			}
			QualitySettings.vSyncCount = syncCount;
			Application.targetFrameRate = frams;
			Time.timeScale = newTimeScale;
		}
	}
	void changeSmoothFollow()
	{
		//SmoothFollowForCamView.distance += distanceFactor;
		//SmoothFollowForCamView.height+=heightFactor;
		//Debug.Log(CameraControlPPnew.distance + " H "+CameraControlPPnew.height);
	}
	void setDefaultValues()
	{
		SmoothFollowForCamView.TargetTwo =null;
		//Camera.main.GetComponent<CameraControl>().enabled = true;
		//Camera.main.GetComponent<SmoothFollowForCamView>().enabled = false;
		Time.timeScale = 1f;
		QualitySettings.vSyncCount = 1;
		Application.targetFrameRate = 300;
//		SmoothFollowForCamView.distance =Camera.main.GetComponent<SmoothFollowForCamView>().d;
//		SmoothFollowForCamView.height = Camera.main.GetComponent<SmoothFollowForCamView>().h;
	}
	void SetDefaultView()
	{

		setDefaultValues();
//		SmoothFollowForCamView.defaultView = true;
//		SmoothFollowForCamView.leftView = false;
//		SmoothFollowForCamView.rightView = false;
//		SmoothFollowForCamView.backView = false;
//		SmoothFollowForCamView.frontView = false;
	}
	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.name == "Truck Body")
		{
			if(!setAutoDefault)
			{
				SetDefaultView();
			}
		}
	}
}
