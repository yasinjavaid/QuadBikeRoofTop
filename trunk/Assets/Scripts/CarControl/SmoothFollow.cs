

using UnityEngine;
using System.Collections;

public class SmoothFollow: MonoBehaviour {
/*
This camera smoothes out rotation around the y-axis and height.
Horizontal Distance to the target is always fixed.

There are many different ways to smooth the rotation but doing it this way gives you a lot of control over how the camera behaves.

For every of those smoothed values we calculate the wanted value and the current value.
Then we smooth it using the Lerp function.
Then we apply the smoothed values to the transform's position.
*/

// The target we are following
public Transform target;
public static	Vector3 originalPos;
	public static float shakeAmount = 0.07f;
// The distance in the x-z plane to the target
public static float distance;
// the height we want the camera to be above the target
public static float height;
	public float h,d;
// How much we 
public float heightDamping= 2.0f;
public float rotationDamping= 3.0f;
private int lerpSpeed = 8;
private float localHeight;
	public static bool shakeStart=false;

	float elapsed = 0.0f;


	//public GameObject otherBtn;

	public CameraControl cam;
	public Vector3 spawnPoint;
	public Vector3 spawnRot;
	public GameObject[] vehicles;
	public GameObject chaseVehicle;
	public GameObject chaseVehicleDamage;
	float chaseCarSpawnTime;
	GameObject newVehicle;
	bool autoShift;
	bool assist;
	bool stuntMode;
//	public Toggle autoShiftToggle;
//	public Toggle assistToggle;
//	public Toggle stuntToggle;
//	public Text speedText;
//	public Text gearText;
//	public Slider rpmMeter;
//	public Slider boostMeter;
//	public Text propertySetterText;
//	public Text stuntText;
//	public Text scoreText;
//	public Toggle camToggle;
	VehicleParent vp;
	Motor engine;
	Transmission trans;
	GearboxTransmission gearbox;
	ContinuousTransmission varTrans;
	StuntDetect stunter;
	float stuntEndTime = -1;
	PropertyToggleSetter propertySetter;




// Place the script in the Camera-Control group in the component menu
//@script AddComponentMenu("Camera-Control/Smooth Follow")
	void Start(){
		 
//		Debug.Log("in on start");

		elapsed = 0.0f;
//		GameObject.Find("PlayerManager").GetComponent<PlayerManager>().SwitchControls();
	//	otherBtn.SetActive(true);
		cam = GetComponent<CameraControl>();
		this.setCurrentVehicles();
//		this.InitiateCar();
		Invoke ("InitiateCar",0.5f);
//		SpawnChaseVehicle();

		this.setCameraDistanceHeight();
		h = height;
		d  = distance;
//		
//		UserPrefs.currentCameraControl = 1;
//		this.SetCameraFOVForIphone();
//		this.SetCameraAngle();
//		localHeight = height;
	}


	public void SpawnChaseVehicle()
	{

		if(newVehicle)
		{
//			GameObject chaseCar1 = Instantiate(Resources.Load("Vehicles/Chase1"),new Vector3(-224.3f,-31.99f,-97.6f),Quaternion.identity) as GameObject;
//			chaseCar1.GetComponent<FollowAI>().target = newVehicle.transform;
//
//			GameObject chaseCar2 = Instantiate(Resources.Load("Vehicles/Chase1"),new Vector3(-164.6f,-31.99f,-97.6f),Quaternion.identity) as GameObject;
//			chaseCar2.GetComponent<FollowAI>().target = newVehicle.transform;
//
		//	GameObject chaseCar3 = Instantiate(Resources.Load("Vehicles/Chase3"),new Vector3(-48.2f,-10.26f,-15f),Quaternion.identity) as GameObject;
		//	chaseCar3.GetComponent<FollowAI>().target = newVehicle.transform;
		}
	}

	void Update()
	{
		height = h;
		distance = d;
	} 
	

	void  LateUpdate (){

		// Early out if we don't have a target
		if (!target || target == null)
			return;

		// Calculate the current rotation angles
		float wantedRotationAngle= target.eulerAngles.y;
		float wantedHeight= target.position.y + height;
			
		float currentRotationAngle= transform.eulerAngles.y;
		float currentHeight= transform.position.y;
		
		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
	
		// Damp the height
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
	
		// Convert the angle into a rotation
		Quaternion currentRotation= Quaternion.Euler (0, currentRotationAngle, 0);
		
		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;
	
		// Set the height of the camera
		transform.position = new Vector3(transform.position.x,currentHeight,transform.position.z);
		
		// Always look at the target
		transform.LookAt (target);

	}

	private void SetCameraFOVForIphone(){
		#if UNITY_IPHONE
			Debug.Log("Screen Width" + Screen.width);
			if(Screen.width==960&&Screen.width==480){
				Camera.main.fieldOfView = 48;
			}
			if(Screen.width==2048||Screen.width==1024){
				Camera.main.fieldOfView = 52;
			}
		#endif
	}
	
	public  void SetCameraAngle(){
		if(UserPrefs.currentCameraControl == 1){
			this.SetMainCameraView();
		}else if(UserPrefs.currentCameraControl == 6){
			SetBottomLeftCameraView();
		}else if(UserPrefs.currentCameraControl == 4){
			SetTopLeftCameraView();
		}else if(UserPrefs.currentCameraControl == 3){
			SetTopCameraView();
		}else if(UserPrefs.currentCameraControl == 2){
			SetTopRightCameraView();
		}else if(UserPrefs.currentCameraControl == 8){
			SetBottomRightCameraView();
		
		}else if(UserPrefs.currentCameraControl == 9){
			ParkedView();
		}
		else if(UserPrefs.currentCameraControl == 5){
			SetTopFrontCameraView();
		}
		else if(UserPrefs.currentCameraControl == 7){
			SetBottomCameraView();
		}else{
			UserPrefs.currentCameraControl = 1;
		}
		
	}
	
	
	
	
	private void  SetTopCameraView (){
		SetDefaultsPosition();
		target.transform.localRotation = Quaternion.Euler(new Vector3(0,270,0));		
//		CameraRotation.x = 270 + CameraRotation.rotationFactor;
		
	}	
	private void  SetBottomCameraView (){
		SetDefaultsPosition();
		target.transform.localRotation = Quaternion.Euler(new Vector3(0,90,0));		
//		CameraRotation.x = 90 + CameraRotation.rotationFactor;
	}
	
	private void  SetTopLeftCameraView (){
		SetDefaultsPosition();
		target.transform.localRotation = Quaternion.Euler(new Vector3(0,226,0));
//		CameraRotation.x = 227 + CameraRotation.rotationFactor;
	}
	
	private void  SetTopRightCameraView (){
		SetDefaultsPosition();
		target.transform.localRotation = Quaternion.Euler(new Vector3(0,317,0));	
//		CameraRotation.x = 330 + CameraRotation.rotationFactor;
	}
	
	private void  SetBottomLeftCameraView (){
		SetDefaultsPosition();
		target.transform.localRotation = Quaternion.Euler(new Vector3(0,137,0));		
//		CameraRotation.x = 136 + CameraRotation.rotationFactor;
	}
	
	private void  SetBottomRightCameraView (){
		SetDefaultsPosition();
		target.transform.localRotation = Quaternion.Euler(new Vector3(0,47,0));
//		CameraRotation.x = 47 + CameraRotation.rotationFactor;
	}
	private void SetTopFrontCameraView()
	{
		SetDefaultsPosition();
		target.transform.localRotation = Quaternion.Euler(new Vector3(0,180,0));
//		CameraRotation.x = 180 + CameraRotation.rotationFactor;
	}

	private void  SetMainCameraView (){
		if(target == null) return;
		SetDefaultsPosition();
		target.transform.localRotation = Quaternion.Euler(new Vector3(0,0,0));	
//		CameraRotation.x = CameraRotation.rotationFactor;
	}
	private void  ParkedView (){
		SetDefaultsPosition();
		target.transform.localRotation = Quaternion.Euler(new Vector3(0,15,0));
//		CameraRotation.x = 15 + CameraRotation.rotationFactor;
	}
	
	private void SetDefaultsPosition(){
	//	distance = 20.0f;
	//	height = 3.0f;
	}
	
	public void InitiateCar(){

		var pos =  GameObject.FindGameObjectWithTag("CarPosition");
		if (UserPrefs.currentVehicle == 1) {
			//UserPrefs.accelerometerFactor = 2;
			newVehicle = Instantiate (Resources.Load ("Vehicles/QuadBikeMonster"), new Vector3(1,1,1), Quaternion.identity) as GameObject;	
			//for engine upgrade
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel-1==1)
			{
				newVehicle.GetComponentInChildren<GasMotor>().power=1.3f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().minRatio=1;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().maxRatio=1.5f;
				newVehicle.GetComponent<Rigidbody>().mass+=200;

			}
			else
				if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel-1==2)
			{
				newVehicle.GetComponentInChildren<GasMotor>().power=2f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().minRatio=1;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().maxRatio=1f;

				newVehicle.GetComponent<Rigidbody>().mass+=200;

			}
			else
				if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel-1==3)
			{
				newVehicle.GetComponentInChildren<GasMotor>().power=3f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().minRatio=0.5f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().maxRatio=1f;
				newVehicle.GetComponent<Rigidbody>().mass+=200;

			}
			//for health upgrade

			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel-1==1)
			{
				newVehicle.GetComponentInChildren<VehicleDamage>().strength+=0.12f;
				newVehicle.GetComponentInChildren<Motor>().strength+=0.12f;

			}
			else
				if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel-1==2)
			{
				newVehicle.GetComponentInChildren<VehicleDamage>().strength+=0.17f;
				newVehicle.GetComponentInChildren<Motor>().strength+=0.17f;

			}
			else
				if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel-1==3)
			{
				newVehicle.GetComponentInChildren<VehicleDamage>().strength+=0.35f;
				newVehicle.GetComponentInChildren<Motor>().strength+=0.35f;
			
			}
			//for handling and brake upgrade
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel-1==1)
			{
				Suspension [] suspen=newVehicle.GetComponentsInChildren<Suspension>();
				for(int i=0;i<suspen.Length;i++){
					suspen[i].brakeForce+=1;
					suspen[i].ebrakeForce+=1;
				}
				Wheel [] wheels= newVehicle.GetComponent<VehicleParent>().wheels;
				wheels[0].sidewaysFriction+=1;
				wheels[1].sidewaysFriction+=1;
				wheels[2].sidewaysFriction-=0.2f;
				wheels[3].sidewaysFriction-=0.2f;
				
			}
			else
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel-1==2){
				Suspension [] suspen=newVehicle.GetComponentsInChildren<Suspension>();
				for(int i=0;i<suspen.Length;i++){
					suspen[i].brakeForce+=2;
					suspen[i].ebrakeForce+=2;
				}
				Wheel [] wheels= newVehicle.GetComponent<VehicleParent>().wheels;
				wheels[0].sidewaysFriction+=1;
				wheels[1].sidewaysFriction+=1;
				wheels[2].sidewaysFriction-=0.2f;
				wheels[3].sidewaysFriction-=0.2f;
				
			}
			else
				if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel-1==3)
			{
				Suspension [] suspen=newVehicle.GetComponentsInChildren<Suspension>();
				for(int i=0;i<suspen.Length;i++){
					suspen[i].brakeForce+=3;
					suspen[i].ebrakeForce+=3;
				}
				Wheel [] wheels= newVehicle.GetComponent<VehicleParent>().wheels;
				wheels[0].sidewaysFriction+=1;
				wheels[1].sidewaysFriction+=1;
				wheels[2].sidewaysFriction-=0.2f;
				wheels[3].sidewaysFriction-=0.2f;
				
			}


		} else if (UserPrefs.currentVehicle == 2) {
			newVehicle = Instantiate (Resources.Load ("Vehicles/QuadBikeYamaha"),  new Vector3(1,1,1), Quaternion.identity) as GameObject;	
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel-1==1)
			{
				newVehicle.GetComponentInChildren<GasMotor>().power=1.3f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().minRatio=1;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().maxRatio=1.5f;
				newVehicle.GetComponent<Rigidbody>().mass+=200;
				
			}
			else
				if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel-1==2)
			{
				newVehicle.GetComponentInChildren<GasMotor>().power=2f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().minRatio=1;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().maxRatio=1f;
				newVehicle.GetComponent<Rigidbody>().mass+=200;
				
				
			}
			else
				if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel-1==3)
			{

				newVehicle.GetComponentInChildren<GasMotor>().power=3f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().minRatio=0.5f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().maxRatio=1f;
				newVehicle.GetComponent<Rigidbody>().mass+=200;
				
			}

			//for health upgrade
			
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel-1==1)
			{
				newVehicle.GetComponentInChildren<VehicleDamage>().strength+=0.15f;
				newVehicle.GetComponentInChildren<Motor>().strength+=0.15f;


			}
			else
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel-1==2){
				newVehicle.GetComponentInChildren<VehicleDamage>().strength+=0.25f;
				newVehicle.GetComponentInChildren<Motor>().strength+=0.25f;
			
				
			}
			else
				if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel-1==3)
			{
				newVehicle.GetComponentInChildren<VehicleDamage>().strength+=0.35f;
				newVehicle.GetComponentInChildren<Motor>().strength+=0.35f;

			}
			//for handling and brake upgrade
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel-1==1)
			{
				Suspension [] suspen=newVehicle.GetComponentsInChildren<Suspension>();
				for(int i=0;i<suspen.Length;i++){
					suspen[i].brakeForce+=1;
					suspen[i].ebrakeForce+=1;
				}
				Wheel [] wheels= newVehicle.GetComponent<VehicleParent>().wheels;
				wheels[0].sidewaysFriction+=1;
				wheels[1].sidewaysFriction+=1;
				wheels[2].sidewaysFriction-=0.2f;
				wheels[3].sidewaysFriction-=0.2f;
			}
			else
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel-1==2){
				Suspension [] suspen=newVehicle.GetComponentsInChildren<Suspension>();
				for(int i=0;i<suspen.Length;i++){
					suspen[i].brakeForce+=2;
					suspen[i].ebrakeForce+=2;
				}
				Wheel [] wheels= newVehicle.GetComponent<VehicleParent>().wheels;
				wheels[0].sidewaysFriction+=1;
				wheels[1].sidewaysFriction+=1;
				wheels[2].sidewaysFriction-=0.2f;
				wheels[3].sidewaysFriction-=0.2f;
				
			}
			else
				if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel-1==3)
			{
				Suspension [] suspen=newVehicle.GetComponentsInChildren<Suspension>();
				for(int i=0;i<suspen.Length;i++){
					suspen[i].brakeForce+=3;
					suspen[i].ebrakeForce+=3;
				}
				Wheel [] wheels= newVehicle.GetComponent<VehicleParent>().wheels;
				wheels[0].sidewaysFriction+=1;
				wheels[1].sidewaysFriction+=1;
				wheels[2].sidewaysFriction-=0.2f;
				wheels[3].sidewaysFriction-=0.2f;
				
			}









		} else if (UserPrefs.currentVehicle == 3) {
			newVehicle = Instantiate (Resources.Load ("Vehicles/QuadBikeRed"),  new Vector3(1,1,1), Quaternion.identity) as GameObject;
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel==1)
			{
				newVehicle.GetComponentInChildren<GasMotor>().power=1.3f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().minRatio=1;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().maxRatio=1.5f;
				newVehicle.GetComponent<Rigidbody>().mass+=200;
				
			}
			else
				if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel==2)
			{
				newVehicle.GetComponentInChildren<GasMotor>().power=2f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().minRatio=1;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().maxRatio=1f;
				newVehicle.GetComponent<Rigidbody>().mass+=200;
				
				
			}
			else
			{
				newVehicle.GetComponentInChildren<GasMotor>().power=3f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().minRatio=0.5f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().maxRatio=1f;
				newVehicle.GetComponent<Rigidbody>().mass+=200;
				
			}
			//for health upgrade
			
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel==1)
			{
				newVehicle.GetComponentInChildren<VehicleDamage>().strength+=0.15f;
				newVehicle.GetComponentInChildren<Motor>().strength+=0.15f;

			}
			else
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel==2){
				newVehicle.GetComponentInChildren<VehicleDamage>().strength+=0.2f;
				newVehicle.GetComponentInChildren<Motor>().strength+=0.2f;

				
			}
			else
				if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel==3)
			{
				newVehicle.GetComponentInChildren<VehicleDamage>().strength+=0.32f;
				newVehicle.GetComponentInChildren<Motor>().strength+=0.32f;

			}
			//for handling and brake upgrade
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel==1)
			{
				Suspension [] suspen=newVehicle.GetComponentsInChildren<Suspension>();
				for(int i=0;i<suspen.Length;i++){
					suspen[i].brakeForce+=1;
					suspen[i].ebrakeForce+=1;
				}
				Wheel [] wheels= newVehicle.GetComponent<VehicleParent>().wheels;
				wheels[0].sidewaysFriction+=1;
				wheels[1].sidewaysFriction+=1;
				wheels[2].sidewaysFriction-=0.2f;
				wheels[3].sidewaysFriction-=0.2f;
				
			}
			else
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel==2){
				Suspension [] suspen=newVehicle.GetComponentsInChildren<Suspension>();
				for(int i=0;i<suspen.Length;i++){
					suspen[i].brakeForce+=2;
					suspen[i].ebrakeForce+=2;
				}
				Wheel [] wheels= newVehicle.GetComponent<VehicleParent>().wheels;
				wheels[0].sidewaysFriction+=1;
				wheels[1].sidewaysFriction+=1;
				wheels[2].sidewaysFriction-=0.2f;
				wheels[3].sidewaysFriction-=0.2f;
				
			}
			else
				if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel==3)
			{
				Suspension [] suspen=newVehicle.GetComponentsInChildren<Suspension>();
				for(int i=0;i<suspen.Length;i++){
					suspen[i].brakeForce+=3;
					suspen[i].ebrakeForce+=3;
				}
				Wheel [] wheels= newVehicle.GetComponent<VehicleParent>().wheels;
				wheels[0].sidewaysFriction+=1;
				wheels[1].sidewaysFriction+=1;
				wheels[2].sidewaysFriction-=0.2f;
				wheels[3].sidewaysFriction-=0.2f;
				
			}




		} else if (UserPrefs.currentVehicle == 4) {
			newVehicle = Instantiate (Resources.Load ("Vehicles/QuadBikeBoss"),  new Vector3(1,1,1), Quaternion.identity) as GameObject;

			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel==1)
			{
				newVehicle.GetComponentInChildren<GasMotor>().power=1.5f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().minRatio=1;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().maxRatio=1.5f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().targetRatio=0.6f;
				newVehicle.GetComponent<Rigidbody>().mass+=200;
			}
			else
				if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel==2)
			{
				newVehicle.GetComponentInChildren<GasMotor>().power=2f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().minRatio=1;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().maxRatio=1f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().targetRatio=0.5f;
				newVehicle.GetComponent<Rigidbody>().mass+=200;
				
			}
			else
			{
				newVehicle.GetComponentInChildren<GasMotor>().power=3f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().minRatio=0.5f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().maxRatio=1f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().targetRatio=0.4f;
				newVehicle.GetComponent<Rigidbody>().mass+=200;
			}
			//for health upgrade
			
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel==1)
			{
				newVehicle.GetComponentInChildren<VehicleDamage>().strength+=0.17f;
				newVehicle.GetComponentInChildren<Motor>().strength+=0.17f;

			}
			else
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel==2){
				newVehicle.GetComponentInChildren<VehicleDamage>().strength+=0.22f;
				newVehicle.GetComponentInChildren<Motor>().strength+=0.22f;

				
			}
			else
				if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel==3)
			{
				newVehicle.GetComponentInChildren<VehicleDamage>().strength+=0.37f;
				newVehicle.GetComponentInChildren<Motor>().strength+=0.37f;
			
			}
			//for handling and brake upgrade
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel==1)
			{
				Suspension [] suspen=newVehicle.GetComponentsInChildren<Suspension>();
				for(int i=0;i<suspen.Length;i++){
					suspen[i].brakeForce+=1;
					suspen[i].ebrakeForce+=1;
				}
				Wheel [] wheels= newVehicle.GetComponent<VehicleParent>().wheels;
				wheels[0].sidewaysFriction+=1;
				wheels[1].sidewaysFriction+=1;
				wheels[2].sidewaysFriction-=0.2f;
				wheels[3].sidewaysFriction-=0.2f;
				
			}
			else
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel==2){
				Suspension [] suspen=newVehicle.GetComponentsInChildren<Suspension>();
				for(int i=0;i<suspen.Length;i++){
					suspen[i].brakeForce+=2;
					suspen[i].ebrakeForce+=2;
				}
				Wheel [] wheels= newVehicle.GetComponent<VehicleParent>().wheels;
				wheels[0].sidewaysFriction+=1;
				wheels[1].sidewaysFriction+=1;
				wheels[2].sidewaysFriction-=0.2f;
				wheels[3].sidewaysFriction-=0.2f;
				
			}
			else
				if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel==3)
			{
				Suspension [] suspen=newVehicle.GetComponentsInChildren<Suspension>();
				for(int i=0;i<suspen.Length;i++){
					suspen[i].brakeForce+=3;
					suspen[i].ebrakeForce+=3;
				}
				Wheel [] wheels= newVehicle.GetComponent<VehicleParent>().wheels;
				wheels[0].sidewaysFriction+=1;
				wheels[1].sidewaysFriction+=1;
				wheels[2].sidewaysFriction-=0.2f;
				wheels[3].sidewaysFriction-=0.2f;
				
			}




		}

		else if(UserPrefs.currentVehicle == 5) {
			newVehicle = Instantiate (Resources.Load ("Vehicles/QuadBikeNew"),    new Vector3(1,1,1), Quaternion.identity) as GameObject;
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel==1)
			{
				newVehicle.GetComponentInChildren<GasMotor>().power=1.8f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().minRatio=1;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().maxRatio=1.5f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().targetRatio=0.6f;
				newVehicle.GetComponent<Rigidbody>().mass+=200;
				
			}
			else
				if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel==2)
			{
				newVehicle.GetComponentInChildren<GasMotor>().power=2f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().minRatio=1;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().maxRatio=1f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().targetRatio=0.5f;
				newVehicle.GetComponent<Rigidbody>().mass+=200;
				
			}
			else
			{
				newVehicle.GetComponentInChildren<GasMotor>().power=3f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().minRatio=0.5f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().maxRatio=1f;
				newVehicle.GetComponentInChildren<ContinuousTransmission>().targetRatio=0.4f;
				newVehicle.GetComponent<Rigidbody>().mass+=200;
			}
			//for health upgrade
			
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel==1)
			{
				newVehicle.GetComponentInChildren<VehicleDamage>().strength+=0.2f;
				newVehicle.GetComponentInChildren<Motor>().strength+=0.2f;

			}
			else
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel==2){
				newVehicle.GetComponentInChildren<VehicleDamage>().strength+=0.3f;
				newVehicle.GetComponentInChildren<Motor>().strength+=0.3f;

				
			}
			else
				if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel==3)
			{
				newVehicle.GetComponentInChildren<VehicleDamage>().strength+=0.5f;
				newVehicle.GetComponentInChildren<Motor>().strength+=0.5f;

			}
			//for handling and brake upgrade
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel==1)
			{
				Suspension [] suspen=newVehicle.GetComponentsInChildren<Suspension>();
				for(int i=0;i<suspen.Length;i++){
					suspen[i].brakeForce+=1;
					suspen[i].ebrakeForce+=1;
				}
				Wheel [] wheels= newVehicle.GetComponent<VehicleParent>().wheels;
				wheels[0].sidewaysFriction+=1;
				wheels[1].sidewaysFriction+=1;
				wheels[2].sidewaysFriction-=0.2f;
				wheels[3].sidewaysFriction-=0.2f;

				
			}
			else
			if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel==2){
				Suspension [] suspen=newVehicle.GetComponentsInChildren<Suspension>();
				for(int i=0;i<suspen.Length;i++){
					suspen[i].brakeForce+=2;
					suspen[i].ebrakeForce+=2;
				}
				Wheel [] wheels= newVehicle.GetComponent<VehicleParent>().wheels;
				wheels[0].sidewaysFriction+=1;
				wheels[1].sidewaysFriction+=1;
				wheels[2].sidewaysFriction-=0.2f;
				wheels[3].sidewaysFriction-=0.2f;

			}
			else
				if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel==3)
			{
				Suspension [] suspen=newVehicle.GetComponentsInChildren<Suspension>();
				for(int i=0;i<suspen.Length;i++){
					suspen[i].brakeForce+=3;
					suspen[i].ebrakeForce+=3;
				}
				Wheel [] wheels= newVehicle.GetComponent<VehicleParent>().wheels;
				wheels[0].sidewaysFriction+=1;
				wheels[1].sidewaysFriction+=1;
				wheels[2].sidewaysFriction-=0.2f;
				wheels[3].sidewaysFriction-=0.2f;

			}





		}
		else if(UserPrefs.currentVehicle == 6){
			newVehicle = Instantiate (Resources.Load ("Vehicles/MustangNew"),   new Vector3(1,1,1), Quaternion.identity) as GameObject;

		}
			//var pos =  GameObject.FindGameObjectWithTag("CarPosition");
			//newVehicle.gameObject.transform.position = pos.transform.position;
			//newVehicle.gameObject.transform.rotation = pos.transform.rotation;
//			cam.target = newVehicle.transform;
//			cam.Initialize();
//			vp = newVehicle.GetComponent<VehicleParent>();
//			autoShift=true;
//			
//			trans = newVehicle.GetComponentInChildren<Transmission>();
//			if (trans)
//			{
//				trans.automatic = autoShift;
//				newVehicle.GetComponent<VehicleParent>().brakeIsReverse = autoShift;
//				
//				if (trans is GearboxTransmission)
//				{
//					gearbox = trans as GearboxTransmission;
//				}
//				else if (trans is ContinuousTransmission)
//				{
//					varTrans = trans as ContinuousTransmission;
//					
//					if (!autoShift)
//					{
//						vp.brakeIsReverse = true;
//					}
//				}
//			}
//			assist=true;
//			if (newVehicle.GetComponent<VehicleAssist>())
//			{
//				newVehicle.GetComponent<VehicleAssist>().enabled = assist;
//			}
//			
//			if (newVehicle.GetComponent<FlipControl>() && newVehicle.GetComponent<StuntDetect>())
//			{
//				newVehicle.GetComponent<FlipControl>().flipPower = stuntMode && assist ? new Vector3(10, 10, -10) : Vector3.zero;
//				newVehicle.GetComponent<FlipControl>().rotationCorrection = stuntMode ? Vector3.zero : (assist ? new Vector3(5, 1, 10) : Vector3.zero);
//				newVehicle.GetComponent<FlipControl>().stopFlip = assist;
//				stunter = newVehicle.GetComponent<StuntDetect>();
//			}
//			
//			engine = newVehicle.GetComponentInChildren<Motor>();
//			propertySetter = newVehicle.GetComponent<PropertyToggleSetter>();
//			
//			//			stuntText.gameObject.SetActive(stuntMode);
//			//			scoreText.gameObject.SetActive(stuntMode);
//
//
//
//		Debug.Log("in InitiateCar");
////		if(UserPrefs.currentEpisode==1 && UserPrefs.currentLevel==1 && !UserPrefs.isTutorialSeen)
////		{
////			target=GameObject.FindGameObjectWithTag("Thief").transform;
////		
////		}else
////		{
////			target=GameObject.Find("EmptyBody").transform;
////		}
		/// 
		/// 
		target = GameObject.Find ("COM").transform;
		Constants.playerMass = newVehicle.GetComponent<Rigidbody> ().mass;
		if(UserPrefs.currentEpisode==1)
		Constants.playerMass -= 600;
		else
			Constants.playerMass -= 800;
		StartCoroutine (setDamage());
		SpawnChaseVehicle();
	}
	public GameObject player()
	{

		return newVehicle;

	}
	private void SetRealCamera()
	{
		target=GameObject.Find("EmptyBody").transform;
		GameObject.FindGameObjectWithTag("Thief").gameObject.transform.eulerAngles=new Vector3(0,43.41f,0);
		Invoke("InitializeTutorial",3);
		Invoke("DestroyTutorial",8);
	}
	private void InitializeTutorial()
	{
		Instantiate(Resources.Load("SubMenusNew/Tutorial02"));
	}
	private void DestroyTutorial()
	{
		Destroy(GameObject.FindGameObjectWithTag("Tutorial02"));
	}
	private void setCurrentVehicles(){
		if(!isNewMenu()){
			if(UserPrefs.currentEpisode == 1){
				UserPrefs.currentVehicle = 1;		
			}else if(UserPrefs.currentEpisode == 2){
				UserPrefs.currentVehicle = 2;
			}else if(UserPrefs.currentEpisode == 3){
				UserPrefs.currentVehicle = 3;
			}	
		}
	}

	private void setCameraDistanceHeight(){
		if(UserPrefs.currentVehicle == 1){
		
//			distance = 7.5f;
//			height = 4.5f;
			distance = 8.65f;
			height = 1.58f;
			CameraControlPPnew.distance=distance;
			CameraControlPPnew.height=height;
			CameraControlPP.distance=distance;
			CameraControlPP.height=height;
		} else if(UserPrefs.currentVehicle == 2){
			distance = 7.3f;
			height = 1.88f;
			CameraControlPPnew.distance=distance;
			CameraControlPPnew.height=height;
			CameraControlPP.distance=distance;
			CameraControlPP.height=height;
		} else if(UserPrefs.currentVehicle == 3){
		
			distance = 8.65f;
			height = 1.58f;
			CameraControlPPnew.distance=distance;
			CameraControlPPnew.height=height;
			CameraControlPP.distance=distance;
			CameraControlPP.height=height;
		}	
		else if(UserPrefs.currentVehicle == 4){
			
			distance = 9.03f;
			height = 2.95f;
			CameraControlPPnew.distance=distance;
			CameraControlPPnew.height=height;
			CameraControlPP.distance=distance;
			CameraControlPP.height=height;
		}		
		else if(UserPrefs.currentVehicle == 5){
			
			distance = 10f;
			height = 3.7f;
			CameraControlPPnew.distance=distance;
			CameraControlPPnew.height=height;
			CameraControlPP.distance=distance;
			CameraControlPP.height=height;
		}		
		else if(UserPrefs.currentVehicle == 6){
			
			distance = 9.4f;
			height = 3.2f;
			CameraControlPPnew.distance=distance;
			CameraControlPPnew.height=height;
			CameraControlPP.distance=distance;
			CameraControlPP.height=height;
		}		
		else if(UserPrefs.currentVehicle == 7){
			
			distance = 9.4f;
			height = 3.2f;
			CameraControlPPnew.distance=distance;
			CameraControlPPnew.height=height;
			CameraControlPP.distance=distance;
			CameraControlPP.height=height;
		}		
	}
	
public bool isNewMenu()
	{
		if(GameObject.Find("MenuManager").GetComponent<MenuManager>().menuType==2)
		{
			return true;
		}
		return false;
	}
	IEnumerator setDamage()
	{
		yield return new WaitForSeconds (1.5f);
		if(Constants.levelType[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1] == 3)
		{
//			var car = GameObject.FindGameObjectWithTag("Player2").GetComponent<CarDamage>();
//			car.minForce = 1.5f;
//			car.deformRadius = 0.5f;
		}
	}
	public static void StartShake()
	{
//		originalPos = target.gameObject.transform.localPosition;
//		shakeStart=true;

	}

//	static	IEnumerator Shake(float waitTime) {
//		yield return new WaitForSeconds(1f);
//			
//
//	
////		target.gameObject.transform.localPosition.y=0;
////		Camera.main.transform.position = originalCamPos;
//	}

}