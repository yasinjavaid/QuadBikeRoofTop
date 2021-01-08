using UnityEngine;
using System.Collections;

public class HudStatus : MonoBehaviour {

	public GameObject mphNeedle;
	public GameObject rpmNeedle;
	public GameObject fuelNeedle;
	public UILabel lblSpeedCamera;
	public UILabel lblDistance;
	public UILabel lblTopSpeed;
	public UILabel lblTopSpeedIndicator;
	public UILabel lowSpeedWarning;
	public UILabel GainSpeed;
	public UILabel TimeText;
	public UILabel time;
	VehicleStats stats;
	public bool speedThresholdless=true;
	private int  counter = 6;
	public GameObject Green;
	public bool islevelFail=false;
	public UILabel lblName;
	[HideInInspector]
	public Level lvl;
	public UILabel countDown;
	public UILabel instructionLbl;
	public GameObject TutorialPanel;
	public GameObject upgradePanel;
	public GameObject resetPanel;
	public UILabel Go;
	public static bool GoDisable=false;
	public GameObject recording;
	public UILabel LapNo;
	public UILabel timeLbl;
	public GameObject laptimeBG;
	public UISlider HealthBar;
	public bool isCanel=false;

	public GameObject tutorialScript;
	// Use this for initialization
	void Start () {
		lblTopSpeed.text = string.Format ("{0:00} KM/H" , UserPrefs.topSpeed);
		isCanel = false;
	}
	
	// Update is called once per frame
	void LateUpdate () {
//		if (stats == null) {
//			stats = GameObject.FindObjectOfType<VehicleStats> ();
//			if(stats == null)
//				return;
//		}
//
//		mphNeedle.transform.localEulerAngles = new Vector3(0,0,126 - ((stats.Speed/300) * 252)); 
//		rpmNeedle.transform.localEulerAngles = new Vector3(0,0,110 - ((stats.RPM/9000) * 220)); 
//		if(!(UserPrefs.currentFuel % 360 >= 76 && UserPrefs.currentFuel % 360 <= 77))
//			fuelNeedle.transform.localEulerAngles = new Vector3(0,0,fuelNeedle.transform.localEulerAngles.z + 0.01f); 
//		UserPrefs.currentFuel = fuelNeedle.transform.localEulerAngles.z;
//		//lblDistance.text = string.Format ("{0:00.0} KM" , stats.Distance*10f);

	}

	public void ShowTopSpeedIndicator(){
		lblTopSpeedIndicator.enabled = true;
		lblTopSpeedIndicator.GetComponent<TweenScale>().enabled = true;
		lblTopSpeed.text = string.Format ("{0:00} KM/H" , UserPrefs.topSpeed);
	}

	void DisableTopSpeedIndicator(){
		lblTopSpeedIndicator.enabled = false;
		lblTopSpeedIndicator.GetComponent<TweenScale>().enabled = false;
	}

	public void ShowLowSpeedWarning()
	{

			Go.gameObject.SetActive (true);
			

			
			counter = 4;
			speedThresholdless = true;
			lowSpeedWaringEnabler ();
		lowSpeedWarning.color = Color.red;
			lowSpeedWarning.text = "3";
		Go.color = Color.red;

	}
	public void lowSpeedWaringEnabler(){
		
		iTween.ScaleFrom (Go.gameObject, iTween.Hash ("x", 160, "y", 160, "time", 1f, "isLocal", true, "easeType", iTween.EaseType.linear, "oncomplete", "DecrementCounter","oncompletetarget",this.gameObject));
		
		
		
	}
	
	
	
	void DecrementCounter(){
		counter --;
		if (counter > 0) {
			if(counter==2)
				Go.color=Color.blue;
			if(counter==1)
			{
				Go.color=Color.yellow;}
			Go.text = counter.ToString ();

		}
		if (counter == 0){
			Go.color=Color.green;
			Go.text="Go!";

			StartCoroutine(WaitandDisable());


		}
		lowSpeedWaringEnabler();
		
	}
	
	public void DisableLowSpeedWarning()
	{
		lowSpeedWarning.gameObject.SetActive (false);
		GainSpeed.gameObject.SetActive(false) ;
		speedThresholdless = false;
	}
	
	public void ShowSpeedCameraLabel(bool show){
		lblSpeedCamera.enabled = show;
		if (show) {
			var speed = GameObject.FindObjectOfType<VehicleStats> ().Speed;
			lblSpeedCamera.text = string.Format ("{0:00} KM/H", speed);
			SpeedCamera.currentCameraSpeed = speed;
		}
	}
	IEnumerator LowSpeedText(float waitTime,string value) {
		yield return new WaitForSeconds(waitTime);
		
		lowSpeedWarning.text = string.Format (value);
		
	}
	public void activeUpgradePanel()
	{
//		soundState = UserPrefs.isSound;
	
		upgradePanel.SetActive (true);

		Time.timeScale = 0;



	}
	public void activeResetPanel()
	{

//		soundState = UserPrefs.isSound;

		resetPanel.SetActive (true);
		Time.timeScale = 0;

	}

	public void SetInstructionText(GameObject object1 )
	{

//		Level lvl = GameObject.FindObjectOfType<Level> ();
//
//		if (lvl.type == Level.LevelType.Distance) {
//			instructionLbl.text="Cover "+lvl.TotalVal+"m before you get caught from Cops Chasing you!";
//
//
//		}
//		else if (lvl.type == Level.LevelType.TimeZone) {
//			instructionLbl.text="Drive "+lvl.TotalVal+"s before you get caught from Cops Chasing you!";
//				
//				
//		}
//		else if (lvl.type == Level.LevelType.Hit) {
//			instructionLbl.text="Destory "+lvl.TotalVal+" Blocking police cars and don't get caught";
//				
//				
//		}
//		else if (lvl.type == Level.LevelType.EndPoint) {
//			if(UserPrefs.currentEpisode==1&&UserPrefs.currentLevel==10)
//				instructionLbl.text="You are heading with Drugs follow the arrow to reach the delivery point";
//			if(UserPrefs.currentEpisode==1&&UserPrefs.currentLevel==11)
//				instructionLbl.text="Your car is full of explosive material deliver it to the destination";
//			if(UserPrefs.currentEpisode==1&&UserPrefs.currentLevel==12)
//				instructionLbl.text="Be Quick!reach at the destination and don't get caught from police as you have DON sitting with you";
//			if(UserPrefs.currentEpisode==2)
//			{
//				int value=Random.Range(0,3);
//				if(value==0)
//				instructionLbl.text="Be Quick!reach at the destination and don't get caught from police as you have DON sitting with you";
//				if(value==1)
//					instructionLbl.text="Drive Fast and Furious and reach to the destination with the Drugs";
//				if(value==2)
//				{
//					instructionLbl.text="Follow the Arrow Reach at the drug dealer place";
//
//				}
//
//			}
//
//		}
		if (UserPrefs.currentEpisode == 1) {
			if(UserPrefs.currentLevel==1){
				instructionLbl.text="Drag and throw all the opponents off the Helipad to WIN";
				UserPrefs.isTutorial=true;

			}

			if(UserPrefs.currentLevel==3)
			{
				instructionLbl.text="Drag and throw all the opponents off the Helipad to WIN";


			}
			if(UserPrefs.currentLevel==5)
			{

				instructionLbl.text="Drag and throw all the opponents off the Helipad to WIN";

			}
			if(UserPrefs.currentLevel==8)
			{
				instructionLbl.text="Drag and throw all the opponents off the Helipad to WIN";

			}

		}
		if (UserPrefs.currentEpisode == 3) {

			instructionLbl.text="Drag and throw all the opponents off the Island to WIN";
		}
		if (UserPrefs.currentEpisode == 2) {
			instructionLbl.text="Drag and throw all the opponents off the Rock in to Lava to WIN";
			UserPrefs.isTutorial=true;

		}

		TutorialPanel.SetActive(true);


		//UserPrefs.isSound = false;
		object1.SetActive (false);
		if(!Constants.isBossMode)
		Time.timeScale = 0;


	}

	public void SetNitrousDialogue()
	{
		instructionLbl.text="Use Nitrous to hit the car with more velocity";
		TutorialPanel.SetActive (true);
		Transform t = TutorialPanel.transform.FindChild("Arrow3D").transform;
		t.localPosition = new Vector3(401.8f,61.0f,0f);
		t.localEulerAngles = new Vector3(0f,0f,-90f);
		t.localScale = new Vector3(100f,100,100f);


	}
	IEnumerator WaitandDisable() {
		yield return new WaitForSeconds(1f);
		Go.gameObject.SetActive (false);
		returnValue (true);

	}
	public bool returnValue(bool value)
	{

		if (value == true)
			return false;
		else
			return false;
	}
	public void TutorialInstructionText(string text)
	{

		instructionLbl.text=text;
		TutorialPanel.SetActive(true);
		
//		soundState = UserPrefs.isSound;
		//UserPrefs.isSound = false;

		Time.timeScale = 0;
	}

}
