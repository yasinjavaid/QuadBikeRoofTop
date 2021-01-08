using UnityEngine;
using System.Collections;

public class CamAnimation : MonoBehaviour {

	// Use this for initialization
	public float waitToSwitch = 2f;
	public GameObject SwitchCamera1;
	public GameObject SwitchCamera2;
	public bool camAnimation=false;
	GameObject skidSound;
	GameObject engine;
	public GameObject [] points;
	bool isIncreament = true;
	float pitchVal = 0;
	AudioSource engineSource;
	GameObject p;
	VehicleParent vp;
	public GameObject [] arrows;
	public GameObject text1;
	public GameObject text2;
	public GameObject Camera1;
	public GameObject Camera2;
	public GameObject text3;
	public GameObject three;
	public GameObject two;
	public GameObject one;
	bool dataloaded = false;
	private EnginePowerManager ePM;
	void LoadAsset()
	{
		dataloaded = false;
		if (Constants.isBossMode) {
			LevelsData lvl=GameObject.FindObjectOfType<LevelsData>();
			lvl.HelipadEnemyInstantiateBoss();
		}
//		if (UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 5 || UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 8) {
//			three.SetActive(false);
//			two.SetActive(false);
//			one.SetActive(false);
//			text1.GetComponent<TextMesh>().text="Race Mode";
//			text1.GetComponent<TextMesh>().color=Color.red;
//			text2.GetComponent<TextMesh>().text=" Follow the red points to complete the lap";
//			text2.GetComponent<TextMesh>().color=Color.red;
//			text3.GetComponent<TextMesh>().text="Complete the lap in Given time";
//			text3.GetComponent<TextMesh>().color=Color.red;
//			Camera1.transform.position=SwitchCamera1.transform.position;
//			Camera1.transform.localRotation=SwitchCamera1.transform.localRotation;
//			Camera2.transform.position=SwitchCamera2.transform.position;
//			Camera2.transform.localRotation=SwitchCamera2.transform.localRotation;
//			foreach ( GameObject arrow in arrows)
//			{
//				arrow.SetActive(true);
//			}
//		}
		
		
		StartCoroutine("anim");


	}
	void Start () {

		Invoke ("LoadAsset", 1.0f);

	}
	
	// Update is called once per frame
	void Update () {
		if(engineSource!=null){

			if(isIncreament)
			{
				pitchVal = Mathf.Clamp(pitchVal+=0.025f,0f,3f);
			}
			else
			{
				pitchVal = Mathf.Clamp(pitchVal-=0.02f,0f,3f);
			}
			engineSource.pitch = pitchVal;

		}
		if(Input.GetMouseButtonUp(0) && dataloaded)
		{
			SkipTime();
		}
	}
	void Loaded()
	{
		UserPrefs.isLoaded = true;
	}
	void SkipTime()
	{
		Invoke("Loaded",2f);
		camAnimation = true;
		points[3].SetActive(false);
		vp.SetAccel(0);
		vp.SetBrake(0);
	
		if (!Constants.isBossMode) {
			EnemyCar [] en = GameObject.FindObjectsOfType<EnemyCar> ();
			foreach (EnemyCar e in en) {
				e.FindTargets ();
			}

		}

		UserPrefs.isAccelaratorPressed = false;
		SteerNew.isBackAccelerationPressed = false;
		//
		if(!Constants.isBossMode)
		p.GetComponent<Rigidbody>().isKinematic = false;

		engineSource = null;
	
		if (UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 1) {
			GameObject.FindObjectOfType<HudStatus> ().SetInstructionText (this.gameObject);
		}
		if (UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 3||UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 5||UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 8) {
			GameObject.FindObjectOfType<HudStatus> ().SetInstructionText (this.gameObject);
		}
		if (UserPrefs.currentEpisode == 2&& UserPrefs.currentLevel == 1) {

			GameObject.FindObjectOfType<HudStatus> ().SetInstructionText (this.gameObject);
		}
		if (UserPrefs.currentEpisode == 3&& UserPrefs.currentLevel == 1) {
			
			GameObject.FindObjectOfType<HudStatus> ().SetInstructionText (this.gameObject);
		}

			this.gameObject.SetActive (false);
	
	


	}
	IEnumerator anim()
	{
		if(!Constants.isBossMode)
		yield return new WaitForSeconds(1.3f);


		p = GameObject.FindGameObjectWithTag("Player2");

		vp = p.GetComponent<VehicleParent>();
		vp.SetAccel(1f);
		vp.SetBrake(1f);
		UserPrefs.isAccelaratorPressed = true;
		SteerNew.isBackAccelerationPressed = true;
		this.transform.position = p.transform.position;
		this.transform.rotation = p.transform.rotation;
		points[0].SetActive(true);
		if(UserPrefs.isSound && !Constants.isBossMode)
		{
			SoundManager.Instance.GetComponent<AudioSource>().PlayOneShot(SoundManager.Instance.countSound);
		}
		skidSound = p.transform.FindChild("tirescreech").gameObject;
		engine = p.GetComponent<VehicleDamage>().damageParts[0].gameObject;
		engine.GetComponent<AudioSource>().volume = 0.3f;
		engineSource = engine.GetComponent<AudioSource>();
	//	engine.GetComponent<GasMotor>().enabled = false;
		skidSound.SetActive(false);


		//
		yield return new WaitForSeconds(0.2f);
		p.GetComponent<Rigidbody>().isKinematic = true;

		dataloaded = true;
		if (Constants.isBossMode)
			SkipTime ();
		yield return new WaitForSeconds(waitToSwitch);
		points[0].SetActive(false);
		points[1].SetActive(true);
		if(UserPrefs.isSound)
		{
			SoundManager.Instance.GetComponent<AudioSource>().PlayOneShot(SoundManager.Instance.countSound);
		}
		//
		yield return new WaitForSeconds(waitToSwitch);
		points[1].SetActive(false);
		points[2].SetActive(true);
		if(UserPrefs.isSound)
		{
			SoundManager.Instance.GetComponent<AudioSource>().PlayOneShot(SoundManager.Instance.countSound);
		}
		vp.SetAccel(0);
		vp.SetBrake (0);
		//
		yield return new WaitForSeconds(waitToSwitch);
		points[2].SetActive(false);
		points[3].SetActive(true);
		if(UserPrefs.isSound)
		{
			SoundManager.Instance.GetComponent<AudioSource>().PlayOneShot(SoundManager.Instance.goSound);
		}
		skidSound.SetActive(true);
		isIncreament = false;
		//

		yield return new WaitForSeconds(waitToSwitch);
		SkipTime();


	}
}
