using UnityEngine;
using System.Collections;

public class VehicleStats : MonoBehaviour {

	public GasMotor engine;

	float vehicleSpeed = 0;
	float vehicleDistance = 0;
	float vehicleDamage;
	float vehicleFuel;
	float modeMaxSpeed = 0;
	[HideInInspector]
	public float distanceTravelled= 0;
	Vector3 lastPosition;

	GameObject _mVehicle;
	public float ModeMaxSpeed {
		get {
			return this.modeMaxSpeed;
		}
		set {
			modeMaxSpeed = value;
		}
	}
	public float Speed {
		get {
			return this.vehicleSpeed;
		}
		set {
			vehicleSpeed = value;
		}
	}

	public float Distance {
		get {
			return this.vehicleDistance;
		}
		set {
			vehicleDistance = value;
		}
	}

	public float Damage {
		get {
			return this.vehicleDamage;
		}
		set {
			vehicleDamage = value;
		}
	}

	public float Fuel {
		get {
			return this.vehicleFuel;
		}
		set {
			vehicleFuel = value;
		}
	}

	public float RPM {
		get {
			return 0; /*Mathf.Abs(this.engine.targetDrive.feedbackRPM);*/
		}
	}

	float time;

	// Use this for initialization
	void Start () {
		time = Time.time;
		_mVehicle = this.gameObject;
	}
//	void Update()
//	{
//		distanceTravelled += Vector3.Distance(transform.position, lastPosition);
//		lastPosition = transform.position;
//	}
	// Update is called once per frame
	void LateUpdate () {
		vehicleSpeed = new Vector2 (Vector3.Dot (_mVehicle.GetComponent<Rigidbody>().velocity, _mVehicle.transform.forward), Vector3.Dot (_mVehicle.GetComponent<Rigidbody>().velocity, _mVehicle.transform.right)).magnitude;
		if (Time.time >= time + 1) {
			time = Time.time;
			vehicleDistance += vehicleSpeed * Constants.KMHtoKMS;
		}
		if (modeMaxSpeed == 0)
			modeMaxSpeed = vehicleSpeed;

		if (vehicleSpeed > modeMaxSpeed)
			modeMaxSpeed = vehicleSpeed;
		if (vehicleSpeed > UserPrefs.topSpeed) {
			UserPrefs.topSpeed = vehicleSpeed;
			UserPrefs.SaveTopSpeed();
			GameObject.FindObjectOfType<HudStatus>().ShowTopSpeedIndicator();
		}
		distanceTravelled += Vector3.Distance(transform.position, lastPosition);
		lastPosition = transform.position;
	}
}
