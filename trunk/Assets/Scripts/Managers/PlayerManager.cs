using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	//police man controls
	public GameObject[] controls;

	//police car controls
	public GameObject[] carControls;
	public GameObject[] steerConrol;
	public GameObject[] touchControl;

	public GameObject _mCamera;
	public GameObject policeMan;
	public GameObject car;
	bool firstTime = true; // TODO -- Remove this Chaipi
	public bool isPoliceManEnabled = false;

	// Use this for initialization
	void Start () {
		UserPrefs.remainingtTimeForCurrentLevel = "100";
		//GAManager.Instance.LogDesignEvent("LevelStart::Episode"+UserPrefs.currentEpisode+"::Level"+UserPrefs.currentLevel);
		if(policeMan == null){
			policeMan = GameObject.FindGameObjectWithTag("Police");
		}
		if(car == null){
			StartCoroutine (findCar ());
		}

	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(!isPoliceManEnabled && car != null){
			policeMan.transform.position = car.transform.position;
			policeMan.transform.rotation = car.transform.rotation;
		}
	}

	public void SwitchControls(){
		isPoliceManEnabled = !isPoliceManEnabled;


		if(isPoliceManEnabled){
			foreach(var control in carControls){
				control.SetActive(false);
			}
			foreach(var control in steerConrol){
				control.SetActive(false);
			}
			foreach(var control in touchControl){
				control.SetActive(false);
			}
			foreach(var control in controls){
				control.SetActive(true);
			}

			_mCamera.GetComponent<SmoothFollow>().target = null;
			policeMan.GetComponent<ThirdPersonCamera>().cameraTransform = _mCamera.transform;
			foreach(var renderer in policeMan.GetComponentsInChildren<MeshRenderer>()){
				renderer.enabled = true;
			}
			foreach(var renderer in policeMan.GetComponentsInChildren<SkinnedMeshRenderer>()){
				renderer.enabled = true;
			}
			if(!firstTime)
				policeMan.transform.position = GameObject.Find("toSpawnPosition").transform.position;

//			CarMain.handBrakValue = 10;
//			CarMain.SendInput(car.GetComponent<CarControl>(),false,false);
			policeMan.GetComponent<ThirdPersonCamera>().enabled = true;
			policeMan.GetComponent<ThirdPersonController>().enabled = true;
			policeMan.GetComponent<CharacterController>().enabled = true;
			policeMan.GetComponent<CapsuleCollider>().enabled = true;
//			policeMan.GetComponent<ThirdPersonCamera>().enableCamera();
			firstTime = false;

		}else{
			foreach(var control in controls){
				control.SetActive(false);
			}
			foreach(var control in carControls){
				control.SetActive(true);
			}

			if(UserPrefs.accelerometerFactor == 0)
			{
				foreach(var control in steerConrol){
					control.SetActive(true);
				}
				foreach(var control in touchControl){
					control.SetActive(false);
				}
			}
			else if(UserPrefs.accelerometerFactor == 2)
			{
				foreach(var control in steerConrol){
					control.SetActive(false);
				}
				foreach(var control in touchControl){
					control.SetActive(true);
				}
			}
			TutorialManager.Instance.ChangeState(TutorialManager.TutorialStates.CHECKPOINT);
//			camera.GetComponent<SmoothFollow>().enabled = true;
//			camera.GetComponent<SmoothFollow>().target = car.transform.FindChild("EmptyBody").transform;
//			policeMan.GetComponent<ThirdPersonCamera>().cameraTransform = null;
			//policeMan.transform.parent = car.transform;
//			foreach(var renderer in policeMan.GetComponentsInChildren<MeshRenderer>()){
//				renderer.enabled = false;
//			}
//			foreach(var renderer in policeMan.GetComponentsInChildren<SkinnedMeshRenderer>()){
//				renderer.enabled = false;
//			}
//			CarMain.handBrakValue = 0;
//			CarMain.SendInput(car.GetComponent<CarControl>(),false,false);
			policeMan.GetComponent<ThirdPersonCamera>().enabled = false;
			policeMan.GetComponent<ThirdPersonController>().enabled = false;
			policeMan.GetComponent<CharacterController>().enabled = false;
			policeMan.GetComponent<CapsuleCollider>().enabled = false;
			//policeMan.transform.parent = car.transform;
		}
	}
	IEnumerator policeManPosition()
	{
		policeMan.GetComponent<ThirdPersonController>().enabled = false;
		yield return new WaitForSeconds(0f);
		if(car != null)
		{
			var pos = GameObject.Find("PolicePosition");
//			policeMan.transform.position = pos.transform.position;
//			policeMan.transform.LookAt(pos.transform);
//			policeMan.GetComponent<ThirdPersonController>().enabled = true;
//			policeMan.transform.rotation = new Quaternion(pos.transform.rotation.x, -1 * pos.transform.rotation.y, pos.transform.rotation.z, pos.transform.rotation.w); 

		}
	}

	void PoliceManPosition()
	{
		policeMan.GetComponent<ThirdPersonController>().enabled = false;
		if(car != null)
		{
			var pos = GameObject.Find("PolicePosition");
			policeMan.transform.position = pos.transform.position;
			policeMan.transform.LookAt(pos.transform);
			policeMan.GetComponent<ThirdPersonController>().enabled = true;
			//			policeMan.transform.rotation = new Quaternion(pos.transform.rotation.x, -1 * pos.transform.rotation.y, pos.transform.rotation.z, pos.transform.rotation.w); 
			
		}
	}


	IEnumerator findCar(){
		yield return new WaitForSeconds(0f);
		car = GameObject.FindGameObjectWithTag("Player2");
		StartCoroutine(policeManPosition());
		SwitchControls();
	}


}
