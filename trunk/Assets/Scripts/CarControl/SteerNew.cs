using UnityEngine;
using System.Collections;

public class SteerNew : MonoBehaviour {
	
	public static float stteringBtnPressedTime=0;
	VehicleParent vp;
	GameObject player;
	bool brakeCheck=true;
	DeviceOrientation orientation;
	public static bool  forward = false;
	public static bool  brake = false;
	public static bool  reverse = false;
	public static bool  back = false;
	public GameObject player1;
	public SteeringWheel steering;
	public GameObject steeringImage;
	public UILabel Steeringvalue;
	float BrakeTimeStart = 0;
	float maxBrakeTime;
	Vector2 acceleratorScreenPoint;
	Vector2 brakeScreenPoint;
	Vector2 gearBaseScreenPoint;
	Vector3 gearWorldPoint;
	float steerValue=0.0f;
	Vector2 steeringScreenPoint;

	public static bool isLeftArrowPressed=false;
	public static bool isRightArrowPressed=false;
	static bool  isStreeringMoving = false;
	bool  isMobile ;
	Vector2 preXY ;
	Vector2 postXY ;
	int factor;
	public GameObject AccelArrow;
	public static float timer = 0;
	public static float maxMovementTimer = 1.8f;
	private bool  isRotatingBack = false;
	private bool click= false;
	private Vector2 ignoreMovement ;
	private int isAcceteratorPress; 
	private int isBrakePress;
	private int isSteerClick;
	private Transform acceleratorPosition;
	private Transform brakePosition;
	public UISlider brakeSlider;
	private QuadBikeController quadBike;
	//	public Texture acceleratorPress;
	//	public Texture acceleratorRelease;
	//	public Texture brakePress;
	//	public Texture brakeRelease;
	//	public Texture gearReverse;
	//	public Texture gearDrive;
	//	CarControl car;
	
	#region CollidersConstants
	private int steeringColliderConstant = 250;
	//		private int accerLationColliderConstantX = 71;
	//		private int accerLationColliderConstantY = 115;
	//		private int brakeColliderConstantX = 70;
	//		private int brakeColliderConstantY = 120;
	//		private int gearColliderConstantX = 60;
	//		private int gearColliderConstantY = 85;
	#endregion
	private bool isAccelerationPressed;
	public static bool isBackAccelerationPressed;
	private bool isBreakPressed;
	private float steerSpeedTime;
	
	private bool isGameStateChanged = false;
	
	public GameObject otherBtn;
	
	public CameraControl cam;
	int currentCameraAngle = 1;
	
	public GameObject[] steerBtns;
	
	void  Start ( ){
		steerSpeedTime = 0.005f;//0.002f;
		calculateSteerSpeedTime();
		orientation = Input.deviceOrientation;
		player = GameObject.FindGameObjectWithTag ("Player2");
		//		CarMain.accellPressedValue=0f;
		//	static public float reverseGear=0f;
		//		CarMain.reverseGear=false;
		//		CarMain.steerValue2=0f;
		//		CarMain.brakeValue=1f;
		//		CarMain.revValue=0f;
		//		CarMain.brakePressed=false;
		//		CarMain.handBrakValue=0f;
		isGameStateChanged = false;
		isMobile = true;
		#if UNITY_EDITOR
		isMobile = false;
		#endif
		isStreeringMoving  = false;
		forward = false;
		brake = false;
		reverse = false;
		back = false;
		isAcceteratorPress = -1;
		isBrakePress = -1;
		timer = 0;
		factor  = 300; 
		isSteerClick = -1;
		isAccelerationPressed = false;
		isBreakPressed = false;
		isBackAccelerationPressed = false;
		#if UNITY_IPHONE
		this.SetCameraFOVForIphone();
		#endif
		if (this.tag.Equals ("MainCamera")) {
			steeringScreenPoint = Camera.main.WorldToScreenPoint (this.gameObject.transform.position);
			this.SetControlsOnRuntime ();
		}
		
		Invoke("SetCar",1f);
		
	}
	void SetCar()
	{
		//		car = GameObject.FindGameObjectWithTag("Player2").GetComponent<CarControl>();
	}
	public static bool accelDown=false,brakeDown=false;
	float SpeedMS = 0;
	
	void FixedUpdate()
	{
		
	}
	
	bool isbackdown = false;
	void Update (){
		if (this.gameObject.tag == "MainCamera") {
		
			if (GameManager.Instance.GetCurrentGameState () == GameManager.GameState.GAMEPLAY) {
				
				if (isGameStateChanged) {
					isGameStateChanged = false;
					
					if (UserPrefs.accelerometerFactor == 0) {

						steeringImage.SetActive (true);

					}
					
					//brakePosition.renderer.enabled = true;
					//acceleratorPosition.renderer.enabled = true;
					//GameObject.FindGameObjectWithTag("GearBase").transform.renderer.enabled = true;
				}
				
//				if (isMobile) {
//					if (Input.GetMouseButtonUp (0)) {
//						//												CameraRotation.isBtnClicked = false;
//					}
//					if (UserPrefs.accelerometerFactor == 0)
//						this.steeringControlerNew ();
//					//	this.ForMobileMovingControls();
//				} else {
//					if (Input.touchCount == 0) {
//						//												CameraRotation.isBtnClicked = false;
//					}
					if (UserPrefs.accelerometerFactor == 0) {
						this.steeringControlerNew ();
					}
					//this.ForComputerMovingControls();
		//		}	
				
				
			} else {
				
				if (!isGameStateChanged) {
					isGameStateChanged = true;
					
					if (UserPrefs.accelerometerFactor == 0) {
						steeringImage.SetActive (false);

						isRotatingBack = true;
						RotateSteerBack ();
					}
					
					//	brakePosition.renderer.enabled = false;
					//	brakePosition.renderer.material.mainTexture = brakeRelease;
					
					//	acceleratorPosition.renderer.enabled = false;
					//acceleratorPosition.renderer.material.mainTexture = acceleratorRelease;
					
					//GameObject.FindGameObjectWithTag("GearBase").transform.renderer.enabled = false;
				}
			}
		}
		//		
		
		
		
		if(this.name.Equals("btnAccel") && UserPrefs.accelerometerFactor == 1){
			if (vp == null) {
				GameObject temp = GameObject.FindGameObjectWithTag("Player2");
				quadBike=temp.GetComponentInChildren<QuadBikeController>();
				if(temp!=null)
					vp = temp.GetComponent<VehicleParent>();
				if(vp == null)
					return;
			}
			if(Input.acceleration.x * 2 < -0.2f || Input.acceleration.x * 2 > 0.2f){
				if(orientation == Input.deviceOrientation)
					vp.SetSteer(Input.acceleration.x);
				else
					vp.SetSteer(-Input.acceleration.x);

				if(Input.acceleration.x<0)
				{
					if(quadBike)
						quadBike.isLeft(true);
					else
					{
						quadBike=vp.transform.root.GetComponentInChildren<QuadBikeController>();
						quadBike.isLeft(true);
					}


				}
				else
				{
					if(quadBike)
						quadBike.isRight(true);
					else
					{
						quadBike=vp.transform.root.GetComponentInChildren<QuadBikeController>();
						quadBike.isRight(true);
					}

				}

			}
			else 
			{
				if(quadBike)
				{

					quadBike.isLeft(false);
					quadBike.isRight(false);
				}
				vp.SetSteer(0);
			}
			}
	}

	void OnPress (bool isDown)
	{	if(vp==null)
		vp = GameObject.FindGameObjectWithTag("Player2").GetComponent<VehicleParent>();
		//	car = GameObject.FindGameObjectWithTag("Player2").GetComponent<CarControl>();
		if(this.name.Equals("btnAccel"))
		{
			if(UserPrefs.currentLevel==1&&UserPrefs.currentEpisode==1&&UserPrefs.isTutorial)
			{
				AccelArrow.SetActive(false);
				//UserPrefs.isTutorial=false;
				Time.timeScale=1;



			}

			if(isDown)
			{
				//				CameraRotation.isBtnClicked = true;
				vp.SetAccel(1f);
				//				if(CarMain.reverseGear)
				//				{
				//					CarMain.revValue=-1f;
				//					CarMain.accellPressedValue=0f;
				//				}
				//				else
				//				{
				//					CarMain.accellPressedValue=1f;
				//					CarMain.revValue=0f;
				//				}
				
				
				//				CarMain.SendInput(car,false,false);
				
				if(!isAccelerationPressed)
				{
					isAccelerationPressed = true;
					//		Debug.LogError("isAccelerationPressed = true   for mobile");
					UserPrefs.isAccelaratorPressed = isAccelerationPressed;
				}
			}
			else if(!isDown)
			{
				//				CameraRotation.isBtnClicked = false;
				
				//				CarMain.accellPressedValue=0f;
				//				CarMain.revValue=0f;
				//
				//				CarMain.SendInput(car,false,false);
				vp.SetAccel(0f);
				isAcceteratorPress = -1;
				
				isAccelerationPressed = false;
				UserPrefs.isAccelaratorPressed =  isAccelerationPressed;
			}
		}
		
		
		
		if(this.name.Equals("btnBrake"))
		{
			if(UserPrefs.currentLevel==1&&UserPrefs.currentEpisode==1&&UserPrefs.islevel4)
				
			{
				AccelArrow.SetActive(false);
				Time.timeScale=1;
				UserPrefs.islevel4=false;
				if(player)
					player.GetComponent<Rigidbody>().isKinematic=true;
				else{
					player=GameObject.FindGameObjectWithTag("Player2");
					player.GetComponent<Rigidbody>().isKinematic=true;
				}
				
				
			}
			else
			{
				if(player)
					player.GetComponent<Rigidbody>().isKinematic=false;
				else{
					player=GameObject.FindGameObjectWithTag("Player2");
					
				}
				
			}

			brakeDown = isDown;
			//			CameraRotation.isBtnClicked = true;
			

			if(isDown)
			{
				//					CarMain.handBrakValue=1f;
				//					//					CarMain.brakePressed=true;
				//					CarMain.SendInput(car,false,false);


				vp.SetEbrake(1f);
				if(!isBreakPressed)
				{
					isBreakPressed = true;
					
				}
			}
			
			else if(!isDown)
			{
				//					CarMain.brakePressed=false;
				vp.SetEbrake(0f);
				//					CameraRotation.isBtnClicked = false;
				
				//					CarMain.handBrakValue=0f;
				//					//					CarMain.brakePressed=false;
				//					
				//					CarMain.SendInput(car,false,true);
				isBrakePress = -1;
				isBreakPressed = false;
				
			}
			
		}
		
		
		
		
		
		
		if(this.name.Equals("btlLeftsteer"))
		{
			if(isDown)
			{
				isLeftArrowPressed = true;

				vp.SetSteer(-1);
				if(quadBike)
				quadBike.isLeft(true);
				else
				{
					quadBike=vp.transform.root.GetComponentInChildren<QuadBikeController>();
					quadBike.isLeft(true);
				}
				
			}
			else if(!isDown)
			{
				steerValue=0;
				vp.SetSteer(0);
				isLeftArrowPressed = false;
				if(quadBike)
				quadBike.isLeft(false);
				else
				{
				quadBike=vp.transform.root.GetComponentInChildren<QuadBikeController>();
					quadBike.isLeft(false);
				}
			}
		}
		
		
		if(this.name.Equals("btnRightSteer"))
		{
			if(isDown)
			{

				vp.SetSteer(1);
				isRightArrowPressed = true;
				if(quadBike)
				quadBike.isRight(true);
					else
				{
						quadBike=vp.transform.root.GetComponentInChildren<QuadBikeController>();
					quadBike.isRight(true);
				}
				
			}
			else if(!isDown)
			{

				vp.SetSteer(0);
				isRightArrowPressed = false;
				if(quadBike)
				{
				quadBike.isRight(false);
				}
					else{
					quadBike=vp.transform.root.GetComponentInChildren<QuadBikeController>();
				quadBike.isRight(false);


			}
			}
		}
		
		
		
		
		if (this.name.Equals ("btnBack"))
		{

		

			if (isDown) {







					vp.SetBrake(1);



				if (!isAccelerationPressed) {
					//	player.GetComponent<Rigidbody>().drag=0.01f;
					isAccelerationPressed = true;
					isBackAccelerationPressed=true;
					UserPrefs.isAccelaratorPressed = isAccelerationPressed;
				}
			
			} else if (!isDown) {
				vp.SetBrake(0f);

				isAcceteratorPress = -1;
				isAccelerationPressed = false;
				isBackAccelerationPressed=false;
				UserPrefs.isAccelaratorPressed = isAccelerationPressed;
			}
		}
		

		
		
	}
	void OnClick()
	{
		if (this.gameObject.name.Equals ("btnEnter")) {
			GameObject.Find ("PlayerManager").GetComponent<PlayerManager> ().SwitchControls ();
			otherBtn.SetActive (true);
			this.gameObject.SetActive (false);
			TutorialManagerNew.Instance.ChangeState (TutorialManagerNew.TutorialState.HIDEENTERBTNARROW);
			TutorialManagerNew.Instance.ChangeState (TutorialManagerNew.TutorialState.INTROPICKNDROP);
			TutorialManagerNew.Instance.ChangeState (TutorialManagerNew.TutorialState.INTROARRESTTHIEF);
		} else if (this.gameObject.name.Equals ("btnExit")) {
			GameObject.Find ("PlayerManager").GetComponent<PlayerManager> ().SwitchControls ();
			TutorialManagerNew.Instance.ChangeState (TutorialManagerNew.TutorialState.HIDEENTERBTNARROW);
			otherBtn.SetActive (true);
			this.gameObject.SetActive (false);
		} else if (this.gameObject.name.Equals ("btnTraffic")) {
			foreach (var trafficController in GameObject.FindObjectsOfType<TrafficPatchHandler>()) {
				if (!trafficController.isActive)
					continue;
				trafficController.ReduceCars ();
				this.gameObject.GetComponentInChildren<UILabel> ().text = trafficController.carsCount.ToString ();
			}
		} else if (this.gameObject.name.Equals ("btnCamera")) {
			//			currentCameraAngle++;
			//			currentCameraAngle = currentCameraAngle == 10 ? 1 : currentCameraAngle;
			currentCameraAngle = currentCameraAngle == 1 ? 9 : 1;
//			cam.SetCameraAdjustments(currentCameraAngle);
		} else if (this.gameObject.name.Equals ("Spawn")) {
			GameObject spawnCar = Instantiate (Resources.Load ("Vehicles/Chase Muscle Car"), new Vector3 (-19.92f, -14.31f, -94.78f), Quaternion.identity)as GameObject;
			
			spawnCar.GetComponent<FollowAI> ().target = GameObject.FindGameObjectWithTag ("Player2").transform;
		} 
//		else if (this.name.Equals ("btnBack")) {
//			//downward force applying here to stop abruptly 
//			for(int i=0;i<15;i++)
//			player.GetComponent<Rigidbody>().AddForce(Vector3.down*50f);
//
//		}
		
	}

	private void steeringControlerNew()
	{		if (vp == null) {
			GameObject temp = GameObject.FindGameObjectWithTag ("Player2");
			if (temp != null)
				vp = temp.GetComponent<VehicleParent> ();
			if (vp == null)
				return;
		}

		if (vp && steering) {
			vp.SetSteer (steering.GetInput ());

		
		}
	}

	private void ForComputerSteerMoving ( ){
		Debug.Log("STEEEEEEEEER");
		if ( Input.GetMouseButtonDown(0) )
		{
			click = true ;
			isRotatingBack=false;		
			preXY = Input.mousePosition;
			postXY = preXY;		
		}
		
		if ( Input.GetMouseButtonUp(0) )
		{
			click = false ;
			isStreeringMoving = false;
			isRotatingBack = true;
		}
		
		
		if ( click )
		{
			preXY = postXY;
			postXY = Input.mousePosition;
			isRotatingBack = true;
			if ( (steeringScreenPoint.x < (Input.mousePosition.x + steeringColliderConstant) && steeringScreenPoint.x > (Input.mousePosition.x - steeringColliderConstant) ) &&
			    (steeringScreenPoint.y < (Input.mousePosition.y + steeringColliderConstant) && steeringScreenPoint.y > (Input.mousePosition.y - steeringColliderConstant) ) )
			{
				//				CameraRotation.isBtnClicked = true;
				isRotatingBack = false;
				
				if ( steeringScreenPoint.x < Input.mousePosition.x && steeringScreenPoint.y > Input.mousePosition.y )
				{
					if ( (postXY.x > preXY.x || postXY.y > preXY.y) && timer >= -maxMovementTimer )
					{
						this.RotateSteeringUp();
					}
					if ( (postXY.x < preXY.x || postXY.y < preXY.y) && timer <= maxMovementTimer )
					{
						this.RotateSteeringDown();
					}
				}
				
				if ( steeringScreenPoint.x > Input.mousePosition.x && steeringScreenPoint.y > Input.mousePosition.y )
				{
					if ( (postXY.x > preXY.x || postXY.y < preXY.y) && timer >= -maxMovementTimer )
					{
						this.RotateSteeringUp();
					}
					if ( (postXY.x < preXY.x || postXY.y > preXY.y) && timer <= maxMovementTimer )
					{
						this.RotateSteeringDown();
					}
				}
				
				if ( steeringScreenPoint.x > Input.mousePosition.x && steeringScreenPoint.y < Input.mousePosition.y )
				{
					if ( (postXY.x < preXY.x || postXY.y < preXY.y) && timer >= -maxMovementTimer )
					{
						this.RotateSteeringUp();
					}
					if ( (postXY.x > preXY.x || postXY.y > preXY.y) && timer <= maxMovementTimer )
					{
						this.RotateSteeringDown();
					}
				}
				
				if ( steeringScreenPoint.x < Input.mousePosition.x && steeringScreenPoint.y < Input.mousePosition.y )
				{
					if ( (postXY.x < preXY.x || postXY.y > preXY.y) && timer >= -maxMovementTimer )
					{
						this.RotateSteeringUp();
					}
					if ( (postXY.x > preXY.x || postXY.y < preXY.y) && timer <= maxMovementTimer )
					{
						this.RotateSteeringDown();
					}
				}
			}
		}
		RotateSteerBack();
	}
	
	private void ForMobileSteerMoving (){
		
		Vector3 tempTouchPosition;
		
		for(int i= 0; i< Input.touchCount; i++){
			
			tempTouchPosition = Input.GetTouch(i).position;
			
			if((steeringScreenPoint.x < (tempTouchPosition.x + steeringColliderConstant) && steeringScreenPoint.x > (tempTouchPosition.x - steeringColliderConstant)) && 
			   (steeringScreenPoint.y < (tempTouchPosition.y + steeringColliderConstant) && steeringScreenPoint.y > (tempTouchPosition.y - steeringColliderConstant)))
			{
				//				CameraRotation.isBtnClicked = true;
				isRotatingBack = false;
				isSteerClick = i;
				if (Input.GetTouch(i).phase == TouchPhase.Began)
				{
					click = true ;
					isRotatingBack = false;
					isStreeringMoving = true;
					preXY = Input.GetTouch(i).position;
					postXY = preXY;	
					ignoreMovement = Input.GetTouch(i).position;
				}
				
				if ( Input.GetTouch(i).phase == TouchPhase.Ended )
				{
					click = false ;
					isStreeringMoving = false;
					isRotatingBack = true;
					isSteerClick = -1;
				}
				if (Input.GetTouch(i).phase == TouchPhase.Moved)
				{
					
					if(click)
					{
						
						preXY = postXY;
						postXY = Input.GetTouch(i).position;
						if((postXY.x > ignoreMovement.x + 7) || (postXY.y > ignoreMovement.y + 7) || (postXY.x < ignoreMovement.x - 7) || (postXY.y < ignoreMovement.y - 7))
						{
							if(steeringScreenPoint.x < Input.GetTouch(i).position.x && steeringScreenPoint.y > Input.GetTouch(i).position.y)
							{
								if((postXY.x > preXY.x || postXY.y > preXY.y) && timer > -maxMovementTimer)
								{
									this.RotateSteeringUp();
								}
								if((postXY.x < preXY.x || postXY.y < preXY.y) && timer < maxMovementTimer)
								{
									this.RotateSteeringDown();
								}
							}
							
							if(steeringScreenPoint.x > Input.GetTouch(i).position.x && steeringScreenPoint.y > Input.GetTouch(i).position.y)
							{
								if((postXY.x > preXY.x || postXY.y < preXY.y) && timer > -maxMovementTimer)
								{
									this.RotateSteeringUp();
								}
								if((postXY.x < preXY.x || postXY.y > preXY.y) && timer < maxMovementTimer)
								{
									this.RotateSteeringDown();
								}
							}
							
							if(steeringScreenPoint.x > Input.GetTouch(i).position.x && steeringScreenPoint.y < Input.GetTouch(i).position.y)
							{
								if((postXY.x < preXY.x || postXY.y < preXY.y) && timer > -maxMovementTimer)
								{
									this.RotateSteeringUp();
								}
								if((postXY.x > preXY.x || postXY.y > preXY.y) && timer < maxMovementTimer)
								{
									this.RotateSteeringDown();
								}
							}
							
							if(steeringScreenPoint.x < Input.GetTouch(i).position.x && steeringScreenPoint.y < Input.GetTouch(i).position.y)
							{
								if((postXY.x < preXY.x || postXY.y > preXY.y) && timer > -maxMovementTimer)
								{
									this.RotateSteeringUp();
								}
								if((postXY.x > preXY.x || postXY.y < preXY.y) && timer < maxMovementTimer)
								{
									this.RotateSteeringDown();
								}
							}
						}
					}
				}
				else
				{
					ignoreMovement = postXY;
				}
				
			}
			else if(!isStreeringMoving || isSteerClick == i)
			{
				isRotatingBack = true;
				isSteerClick = -1;
			}	
		}
		RotateSteerBack();
	}
	
	private void RotateSteerBack(){
		
		if(isRotatingBack)
		{
			if(timer < -0.02f)
			{
				
				moveBackToDefaultPosition();
				
				this.RotateSteeringDown();
				
			}
			else if(timer > 0.02f)
			{
				
				moveBackToDefaultPosition();
				
				this.RotateSteeringUp();
				
			}
			else if(timer < 0.01f && timer > 0)
			{
				this.gameObject.transform.Rotate(Vector3.up,timer*factor);
				timer = 0;
				moveBackToDefaultPosition();
				
			}
			else if(timer > -0.01f && timer < 0)
			{
				this.gameObject.transform.Rotate(Vector3.down,timer*factor*-1);
				timer = 0;
				moveBackToDefaultPosition();
			}
			else
			{
				timer = 0;
				isRotatingBack = false;
				moveBackToDefaultPosition();
			}
		}
		
	}
	
	private void moveBackToDefaultPosition(){
		//		CarMain.steerValue2 = 0f;
		stteringBtnPressedTime = 0;
		if (vp == null) {
			vp = GameObject.FindGameObjectWithTag("Player2").GetComponent<VehicleParent>();
			if(vp == null)
				return;
		}
		vp.SetSteer (stteringBtnPressedTime);
		//		CarMain.SendInput(car,false,false);
		//		if(stteringBtnPressedTime<0)
		//		{
		//			stteringBtnPressedTime+=0.02f;
		//			if(stteringBtnPressedTime>0)
		//			{
		//				stteringBtnPressedTime=0;
		//			}
		//			CarMain.steerValue2=0;
		//			CarMain.SendInput(car,false,false);
		//			
		//		}
		//		else if(stteringBtnPressedTime>0)
		//		{
		//			stteringBtnPressedTime-=0.02f;
		//			if(stteringBtnPressedTime<0)
		//			{
		//				stteringBtnPressedTime=0;
		//			}
		//			CarMain.steerValue2=0;
		//			CarMain.SendInput(car,false,false);
		//			
		//		} else {
		//			CarMain.steerValue2=0.0f;
		//			CarMain.SendInput(car,false,false);
		//		}
	}
	
	//	private void ForComputerMovingControls(){
	//		if (BrakeTimeStart > 0f) {
	//			if(Time.time>maxBrakeTime)
	//			{
	//				GameObject.FindObjectOfType<CoinsHandler>().DeductCoins(UserPrefs.CoinsToDeductOnTraficSignal,"Hard Brake -50 Coins deduct");
	//				BrakeTimeStart = 0f;
	//				
	//			}
	//		}
	//		car = GameObject.FindGameObjectWithTag("Player").GetComponent<CarControl>();
	//		if(Input.GetMouseButtonDown(0))
	//		{
	////			Debug.Log(Input.mousePosition.x +"     "+ Input.mousePosition.y);
	//			if((acceleratorScreenPoint.x < (Input.mousePosition.x + accerLationColliderConstantX) && acceleratorScreenPoint.x > (Input.mousePosition.x - accerLationColliderConstantX)) && 
	//			(acceleratorScreenPoint.y < (Input.mousePosition.y + accerLationColliderConstantY) && acceleratorScreenPoint.y > (Input.mousePosition.y - accerLationColliderConstantY)))
	//			{	
	////				if(reverse)
	////				{
	////					forward = false;
	////					back = true;
	////					brake = false;
	////				}
	////				else
	////				{
	////					forward = true;
	////					back = false;
	////					brake = false;
	////				}
	//				
	//				if(CarMain.reverseGear)
	//				{
	//					CarMain.revValue=-1f;
	//					CarMain.accellPressedValue=0f;
	//				}
	//				else
	//				{
	//					CarMain.accellPressedValue=1f;
	//					CarMain.revValue=0f;
	//				}
	//				//GameObject.FindGameObjectWithTag("Biker").GetComponent<GolfPlayerController>().setIdleAnimationFalse();
	//				CarMain.SendInput(car,false,false);
	//				
	//			acceleratorPosition.renderer.material.mainTexture = acceleratorPress;
	//			}	
	//			
	//			if((brakeScreenPoint.x < (Input.mousePosition.x + brakeColliderConstantX) && brakeScreenPoint.x > (Input.mousePosition.x - brakeColliderConstantX)) && 
	//			(brakeScreenPoint.y < (Input.mousePosition.y + brakeColliderConstantY) && brakeScreenPoint.y > (Input.mousePosition.y - brakeColliderConstantY)))
	//			{
	//				CarMain.brakePressed=true;
	//				CarMain.SendInput(car,false,false);
	////				brake = true;
	////				forward = false;
	////				back = false;
	//				brakePosition.renderer.material.mainTexture = brakePress;
	//
	//
	//				if(GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<WheelCollider>().rpm > 5f)
	//				{
	//
	//					BrakeTimeStart = Time.time;
	//					maxBrakeTime = BrakeTimeStart+2f;
	//					
	//				}
	//				else
	//				{
	//					BrakeTimeStart = 0f;
	//				}
	//			}
	//		
	//		
	//			if((gearBaseScreenPoint.x < (Input.mousePosition.x + gearColliderConstantX) && gearBaseScreenPoint.x > (Input.mousePosition.x - gearColliderConstantX)) && 
	//			(gearBaseScreenPoint.y < (Input.mousePosition.y + gearColliderConstantY) && gearBaseScreenPoint.y > (Input.mousePosition.y - gearColliderConstantY)))
	//			{
	//				reverse = !reverse;
	//				//GameObject.FindGameObjectWithTag("Biker").GetComponent<GolfPlayerController>().setIdleAnimationFalse();
	//				if(reverse)
	//				{
	//					CarMain.reverseGear=true;
	////					Debug.Log("ReverSed");
	//					GameObject.FindGameObjectWithTag("GearBase").transform.renderer.material.mainTexture = gearReverse;   	
	//				}
	//				else
	//				{	
	////					Debug.Log("Forward");
	//					CarMain.reverseGear=false;
	//					GameObject.FindGameObjectWithTag("GearBase").transform.renderer.material.mainTexture = gearDrive;
	//				}
	//			}
	//			
	//		}
	//		
	//		if(Input.GetMouseButtonUp(0))
	//		{
	//			CarMain.accellPressedValue=0f;
	//			CarMain.revValue=0f;
	//			CarMain.brakePressed=false;
	//			CarMain.SendInput(car,false,false);
	//			UserPrefs.specialFlag = true;
	//			acceleratorPosition.renderer.material.mainTexture = acceleratorRelease;
	//			brakePosition.renderer.material.mainTexture = brakeRelease;	
	//			BrakeTimeStart = 0f;
	//		}
	//		
	//	}
	//	
	//	private void ForMobileMovingControls(){
	//		if (BrakeTimeStart > 0f) {
	//			if(Time.time>maxBrakeTime)
	//			{
	//				GameObject.FindObjectOfType<CoinsHandler>().DeductCoins(UserPrefs.CoinsToDeductOnTraficSignal,"Hard Brake -50 Coins deduct");
	//				BrakeTimeStart = 0f;
	//				
	//			}
	//		}
	//		 car = GameObject.FindGameObjectWithTag("Player").GetComponent<CarControl>();
	//
	//		for ( int i= 0 ; i < Input.touchCount ; i++ ) 
	//		{
	//		
	//			if((acceleratorScreenPoint.x < (Input.GetTouch(i).position.x + accerLationColliderConstantX) && acceleratorScreenPoint.x > (Input.GetTouch(i).position.x - accerLationColliderConstantX)) && 
	//			(acceleratorScreenPoint.y < (Input.GetTouch(i).position.y + accerLationColliderConstantY) && acceleratorScreenPoint.y > (Input.GetTouch(i).position.y - accerLationColliderConstantY)))
	//			{
	//				CameraRotation.isBtnClicked = true;
	//				isAcceteratorPress = i;
	//				if(Input.GetTouch(i).phase == TouchPhase.Began)
	//				{
	//					
	//					
	//					if(CarMain.reverseGear)
	//					{
	//						CarMain.revValue=-1f;
	//						CarMain.accellPressedValue=0f;
	//					}
	//					else
	//					{
	//						CarMain.accellPressedValue=1f;
	//						CarMain.revValue=0f;
	//					}
	//					
	//
	//				CarMain.SendInput(car,false,false);
	//					
	//					
	//					if(reverse)
	//					{
	//						forward = false;
	//						back = true;
	//						brake = false;
	//					}
	//					else
	//					{
	//						forward = true;
	//						back = false;
	//						brake = false;
	//					}
	//						acceleratorPosition.renderer.material.mainTexture = acceleratorPress;
	//					
	//				}
	//				if(Input.GetTouch(i).phase == TouchPhase.Moved)
	//				{
	//						if(CarMain.reverseGear)
	//					{
	//						CarMain.revValue=-1f;
	//						CarMain.accellPressedValue=0f;
	//					}
	//					else
	//					{
	//						CarMain.accellPressedValue=1f;
	//						CarMain.revValue=0f;
	//					}
	//					
	//
	//				CarMain.SendInput(car,false,false);
	//					if(reverse)
	//					{
	//						forward = false;
	//						back = true;
	//						brake = false;
	//					}
	//					else
	//					{
	//						forward = true;
	//						back = false;
	//						brake = false;
	//					}
	//					if(!isAccelerationPressed)
	//					{
	//						isAccelerationPressed = true;
	//						acceleratorPosition.renderer.material.mainTexture = acceleratorPress;
	//					}
	//					
	//				}
	//				
	//				if(Input.GetTouch(i).phase == TouchPhase.Ended)
	//				{
	//					CarMain.accellPressedValue=0f;
	//				CarMain.revValue=0f;
	//
	//				CarMain.SendInput(car,false,false);
	//					forward = false;
	//					back = false;
	//					brake = false;
	//					isAcceteratorPress = -1;
	//					acceleratorPosition.renderer.material.mainTexture = acceleratorRelease;	  
	//					isAccelerationPressed = false;
	//				}
	//			}
	//			
	//			else if(isAcceteratorPress == i)
	//			{
	//				CarMain.accellPressedValue=0f;
	//				CarMain.revValue=0f;
	//
	//				CarMain.SendInput(car,false,false);
	//				forward = false;
	//				brake = false;
	//				back = false;
	//				isAcceteratorPress = -1;
	//				isAccelerationPressed = false;
	//				acceleratorPosition.renderer.material.mainTexture = acceleratorRelease;
	//			}
	//			
	//			if((brakeScreenPoint.x < (Input.GetTouch(i).position.x + brakeColliderConstantX) && brakeScreenPoint.x > (Input.GetTouch(i).position.x - brakeColliderConstantX)) && 
	//			(brakeScreenPoint.y < (Input.GetTouch(i).position.y + brakeColliderConstantY) && brakeScreenPoint.y > (Input.GetTouch(i).position.y - brakeColliderConstantY)))
	//			{
	//				CameraRotation.isBtnClicked = true;
	//
	//				if(BrakeTimeStart > 0)
	//				{
	//					if(Time.time >=maxBrakeTime)
	//					{
	//						GameObject.FindObjectOfType<CoinsHandler>().DeductCoins(UserPrefs.CoinsToDeductOnTraficSignal,"HardBrake -50 Coins deduct");
	//
	//					}
	//				}
	//				if(Input.GetTouch(i).phase == TouchPhase.Began)
	//				{
	//					
	//					if(GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<WheelCollider>().rpm > 35f)
	//					{
	//						
	//						BrakeTimeStart = Time.time;
	//						maxBrakeTime = BrakeTimeStart+1.5f;
	//						
	//					}
	//					else
	//					{
	//						BrakeTimeStart = 0f;
	//					}
	//					CarMain.brakePressed=true;
	//					CarMain.SendInput(car,false,false);
	//					forward = false;
	//					brake = true;
	//					back = false;
	//	
	//						brakePosition.renderer.material.mainTexture = brakePress;
	//				}
	//				if(Input.GetTouch(i).phase == TouchPhase.Moved)
	//				{
	//					CarMain.brakePressed=true;
	//				CarMain.SendInput(car,false,false);
	//					forward = false;
	//					brake = true;
	//					back = false;
	//					if(!isBreakPressed)
	//					{
	//						isBreakPressed = true;
	//						brakePosition.renderer.material.mainTexture = brakePress;
	//					}
	//				}
	//				
	//				if(Input.GetTouch(i).phase == TouchPhase.Ended)
	//				{
	//					CarMain.brakePressed=false;
	//				CameraRotation.isBtnClicked = false;
	//					forward = false;
	//					brake = false;
	//					back = false;
	//					isBrakePress = -1;
	//					isBreakPressed = false;
	//					brakePosition.renderer.material.mainTexture = brakeRelease;	
	//					BrakeTimeStart = 0f;
	//
	//				}
	//				isBrakePress = i;
	//			
	//			}
	//			
	//			else if(isBrakePress == i)
	//			{
	//				CarMain.brakePressed=false;
	//				CameraRotation.isBtnClicked = false;
	//				forward = false;
	//				brake = false;
	//				back = false;
	//				isBrakePress = -1;
	//				isBreakPressed = false;
	//				brakePosition.renderer.material.mainTexture = brakeRelease;			     	
	//			}
	//			
	//			if((gearBaseScreenPoint.x < (Input.GetTouch(i).position.x + gearColliderConstantX) && gearBaseScreenPoint.x > (Input.GetTouch(i).position.x - gearColliderConstantY)) && 
	//			(gearBaseScreenPoint.y < (Input.GetTouch(i).position.y + gearColliderConstantY) && gearBaseScreenPoint.y > (Input.GetTouch(i).position.y - gearColliderConstantY)))
	//			{
	//				CameraRotation.isBtnClicked = true;
	//				if(Input.GetTouch(i).phase == TouchPhase.Began)
	//				{
	//					reverse = !reverse;
	//					if(reverse)
	//					{
	//						Debug.Log("ReverSed");	
	//						CarMain.reverseGear=true;
	//						GameObject.FindGameObjectWithTag("GearBase").transform.renderer.material.mainTexture = gearReverse;
	//					}
	//					else
	//					{	
	//						Debug.Log("Forward");
	//						CarMain.reverseGear=false;
	//						GameObject.FindGameObjectWithTag("GearBase").transform.renderer.material.mainTexture = gearDrive;					    	
	//					}
	//				}		  
	//			}
	//		}
	//	}
	//
	
	private void  setCameraControls (){
		//		acceleratorPosition = GameObject.FindGameObjectWithTag("Accelerator").transform;
		//		brakePosition = GameObject.FindGameObjectWithTag("Brake").transform;
		//		gearBaseScreenPoint   = Camera.main.WorldToScreenPoint(GameObject.FindGameObjectWithTag("GearBase").transform.position);			
		
		steeringScreenPoint   = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
		//		acceleratorScreenPoint   = Camera.main.WorldToScreenPoint(acceleratorPosition.position);
		//		brakeScreenPoint   = Camera.main.WorldToScreenPoint(brakePosition.position);
	}
	float fact = 2.5f;
	private void RotateSteeringDown(){
		if(!isRotatingBack){
			timer = timer + Time.deltaTime;
			
			this.gameObject.transform.Rotate(Vector3.down,Time.deltaTime*factor);
		}
		else{
			timer = timer + Time.deltaTime*fact;
			this.gameObject.transform.Rotate(Vector3.down,Time.deltaTime*factor*fact);
		}
		if(stteringBtnPressedTime<1f)
		{
			stteringBtnPressedTime+=steerSpeedTime + 0.005f;
			if(!isRotatingBack){
				vp.SetSteer(stteringBtnPressedTime);
			}
			
		}
	}
	private void RotateSteeringUp(){
		
		if (!isRotatingBack) {
			timer = timer - Time.deltaTime;
			this.gameObject.transform.Rotate (Vector3.up, Time.deltaTime * factor);
		}
		else{
			timer = timer - Time.deltaTime*fact;
			
			this.gameObject.transform.Rotate(Vector3.up,Time.deltaTime*factor*fact);
		}
		
		if(stteringBtnPressedTime>-1f)
		{
			stteringBtnPressedTime-=steerSpeedTime + 0.005f;
			if(!isRotatingBack){
				vp.SetSteer(stteringBtnPressedTime);
			}
			
		}
	}
	
	private void SetControls(){
		// 0 for Steering, 1 for Accelerometer, 2 for ArrowLeft Right
		
		//For Steering
		//		if(UserPrefs.accelerometerFactor==0)
		//		{
		//			GameObject.FindWithTag("Steering").GetComponent<Renderer>().enabled = true;
		//			GameObject.Find("btlLeftsteer").SetActive(false);//to hide Left Arrow
		//			GameObject.Find("btnRightSteer").SetActive(false);//to hide right Arrow
		//		}
		//		
		//		//For Accelerometer
		//		if(UserPrefs.accelerometerFactor==1)
		//		{
		//			GameObject.FindWithTag("Steering").GetComponent<Renderer>().enabled = false;//to hide steering
		//			GameObject.Find("btlLeftsteer").SetActive(false);//to hide Left Arrow
		//			GameObject.Find("btnRightSteer").SetActive(false);//to hide right Arrow
		//		}
		//		//For Arrow Left Right
		//		else if(UserPrefs.accelerometerFactor==2)
		//		{
		////			GameObject.FindWithTag("Steering").GetComponent<Renderer>().enabled = false;//to hide steering
		//		}
	}
	
	private void SetCameraFOVForIphone(){
		#if UNITY_IPHONE
		Debug.Log("Screen Width" + Screen.width);
		if(Screen.width==960||Screen.width==480)      // For Iphone 4 etc
		{
			Camera.main.fieldOfView = 45; //48
		}
		
		if(Screen.width==2048||Screen.width==1024){
			Camera.main.fieldOfView = 52;   
		}
		#endif
	}
	void calculateSteerSpeedTime()
		
	{
		//int currentSteeringUpgradeLevel = 1;//VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel;
		int currentSteeringUpgradeLevel = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel;
		
		//		switch(UserPrefs.currentVehicle)
		//		{
		//		case 1:
		//			steerSpeedTime=0.006f;
		//			break;
		//		case 2:
		//			steerSpeedTime=0.007f;
		//			break;
		//		case 3:
		//			steerSpeedTime=0.008f;
		//			break;
		//		default:
		//			break;
		//		}
		if(currentSteeringUpgradeLevel>1)
		{
			steerSpeedTime=steerSpeedTime+(ConstantsNew.STEERING_UPGRADE_FACTOR*(currentSteeringUpgradeLevel-1));
		}
	}
	
	public void SetControlsOnRuntime(){
		if(UserPrefs.accelerometerFactor==0)
		{
			steeringImage.SetActive(true);
			foreach(var btn in steerBtns){
				btn.SetActive(false);
			}
		}
		//For Accelerometer
		else if(UserPrefs.accelerometerFactor==1)
		{
		//	steeringImage.SetActive(false);
			foreach(var btn in steerBtns){
				btn.SetActive(false);
			}
		}
		//For Arrow Left Right
		else if(UserPrefs.accelerometerFactor==2)
		{
		//	steeringImage.SetActive(false);
			foreach(var btn in steerBtns){
				btn.SetActive(true);
			}
		}
	}

	//for PC control RVP
#if UNITY_EDITOR
	void LateUpdate(){
		if (vp == null) {
			player1 = GameObject.FindGameObjectWithTag ("Player2");
			if(player1)
				vp=player1.GetComponent<VehicleParent>();
			else
				return;
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			
			vp.SetAccel(1f);
			
			if (!isAccelerationPressed) {
				isAccelerationPressed = true;
				UserPrefs.isAccelaratorPressed = isAccelerationPressed;
			}
			
			
			
			
			
			
			
			
			
		} else if (Input.GetKeyUp (KeyCode.UpArrow)) {
			
			//				CarMain.SendInput(car,false,false);
			vp.SetAccel(0f);
			isAcceteratorPress = -1;
			
			isAccelerationPressed = false;
			UserPrefs.isAccelaratorPressed =  isAccelerationPressed;
			
			
			
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			
			vp.SetBrake(1f);
			if (!isAccelerationPressed) {
				isAccelerationPressed = true;
				isBackAccelerationPressed=true;
				//		Debug.LogError("isAccelerationPressed = true   for mobile");
				UserPrefs.isAccelaratorPressed = isAccelerationPressed;
			}
		
		

			//					CarMain.brakePressed=false;

			
			
		} else if (Input.GetKeyUp (KeyCode.DownArrow)) {
			
			vp.SetBrake(0f);
			//				CarMain.accellPressedValue = 0f;
			//				CarMain.revValue = 0f;
			//				
			//				CarMain.SendInput (car, false, false);
			isAcceteratorPress = -1;
			
			isAccelerationPressed = false;
			isBackAccelerationPressed=false;
			UserPrefs.isAccelaratorPressed = isAccelerationPressed;
			
		}
		
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			isLeftArrowPressed = true;
			vp.SetSteer(-1f);
		} else if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			vp.SetSteer(0f);
			//				CameraRotation.isBtnClicked = false;
			
			isLeftArrowPressed = false;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			
			
			vp.SetSteer(1f);
			isRightArrowPressed = true;
			
			
			
		} else if (Input.GetKeyUp (KeyCode.RightArrow)) {
			
			vp.SetSteer(0f);
			//				CameraRotation.isBtnClicked = false;
			
			isRightArrowPressed = false;
			
		}
		
		
//		if (Input.GetKeyDown (KeyCode.Space)) {
//			
//			CarMain.handBrakValue = 1f;
//			//								CarMain.brakePressed=true;
//			CarMain.SendInput (car, false, false);
//			
//			if (!isBreakPressed) {
//				isBreakPressed = true;
//				
//			}
			
			
			
			
		//}
	}


#endif








	
}
