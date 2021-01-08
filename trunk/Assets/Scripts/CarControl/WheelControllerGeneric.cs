 using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class WheelControllerGeneric : MonoBehaviour {

//	public GameObject glowLight1, glowLight2;
//	public Texture brakeLights ;
//	public Texture pakingLights;
//	private Texture lights;
//	public Material brakeMaterial;
//	public static bool roofCollided=false;
//	
//	public Transform vehicleTyres;
//	public Transform vehicleTyresColliders;
//	public Transform steerLeftTyreCollider;
//	public Transform steerLeftTyre;
//	public Transform steerRightTyreCollider;
//	public Transform steerRightTyre;
//	
////	public WheelCollider[] wheelColliders;
//	public WheelCollider[] workingWheelColliders;
//	public WheelCollider[] nonWorkingWheelColliders;
////	public Transform[] wheelsTransform;
//	public Transform[] workingWheelsTransform;
//	public Transform[] nonWorkingWheelsTransform;
//	
//	public Texture yellowLight;
//	 public Texture redLight;
//	 public Texture greenLight;
//	public static bool isThiefOnBoard = false;
//	public static bool isDummyState = false;
//	GameObject thief,police;
////	public WheelCollider WCWheelRL;
////	public WheelCollider WCWheelRR;
////	public WheelCollider WCWheelFL;
////	public WheelCollider WCWheelFR;
////	public WheelCollider WCWheelML;
////	public WheelCollider WCWheelMR;
////	
////	public Transform wheelFL;
////	public Transform wheelFR;
////	public Transform wheelRL;
////	public Transform wheelRR;
////	public Transform wheelML;
////	public Transform wheelMR;
//	
//	private float steer_max = 30;
//	private int STEER_Constant = 30;
//	private float motor_max= 12; 
//	private int brake_max = 80;
//	private bool levelFailLaps = false;
//	int steerSpeed = 30; 
//	 
//	private int steer = 0;
//	public  int forward = 0;
//	public  int back= 0;
//	private bool  brakeRelease= false;
//	private int motor = 0;
//	private int brake = 0;
//	private float speed= 0;
//	private float blinkingTime= 0;
//	private bool parkingLightStatus= false;
//	public static bool isLevelFinished = false;
//	
//	//for Parking indicator
//	bool isParkingLotIndicator = false;
//	Vector3 preCarPostion ;
//	private GameObject emptyBody;
//	public static bool isLevelFailOrComplete = false; // false means level fail
//
//	public static bool CopinPosition=false;
//
//	private  float numberOfThiefHits = 0;
//	float currentDamage = 0;
//	private GameObject thiefCar;
//	GameObject mainCamera;
//	GameObject thiefCamera;
//	private float timer;
//	float missionCompleteTime = 0;
//	public static float relativeVelocityMagnitude;
////	IRDSLevelLoadVariables loadedStettings;
//	int carsDestroyed = 0;
//	public GameObject _mAudio;
//	void Awake ()
//	{
////		GameManager.Instance.ChangeState(GameManager.GameState.GAMEPLAY);
//		if(UserPrefs.isSound)
//			_mAudio.SetActive(true);
//		else
//			_mAudio.SetActive(false);
//	}
//	
//	void  Start (){
//		isThiefOnBoard = false;
//		isDummyState = false;
//		//thiefCamera = GameObject.FindGameObjectWithTag("ThiefCamera");
//		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
//		//thiefCamera.camera.enabled = false;
//		timer = Time.time;
////		loadedStettings = GameObject.FindObjectOfType(typeof(IRDSLevelLoadVariables)) as IRDSLevelLoadVariables;
//		//loadedStettings.laps = 1;
////		GameObject.Find("Main_Camera").GetComponent<Camera>().enabled=false;
////		IRDSStatistics.SetCanRace (true); //true
//		numberOfThiefHits = 0;
//		isLevelFinished=false;
//		isLevelFailOrComplete=false;
//		roofCollided=false;
//		Time.timeScale = 1;
////		InitializeVehicleTyresAndColliders();
////		UserPrefs.totalParkingLot = Constants.totalParkingLot[UserPrefs.currentEpisode-1 ,UserPrefs.currentLevel-1];
////		steer = 0;
////		forward = 0;
////		back = 0;
////		motor = 0;
////		brake = 0;
////		isParkingLotIndicator = false;
////		rigidbody.centerOfMass = new Vector3 (0, 0, 0);
////		isLevelFinished = false;
//		//thiefCar = GameObject.FindGameObjectWithTag("Player");
//		emptyBody = GameObject.Find("EmptyBody");
////		lights=brakeMaterial.mainTexture;
////		this.BusSpeed();
////		if(GameObject.FindGameObjectWithTag("Thief")==null)
////			GameObject.FindGameObjectWithTag("Indicator").gameObject.SetActive(false);
//	}
//
//	 void Update(){
//	
//		if(GameManager.Instance.GetCurrentGameState()== GameManager.GameState.GAMEPLAY)
//		{ 
//			if(UserPrefs.isSound)
//				_mAudio.SetActive(true);
//			else
//				_mAudio.SetActive(false);
//		}
//		else if(GameManager.Instance.GetCurrentGameState() != GameManager.GameState.GAMEPLAY)
//		{ 
//			_mAudio.SetActive(false);
//		}
//		if(isDummyState)
//		{
////			Debug.LogError(GameManager.Instance.GetCurrentGameState());
////			CarMain.handBrakValue = 50;
////			CarMain.SendInput(this.GetComponent<CarControl>(),false,false);
//			//this.RemovePhysics();
//		}
//		if(GameManager.Instance.GetCurrentGameState()== GameManager.GameState.DISABLEHUD)
//		{
//			if(UserPrefs.rpmValue < 10){
//				GameManager.Instance.ChangeState(GameManager.GameState.CRASHED);
//			}
//		}
//		if(GameManager.Instance.GetCurrentGameState()== GameManager.GameState.TIMEOVER)
//		{
//			this.RemovePhysics();
//		}
//
//		if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.CAMERAROTATION)
//		{
////			if(isLevelFinished)
////				this.RemovePhysics();
//
//		//	emptyBody.transform.Rotate(Vector3.down * Time.deltaTime * 50);
//			//CarMain.SendInput()
//			if(missionCompleteTime == 0){
//				missionCompleteTime = Time.time;
//			}
//			if(Time.time >= missionCompleteTime + 5){
//				if(!isLevelFailOrComplete)
//				{
//					//Debug.LogError("Crashed");
//					GameManager.Instance.ChangeState(GameManager.SoundState.LEVELFAILSOUND ,GameManager.GameState.CRASHED);		
//				}
//				else
//				{
//					GameManager.Instance.ChangeState(GameManager.SoundState.LEVELSUCCESSSOUND ,GameManager.GameState.LEVELCOMPLETE);
//				}
//			}
//			if(Input.GetMouseButtonDown(0))
//			{
//				if(!isLevelFailOrComplete)
//				{
//					//Debug.LogError("Crashed");
//					GameManager.Instance.ChangeState(GameManager.SoundState.LEVELFAILSOUND ,GameManager.GameState.CRASHED);		
//				}
//				else
//				{
//					GameManager.Instance.ChangeState(GameManager.SoundState.LEVELSUCCESSSOUND ,GameManager.GameState.LEVELCOMPLETE);
//				}
//			}
//		}
//		if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.PARKED)
//		{
////			ActivateParkinglights();
//		}
//	
//	}
// 
//	void  FixedUpdate (){
//
////		if(GameObject.FindGameObjectWithTag("Player").GetComponent<IRDSCarControllerAI>().GetEndRace())
////		{
////			this.LevelFailed();
////		}
//		if(SteerNew.brakeDown)
//		{	
//
//			glowLight1.SetActive(true);
//			glowLight2.SetActive(true);
//			
//		}
//		else
//		{
//			glowLight1.SetActive(false);
//			glowLight2.SetActive(false);
//		}
//		if(GameManager.Instance.GetCurrentGameState()== GameManager.GameState.GAMEPLAY && this.gameObject.transform.localPosition.y>15)
//		{
//
//			gameObject.GetComponent<Rigidbody>().velocity = Vector3.Lerp(gameObject.GetComponent<Rigidbody>().velocity, Vector3.down * (transform.position.y - 15), Time.deltaTime * 1f);
//
////			this.rigidbody.AddForce(Vector3.down*100);
//		}
//
////		Debug.LogError(GameObject.FindGameObjectWithTag("Player").GetComponent<IRDSCarControllerAI>().GetLap());
//		//Debug.LogError(UserPrefs.currentEpisode-1);
////		if(UserPrefs.isTutorialFinished){
////		if(!levelFailLaps && GameObject.FindGameObjectWithTag("Player").GetComponent<IRDSCarControllerAI>().GetLap() > Constants.totalLaps[UserPrefs.currentEpisode-1 , UserPrefs.currentLevel-1])
////		{
////				GameObject.Find("HudMenuNew").SetActive(false);
////				CarMain.accellPressedValue=0f;
////				CarMain.revValue=0f;
////				CarMain.brakeValue=1;
////				CarMain.SendInput(this.GetComponent<CarControl>(),false,false);
////				GameManager.Instance.ChangeState(GameManager.SoundState.MUTESOUND);
////				UserPrefs.crashCause = 1;
////				this.LevelFailed();
////				levelFailLaps = true;
////		}
////		}
//
////	Debug.Log("-------------------------"+UserPrefs.currentLevel+"----"+UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]);
////		if(GameManager.Instance.GetCurrentGameState()== GameManager.GameState.GAMEPLAY)
////		{
////			if(rigidbody.isKinematic){
////				this.AddPhysics();
////			}
////			else if(HudMenuListenerNew.forward)
////			{
////				
////				forward = 1;
////				back = 0;
////			
////			}
////			else if(HudMenuListenerNew.back)
////			{
////				forward = 0;
////				back = 1;
////				
////			}
////			else if(!HudMenuListenerNew.back && !HudMenuListenerNew.forward)
////			{
////				forward = 0;
////				back = 0;
////
////			}
////		
////			//for steering
////			if(UserPrefs.accelerometerFactor == 0){
////				steer_max =	(Steer.timer * STEER_Constant ) / Steer.maxMovementTimer ;
////				
////			}
////			//for Arrows
////			else{
////				steer_max = 30;
////			}
////			if(isNewMenu())
////			{
////				setSteerMax();
////				
////			}
////			if(steer_max < 0)
////			steer_max = steer_max * -1;
////			
////		 
////			speed = rigidbody.velocity.sqrMagnitude;
////			
////	
////			//for Accelerometer
////			if(UserPrefs.accelerometerFactor==1)
////			{
////				steer_max = (Steer.maxMovementTimer/1.2f * Mathf.Clamp(Input.acceleration.x,-0.7f,0.7f)) * STEER_Constant;
////				
////				if(Input.acceleration.x < -0.001f || Input.acceleration.x > 0.001f)
////				{
////					if(Input.acceleration.x < 0)
////					{
////						steer = -1;
////					}
////					else if(Input.acceleration.x > 0)
////					{
////						steer = 1;
////					}
////				}
////				else
////				{
////					steer = 0;
////				}	
////			}
////			//for Left right Arrow
////			else if(UserPrefs.accelerometerFactor==2){
////			
////				if(HudMenuListenerNew.move != 0)
////				{
////					if(HudMenuListenerNew.move < 0)
////					{
////						steer = -1;
////					}
////					else if(HudMenuListenerNew.move > 0)
////					{
////						steer = 1;
////					}
////				}
////				else
////				{
////					steer = 0;
////				}
////			}
////			//for Steering
////			else{
////				if(Steer.timer != 0)
////				{
////					if(Steer.timer < 0)
////					{
////						steer = -1;
////					}
////					else if(Steer.timer > 0)
////					{
////						steer = 1;
////					}
////				}
////				else
////				{
////					steer = 0;
////				}
////			}	
////		 
////			if(speed == 0 && forward == 0 && back == 0) 
////			{
////				brakeRelease = true;
////			}
////			 
////			if(speed == 0 && brakeRelease)
////			{
////			}
//			if(HudMenuListenerNew.isBreakPressed)
//			{	
//				brakeMaterial.mainTexture =brakeLights; 
////				brake = 1;
//			}
//			else
//			{
////				brakeMaterial.mainTexture =lights; 
//			}
////			 	if(HudMenuListenerNew.reverse)
////				{
////					
////					motor = -1 * back;
////					brake = forward;
////				}
////				else
////				{
////				//	brakeLights.renderer.enabled = false;
////					motor = forward;
////					brake = back;
////				}
////				if (brake > 0 ) 
////				{ 
////					brakeRelease = false; 
////				}
////			}
////		 
////			
////			ApplyMotorTorqueOnTyres();
////			ApplyBrakeTorqueOnTyres();
////
////			ApplySteeringControl();
////	
////			RotateWheels();
////		}
////		else{
////			if(!rigidbody.isKinematic){
////				Invoke("RemovePhysics",1);
////			}
////		}
////		
////			
//	}
//	
////	}
//
//	void ParkingComplete(Collider collisionInfo){
//		if(!isThiefOnBoard)
//		{
//			isDummyState = true;
//			if(!UserPrefs.isTutorial)
//				TutorialManager.Instance.ChangeState(TutorialManager.TutorialStates.PICKTHIEF);
//			collisionInfo.gameObject.transform.parent.gameObject.tag = null;
//			collisionInfo.gameObject.transform.parent.gameObject.SetActive(false);
//			thief= GameObject.FindGameObjectWithTag("Thief");
//			police =GameObject.FindGameObjectWithTag("Finish") ;
//			GameObject.FindGameObjectWithTag("Thief").GetComponent<ArrestController>().IsToMove = true;
//			GameObject.FindGameObjectWithTag("Finish").GetComponent<ArrestController>().IsToMove = true;
//			isThiefOnBoard = true;
//			RemovePhysics();
//			
//		}
//		else{
//			if(UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 1 && !UserPrefs.isPicknDropTutorialCompleted){
//				UserPrefs.isPicknDropTutorialCompleted = true;
//				GAManager.Instance.LogDesignEvent("Tutorial::DropArrestedCriminal");
//				GAManager.Instance.LogDesignEvent("Tutorial::lvlEnd");
//			}else if(UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 2 && !UserPrefs.isArrestThiefTutorialCompleted){
//				UserPrefs.isArrestThiefTutorialCompleted = true;
//			}else if(UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 3 && !UserPrefs.isSmashCarTutorialCompleted){
//				UserPrefs.isSmashCarTutorialCompleted = true;
//			}else if(UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 6 && !UserPrefs.isCollectItemTutorialCompleted){
//				UserPrefs.isCollectItemTutorialCompleted = true;
//			}
//			
//			GameObject.FindGameObjectWithTag("Arrow3D").SetActive(false);
//			collisionInfo.gameObject.transform.parent.gameObject.SetActive(false);
//			Destroy(collisionInfo.gameObject.transform.parent.gameObject);
//			isDummyState = true;
//			thief.gameObject.SetActive(true);
//			police.SetActive(true);
//			StartCoroutine(dropThief());
//			RemovePhysics();
//		} 
//	}
//
//
//	void  OnTriggerEnter (Collider collisionInfo){
//		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY){
//			if (collisionInfo.gameObject.tag == "VehicleEnter" && UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 1) {
//				ParkingComplete(collisionInfo);
//			}else if(collisionInfo.gameObject.tag == "tutorialVehicleEnter"){
//				RemovePhysics();
//				TutorialManagerNew.Instance.ChangeState(TutorialManagerNew.TutorialState.GETOUTOFCAR);
//				Destroy(collisionInfo.gameObject.transform.parent.gameObject);
//			}
//		}
//	}
//	IEnumerator dropThief()
//	{
//		yield return new WaitForSeconds (1f);
//		police.transform.position = GameObject.Find("toSpawnPosition").transform.position;
//		thief.transform.position = GameObject.Find("toSpawnPosition").transform.position;
//		thief.GetComponent<Rigidbody>().isKinematic = false;
//		thief.GetComponent<CapsuleCollider>().enabled = true;
//		police.GetComponent<ArrestController>().currentWaypoint++;
//		thief.GetComponent<ArrestController>().currentWaypoint++;
//		StartCoroutine(waitToLevelComplete());
//	}
//	IEnumerator waitToLevelComplete()
//	{
//		yield return new WaitForSeconds (1.5f);
//		LevelCompleted();
//	}
//
//	IEnumerator waitToRemovePhysics()
//	{
//		yield return new WaitForSeconds (0.4f);
//		this.RemovePhysics();
//	}
//	void  OnTriggerStay (Collider collisionInfo){
//		if(GameManager.Instance.GetCurrentGameState()!=GameManager.GameState.GAMEPLAY){
//
//		}
//		else if(collisionInfo.gameObject.tag == "VehicleEnter"){
//			float distanceDifference = 5f;
//			float distance  = Vector3.Distance(collisionInfo.gameObject.transform.position,this.gameObject.transform.position);
//
//			distance = distance / 0.6f;
//
//			UserPrefs.parkingLotLoadingValue = 1.24f-distance;
//
//				if(distance<distanceDifference){
//					float carMoved = Vector3.Distance(preCarPostion,this.gameObject.transform.position);
//					if(carMoved<.005 && SteerNew.brakeDown){								
//						collisionInfo.transform.position = new Vector3(0.0f,-1000f,0f);
//						ParkingComplete(collisionInfo);
//					}
//				}
//			preCarPostion = this.gameObject.transform.position;
//		}
//	 }
//
//	void  OnTriggerExit (Collider collisionInfo){
//		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY){
//			if (collisionInfo.gameObject.tag == "VehicleEnter") {
//
//			}
//		}
//	}
//	
//	void  OnCollisionEnter (Collision collisionInfo){
//
//
//		if((GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY && !isLevelFinished) || roofCollided==true){
////			Debug.LogError("Relative Velocity Magnitude  " + relativeVelocityMagnitude + "<<<<<<<<<<<<<<<<");
////			Debug.LogError("<<<<Police car collided with   "+collisionInfo.gameObject.transform.tag);
//
//			if(collisionInfo.gameObject.tag == "Player")
//			{
//				thiefCar = collisionInfo.gameObject;
//				relativeVelocityMagnitude = collisionInfo.relativeVelocity.magnitude;
//
//
//				if(Time.time > timer + 3f){
//					timer = Time.time;
//					float remaingHealth = collisionInfo.gameObject.GetComponent<RacerControl>().SetHealth(relativeVelocityMagnitude);
//					if(UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 3) remaingHealth = 0;
//					if(remaingHealth <= 0){
//						carsDestroyed++;
//						GameObject.FindGameObjectWithTag("ThiefArrow").SetActive(false);
//						GameObject.FindWithTag("Hud").GetComponent<RacersLabelHandler>().DecrementRemainingRacerCount();
//						var fire = Instantiate(Resources.Load("fire"),thiefCar.transform.position,Quaternion.identity) as GameObject;
//						fire.transform.parent = thiefCar.transform;
//						var fire2 = Instantiate(Resources.Load("Fire2"),thiefCar.transform.position,Quaternion.identity) as GameObject;
//						fire2.transform.parent = thiefCar.transform;
//						
//						thiefCar.GetComponent<Rigidbody>().AddForce(Vector3.up * 200000);
//						thiefCar.GetComponent<RotateGameObject>().SetDefaultValues();
//						thiefCar.GetComponent<RotateGameObject>().enabled = true;
//
//						
//						try{
//							
//							thiefCar.GetComponent<iTween>().enabled = true;
//							
//						}catch(System.Exception e){}
//						
//						thiefCar.GetComponent<CarBalance>().enabled = false;
//						
//						StartCoroutine(stopRotation());
//						if(carsDestroyed < Constants.totalCars[UserPrefs.currentEpisode - 1, UserPrefs.currentLevel - 1])
//							StartCoroutine(vehicleDestory(thiefCar));
//					}
//				}
//				if(carsDestroyed >= Constants.totalCars[UserPrefs.currentEpisode - 1, UserPrefs.currentLevel - 1]){
//
//					if(UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 1)
//					{
//						GAManager.Instance.LogDesignEvent("Tutorial::CarSmash2");
//						GAManager.Instance.LogDesignEvent("Tutorial::LvlSuccess");
//					}
//					//mainCamera.SetActive(false);
////					thiefCamera.camera.enabled = true;
////					thiefCamera.GetComponent<CameraAnimation>().enabled = true;
//
////					IRDSStatistics.SetCanRace (false); 
//					IRDSLevelEndListener.isLevelFinished = true;
//					this.LevelCompleted();
//					GameManager.Instance.ChangeState(GameManager.SoundState.EXPLODE);
//				}
//				
//
//
////				if(!UserPrefs.isTutorialFinished){
////					mainCamera.SetActive(false);
////					thiefCamera.camera.enabled = true;
////					thiefCamera.GetComponent<CameraAnimation>().enabled = true;
////					var fire = Instantiate(Resources.Load("fire"),thiefCar.transform.position,Quaternion.identity) as GameObject;
////					fire.transform.parent = thiefCar.transform;
////					var fire2 = Instantiate(Resources.Load("Fire2"),thiefCar.transform.position,Quaternion.identity) as GameObject;
////					fire2.transform.parent = thiefCar.transform;
////					thiefCar.rigidbody.AddForce(Vector3.up * 200000);
////					thiefCar.GetComponent<RotateGameObject>().SetDefaultValues();
////					thiefCar.GetComponent<RotateGameObject>().enabled = true;
////					try{
////						thiefCar.GetComponent<iTween>().enabled = true;
////					}catch(System.Exception e){}
////					thiefCar.GetComponent<CarBalance>().enabled = false;
////					StartCoroutine(stopRotation());
////					StartCoroutine(vehicleDestory());
////					this.LevelCompleted();
////					UserPrefs.isTutorialFinished = true;
////					UserPrefs.Save();
////					GameManager.Instance.ChangeState(GameManager.SoundState.EXPLODE);
////				}
////				else if(Time.time > timer +1.5f){
////					numberOfThiefHits+=1;
////					currentDamage += relativeVelocityMagnitude;
////					timer = Time.time;
//////					Debug.LogError("Number of Hitts with Thief Car   "+numberOfThiefHits);
////					var healthSprite = GameObject.Find("healthSprite");
////					healthSprite.transform.localScale = new Vector3((1 - (currentDamage / Constants.totalMagnitude[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1])) * healthSprite.transform.localScale.x,healthSprite.transform.localScale.y,1);
////					if(currentDamage / Constants.totalMagnitude[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1] > 0.5f){
////						healthSprite.GetComponent<UISprite>().color = Color.red;
////					}
////					if(numberOfThiefHits == Constants.totalHits[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1] - 1){
////						foreach(var dectector in GameObject.FindGameObjectsWithTag("ThiefDectectionCollider")){
////							dectector.collider.enabled = false;
////						}
////					}
////					//thiefCar.rigidbody.useGravity = false;
////					//if(numberOfThiefHits >= Constants.totalHits[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1])
////					if(currentDamage >= Constants.totalMagnitude[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1])
////					{
////						mainCamera.SetActive(false);
////						thiefCamera.camera.enabled = true;
////						thiefCamera.GetComponent<CameraAnimation>().enabled = true;
////						//Time.timeScale = 0.5f;
//////						Debug.LogError("Level Completed");
////						var fire = Instantiate(Resources.Load("fire"),thiefCar.transform.position,Quaternion.identity) as GameObject;
////						fire.transform.parent = thiefCar.transform;
////						var fire2 = Instantiate(Resources.Load("Fire2"),thiefCar.transform.position,Quaternion.identity) as GameObject;
////						fire2.transform.parent = thiefCar.transform;
////						thiefCar.rigidbody.AddForce(Vector3.up * 200000);
////						thiefCar.GetComponent<RotateGameObject>().SetDefaultValues();
////						thiefCar.GetComponent<RotateGameObject>().enabled = true;
////						try{
////						thiefCar.GetComponent<iTween>().enabled = true;
////						}catch(System.Exception e){}
////						thiefCar.GetComponent<CarBalance>().enabled = false;
////						StartCoroutine(stopRotation());
////						//Destroy(collisionInfo.gameObject);
////						//IRDSStatistics.SetCanRace (false);
////						StartCoroutine(vehicleDestory());
////						this.LevelCompleted();
////						GameManager.Instance.ChangeState(GameManager.SoundState.EXPLODE);
////					}
////					timer = Time.time;
////				}
//			}
//			if(collisionInfo.gameObject.tag == "ET_AI")
//			{
//				GameObject.Find("HudMenuNew").SetActive(false);
////				CarMain.accellPressedValue=0f;
////				CarMain.revValue=0f;
////				CarMain.brakeValue=1;
////				CarMain.SendInput(this.GetComponent<CarControl>(),false,false);
//				GameManager.Instance.ChangeState(GameManager.SoundState.MUTESOUND);
//				UserPrefs.crashCause = 3;
//				LevelFailed();
//			}
////			if(collisionInfo.gameObject.tag!= "Pillar")
////			{
////			//	if((collisionInfo.gameObject.tag!= "MainBase" && collisionInfo.gameObject.tag!= "Wait") || collisionInfo.contacts[0].thisCollider.name=="Truck Body"){
////				if((collisionInfo.gameObject.tag!= "MainBase" && collisionInfo.gameObject.tag!= "Wait")){
////					roofCollided=true;
////					// if(collisionInfo.gameObject.transform.parent.name=="Terrorist"||collisionInfo.gameObject.transform.parent.name=="Civilian"||collisionInfo.gameObject.transform.parent.name=="Passenger")
////					//{
////					//	UserPrefs.PersonKilled=true;
////					//}
////
////					GameManager.Instance.ChangeState(GameManager.SoundState.VEHICLECRASHSOUND ,GameManager.GameState.CAMERAROTATION);
////					
////
////					isLevelFailOrComplete = false;
////					isLevelFinished = true;
////					StartCoroutine(LevelFail());
////				}
////
////			}
//
//
//		}
//	}
//
//	IEnumerator vehicleDestory(GameObject objToDestroy)
//	{
//		yield return new WaitForSeconds(3f);
////		objToDestroy.GetComponent<IRDSCarControllerAI>().SetEndRace(false);
////		IRDSStatistics.SetCanRace (false);
//////		mainCamera.SetActive(false);
//////		thiefCamera.SetActive(true);
////		yield return new WaitForSeconds(1.7f);
//		Destroy(objToDestroy);
//		//thiefCamera.SetActive(false);
//		//mainCamera.SetActive(true);
//		
//	}
//	
//	IEnumerator LevelFail()
//	{
//		yield return new WaitForSeconds(1);
//		
////		RemovePhysics();
//		
//	}
//	public void LevelFailed(){
//
//			roofCollided=true;
//			// if(collisionInfo.gameObject.transform.parent.name=="Terrorist"||collisionInfo.gameObject.transform.parent.name=="Civilian"||collisionInfo.gameObject.transform.parent.name=="Passenger")
//			//{
//			//	UserPrefs.PersonKilled=true;
//			//}
//			isLevelFailOrComplete = false;
//			isLevelFinished = true;
//			GameManager.Instance.ChangeState(GameManager.SoundState.LEVELFAILSOUND ,GameManager.GameState.DISABLEHUD);	
//			
//			
//			
//			StartCoroutine(LevelFail());
//	}
//	public void LevelCompleted()
//	{
////		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY && !isLevelFinished)
////		{
//		GAManager.Instance.LogDesignEvent("LevelSuccess::Episode"+UserPrefs.currentEpisode+"::Level"+UserPrefs.currentLevel);		
//		isLevelFailOrComplete = true;
//				isLevelFinished = true;
//				GameManager.Instance.ChangeState(GameManager.SoundState.APPLAUSESOUND ,GameManager.GameState.CAMERAROTATION);
////		GameManager.Instance.AddCoins(ConstantsNew.Coins_Level_Success);
//				RemovePhysics();
//		if(UserPrefs.isTutorialFinished){
//				UserPrefs.vehiclesParked = UserPrefs.vehiclesParked + 1;
//			UserPrefs.currentLevel++;
//				if(isNewMenu())
//			{
//				if(UserPrefs.currentLevel > Constants.levelsPerEpisode )
//				{
//					
////					UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]=1;
//					UserPrefs.episodeCompletedArray[UserPrefs.currentEpisode-1] = true;
//				}
//				else
//				{
//					if(UserPrefs.currentLevel - 1 == UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode - 1])
//						UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]++;
//				}
//
//			}
//			else
//			{
//				GameManager.Instance.AddCoins(Constants.LEVELCOMPLETEREWARD);
//			}
//			
//		}
//			
////		}
//		
//	}
//	
////	private void CompleteLevel()
////	{
////		StartCoroutine(Complete());
////	}
////	void CompleteLevel()
////	{
////		
////		
////		UserPrefs.currentCameraControl = 1;
////		Camera.main.GetComponent<SmoothFollow>().SetCameraAngle();
////		UserPrefs.totalParkingLot = UserPrefs.totalParkingLot - 1 ;
////		this.ResetParkingIndicatorValues();
////		UserPrefs.vehiclesParked = UserPrefs.vehiclesParked + 1;
////	}
////	private void ThiefCaptured()
////	{
////		isLevelFailOrComplete = true;
////		isLevelFinished = true;
////		UserPrefs.currentCameraControl = 1;
////		
////		Camera.main.GetComponent<SmoothFollow>().SetCameraAngle();
////		if(isNewMenu())
////		{
////			if(UserPrefs.currentLevel+1 > Constants.levelsPerEpisode )
////			{
////				UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]=1;
////				UserPrefs.episodeCompletedArray[UserPrefs.currentEpisode-1] = true;
////			}
////			else
////			{
////				UserPrefs.unlockLevelsArrays[UserPrefs.currentEpisode-1]++;
////			}
////			GameManager.Instance.AddCoins(ConstantsNew.Coins_Level_Success);
////		}
////		else
////		{
////			GameManager.Instance.AddCoins(Constants.LEVELCOMPLETEREWARD);
////		}
////		UserPrefs.Save();
////	}
//	
//
////	private void AddParkingIndicator(){
////		if(!isParkingLotIndicator && !isLevelFinished){
////			preCarPostion = this.gameObject.transform.position;
////			Instantiate(Resources.Load("SubMenus/ParkStatus"));
////			isParkingLotIndicator = true;
////			UserPrefs.parkingLotLoadingValue = 0;
////		}
////	}
////	
////	private void ResetParkingIndicatorValues(){
////		if(isParkingLotIndicator){
////			Destroy ( GameObject.FindGameObjectWithTag ("ParkStatus")) ;
////			isParkingLotIndicator = false;
////		}
////		UserPrefs.parkingLotLoadingValue = 0;
////	}
//	public void RemovePhysics(){
//		if(!GetComponent<Rigidbody>().isKinematic)
//		{
//			GetComponent<Rigidbody>().isKinematic = true;
//		}
//	}
//	public void AddPhysics(){
//		if(GetComponent<Rigidbody>().isKinematic)
//		{
//			GetComponent<Rigidbody>().isKinematic = false;
//		}
//	}
//	
////	private void BusSpeed(){
////		
////		switch (UserPrefs.currentVehicle){
////			
////			case 1: 
////				brake_max = 200;
////				motor_max= 10;			 	
////				break;
////			case 2: 
////				brake_max = 80;
////				motor_max= 20;			 	
////				break;
////			case 3: 
////			 	brake_max = 80;
////				motor_max= 8;
////				break;
////			
////			default :
////				brake_max = 80;
////				motor_max= 20;
////				break;
////				
////			
////			
////		}
////		
////		
////		if(isNewMenu())
////		{
////			SetCarSpeed();
////			SetCarBrakes();
////
////		}
////		
////	}
//	
////	void ActivateParkinglights()
////	{
////		if(Time.time>blinkingTime && !parkingLightStatus)
////		{
////				brakeMaterial.mainTexture =pakingLights; 
////				blinkingTime=Time.time+1;
////				parkingLightStatus=true;
////		}
////		else if(Time.time>blinkingTime && parkingLightStatus)
////		{
////			brakeMaterial.mainTexture =lights; 
////			blinkingTime=Time.time+1;
////			parkingLightStatus=false;
////		}
////		
////	}
////	private void InitializeVehicleTyresAndColliders()
////	{
////		int i = 0;
////		foreach(Transform tyre in vehicleTyres)
////		{
////			if(tyre.gameObject.name=="WorkingTyres")
////			{
////				workingWheelsTransform = new Transform[tyre.childCount];
////				
////				foreach(Transform workingTyre in tyre)
////				{
////					workingWheelsTransform[i++]=workingTyre;
////				}
////			}
////			else{
////				
////				nonWorkingWheelsTransform = new Transform[tyre.childCount];
////				
////				foreach(Transform nonWorkingTyre in tyre)
////				{
////					nonWorkingWheelsTransform[i++]=nonWorkingTyre;
////				}
////			}
////			i = 0;
////		}
////		
////		i = 0;
////		
////		foreach(Transform wheelCollider in vehicleTyresColliders)
////		{
////			if(wheelCollider.gameObject.name=="WorkingColliders")
////			{
////				workingWheelColliders = new WheelCollider[wheelCollider.childCount];
////				foreach(Transform workingCollider in wheelCollider)
////				{
////					workingWheelColliders[i++]=workingCollider.gameObject.GetComponent<WheelCollider>();
////				}
////			}
////			else{
////				nonWorkingWheelColliders = new WheelCollider[wheelCollider.childCount];
////				foreach(Transform nonWorkingCollider in wheelCollider)
////				{
////					nonWorkingWheelColliders[i++]=nonWorkingCollider.gameObject.GetComponent<WheelCollider>();
////				}
////			}
////			i = 0;
////		}
////	}
////	
//	
//	
////	public void ApplyMotorTorqueOnTyres()
////	{
////		foreach(WheelCollider workingTyre in workingWheelColliders)
////		{
////			
////					workingTyre.motorTorque = motor_max * motor;
////
////		}
////	}
//	
//	
////	public void ApplyBrakeTorqueOnTyres()
////	{
////		foreach(WheelCollider workingTyre in workingWheelColliders)
////		{
////
////					workingTyre.brakeTorque = brake_max * brake;
////		}
////	}
//	
////	public void RotateWheels()
////	{
////		
////		foreach(Transform workingWheels in workingWheelsTransform)
////		{
////			workingWheels.Rotate(workingWheelColliders[0].rpm * 6 * Time.deltaTime, 0, 0);
////		//	Debug.Log("workingWheelColliders[0].rpm"+workingWheelColliders[0].rpm);
////		}
////		
////		foreach(Transform nonWorkingWheels in nonWorkingWheelsTransform)
////		{
////			nonWorkingWheels.Rotate(nonWorkingWheelColliders[0].rpm * 6 * Time.deltaTime, 0, 0);
////		}
////		UserPrefs.rpmValue = workingWheelColliders[0].rpm * 6 * Time.deltaTime;
////		
////	}
////	
//	
////	public void ApplySteeringControl()
////	{
////		WheelCollider leftWheelCollider = steerLeftTyreCollider.GetComponent<WheelCollider>();
////		WheelCollider rightWheelCollider = steerRightTyreCollider.GetComponent<WheelCollider>();
////		Transform stLeftTyre=steerLeftTyre.GetComponent<Transform>();
////		Transform stRightTyre=steerRightTyre.GetComponent<Transform>();
////		if ( steer == 0 && leftWheelCollider.steerAngle != 0) 
////			{
////				if (Mathf.Abs(leftWheelCollider.steerAngle) <= (steerSpeed * Time.deltaTime)) 
////				{
////					leftWheelCollider.steerAngle = 0;
////				} 
////				else if (leftWheelCollider.steerAngle > 0) 
////				{
////					leftWheelCollider.steerAngle = leftWheelCollider.steerAngle - (steerSpeed * Time.deltaTime);
////				} 
////				else
////				{
////					leftWheelCollider.steerAngle = leftWheelCollider.steerAngle + (steerSpeed * Time.deltaTime);
////				}
////			} 
////			else 
////			{
////				leftWheelCollider.steerAngle = leftWheelCollider.steerAngle + (steer * steerSpeed * Time.deltaTime);
////				
////				if (leftWheelCollider.steerAngle > steer_max) 
////				{ 
////					leftWheelCollider.steerAngle = steer_max; 
////				}
////				if (leftWheelCollider.steerAngle < -1 * steer_max) 
////				{ 
////					leftWheelCollider.steerAngle = -1 * steer_max; 
////				}
////			}
////			
////			rightWheelCollider.steerAngle = leftWheelCollider.steerAngle;
////			stLeftTyre.localEulerAngles = new Vector3 (stLeftTyre.localEulerAngles.x,leftWheelCollider.steerAngle,stLeftTyre.localEulerAngles.z);//WCWheelFL.steerAngle;
////			stRightTyre.localEulerAngles = new Vector3 (stRightTyre.localEulerAngles.x,rightWheelCollider.steerAngle,stRightTyre.localEulerAngles.z);//WCWheelFR.steerAngle;	 
////	}
////	
//	public bool isNewMenu()
//	{
//		if(GameObject.Find("MenuManager").GetComponent<MenuManager>().menuType==2)
//		{
//			return true;
//		}
//		return false;
//	}
//	
////	public bool isFuelUpgrade()
////	{
////		if(GameObject.Find("MenuManager").GetComponent<MenuManager>().additionalUpgradeSelection.Equals("Fuel",System.StringComparison.InvariantCultureIgnoreCase))
////		{
////			// upgrade fuel here
////			return true;
////		}
////		return false;
////	}
//	
//	
////	void setSteerMax()
////	{
////		int currentSteeringUpgradeLevel = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel;
////				
////		
////		if(currentSteeringUpgradeLevel==1)
////		{
////			steer_max=6;
////		}
////		else{
////			steer_max=6+(ConstantsNew.STEERING_UPGRADE_FACTOR*(currentSteeringUpgradeLevel-1));
////		}
////		if(HudMenuListenerNew.stteringBtnPressedTime>0)
////		{
////		//	Debug.LogError("aslkdj laksdj laksdj alksd jalksdj alkjsd  laksjd lkajsd lakjsd lakjsd stteringBtnPressedTime="+HudMenuListenerNew.stteringBtnPressedTime);
////			if(HudMenuListenerNew.stteringBtnPressedTime>15 && steer_max < 24)
////			{
////				steer_max+=(HudMenuListenerNew.stteringBtnPressedTime/10)*currentSteeringUpgradeLevel;
////				if(steer_max>24)
////				{
////					steer_max=24;
////				}
////				//Debug.LogError("aslkdj laksdj laksdj alksd jalksdj alkjsd  laksjd lkajsd lakjsd lakjsd steer max="+steer_max);
////			
////			}
////		
////		}
////		
////		
////	}
//	
////	void SetCarSpeed()
////	{
////	
////		int currentEngineUpgradeLvl = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel;
////		if(currentEngineUpgradeLvl==1)
////		{
////			motor_max=25;
////		}
////		else
////		{
////			motor_max=25+(ConstantsNew.ENGINE_UPGRADE_FACTOR*(currentEngineUpgradeLvl-1));
////		}
////
////	}
////	
////	void SetCarBrakes()
////	{
////		int currentBrakeUpgradeLvl = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel;
////					
////	
////		if(currentBrakeUpgradeLvl==1)
////		{
////			brake_max=12;
////		}
////		else
////		{
////			brake_max=12+(ConstantsNew.BRAKE_UPGRADE_FACTOR*(currentBrakeUpgradeLvl-1));
////		}
////
////		
////	}
////	 private void calculateDistance (){
////		
////				if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.GAMEPLAY){
////					if (GameObject.FindGameObjectWithTag("Thief")!=null && GameObject.FindGameObjectWithTag("Player")!=null){				  	
////						float distance = Vector3.Distance(GameObject.FindGameObjectWithTag("Thief").transform.position,GameObject.FindGameObjectWithTag("Player").transform.position);
////						if (GameObject.FindGameObjectWithTag("Indicator")!=null){
////							UITexture indicator  = GameObject.FindGameObjectWithTag("Indicator").GetComponentInChildren<UITexture>();
////							//Showint Distance
////						GameObject.FindGameObjectWithTag("Indicator").GetComponentInChildren<UILabel>().text=""+Mathf.CeilToInt(distance)+"m";
////					////////////////////////////////////////////
////							if(distance>15 && distance< 20){
////								// Getting closer
////								indicator.mainTexture = yellowLight;
////							}
////							else if(distance >20 && distance<35 ){
////								// Save Distance
////								indicator.mainTexture = greenLight;
////							}
////							else if(distance>35){
////								// Left behind
////								indicator.mainTexture = yellowLight;
////							}
////							else if (distance<15 || distance>250) {
////								// Too close or too behind to end level
////								indicator.mainTexture = redLight;	
////								GameManager.Instance.ChangeState(GameManager.SoundState.LEVELFAILSOUND ,GameManager.GameState.THIEFESCAPED);
////								isLevelFailOrComplete = false;
////								isLevelFinished = true;				
////							}
////						}		
////					}
////	
////				}
////			}
//
////	void OnGUI(){
////		if( GUI.Button( new Rect( 10, 10, 50, 50 ), "force" ) )
////		{
////			thiefCar.rigidbody.AddForce(Vector3.up * 300000);
////			thiefCar.GetComponent<RotateGameObject>().enabled = true;
////			try{
////			thiefCar.GetComponent<iTween>().enabled = true;
////			}catch(System.Exception e){}
////			thiefCar.GetComponent<CarBalance>().enabled = false;
////			StartCoroutine(stopRotation());
////		}
////		GUI.Label(new Rect(10,Screen.height*0.3f,200,100),"x  "+Input.acceleration.x);
////		GUI.Label(new Rect(10,Screen.height*0.35f,200,100),"y   "+Input.acceleration.y);
////		GUI.Label(new Rect(10,Screen.height*0.4f,200,100),"z  "+Input.acceleration.z);
////
////	}
//
//	IEnumerator stopRotation()
//	{
//		yield return new WaitForSeconds(1f);
//		thiefCar.GetComponent<RotateGameObject>().enabled = false;
//		//thiefCar.GetComponent<CarBalance>().enabled = true;
//		thiefCar.GetComponent<iTween>().enabled = false;
//		//Destroy(thiefCar.GetComponent<iTween>());
//		//thiefCar.transform.rotation = Quaternion.Lerp(thiefCar.transform.rotation, toRotation, Time.deltaTime);
//		
//	}

}