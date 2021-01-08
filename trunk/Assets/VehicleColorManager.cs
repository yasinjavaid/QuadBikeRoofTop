using UnityEngine;
using System.Collections;

public class VehicleColorManager : MonoBehaviour {

	public GameObject VehicleBody;
	private VehicleManager vehicleManager;
	public GameObject []VehicleWheels;
	void Start () {
		vehicleManager = GameObject.FindGameObjectWithTag("VehicleManager").GetComponent<VehicleManager>();
		if (VehicleBody) {
			if (UserPrefs.currentVehicle == 2) {
				VehicleBody.GetComponent<Renderer> ().materials [1].color = vehicleManager.vehicleBodyColors [VehicleManager.vehicleArray [(UserPrefs.currentVehicle - 1)].currentColor - 1];
			} else

				VehicleBody.GetComponent<Renderer> ().material.color = vehicleManager.vehicleBodyColors [VehicleManager.vehicleArray [(UserPrefs.currentVehicle - 1)].currentColor - 1];
		}

		int wheelId = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].currentWheel-1;
		Renderer []renderer =GameObject.FindGameObjectWithTag("Wheels").GetComponentsInChildren<Renderer>();
		
		for(int i= 0;i< renderer.Length;i++){

				renderer[i].materials[1].mainTexture= vehicleManager.Wheels[wheelId];	

					
			
		}




	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void setCarColor(int colorId)
	{

		

		
	}
}
