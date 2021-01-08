using UnityEngine;
using System.Collections;

public class CarStandController : MonoBehaviour {

	// Use this for initialization
	public GameObject[] CarsOnStand = new GameObject[2];

	void Start () {
		enableCarAt(UserPrefs.currentVehicle-1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void enableCarAt(int carIndex){
		for(int i = 0; i < CarsOnStand.Length; i++){
			if(i == carIndex){
				//GameObject carStandObj = GameObject.FindGameObjectWithTag("CarStand");
				//CarsOnStand[i].transform.rotation = carStandObj.transform.rotation;
				CarsOnStand[i].SetActive(true);
			}
			else{
				CarsOnStand[i].SetActive(false);
			}
		}
	}
}
