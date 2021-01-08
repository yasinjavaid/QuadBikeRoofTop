using UnityEngine;
using System.Collections;

public class HudListener : MonoBehaviour {
	
	public CameraControl cam;
	public GameObject gearSlider;
	
	VehicleParent vp;
	
	public static bool isBrakePressed;
	public static bool isReverse;
	public static bool isAccel;
	public static bool isLeft;
	public static bool isRight;
	public static float steerPressedTime = 0;
	public static float accelPressedTime = 0;
	public static float brakePressedTime = 0;
	float factor = 0.1f;
	int currentCameraAngle = 1;
	public GameObject[] myIndicatorSprites;
	public GameObject otherIndicatorSprite;
	static bool isRightIndicatorEnabled = true;
	static bool isLeftIndicatorEnabled = true;
	static bool isBothIndicatorEnabled = true;
	public float maxBoost ;
	public UISprite boostSprite;
	public static bool isBoostPressed = false;
	float noseRefillamount ;
	GameObject car;
	// Use this for initialization
	void Start () {
		if(this.name.Equals("btnNitro")){
			//Debug.Log(boostSprite.transform.localScale.y);
			maxBoost = boostSprite.transform.localScale.y;
		}
		isBrakePressed = false;
		isReverse = false;
		isAccel = false;
		isLeft = false;
		isRight = false;
		steerPressedTime = 0;
		accelPressedTime = 0;
		brakePressedTime = 0;
		Invoke("FindCar",1f);
	}
	void FindCar()
	{
		car = GameObject.FindGameObjectWithTag("Player2");
	}
	void LateUpdate()
	{
		if(this.name.Equals("btnAccel") && UserPrefs.accelerometerFactor == 1){
			if(Input.acceleration.x * 2 < -0.2f || Input.acceleration.x * 2 > 0.2f)
				HudListener.steerPressedTime = Input.acceleration.x;
			else 
				HudListener.steerPressedTime = 0;
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (this.gameObject.name.Equals ("btnAccel") && isAccel) {
			accelPressedTime += factor;
		}
		else 
		if (this.gameObject.name.Equals ("btnBack") && isReverse) {
			accelPressedTime += factor;
		}
		else if (this.gameObject.name.Equals ("leftSteerBtn") && isLeft) {
			steerPressedTime -= factor * 0.1f;
		}else if (this.gameObject.name.Equals ("rightSteerBtn") && isRight) {
			steerPressedTime += factor * 0.1f;
		}
		else if(this.name.Equals("btnNitro")){
			if(isBoostPressed){
				if(boostSprite.transform.localScale.y > 0){
					if(CameraControlPPnew.distance < 20){
						CameraControlPPnew.distance += 0.05f;
					}
					Camera.main.GetComponent<MotionBlur>().enabled = true;

					Rigidbody rb = car.GetComponent<Rigidbody>();
					rb.velocity+=car.transform.forward*0.25f;
					float currentBoost;
					
					car.GetComponent<WheelControllerGenericNew>().Sparks.SetActive(true);

					//					if(UserPrefs.currentEpisode ==  1 && UserPrefs.currentLevel == 1)
					//					{
					//						currentBoost = boostSprite.transform.localScale.y - 0.5f;
					//					}
					//					else
					currentBoost = boostSprite.transform.localScale.y - UserPrefs.nitroFactor;
//					Debug.Log("Nitro :" + UserPrefs.nitroFactor);
					boostSprite.transform.localScale = new Vector3(boostSprite.transform.localScale.x,currentBoost,boostSprite.transform.localScale.z);
				}
				else{
					//					if(UserPrefs.currentEpisode == 1 && (UserPrefs.currentLevel == 3||UserPrefs.currentLevel == 4))
					//					{
					//						//GameObject nitro = GameObject.Find("btnNitro");
					//						//this.gameObject.collider.enabled = true;
					//						this.GetComponent<SteerNew>().boostSprite.transform.localScale = new Vector3(33f,82f,1f);
					//						//Time.timeScale = 1;
					//						//UserPrefs.totalCoins -= priceOfRefillNitro;
					//						//UserPrefs.Save();
					//						//Panel.SetActive(false);
					//
					//					}
					//					else{
				
					Camera.main.GetComponent<MotionBlur>().enabled = false;
					car.GetComponent<WheelControllerGenericNew>().Sparks.SetActive(false);

				
				}
			}
			else
			{
				noseRefillamount = boostSprite.transform.localScale.y;
				if(noseRefillamount < 82f)
				{
					noseRefillamount+=0.05f;
					boostSprite.transform.localScale = new Vector3(boostSprite.transform.localScale.x,noseRefillamount,1f);
				}
			}
		}
	}
	
	void OnClick(){
		if (this.gameObject.name.Equals ("rightIndicatorBtn")) {
			var carLights = GameObject.FindGameObjectWithTag("Player2").GetComponent<CarLightsControl>();
			isRightIndicatorEnabled = !isRightIndicatorEnabled;
			isBothIndicatorEnabled = true;
			isLeftIndicatorEnabled = true;
			if(!isRightIndicatorEnabled){
				otherIndicatorSprite.SetActive(false);
				myIndicatorSprites[0].SetActive(true);
				carLights.ChangeIndicatorState(2);
			}else{
				myIndicatorSprites[0].SetActive(false);
				carLights.ChangeIndicatorState(0);
			}
		}else if (this.gameObject.name.Equals ("leftIndicatorBtn")) {
			var carLights = GameObject.FindGameObjectWithTag("Player2").GetComponent<CarLightsControl>();
			isLeftIndicatorEnabled = !isLeftIndicatorEnabled;
			isRightIndicatorEnabled = true;
			isBothIndicatorEnabled = true;
			if(!isLeftIndicatorEnabled){
				otherIndicatorSprite.SetActive(false);
				myIndicatorSprites[0].SetActive(true);
				carLights.ChangeIndicatorState(1);
			}else{
				myIndicatorSprites[0].SetActive(false);
				carLights.ChangeIndicatorState(0);
			}
		}else if (this.gameObject.name.Equals ("pauseBtn")) {
			UserPrefs.soundState = UserPrefs.isSound;
			UserPrefs.isSound = false;
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.PAUSED);
			Time.timeScale = 0;
		}else if (this.gameObject.name.Equals ("hornBtn")) {
			SoundManager.Instance.CarHorn();
		}else if (this.gameObject.name.Equals ("doubleIndicatorBtn")) {
			var carLights = GameObject.FindGameObjectWithTag("Player2").GetComponent<CarLightsControl>();
			isBothIndicatorEnabled = !isBothIndicatorEnabled;
			isRightIndicatorEnabled = true;
			isLeftIndicatorEnabled = true;
			if(!isBothIndicatorEnabled){
				foreach(var light in myIndicatorSprites){
					light.SetActive(false);
				}
				foreach(var light in myIndicatorSprites){
					light.SetActive(true);
				}
				carLights.ChangeIndicatorState(3);
			}else{
				foreach(var light in myIndicatorSprites){
					light.SetActive(false);
				}
				carLights.ChangeIndicatorState(0);
			}
			
		}else if (this.gameObject.name.Equals ("cameraBtn")) {
			currentCameraAngle = currentCameraAngle == 1 ? 9 : 1;
//			cam.SetCameraAdjustments(currentCameraAngle);
		}else if (this.gameObject.name.Equals ("gearBtn")) {
			//isReverse = !isReverse;
			//gearSlider.GetComponent<MoveWithItween>().enabled = isReverse;
		}
		else if(this.gameObject.name.Equals("resetBtn"))
		{
			Transform t = GameObject.FindGameObjectWithTag("Player2").transform;
			t.eulerAngles = new Vector3(0,t.eulerAngles.y,0);
		}
	}
	
	void OnPress(bool isPressed){
		//		vp = GameObject.FindGameObjectWithTag("Player2").GetComponent<VehicleParent>();
		if (isPressed) {
			if (this.gameObject.name.Equals ("btnAccel")) {
				//				if(!isReverse){
				//					vp.SetAccel(1f);
				//					vp.SetBrake(0);
				//				}
				//				else
				//					vp.SetBrake(1f);
				isAccel = true;
			}
			else if (this.gameObject.name.Equals("btnBack"))
			{
				isReverse = true;
			}
			else if (this.gameObject.name.Equals ("btnBrake")) {
				isBrakePressed = true;
				//				vp.SetAccel(0);
				//				vp.SetEbrake(1f);
				brakePressedTime = 1;
			}else if (this.gameObject.name.Equals ("leftSteerBtn")) {
				//				vp.SetSteer(-1f);
				isLeft = true;
			}else if (this.gameObject.name.Equals ("rightSteerBtn")) {
				//				vp.SetSteer(1f);
				isRight = true;
			}
			else if(this.name.Equals("btnNitro")){
				isBoostPressed = isPressed;
				//Camera.main.GetComponent<MotionBlur>().enabled = isPressed;
			//	GameObject.Find("Sparks").SetActive(isPressed);
				HudListener.isAccel=isPressed ;
				if(isPressed)
				{
					
					accelPressedTime=1f;
				}
				else
					accelPressedTime=0;
				//CarMain.SendInput(car,false,false);
				if(!isPressed){
					StartCoroutine(StopCar());
					
					Camera.main.GetComponent<MotionBlur>().enabled = false;
				}
			}
		} else {
			if (this.gameObject.name.Equals ("btnAccel")) {
				//				if(!isReverse)
				//					vp.SetAccel(0f);
				//				else
				//					vp.SetBrake(0f);
				isAccel = false;
				accelPressedTime = 0;
			}
			else if (this.gameObject.name.Equals("btnBack"))
			{
				isReverse = false;
				accelPressedTime = 0;
			}
			else if (this.gameObject.name.Equals ("btnBrake")) {
				isBrakePressed = false;
				//				vp.SetEbrake(0f);
				brakePressedTime = 0;
			}else if (this.gameObject.name.Equals ("leftSteerBtn")) {
				//				vp.SetSteer(0f);
				isLeft = false;
				steerPressedTime = 0;
			}else if (this.gameObject.name.Equals ("rightSteerBtn")) {
				//				vp.SetSteer(0f);
				isRight = false;
				steerPressedTime = 0;
			}
			else if(this.name.Equals("btnNitro")){
					isBoostPressed = isPressed;
		Camera.main.GetComponent<MotionBlur>().enabled = isPressed;
				//GameObject.Find("Sparks").GetComponent<ParticleEmitter>().emit = isPressed;
				car.GetComponent<WheelControllerGenericNew>().Sparks.SetActive(isPressed);

				HudListener.isAccel=isPressed ;
				if(isPressed)
				{
					
					accelPressedTime=1f;
				}
				else
					accelPressedTime=0;
				//CarMain.SendInput(car,false,false);
				if(!isPressed){
					StartCoroutine(StopCar());
					
					Camera.main.GetComponent<MotionBlur>().enabled = false;
				}
			}
		}
	}
	IEnumerator StopCar(){
		
		yield return new WaitForSeconds(1);
		if(!UserPrefs.isAccelaratorPressed){
			HudListener.accelPressedTime=0;
			//CarMain.SendInput(car,false,false);
		}
	}
}
