using UnityEngine;
using System.Collections;
using EVP;
public class FollowAiEdy : MonoBehaviour {

	// Use this for initialization
	public Transform [] WayPoint;
	public GameObject [] WayPoint1;
	private VehicleController VC;
	private float value=0.0f;
	private float value1=0.0f;
	GameObject hud;
	int counter=0;
	public bool FollowAI=true;
	private float maxSpeedForward;
	private float maxDriveForce;
	private bool UpdateCheck=true;
	private bool lateUpdateStopper =false;
	private GameObject wayPoint;
	private GameObject policeCar;
	private bool GoCheck=false;
	private float mass;

	void Start () {

		GoCheck = false;
		Camera.main.transform.position = Vector3.zero;
		wayPoint = GameObject.FindGameObjectWithTag ("WayPoint");
		counter = 1;
		//policeCar = GameObject.FindGameObjectWithTag ("PoliceCar");
		WayPoint = wayPoint.transform.GetComponentsInChildren<Transform> ();
		//policeCar.GetComponent<FollowAI> ().target = this.gameObject.transform;
//		foreach (Transform wp in wayPoint.transform) {
//			 WayPoint [counter]=wp;
//			counter++;
//		}
		Camera.main.GetComponent<SmoothFollow> ().enabled = true;
		//for firsr four levels

		VC = GetComponent<VehicleController> ();

		maxSpeedForward = this.gameObject.GetComponent<VehicleController> ().maxSpeedForward;
		maxDriveForce = this.gameObject.GetComponent<VehicleController> ().maxDriveForce;

	
		hud = GameObject.FindGameObjectWithTag ("Hud");

		hud.GetComponentInChildren<Camera> ().enabled = true;
		Camera.main.GetComponent<CameraControl> ().enabled = false;
		if(UserPrefs.currentLevel%3!=1&&UserPrefs.currentEpisode==1||UserPrefs.currentEpisode==2)
		{
			this.gameObject.GetComponent<VehicleController> ().maxSpeedForward = 700;
			this.gameObject.GetComponent<VehicleController> ().maxDriveForce = 6000;

			hud.GetComponent<HudStatus>().ShowLowSpeedWarning();
			Camera.main.GetComponent<SmoothFollowForCamView> ().enabled = false;
			Camera.main.GetComponent<SmoothFollow> ().target=this.gameObject.transform.FindChild("EmptyBody");
			SmoothFollow.distance=8f;
			SmoothFollow.height=2f;
			SmoothFollowForCamView.backView = true;
			SmoothFollowForCamView.rightView = false;
//			GameObject.FindObjectOfType<SteerNew>().InitSteerNew();
			StartCoroutine(InstructionShow());
			
		}
		if (UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel%3==1) {
			StartCoroutine ("CameraSwitch");
			this.gameObject.GetComponent<ChasingCars>().Busted=false;
			Camera.main.GetComponent<SmoothFollow> ().enabled = false;
			hud.GetComponentInChildren<Camera> ().enabled = false;
			Camera.main.GetComponent<CameraControl> ().enabled = false;
			hud.GetComponent<HudStatus>().recording.SetActive(true);
			this.gameObject.GetComponent<VehicleController> ().maxSpeedForward = 2000;
			this.gameObject.GetComponent<VehicleController> ().maxDriveForce = 10000;
			mass=this.gameObject.GetComponent<Rigidbody> ().mass;
			this.gameObject.GetComponent<Rigidbody> ().mass = 2000f;
		}

	}
	void LateUpdate(){
		if(lateUpdateStopper)
		if (!FollowAI) {
			value = Mathf.Clamp01 (value - 0.005f);
			if(value>0)
			HudListener.accelPressedTime = value;
			else
				lateUpdateStopper=false;


		}



	}
	// Update is called once per frame
	void Update () {

		if (UpdateCheck) {
			GetComponent<ChasingCars>().canBusted = false;
			if (FollowAI) {
				if (counter < WayPoint.Length) {

					if(UserPrefs.currentEpisode==1&&UserPrefs.currentLevel%3==1)
					this.gameObject.transform.LookAt (WayPoint [counter]);

					if(UserPrefs.currentLevel%3!=1&&UserPrefs.currentEpisode==1||UserPrefs.currentEpisode==2){

						if(Input.GetMouseButtonUp(0))
							counter=WayPoint.Length;

					}
					value = Mathf.Clamp01 (value + 0.04f);
					HudListener.accelPressedTime = value;
					if(counter<WayPoint.Length)
					if (Vector3.Distance (this.gameObject.transform.position, WayPoint [counter].position) < 8)
						counter++;
				} else{
					FollowAI = false;
					lateUpdateStopper=true;
				}

			} else {
				//for first four levels
				if(UserPrefs.currentEpisode==1&&UserPrefs.currentLevel%3==1)
				{
					Camera.main.GetComponent<CameraControl> ().enabled = true;
					Camera.main.GetComponent<SmoothFollowForCamView> ().enabled = false;
					this.gameObject.GetComponent<VehicleController> ().maxSpeedForward = maxSpeedForward;
					this.gameObject.GetComponent<VehicleController> ().maxDriveForce = maxDriveForce;
					Camera.main.GetComponent<SmoothFollowForCamView> ().enabled = false;
					this.gameObject.GetComponent<Rigidbody> ().mass=mass;
					Camera.main.GetComponent<SmoothFollow> ().enabled = true;
					Camera.main.GetComponent<SmoothFollow> ().target=this.gameObject.transform.FindChild("EmptyBody");
					SmoothFollow.distance=8f;
					SmoothFollow.height=2f;
					hud.GetComponentInChildren<Camera>().enabled=true;
//					GameObject.FindObjectOfType<SteerNew>().InitSteerNew();
					hud.GetComponent<HudStatus>().lvl.initData();
					UserPrefs.soundState = UserPrefs.isSound;
//					hud.GetComponent<HudStatus> ().SetInstructionText ();
					UserPrefs.isSound = false;
				

				}

				this.gameObject.GetComponent<VehicleController> ().maxSpeedForward = maxSpeedForward;
				this.gameObject.GetComponent<VehicleController> ().maxDriveForce = maxDriveForce;

				SmoothFollowForCamView.backView = true;
				SmoothFollowForCamView.rightView = false;

				if(UserPrefs.currentEpisode==1&&UserPrefs.currentLevel==4)
					StartCoroutine(setnirtous());
				this.gameObject.GetComponent<Rigidbody> ().mass=1400f;
				if(hud.GetComponent<HudStatus>().lvl.type != Level.LevelType.Hit)
				GetComponent<ChasingCars>().canBusted = true;
				GetComponent<ChasingCars>().BustedbrObject.GetComponent<UISlider>().sliderValue = 0.0f;
				if(UserPrefs.currentEpisode == 1)
				hud.GetComponent<HudStatus>().recording.SetActive(false);
				this.gameObject.GetComponent<ChasingCars>().Busted=true;
				UpdateCheck=false;
				}
			}
		}



			IEnumerator CameraSwitch()
		{
		yield return new WaitForSeconds (4f);
		SmoothFollowForCamView.rightView = true;
		SmoothFollowForCamView.frontView = false;
		yield return new WaitForSeconds (5f);
		SmoothFollowForCamView.frontView = true;
		SmoothFollowForCamView.rightView = false;

		yield return new WaitForSeconds (3f);


		SmoothFollowForCamView.leftView = true;
		SmoothFollowForCamView.frontView = false;
			
		}
	IEnumerator setnirtous()
	{
		yield return new WaitForSeconds(1f);
		hud.GetComponent<HudStatus> ().SetNitrousDialogue ();
	
		
	}

	IEnumerator InstructionShow()
	{
		yield return new WaitForSeconds(1f);
//		hud.GetComponent<HudStatus> ().SetInstructionText ();


	}

}
