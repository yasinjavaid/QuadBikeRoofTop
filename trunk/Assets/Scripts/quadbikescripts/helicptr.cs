using UnityEngine;
using System.Collections;

public class helicptr : MonoBehaviour {

	// Use this for initialization
	public Transform bikepos;
	MoveHurdle mh;
	public GameObject box;
	public GameObject camera;
	public GameObject camera1;
	GameObject player;
	Camera cam;
	EnemyCar [] en;
	void Start () {
	
		//startHeli();

	}
	public void startHeli()
	{

		this.gameObject.transform.position = new Vector3 (105.93f,189.5f, 400f);
		//camera.SetActive (true);
		mh=GetComponent<MoveHurdle>();
		mh.enabled = true;

		StartCoroutine ("cameraEnable");
		StartCoroutine("move");
	}
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator move()
	{

		yield return new WaitForSeconds(mh.duration+1f);


		mh.enabled = false;
		box.SetActive(false);
		yield return new WaitForSeconds(1.5f);
		mh.enabled = true;
		yield return new WaitForSeconds (7);
		this.gameObject.SetActive (false);
	}
	IEnumerator cameraEnable()
	{
		yield return new WaitForSeconds(2f);

		 //camera.SetActive (false);
	}

	IEnumerator move1()
	{
		
		yield return new WaitForSeconds(mh.duration+1f);
		camera1.SetActive (false);

		cam.enabled = true;
		mh.enabled = false;
		box.SetActive(false);
		yield return new WaitForSeconds(1.5f);
		mh.enabled = true;
		player.GetComponent<Rigidbody> ().isKinematic = false;
		Constants.isBossMode = false;
		foreach (EnemyCar e in en) {
			e.FindTargets ();
		}

		yield return new WaitForSeconds (1.5f);
		if(GameObject.FindObjectOfType<instructionButtonHandle>())
		Time.timeScale = 0;
		this.gameObject.SetActive (false);
	}
	public void StartupHeli()
	{
		this.gameObject.transform.position = new Vector3 (105.93f,189.5f, 400f);
		player = GameObject.FindGameObjectWithTag ("Player2");
		player.GetComponent<Rigidbody> ().isKinematic = true;

		en = GameObject.FindObjectsOfType<EnemyCar> ();
		cam = Camera.main.GetComponent<Camera> ();
		cam.enabled = false;
		//camera.SetActive (false);
		camera1.SetActive (true);
		mh=GetComponent<MoveHurdle>();
		mh.enabled = true;
		StartCoroutine("move1");


	}
}
