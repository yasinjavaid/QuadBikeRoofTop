using UnityEngine;
using System.Collections;

public class CameraView : MonoBehaviour {

	// Use this for initialization
	GasMotor engine;
	Transform com;
	float comZpos = 0f;
	bool changePosZ = false;
	SmoothFollow sf;

	float MAX = 8f,MIN = 2.5f;
	void Start () {
	GameObject camera=	 GameObject.FindGameObjectWithTag ("MainCamera");
		camera.GetComponent<SmoothFollow>().h=9f;
		camera.GetComponent<SmoothFollow> ().d = 12f;
		camera.GetComponent<Camera>().fieldOfView = 60;
		engine = GetComponent<EnginePowerManager>().engine.GetComponent<GasMotor>();
		float f = engine.targetDrive.feedbackRPM;
		sf = camera.GetComponent<SmoothFollow>();
		com = sf.target;
	}
	
	// Update is called once per frame
	void Update () {
		if (!Constants.isBossMode) {
			if (engine.targetDrive.feedbackRPM > 500f) {
				sf.h -= 0.8f;
			} else if (engine.targetDrive.feedbackRPM < -500f) {
				sf.h += 0.4f;
			}
			if (sf.h > MAX)
				sf.h = MAX;
			else if (sf.h < MIN)
				sf.h = MIN;
//		if(changePosZ)
//		{
//			comZpos-=0.1f;
//		}
//		else
//		{
//			comZpos+=0.1f;
//		}
//		comZpos = Mathf.Clamp(comZpos,-2,0f);
//		com.localPosition = new Vector3(0,1.88f,comZpos);
//		Debug.Log("RPBM "+engine.targetDrive.feedbackRPM);
		}
	}
	void OnTriggerEnter(Collider other) {
	//	Debug.Log(other.name);
		if (other.tag == "obstacle") {
		//	changePosZ = false;

			//com.localPosition = new Vector3(0,1.88f,0);
		//	Debug.Log(other.name);

		//	Camera.main.GetComponent<SmoothFollow>().h=1.58f;
		}
	}
	void OnTriggerExit(Collider other)
	{	//	Debug.Log(other.name);

		if (other.tag == "obstacle") {
		//	changePosZ = true;
		//	com.localPosition = new Vector3(0,1.88f,-2f);
			//Debug.Log(other.name);
			//
		//	Camera.main.GetComponent<SmoothFollow>().h=4f;

		}

	}

}
