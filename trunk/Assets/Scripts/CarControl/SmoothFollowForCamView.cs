

using UnityEngine;
using System.Collections;

public class SmoothFollowForCamView: MonoBehaviour {
/*
This camera smoothes out rotation around the y-axis and height.
Horizontal Distance to the target is always fixed.

There are many different ways to smooth the rotation but doing it this way gives you a lot of control over how the camera behaves.

For every of those smoothed values we calculate the wanted value and the current value.
Then we smooth it using the Lerp function.
Then we apply the smoothed values to the transform's position.
*/

// The target we are following
	public static Transform TargetTwo;
public static Transform target;
public static	Vector3 originalPos;
	public static float shakeAmount = 0.07f;
// The distance in the x-z plane to the target
public static float distance;
// the height we want the camera to be above the target
public  static float height;
// How much we 
public float heightDamping= 2.0f;
public float rotationDamping= 3.0f;
private int lerpSpeed = 8;
	private Vector3 lastPos = Vector3.zero;
	private Vector3 currentVelocity = Vector3.zero;
	public bool reset = true;		
private float localHeight;
	public static bool shakeStart=false;
	public float velocityDamping = 5.0f;
	public bool followVelocity = true;
	private float wantedRotationAngle = 0.0f;
	public float targetHeightRatio = 0.5f;
	public static bool leftView = false,rightView = false, backView = false, frontView = false, defaultView = false;

	float backPressTime;
	bool isTimeSaved=false;
	bool CamRotated = false;
	public  float h,d;
	float elapsed = 0.0f;
// Place the script in the Camera-Control group in the component menu
//@script AddComponentMenu("Camera-Control/Smooth Follow")
	void Start(){
		 elapsed = 0.0f;
		Debug.Log("in on start");
	//	this.setCurrentVehicles();
		Invoke ("InitiateCar", 1f);
	//	this.setCameraDistanceHeight();
		height = h;
		distance = d;
		//UserPrefs.currentCameraControl = 1;
		//this.SetCameraFOVForIphone();
		localHeight = height;
		shakeStart=false;
	//	StartCoroutine(Shake(5f));
		if(UserPrefs.currentLevel == 8)
		{
			this.transform.position = new Vector3(this.transform.position.x,5000f,this.transform.position.z);
		}
		leftView = false;rightView = false; backView = false; frontView = true; defaultView = false;
	}
	void Update()
	{

//		Debug.Log(distance + " G "+ height);
//		Debug.Log("D: "+distance + " H: "+height);
		//distance = 7f;
	//	height = 3.5f;
		height = h;
		distance = d;
		if(shakeStart)
		{

			

			float duration=1.5f;
			if (elapsed < duration) {
				
				elapsed += Time.deltaTime;          
				
				float percentComplete = elapsed / duration;         
				float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);
				float magnitude=2f;
				// map value to [-1, 1]
				target.gameObject.transform.localPosition=originalPos+ Random.insideUnitSphere * shakeAmount;
				//			target.gameObject.transform.localPosition.y= Random.insideUnitSphere.y * magnitude + 1.78f;
				
				//			yield return null;
			}
			else
			{
				target.gameObject.transform.localPosition=originalPos;
				shakeStart=false;
				elapsed=0f;
//				StartCoroutine(Shake(5f));
			}

					
		}


//		height = Mathf.Lerp(height,CameraRotation.y/8  , Time.deltaTime * lerpSpeed);
//		if(height < 0.4f)
//			height = 0.4f;
//		if(height > 1)
//			height = 1.0f;
	}
	

	void  LateUpdate (){
//		/*if(GameManager.Instance.GetCurrentGameState()!=GameManager.GameState.GAMEPLAY){
//			return;
//		}*/
//		// Early out if we don't have a target
//		if (!target)
//			return;
//
//			// Calculate the current rotation angles
//			float wantedRotationAngle= target.eulerAngles.y;
//			float wantedHeight= target.position.y + height;
//				
//			float currentRotationAngle= transform.eulerAngles.y;
//			float currentHeight= transform.position.y;
//			
//			// Damp the rotation around the y-axis
//			currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
//		
//			// Damp the height
//			currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
//		
//			// Convert the angle into a rotation
//			Quaternion currentRotation= Quaternion.Euler (0, currentRotationAngle, 0);
//			
//			// Set the position of the camera on the x-z plane to:
//			// distance meters behind the target
//			transform.position = target.position;
//			transform.position -= currentRotation * Vector3.forward * distance;
//		
//			// Set the height of the camera
//			transform.position = new Vector3(transform.position.x,currentHeight,transform.position.z);
//			
//			// Always look at the target
//			transform.LookAt (target);

		if (!target)
			return;
		
		if (reset) {
			lastPos = target.position;
			wantedRotationAngle = target.eulerAngles.y;
			currentVelocity = target.forward * 2.0f;
			reset = false;
		}
		
		Vector3 updatedVelocity = (target.position - lastPos) / Time.deltaTime;
		updatedVelocity.y = 0.0f;
		
	

		if (updatedVelocity.magnitude > 1.0f) {
			if(defaultView)
			{
				currentVelocity = Vector3.Lerp (currentVelocity, updatedVelocity, velocityDamping * Time.deltaTime);
			}
			else if(backView)
			{
				currentVelocity = target.forward;
			}
			else if(frontView)
			{
				currentVelocity = -target.forward;
			}
			else if(leftView)
			{
				currentVelocity = target.right;
			}
			else if(rightView)
			{
				currentVelocity = -target.right;
			}
			else
			{
				currentVelocity = Vector3.Lerp (currentVelocity, updatedVelocity, velocityDamping * Time.deltaTime);
			}
			wantedRotationAngle = Mathf.Atan2 (currentVelocity.x, currentVelocity.z) * Mathf.Rad2Deg;
		}
		lastPos = target.position;
		
		if (!followVelocity)
			wantedRotationAngle = target.transform.eulerAngles.y;
		
		
		/*
		var velocity = (target.position - lastPos) / Time.deltaTime;
		velocity.y = 0.0;
		

		var wantedRotationAngle = target.eulerAngles.y;
		if (velocity.magnitude > 1.0)
			wantedRotationAngle = Mathf.Atan2(velocity.x, velocity.z) * Mathf.Rad2Deg;
		lastPos = target.position;
		*/
		
		
		
		float wantedHeight = target.position.y + height;
		
		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;
		
		
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
		
		
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
		

		Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
		
//		Debug.Log(currentRotation);
		transform.position = target.position;
//		Debug.Log(CarMain.reverseGear);
//		if(CarMain.reverseGear && UserPrefs.rpmValue > 40f)
//		{
//			transform.position -= currentRotation * Vector3.forward * distance;
//		}
//		else if(!CarMain.reverseGear)
//		{
//			transform.position -= currentRotation * Vector3.forward * distance;
//		}
//		else
//		{
//			transform.position -= Vector3.forward * distance;
//		}


		/*

		if(SteerNew.isBackPress && !isTimeSaved && CarMain.reverseGear)
		{
			backPressTime = Time.time;
			backPressTime +=2f;
			isTimeSaved = true;

		}
		if(!SteerNew.isBackPress)
		{
			isTimeSaved = false;
		}
		if(isTimeSaved && Time.time> backPressTime)
		{
			transform.position -= currentRotation * Vector3.forward * distance;
			CamRotated = true;
		}
		else if(Time.time<backPressTime)
		{
			CamRotated = false;
			//Quaternion q = new Quaternion(0,0,0,1f);
			transform.position -= Vector3.forward * distance;
		}
		else if(CamRotated)
		{
			transform.position -= currentRotation * Vector3.forward * distance;
		}
		else 
		{
			CamRotated = false;
			Quaternion q = new Quaternion(0,0,0,1f);
			transform.position -= Vector3.forward * distance;
		}

		*/


		transform.position -= currentRotation * Vector3.forward * distance;



		
		Vector3 t = transform.position;
		t.y = currentHeight;
		transform.position = t;
		
		if(TargetTwo==null)
			transform.LookAt (target.position + Vector3.up * height * targetHeightRatio);
		else
			transform.LookAt (TargetTwo);
//		if (target.GetComponent<Rigidbody>()) {
//			
//			Vector3 CoM = Vector3.Scale (target.GetComponent<Rigidbody>().centerOfMass, new  Vector3 (1.0f / target.transform.localScale.x, 1.0f / target.transform.localScale.y, 1.0f / target.transform.localScale.z));
//			CoM = target.transform.TransformPoint (CoM);
//			
//			transform.LookAt (CoM + Vector3.up * height * targetHeightRatio);
//		} else{
//			if(TargetTwo==null)
//			transform.LookAt (target.position + Vector3.up * height * targetHeightRatio);
//			else
//				transform.LookAt (TargetTwo);
//		}

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
	

	
	
	
	

	
	private void SetDefaultsPosition(){
	//	distance = 20.0f;
	//	height = 3.0f;
	}
	
	private void InitiateCar(){
		
//		if(UserPrefs.currentVehicle == 1){
//			//UserPrefs.accelerometerFactor = 2;
//			Instantiate(Resources.Load("Vehicles/SportsCar1"),new Vector3(0,100,0),Quaternion.identity);			
//		}else if(UserPrefs.currentVehicle == 2){
//			Instantiate(Resources.Load("Vehicles/Car01"),new Vector3(0,100,0),Quaternion.identity);			
//		}else if(UserPrefs.currentVehicle == 3){
//			Instantiate(Resources.Load("Vehicles/SportsCar3"),new Vector3(0,100,0),Quaternion.identity);
//		}
//		else if(UserPrefs.currentVehicle == 4){
//			Instantiate(Resources.Load("Vehicles/SportsCar4"),new Vector3(0,100,0),Quaternion.identity);
//		}
//		else if(UserPrefs.currentVehicle == 5){
//			Instantiate(Resources.Load("Vehicles/Truck3-M3"),new Vector3(0,100,0),Quaternion.identity);
//		}
//		else if(UserPrefs.currentVehicle == 6){
//			Instantiate(Resources.Load("Vehicles/Truck3-M3"),new Vector3(0,100,0),Quaternion.identity);
//		}
//		else if(UserPrefs.currentVehicle == 7){
//			Instantiate(Resources.Load("Vehicles/Truck2-M2"),new Vector3(0,100,0),Quaternion.identity);
//		}
//		else if(UserPrefs.currentVehicle == 8){
//			Instantiate(Resources.Load("Vehicles/Truck3-M2"),new Vector3(0,100,0),Quaternion.identity);
//		}
//		else if(UserPrefs.currentVehicle == 9){
//			Instantiate(Resources.Load("Vehicles/Truck4-M2"),new Vector3(0,100,0),Quaternion.identity);
//		}
//		else if(UserPrefs.currentVehicle == 10){
//			Instantiate(Resources.Load("Vehicles/Truck5-M2"),new Vector3(0,100,0),Quaternion.identity);
//		}
//		else if(UserPrefs.currentVehicle == 11){
//			Instantiate(Resources.Load("Vehicles/Truck1-M3"),new Vector3(0,100,0),Quaternion.identity);
//		}
//		else if(UserPrefs.currentVehicle == 12){
//			Instantiate(Resources.Load("Vehicles/Truck2-M3"),new Vector3(0,100,0),Quaternion.identity);
//		}
//		else if(UserPrefs.currentVehicle == 13){
//			Instantiate(Resources.Load("Vehicles/Truck3-M3"),new Vector3(0,100,0),Quaternion.identity);
//		}
//		else if(UserPrefs.currentVehicle == 14){
//			Instantiate(Resources.Load("Vehicles/Truck4-M3"),new Vector3(0,100,0),Quaternion.identity);
//		}
//		else if(UserPrefs.currentVehicle == 15){
//			Instantiate(Resources.Load("Vehicles/Truck5-M3"),new Vector3(0,100,0),Quaternion.identity);
//		}
	//	defaultView = true;
//		Debug.Log("in InitiateCar");
//		if(UserPrefs.currentEpisode==1 && UserPrefs.currentLevel==1 && !UserPrefs.isTutorialSeen)
//		{
//			target=GameObject.FindGameObjectWithTag("Thief").transform;
//		
//		}else
//		{
			target=GameObject.FindGameObjectWithTag("Player2").transform;

//		}
		
		
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
			distance = 5.5f;
			height = 1.5f;
			CameraControlPPnew.distance=distance;
			CameraControlPPnew.height=height;
			CameraControlPP.distance=distance;
			CameraControlPP.height=height;
		} else if(UserPrefs.currentVehicle == 2){
			distance = 5.5f;
			height = 1.5f;
			CameraControlPPnew.distance=distance;
			CameraControlPPnew.height=height;
			CameraControlPP.distance=distance;
			CameraControlPP.height=height;
		} else if(UserPrefs.currentVehicle == 3){
		
			distance = 5.5f;
			height = 2f;
			CameraControlPPnew.distance=distance;
			CameraControlPPnew.height=height;
			CameraControlPP.distance=distance;
			CameraControlPP.height=height;
		}		
	}
public void RightViewCamera()
	{

		frontView = false;
		rightView = true;
	}
public bool isNewMenu()
	{
		if(GameObject.Find("MenuManager").GetComponent<MenuManager>().menuType==2)
		{
			return true;
		}
		return false;
	}

	public static void StartShake()
	{
		originalPos = target.gameObject.transform.localPosition;
		shakeStart=true;

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