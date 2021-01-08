using UnityEngine;
using System.Collections;

public class RandomEnvironment : MonoBehaviour {

	// Use this for initialization\
	public GameObject [] environments;
	public GameObject []envCar1;
	public GameObject []envCar2;
	private bool MenuCheck = true;
	private GameObject currentEnv;
	public Transform wayPoint;
	public bool isActive=true;
	public GameObject birdViewCamera;
	void Start () {
//		Debug.Log ("Current Game State:" + GameManager.Instance.GetCurrentGameState ());
		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.MAINMENU)

		activate ();
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.Instance.GetCurrentGameState () == GameManager.GameState.MAINMENU&&MenuCheck)
			activate ();
		else 
			return;
	
	}
	public void activate()
	{
		MenuCheck = false;
		birdViewCamera.SetActive (true);
		currentEnv = environments [0];
		currentEnv.SetActive (true);

		activeCars (0);


	}
	public void deactivate()
	{
		isActive = false;
		deactiveCars ();
		birdViewCamera.SetActive (false);
		currentEnv.SetActive (false);

	}
	public void activeCars(int num)
	{

		if (num == 0) {
			for(int i=0;i<envCar1.Length;i++)
				envCar1[i].SetActive(true);


		}
		else
			for(int i=0;i<envCar2.Length;i++)
				envCar2[i].SetActive(true);


	}
	public void deactiveCars()
	{
		for(int i=0;i<envCar1.Length;i++)
			envCar1[i].SetActive(false);
		for(int i=0;i<envCar2.Length;i++)
			envCar2[i].SetActive(true);

	}
}
