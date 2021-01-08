using UnityEngine;
using System.Collections;

public class CameraSwitching : MonoBehaviour {

	// Use this for initialization
	public GameObject [] cameras;
	GameObject currentCamera;
	int randomNumber=-1;
	RandomEnvironment RE;
	void Start () {
		randomNumber = -1;
		StartCoroutine (CameraSwitch ());
		RE = GameObject.FindObjectOfType<RandomEnvironment> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnEnable()
	{
		StartCoroutine (CameraSwitch ());

	}
	IEnumerator CameraSwitch() {
		yield return new WaitForSeconds(0.0f);
	point1:

			randomNumber++;
		if (randomNumber >cameras.Length-1)
			randomNumber = 0;
			if (currentCamera)
			currentCamera.SetActive (false);
			
			currentCamera = cameras [randomNumber];
			if(currentCamera==null){

			goto  point1;

		}
			currentCamera.SetActive (true);

		yield return new WaitForSeconds(5.0f);

		goto point1;
		
	}
}
