using UnityEngine;
using System.Collections;

public class HudMenuLocalize : MonoBehaviour {

	public UILabel lbTimeRemaining ;

	public UILabel lblSpeed;
	public UILabel lblDistance;
	public UILabel lblTopSpeed;
	public UILabel lblTopSpeedIndicator;
	public UILabel lblSpeedCamera;
	public UILabel lowSpeedWarning;
	public UILabel GainSpeed;
	public GameObject mphNeedle;
	public GameObject rpmNeedle;

	VehicleStats stats;
	public bool islevelFail=false;
	public bool speedThresholdless=true;
	private int  counter = 6;
	public GameObject Green;

	// Use this for initialization
	void Start () {
		stats = GameObject.FindObjectOfType<VehicleStats> ();
//		lbTimeRemaining.GetComponent<UILabel>().text =     LocalizableString.lbTimeRemaining.ToString();
		lblTopSpeed.text = string.Format ("{0:00} KM/H" , UserPrefs.topSpeed);
	}
	
	// Update is called once per frame
	void LateUpdate () {
//		lbTimeRemaining.GetComponent<UILabel>().text =   UserPrefs.remainingtTimeForCurrentLevel;

		if (stats == null)
			stats = GameObject.FindObjectOfType<VehicleStats> ();

		try{
			lblSpeed.text = string.Format ("{0:00} KM/H" , stats.Speed);
			lblDistance.text = string.Format ("{0:00.0} KM" , stats.Distance);
			mphNeedle.transform.localEulerAngles = new Vector3(0,0,140 - ((stats.Speed/300) * 270)); 
			rpmNeedle.transform.localEulerAngles = new Vector3(0,0,114 - ((stats.RPM/9000) * 227)); 
		}catch(System.NullReferenceException ex){
			
		}
		
	}

	public void ShowEnterButton(bool enable){
//		enterBtn.SetActive(enable);
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
		if (!speedThresholdless) {
			GainSpeed.gameObject.SetActive (true);
			lowSpeedWarning.gameObject.SetActive (true);
			GainSpeed.enabled = true;
			lowSpeedWarning.enabled = true;
			counter = 3;
			speedThresholdless = true;
			lowSpeedWaringEnabler ();
			lowSpeedWarning.text = "3";
		}
	}
	public void lowSpeedWaringEnabler(){

		iTween.ScaleFrom (lowSpeedWarning.gameObject, iTween.Hash ("x", 160, "y", 160, "time", 1f, "isLocal", true, "easeType", iTween.EaseType.linear, "oncomplete", "DecrementCounter","oncompletetarget",this.gameObject));



	}



	void DecrementCounter(){
			counter --;
		lowSpeedWarning.text = counter.ToString ();
		if (counter == 0){
				islevelFail = true;
				return;
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
}
