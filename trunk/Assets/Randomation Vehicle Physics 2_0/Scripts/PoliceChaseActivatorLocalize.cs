using UnityEngine;
using System.Collections;

public class PoliceChaseActivatorLocalize : MonoBehaviour {

	// Use this for initialization
	public GameObject [] policeCars;
	public GameObject player;
	void Start () {

	foreach (GameObject car in policeCars) {
			if(car){
			//car.GetComponent<Rigidbody>().isKinematic=true;
			car.SetActive(false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public bool chaseCar(GameObject player)
	{

		if (player.GetComponent<ChasingCars> ().isCarsChasing ()) {

			if (player.GetComponent<ChasingCars> ().isEligbleForReset ()) {
				player.GetComponent<ChasingCars> ().setCars(policeCars);
				foreach (GameObject car in policeCars) {
					car.SetActive(true);
					car.GetComponent<FollowAI> ().target = player.transform;
				}
				return true;

			}
			else
				return false;
		} else {

			player.GetComponent<ChasingCars> ().setCars(policeCars);
			foreach (GameObject car in policeCars) {

				//car.GetComponent<Rigidbody> ().isKinematic = false;
				car.SetActive(true);
				car.GetComponent<FollowAI> ().target = player.transform;

			}
			return true;
		}



	}
	public bool isActive()
	{
		
	foreach (GameObject cars in policeCars) {
			if(cars)
			if (cars.activeInHierarchy)
				return true;
		}
		return false;
			

		}
//	public void ActivePoliceChasingCars()
//	{
//		foreach (GameObject cars in policeCars) {
//
//			cars.SetActive (true);
//
//
//		}
//
//
//	}
	

}
