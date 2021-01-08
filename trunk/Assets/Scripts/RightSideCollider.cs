using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class RightSideCollider : MonoBehaviour {
	GameObject thiefCar;
	private float bumpTime = 0;
	Quaternion toRotation;
	// Use this for initialization
	void Start () {
		thiefCar = GameObject.FindGameObjectWithTag("Player");
		if(Constants.totalHits[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1] == 1)
		{
			this.gameObject.GetComponent<Collider>().enabled = false;
		}
		thiefCar = GameObject.FindGameObjectWithTag("Player");

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void  OnTriggerEnter (Collider collisionInfo){
		//	Debug.LogError(collisionInfo.gameObject.tag);
//		Debug.LogError("Side Collided With    "+collisionInfo.gameObject.tag);
		if(collisionInfo.gameObject.tag == "PoliceBody")
		{
			toRotation = new Quaternion(thiefCar.transform.rotation.x, thiefCar.transform.rotation.y, 0, 1);
//			Debug.LogError("Right collided with Police <<<<<<<<<<<<<");
			
//			Debug.LogError("");
			if(Time.time > ThiefLeftCollision.timer+3.0f){
				
				thiefCar.GetComponent<Rigidbody>().AddForce(Vector3.up * 1000);
				try{
					thiefCar.GetComponent<iTween>().enabled = true;
				}
				catch(Exception ex)
				{
//					Debug.LogError("<<<<<<<<<<<<<<<======>>>>>>>>>>>>>>>>>");
				}
				thiefCar.GetComponent<RotateGameObject>().enabled = true;
				
				thiefCar.GetComponent<RotateGameObject>().rotationFactor = 10;
				bumpTime = 0.5f;
//				if(WheelControllerGeneric.relativeVelocityMagnitude > 40)
//				{
//					thiefCar.GetComponent<RotateGameObject>().rotationFactor = -25;
//					bumpTime = 2.5f;
//				}
//				else if(WheelControllerGeneric.relativeVelocityMagnitude > 20)
//				{
//					thiefCar.GetComponent<RotateGameObject>().rotationFactor = -20;
//					bumpTime = 1.5f;
//				}
//				else if(WheelControllerGeneric.relativeVelocityMagnitude > 10)
//				{
//					thiefCar.GetComponent<RotateGameObject>().rotationFactor = -15;
//					bumpTime = 1.0f;
//				}
//				else{
//					thiefCar.GetComponent<RotateGameObject>().rotationFactor = -10;
//					bumpTime = 0.5f;
//				}
				RotateGameObject.axis = RotateGameObject.Axis.z;
				thiefCar.GetComponent<CarBalance>().enabled = false;
				
				StartCoroutine(stopRotation());
				ThiefLeftCollision.timer = Time.time;
			}
		}
	}
	
	IEnumerator stopRotation()
	{
//		Debug.LogError("CoRoutine Started");
		yield return new WaitForSeconds(bumpTime);
		Time.timeScale = 1;
		thiefCar.GetComponent<RotateGameObject>().enabled = false;
		thiefCar.GetComponent<CarBalance>().enabled = true;
		thiefCar.GetComponent<iTween>().enabled = false;
		//Destroy(thiefCar.GetComponent<iTween>());
		//thiefCar.transform.rotation = Quaternion.Lerp(thiefCar.transform.rotation, toRotation, Time.deltaTime);
		
	}
}
