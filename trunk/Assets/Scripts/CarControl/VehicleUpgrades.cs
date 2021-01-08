using UnityEngine;
using System.Collections;

public class VehicleUpgrades : MonoBehaviour {

	public GasMotor engine;
	public SteeringControl steering;
	public Suspension[] brakes;

	// Use this for initialization
	void Start () {
		engine.power = VehicleManager.vehicleArray [UserPrefs.currentVehicle - 1].engineCurrentUpgradeLevel * 0.5f;
		steering.steerRate = VehicleManager.vehicleArray [UserPrefs.currentVehicle - 1].handlingCurrentUpgradeLevel * 0.5f;
		foreach (var brake in brakes) {
			brake.brakeForce = VehicleManager.vehicleArray [UserPrefs.currentVehicle - 1].brakeCurrentUpgradeLevel * 0.5f;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
