using UnityEngine;
using System.Collections;

public class RoofCollision : MonoBehaviour {

	// Use this for initialization
	float time;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void  OnTriggerEnter (Collider collisionInfo){
//		//Debug.Log("OOOOO "+collisionInfo.name + " -  " + collisionInfo.gameObject.GetComponent<PoliceChaseActivatorListener>());
//		if(collisionInfo.gameObject.name!="Main_body"&&collisionInfo.gameObject.tag!="Player2" && collisionInfo.gameObject.GetComponent<PoliceChaseActivatorListener>()==null && collisionInfo.gameObject.GetComponent<PoliceCarActivatorListener>() == null)
//		{
//			time=Time.time;
//			time=time+2f;
//
//					}
	}
	void OnTriggerStay(Collider other) {
//		if(other.gameObject.name!="Main_body" &&other.gameObject.tag!="Player2" && other.gameObject.GetComponent<PoliceChaseActivatorListener>()==null && other.gameObject.GetComponent<PoliceCarActivatorListener>() == null) 
//		{
//
//			if(Time.time>time)
//			{
//				this.gameObject.transform.parent.rotation=new Quaternion(0,this.gameObject.transform.rotation.y,0,this.gameObject.transform.rotation.z);
//			}
//
//
//
//		}
	}
}
