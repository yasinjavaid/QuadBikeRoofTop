using UnityEngine;
using System.Collections;
using System;
using System.IO;
public class FrontSideCollision : MonoBehaviour {

//	GameObject thiefCar;
//	private int force;
//	private float bumpTime = 0;
//	// Use this for initialization
//	void Start () {
//		thiefCar = GameObject.FindGameObjectWithTag("Player");
//		if(Constants.totalHits[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1] == 1)
//		{
//			this.gameObject.GetComponent<Collider>().enabled = false;
//		}
//		thiefCar = GameObject.FindGameObjectWithTag("Player");
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
//	void  OnTriggerEnter (Collider collisionInfo){
//		//	Debug.LogError(collisionInfo.gameObject.tag);
////		Debug.LogError("Side Collided With    "+collisionInfo.gameObject.tag);
//		if(collisionInfo.gameObject.tag == "PoliceBody")
//		{
////			Debug.LogError("Front collided with Police <<<<<<<<<<<<<");
//			
////			Debug.LogError("");
//			if(Time.time > ThiefLeftCollision.timer+3.0f){
//				
//
//				try{
//					thiefCar.GetComponent<iTween>().enabled = true;
//				}
//				catch(Exception ex)
//				{
////					Debug.LogError("<<<<<<<<<<<<<<<======>>>>>>>>>>>>>>>>>");
//				}
//
//				thiefCar.GetComponent<RotateGameObject>().enabled = true;
//				
//				thiefCar.GetComponent<RotateGameObject>().rotationFactor = 10;
//				bumpTime = 0.5f;
//				force = 0;
////				if(WheelControllerGeneric.relativeVelocityMagnitude > 40)
////				{
////					thiefCar.GetComponent<RotateGameObject>().rotationFactor = -25;
////					bumpTime = 2.5f;
////					force = 1000;
////				}
////				else if(WheelControllerGeneric.relativeVelocityMagnitude > 20)
////				{
////					thiefCar.GetComponent<RotateGameObject>().rotationFactor = -20;
////					bumpTime = 1.5f;
////					force = 750;
////				}
////				else if(WheelControllerGeneric.relativeVelocityMagnitude > 10)
////				{
////					thiefCar.GetComponent<RotateGameObject>().rotationFactor = -10;
////					bumpTime = 1.0f;
////					force = 500;
////				}
////				else{
////					thiefCar.GetComponent<RotateGameObject>().rotationFactor = -2;
////					bumpTime = 0.5f;
////					force = 0;
////				}
//
////				Debug.LogError("Force =  "+ force);
//				thiefCar.GetComponent<Rigidbody>().AddForce(Vector3.up * force);
//				RotateGameObject.axis = RotateGameObject.Axis.x;
//				thiefCar.GetComponent<CarBalance>().enabled = false;
//				
//				StartCoroutine(stopRotation());
//				ThiefLeftCollision.timer = Time.time;
//			}
//		}
//	}
//	
//	IEnumerator stopRotation()
//	{
////		Debug.LogError("CoRoutine Started");
//		yield return new WaitForSeconds(bumpTime);
//		Time.timeScale = 1;
//		thiefCar.GetComponent<RotateGameObject>().enabled = false;
//		thiefCar.GetComponent<CarBalance>().enabled = true;
//		thiefCar.GetComponent<iTween>().enabled = false;
//		//Destroy(thiefCar.GetComponent<iTween>());
//		
//	}
}
