using UnityEngine;
using System.Collections;

public class TrafficPatchHandler : MonoBehaviour {

	public GameObject trafficPatch;
	public GameObject [] trafficVehicles;

	[HideInInspector]
	public bool isActive = false;
	[HideInInspector]
	public int carsCount;
	// Use this for initialization
	void Start () {
		carsCount = trafficVehicles.Length;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void  OnTriggerEnter (Collider collisionInfo){
		if (collisionInfo.gameObject.transform.root.CompareTag("Player2")) {
			trafficPatch.SetActive(true);
			foreach(var vehicle in trafficVehicles){
				vehicle.SetActive(true);
			}
			isActive = true;
		}
	}

	void  OnTriggerExit (Collider collisionInfo){
		if (collisionInfo.gameObject.transform.root.CompareTag("Player2")) {
			trafficPatch.SetActive(false);
			foreach(var vehicle in trafficVehicles){
				vehicle.GetComponent<TrafficParent>().OnDisableSetParent();
				vehicle.SetActive(false);
			}
			isActive = false;
		}
	}

	public void ReduceCars(){
		carsCount -= 2;
		carsCount = carsCount <= 0 ? trafficVehicles.Length : carsCount;
		for (int i = 0; i < trafficVehicles.Length; i++) {
			if(i < carsCount){
				trafficVehicles[i].SetActive(true);
			}else{
				trafficVehicles[i].SetActive(false);
			}
		}
	}
}
