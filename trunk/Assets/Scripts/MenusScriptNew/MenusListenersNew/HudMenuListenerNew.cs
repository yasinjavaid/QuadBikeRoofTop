using UnityEngine;
using System.Collections;
using System;
public class HudMenuListenerNew : MonoBehaviour {



		VehicleParent vp;
		int  cameraPosition = 1;
		GameObject btnCamera;
		Quaternion currentRPMAngle;
		Quaternion maxRPMAngle;
		Quaternion minRPMAngle;
	
	
	public bool isAccelerationPressed;
	public static bool isBreakPressed;
	public static float stteringBtnPressedTime=0;


	public GameObject[] steeringBtns;
	private static bool isAccel = false;
	// Fuel Manager
		
		UISprite timerSprite ;
		UIPanel timerTextIndicationPanel;
		bool isTimerIndicator;
		UISprite RPMsprite;
		UISprite MPHsprite;
		float previousRPMAngle=0f;
		float previousRPMVal = 0.0f;
		float	reverseTime = 0;
	public static bool  forward = false;
	public static bool  brake = true;
	public static bool  reverse = false;
	public static bool  handBrake = false;
	public static bool  back = false;
	private int isAcceteratorPress; 
	private int isBrakePress;
	int leftMove ;
	int rightMove ;
	private static bool isLeftArrowPressed=false;
	private static bool isRightArrowPressed=false;
	public static int move ;
	public Texture gearReverse;
	public Texture gearDrive;
//	CarControl car;
	private float steerSpeedTime;
	void Start () {	
		if(this.name.Equals("Accel"))
			EnableDiableTouchControl();
		 calculateSteerSpeedTime();
//		CarMain.accellPressedValue=0f;
//	static public float reverseGear=0f;
//	 CarMain.reverseGear=false;
//	 CarMain.steerValue2=0f;
//	CarMain.brakeValue=1f;
//	CarMain.revValue=0f;
//	CarMain.brakePressed=false;
//		CarMain.handBrakValue=0f;
//		CarMain.SendInput(car,false,true);
		setCurrentRPMAngle();
		minRPMAngle= Quaternion.Euler(new Vector3(0,0,150));
	
		if(this.gameObject.name == "btnCamera"){
			btnCamera = GameObject.FindGameObjectWithTag("btnCamera");
			
			UserPrefs.currentCameraControl = 1;	
			UserPrefs.totalParkingLot = Constants.totalParkingLot[UserPrefs.currentEpisode-1 ,UserPrefs.currentLevel-1];

		}
		if(this.gameObject.name == "rpmNeedle"){
			RPMsprite = this.gameObject.GetComponent<UISprite>();
			reverseTime = 10;
		}
		if(this.gameObject.name == "mphNeedle"){
			MPHsprite = this.gameObject.GetComponent<UISprite>();
		}
	//	GameObject.FindGameObjectWithTag("GearBase").GetComponent<UIImageButton>().normalSprite = "Gear-D";
	//	GameObject.FindGameObjectWithTag("Handbrake").GetComponent<UIImageButton>().normalSprite = "handbrake-down-up";
		reverse = false;
		forward = false;
		brake = true;
		handBrake=false;
		back = false;
		isAcceteratorPress = -1;
		isBrakePress = -1;
		
}
	
	
	void calculateSteerSpeedTime()
		
	{
		int currentSteeringUpgradeLevel = 1;//VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].steeringCurrentUpgradeLevel;
				
		switch(UserPrefs.currentVehicle)
		{
		case 1:
			steerSpeedTime=0.003f; //0.003
			break;
		case 2:
			steerSpeedTime=0.004f; //0.004
			break;
		case 3:
			steerSpeedTime=0.006f; //0.006
			break;
		default:
			break;
		}
		if(currentSteeringUpgradeLevel>1)
		{
			steerSpeedTime=steerSpeedTime+(ConstantsNew.STEERING_UPGRADE_FACTOR*(currentSteeringUpgradeLevel-1));
		}
	}
	
	
	
	void setCurrentRPMAngle()
	{
		int currentEngineUpgradeLvl = 1;//VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel;
		float zAngle=60;
		if(currentEngineUpgradeLvl==1)
		{
			zAngle=60;
			currentRPMAngle= Quaternion.Euler(new Vector3(0,0,zAngle));
		}
		else if(currentEngineUpgradeLvl<=4)
		{
			 zAngle=60-(15*currentEngineUpgradeLvl);
			currentRPMAngle= Quaternion.Euler(new Vector3(0,0,zAngle));
		}
		else
		{
			zAngle=360-(20*(currentEngineUpgradeLvl-4));
			currentRPMAngle= Quaternion.Euler(new Vector3(0,0,0));
			maxRPMAngle= Quaternion.Euler(new Vector3(0,0,zAngle));
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
			
	/*	if(GameObject.FindGameObjectWithTag("Thief") == null)
		{		
//			Debug.LogError("Its not thief");
			if(UserPrefs.isAccelaratorPressed){
			if(SoundManager.Instance.vehicleEngineSoundSource.volume < 0.8f)
			{
				BackgroundSoundManager.Instance.backgrpundmusicSource.volume = .2f;
				SoundManager.Instance.vehicleEngineSoundSource.volume +=.015f; 	
			}
			}
			else{
				if(SoundManager.Instance.vehicleEngineSoundSource.volume >.5f){
					SoundManager.Instance.vehicleEngineSoundSource.volume -=.025f;
					if(SoundManager.Instance.vehicleEngineSoundSource.volume <.5f){
						BackgroundSoundManager.Instance.backgrpundmusicSource.volume += .05f;	
					}
				}			
			}					
		}
		else{
//			Debug.LogError("Thief");
			SoundManager.Instance.vehicleEngineSoundSource.volume = 0.0f;
		}
		if(Input.GetMouseButtonUp(0))
		{
					CameraRotation.isBtnClicked = false;
		}
		
		*/




//		if(UserPrefs.isAccelaratorPressed){
//			if(SoundManager.Instance.vehicleEngineSoundSource.volume < 0.5f)
//			{
//				BackgroundSoundManager.Instance.backgrpundmusicSource.volume = .7f;
//				SoundManager.Instance.vehicleEngineSoundSource.volume +=.015f;  
//			}
//		}
//		else{
//			if(SoundManager.Instance.vehicleEngineSoundSource.volume >.5f){
//				SoundManager.Instance.vehicleEngineSoundSource.volume -=.25f;
//				if(SoundManager.Instance.vehicleEngineSoundSource.volume <1f){
//					BackgroundSoundManager.Instance.backgrpundmusicSource.volume += .1f; 
//				}
//			}   
//		}




		
	//	car = GameObject.FindGameObjectWithTag("Player2").GetComponent<CarControl>();
		if(isLeftArrowPressed && stteringBtnPressedTime>-1f)
		{
			stteringBtnPressedTime-=steerSpeedTime;
//			CarMain.steerValue2=stteringBtnPressedTime;
//			CarMain.SendInput(car,false,false);
			
		}
		else if(isRightArrowPressed && stteringBtnPressedTime<1f)
		{
			stteringBtnPressedTime+=steerSpeedTime;
//			CarMain.steerValue2=stteringBtnPressedTime;
//			CarMain.SendInput(car,false,false);
			
		}
		 
		
		else if(isRightArrowPressed==false && isLeftArrowPressed==false)
		{
			if(stteringBtnPressedTime<0)
			{
				stteringBtnPressedTime+=1; //steerSpeedTime
				if(stteringBtnPressedTime>0)
				{
					stteringBtnPressedTime=0;
				}
//				CarMain.steerValue2=stteringBtnPressedTime;
//				CarMain.SendInput(car,false,false);
				
			}
			else if(stteringBtnPressedTime>0)
			{
				stteringBtnPressedTime-=1; //steerSpeedTime
				if(stteringBtnPressedTime<0)
				{
					stteringBtnPressedTime=0;
				}
//				CarMain.steerValue2=stteringBtnPressedTime;
//				CarMain.SendInput(car,false,false);
				
			}
		}
		if(this.name.Equals("Accel") && isAccel){
//			if(Input.acceleration.x * 2 <= -0.2f || Input.acceleration.x * 2 >= 0.2f)
//				CarMain.steerValue2=Input.acceleration.x * 2;
//			else 
//				CarMain.steerValue2=0;
//			CarMain.SendInput(car,false,false);
		}
		
		
	}
				
	
	void OnClick(){
		if(GameManager.Instance.GetCurrentGameState() == GameManager.GameState.GAMEPLAY){
			if(this.name.Equals("btnHome"))
			{
				if(GameManager.Instance.GetCurrentGameState()!=GameManager.GameState.PARKED)
					GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.PAUSED);
				Time.timeScale = 0;
				GameObject.Find("gamePlayEffects").GetComponent<AudioSource>().mute = true;
				try{
//					GameObject.FindObjectOfType<CounterAnimation>().DisablePlayerAudio();
				}
				catch(UnityException e){}
				GameObject.Find("SoundManager").GetComponent<AudioSource>().mute = true;

			}
			if(this.name.Equals("btnCamera"))
			{	cameraPosition++;
				if(cameraPosition> 4)
					cameraPosition = 1;
				//ChangeTexture();
				
				int temp = UserPrefs.currentCameraControl+1;
				if(temp>8 || temp<1){
					temp = 1;
				}
				UserPrefs.currentCameraControl = temp;
				GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND);
				Camera.main.GetComponent<SmoothFollow>().SetCameraAngle();
				
			}
			if(this.name.Equals("TutorialOK"))
			{
				Debug.Log("CLIVK))))))))))))))))))))))))");
				
				Resources.UnloadUnusedAssets();
				GameObject.FindGameObjectWithTag("MainCamera").gameObject.SendMessage("SetRealCamera");
				GameManager.Instance.ChangeState(GameManager.GameState.GAMEPLAY);
				Destroy(GameObject.FindGameObjectWithTag("Tutorial01"));
			}

			if(this.name.Equals("Accel")){
				isAccel = !isAccel;
				if(isAccel){
					foreach(var btn in steeringBtns){
						btn.SetActive(false);
					}
				}else{
					foreach(var btn in steeringBtns){
						btn.SetActive(true);
					}
				}
			}
			
			
		}
		
		
	}

	void EnableDiableTouchControl(){
		isAccel = UserPrefs.isTilt;
		if(isAccel){
			foreach(var btn in steeringBtns){
				btn.SetActive(false);
			}
		}else{
			foreach(var btn in steeringBtns){
				btn.SetActive(true);
			}
		}
	}

	void ChangeTexture(){
		
		if(cameraPosition == 1 ){
			
			btnCamera.GetComponentInChildren<UISprite>().spriteName = "camera-front" ;
		}
		else if(cameraPosition == 2 ){
			btnCamera.GetComponentInChildren<UISprite>().spriteName = "camera-right" ;
			
		}
		else if(cameraPosition == 3 ){
			btnCamera.GetComponentInChildren<UISprite>().spriteName = "camera-rear" ;
			
		}
		else if(cameraPosition == 4 ){
			btnCamera.GetComponentInChildren<UISprite>().spriteName = "camera-left" ;
			
		}
		
	}
	
	
	
	
	public void ScaledTimerText(int time){

		if(this.gameObject.name=="TimerText"){
			int liter = 5;
			if(time == 50){
				liter = 10;
			}else if(time == 75){
				liter = 20;
			}
			this.gameObject.GetComponent<UILabel>().text = "+"+liter+"LTR.";

		}
	}
	
	private void showTimerTextIndicator(){
		if(timerTextIndicationPanel.alpha < 1.0f && !isTimerIndicator){
			timerTextIndicationPanel.alpha += 0.05f;
		} else if(timerTextIndicationPanel.alpha > 0.0f){
			isTimerIndicator = true;
			timerTextIndicationPanel.alpha -= 0.05f;

		} else {
			timerTextIndicationPanel.alpha = 0.0f;
			isTimerIndicator = false;
		}
	}
	

	void OnPress (bool isDown)
	{

		vp = GameObject.FindGameObjectWithTag("Player2").GetComponent<VehicleParent>();
		if(this.name.Equals("btnAccel"))
		{
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
//				CameraRotation.isBtnClicked = true;

			if(!handBrake)
			{
				if(isDown)
				{
//					CarMain.handBrakValue=1f;
//					CarMain.brakePressed=true;
//					CarMain.SendInput(car,false,false);
				
						if(!isBreakPressed)
						{
							isBreakPressed = true;
							
						}
				}
				
				else if(!isDown)
				{
//					CarMain.brakePressed=false;
//					CameraRotation.isBtnClicked = false;

//					CarMain.handBrakValue=0f;
//					CarMain.brakePressed=false;

//					CarMain.SendInput(car,false,true);
						isBrakePress = -1;
						isBreakPressed = false;
						
				}
			}
		}
		
		
		if(this.name.Equals("btnHandBrake"))
		{
//			CameraRotation.isBtnClicked = true;
			if(isDown)
			{
				handBrake=!handBrake;
				if(handBrake)
					{
//					CarMain.handBrakValue=1f;
//					CarMain.SendInput(car,false,false);
					
					GameObject.FindGameObjectWithTag("Handbrake").GetComponent<UIImageButton>().normalSprite = "handbrake-up-up";  
					GameObject.FindGameObjectWithTag("Handbrake").GetComponent<UIImageButton>().hoverSprite = "handbrake-up-up";
					GameObject.FindGameObjectWithTag("Handbrake").GetComponent<UIImageButton>().pressedSprite = "handbrake-up-up";
					}
				else
					{
//						CarMain.handBrakValue=0;
//						CameraRotation.isBtnClicked = false;
						
//						CarMain.SendInput(car,false,true);
						GameObject.FindGameObjectWithTag("Handbrake").GetComponent<UIImageButton>().normalSprite = "handbrake-down-up";  
						GameObject.FindGameObjectWithTag("Handbrake").GetComponent<UIImageButton>().hoverSprite = "handbrake-down-up";
						GameObject.FindGameObjectWithTag("Handbrake").GetComponent<UIImageButton>().pressedSprite = "handbrake-down-up";
					}
				}
			

		}
		
		
		
		if(this.name.Equals("btlLeftsteer"))
		{
			if(isDown)
			{
//				CameraRotation.isBtnClicked = true;

						isLeftArrowPressed = true;
						

			}
			else if(!isDown)
			{

//				CameraRotation.isBtnClicked = false;

					isLeftArrowPressed = false;
			}
		}
		
		
			if(this.name.Equals("btnRightSteer"))
			{
				if(isDown)
				{
//					CameraRotation.isBtnClicked = true;

						isRightArrowPressed = true;
								

				}
				else if(!isDown)
				{

//					CameraRotation.isBtnClicked = false;

					isRightArrowPressed = false;
				}
			}
		
		
		
		
		if(this.name.Equals("Gear"))
			{
				if(isDown)
				{
					reverse = !reverse;
					if(reverse)
					{
//					CarMain.reverseGear=true;
					

					GameObject.FindGameObjectWithTag("GearBase").GetComponent<UIImageButton>().normalSprite = "Gear-R";  
					GameObject.FindGameObjectWithTag("GearBase").GetComponent<UIImageButton>().hoverSprite = "Gear-R";
					GameObject.FindGameObjectWithTag("GearBase").GetComponent<UIImageButton>().pressedSprite = "Gear-R";
					}
					else
					{	
//					CarMain.reverseGear=false;

					GameObject.FindGameObjectWithTag("GearBase").GetComponent<UIImageButton>().normalSprite = "Gear-D";
					GameObject.FindGameObjectWithTag("GearBase").GetComponent<UIImageButton>().hoverSprite = "Gear-D";
					GameObject.FindGameObjectWithTag("GearBase").GetComponent<UIImageButton>().pressedSprite = "Gear-D";
					}
					
				}
			}
		
		if(this.name.Equals("btnBack"))
		{
			if(isDown)
			{
//				CameraRotation.isBtnClicked = true;
//				CarMain.reverseGear=true;
//				if(CarMain.reverseGear)
				{
//					CarMain.revValue=-1f;
//					CarMain.accellPressedValue=0f;
//					
				}
//				CarMain.SendInput(car,false,false);
				
				if(!isAccelerationPressed)
				{
					isAccelerationPressed = true;
					UserPrefs.isAccelaratorPressed = isAccelerationPressed;
				}
				
			}
			
//			else if(!isDown)
//			{
//				CameraRotation.isBtnClicked = false;
//				
//				CarMain.accellPressedValue=0f;
//				CarMain.revValue=0f;
//				
//				CarMain.SendInput(car,false,false);
//				isAcceteratorPress = -1;
//				
//				isAccelerationPressed = false;
//				UserPrefs.isAccelaratorPressed =  isAccelerationPressed;
//			}
		}

		
	}
	
	
}
