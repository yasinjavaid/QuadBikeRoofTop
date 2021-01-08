using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

	// Use this for initialization
	public GameObject startInstruction,firstInstruction,racerLabel,leftPanel,rightPanel,arrow;
	bool CamTranslation = false;
	GameObject map;
	bool lookNow = false;
	Transform target;
	bool isInstuructionStarted = false;
	GameObject [] racers ;
	Camera _mCamera;
	GameObject player;
	bool isTurorial = false;
	public static bool isSkipped = false;
	void Start () {
		Debug.Log("+++++ Start Instructions called");
		isSkipped = false;
		_mCamera = Camera.main.GetComponent<Camera>();
		//StartCoroutine(StartInstruction());
		StartCoroutine("StartInstruction2");

		map = GameObject.Find ("MiniMapCam");
		map.SetActive (false);
		leftPanel.SetActive (false);
		rightPanel.SetActive (false);
		if ((UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 1)) {
						isTurorial = true;
			arrow.SetActive(true);
				}
//		GAManager.Instance.LogDesignEvent("Tutorial::LvlStarted");
		//Invoke("showCallOut",17f);
		Debug.Log("+++++ Start Instructions called end");
	}
	
	// Update is called once per frame
	void Update () {
		if (isInstuructionStarted) {
			if(isSkipped && !isTurorial)
			{
				isInstuructionStarted = false;
				//iTween.Stop (this.gameObject);
				StopCoroutine("StartInstruction2");
				AddPhysicstoAll();


			}
		}
	
	}
	void LateUpdate () {
		if (lookNow) {

				// Look at and dampen the rotation
				var rotation = Quaternion.LookRotation(target.position - _mCamera.transform.position);
			_mCamera.transform.rotation = Quaternion.Slerp(_mCamera.transform.rotation, rotation, Time.deltaTime * 1f);
		}
	}
//	IEnumerator StartInstruction()
//	{
//		yield return new WaitForSeconds (2f);
//		racers =  GameObject.FindGameObjectsWithTag("Player");
//
//		GameObject.FindGameObjectWithTag ("Player2").rigidbody.isKinematic = true;
//
//		//startInstruction.SetActive (true);
//		camera.transform.position = new Vector3 (0, 50f, 0);
//
//		//camera.transform.position = new Vector3 (camera.transform.position.x, 50f, camera.transform.position.z);
//		//iTween.MoveTo (camera.transform.gameObject, new Vector3 (camera.transform.position.x, 50f, camera.transform.position.z), 2f);
//		//yield return new WaitForSeconds (1f);
//		SmoothFollow.target = null;
//		//startInstruction.SetActive (false);
//		Transform racer = GameObject.Find ("CamPoint").transform;
//
//		racer.localEulerAngles = new Vector3 (0, Random.Range (0, 360), 0);
//
//		camera.transform.LookAt (racer);
//		foreach(GameObject r in racers)
//		{
//			r.rigidbody.isKinematic = true;
//		}
//		yield return new WaitForSeconds (0.3f);
//
//		iTween.MoveTo (camera.transform.gameObject, racer.transform.position, 8f);
//		yield return new WaitForSeconds (4f);
//		foreach(GameObject r in racers)
//		{
//			r.rigidbody.isKinematic = false;
//		}
//
//		SmoothFollow.target = racer;
//		//GameObject.FindGameObjectWithTag ("Player").rigidbody.isKinematic = true;
//		yield return new WaitForSeconds (5f);
//		SmoothFollow.target = GameObject.Find ("EmptyBody").transform;
//		GameObject.FindGameObjectWithTag ("Player2").rigidbody.isKinematic = false;
//
//	}
	IEnumerator StartInstruction2()
	{

		yield return new WaitForSeconds (1f);
		racers =  GameObject.FindGameObjectsWithTag("Player");
		player = GameObject.FindGameObjectWithTag ("Player2");
		foreach(GameObject r in racers)
		{
			r.GetComponent<Rigidbody>().isKinematic = true;
		}
		if(isTurorial)
			yield return new WaitForSeconds (1f);
		else
			yield return new WaitForSeconds (1f);


		player.GetComponent<Rigidbody> ().isKinematic = true;

		//startInstruction.SetActive (true);
		//camera.transform.position = new Vector3 (0, 50f, 0);
		
		//camera.transform.position = new Vector3 (camera.transform.position.x, 50f, camera.transform.position.z);

		Vector3 temp = new Vector3 (player.transform.position.x, player.transform.position.y + 50f, player.transform.position.z);
		iTween.MoveTo (_mCamera.transform.gameObject, temp, 2.5f);
		yield return new WaitForSeconds (2f);
		isInstuructionStarted = true;
//		if(!isTurorial)
//			GameObject.FindObjectOfType<RacersLabelHandler> ().skipLabel.gameObject.SetActive (true);
//		SmoothFollow.target = null;
		//startInstruction.SetActive (false);
		Transform racer = GameObject.Find ("CamPoint").transform;
		
		racer.localEulerAngles = new Vector3 (0, Random.Range (0, 360), 0);
		//camera.transform.LookAt (racer);
		target = racer;
		lookNow = true;


		yield return new WaitForSeconds (0.3f);
		
		iTween.MoveTo (_mCamera.transform.gameObject, racer.transform.position, 8f);
		yield return new WaitForSeconds (3f);
		foreach(GameObject r in racers)
		{
			r.GetComponent<Rigidbody>().isKinematic = false;
		}

		yield return new WaitForSeconds (2f);

		lookNow = false;
		if(isInstuructionStarted)
//		SmoothFollow.target = racer;
		//GameObject.FindGameObjectWithTag ("Player").rigidbody.isKinematic = true;
		yield return new WaitForSeconds (6f);
//		SmoothFollow.target = GameObject.Find ("EmptyBody").transform;
		player.GetComponent<Rigidbody> ().isKinematic = false;
		yield return new WaitForSeconds (1f);
		showCallOut ();
//		GameObject.FindObjectOfType<RacersLabelHandler> ().skipLabel.gameObject.SetActive (false);
		leftPanel.SetActive (true);
		rightPanel.SetActive (true);
		yield return null;

	}
	void AddPhysicstoAll()
	{
		lookNow = false;
//		SmoothFollow.target = GameObject.Find ("EmptyBody").transform;

		player.GetComponent<Rigidbody> ().isKinematic = false;
		foreach(GameObject r in racers)
		{
			r.GetComponent<Rigidbody>().isKinematic = false;
		}

//		GameObject.FindObjectOfType<RacersLabelHandler> ().skipLabel.gameObject.SetActive (false);
		HideCallOut ();
		isSkipped = false;
		leftPanel.SetActive (true);
		rightPanel.SetActive (true);
	}
	void showCallOut()
	{
		firstInstruction.SetActive (true);
		Invoke ("HideCallOut", 3f);
	}
	void HideCallOut()
	{
		racerLabel.SetActive (true);
		map.SetActive (true);
		firstInstruction.SetActive (false);
	}
}
