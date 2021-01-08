using UnityEngine;
using System.Collections;

public class LevelsData : MonoBehaviour {

	private bool isComplete = false;
	private bool isFail=false;
	GameObject heli;

	//Use this for initialization
 		public static int DestroyedEnemies;
	public static int helicopterEnemiesDestroyed;
	void Start () {
		DestroyedEnemies = 0;
		helicopterEnemiesDestroyed = 0;
		if (GameObject.FindObjectOfType<helicptr> ()) {
			heli = GameObject.FindObjectOfType<helicptr> ().gameObject;

			heli.SetActive (false);
		}
		GAManager.Instance.LogDesignEvent("LevelStart::Episode"+UserPrefs.currentEpisode+"::Level"+UserPrefs.currentLevel);
		Debug.Log("LevelStart::Episode"+UserPrefs.currentEpisode+"::Level"+UserPrefs.currentLevel);
	}
	

	void Update () {

		
	}
	public  void LevelComplete()
	{


		//GameObject.FindObjectOfType<LevelCompleteAnim>().startAnim = true;

		Invoke ("Complete", 2.0f);

	

	}
	public void LevelFail()
	{
	
//		if (UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 5 || UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 8) {
//			Invoke ("Fail", 2.0f);
//
//			return;
//		}
		if (UserPrefs.currentLevel == 1 && UserPrefs.currentEpisode == 1) {
			Invoke("resetCar",2.0f);

		

		} else {
			if (Constants.levelfailcounter == 3) {
				if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel-1==3&&VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel-1==3&&VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel-1==3)
					Invoke ("Fail", 1.5f);
					else

					StartCoroutine (activePanel ());

			
			


			} else {
				if (Constants.isResetAvailable&&UserPrefs.currentEpisode==1&&UserPrefs.currentLevel<=5 )
					StartCoroutine (activeResetPanel ());
				else

					Invoke ("Fail", 2.0f);

			}
			Constants.levelfailcounter++;
			if (Constants.levelfailcounter == 4) {
				Constants.levelfailcounter = 0;
			}
		}

	}
	public void Complete()
	{
		if (!isFail) {

			isComplete=true;
			if(GameObject.FindGameObjectWithTag("Player2").GetComponentInChildren<Motor>().health<0.05f)
			{
				isComplete=false;
				LevelFail();
				return;
			}
			GameObject player = GameObject.FindGameObjectWithTag ("Player2");
			if(player&&player.GetComponentInChildren<QuadBikeController> ()){
				player.GetComponentInChildren<QuadBikeController> ().levelComplete (true);
			}
			//GameObject.FindGameObjectWithTag ("Player2").GetComponent<Rigidbody> ().isKinematic = true;
			GAManager.Instance.LogDesignEvent ("LevelSuccess::Episode" + UserPrefs.currentEpisode + "::Level" + UserPrefs.currentLevel);
			GameManager.RateUsCount++;
			
			
			player.GetComponentInChildren<Motor>().snd.mute=true;
			player.GetComponent<Rigidbody>().isKinematic=true;
			GameManager.Instance.ChangeState (GameManager.SoundState.LEVELSUCCESSSOUND, GameManager.GameState.LEVELCOMPLETE);


		}
	}
	public void Fail()
	{

	//	GameObject.FindGameObjectWithTag ("Player2").GetComponent<Rigidbody> ().isKinematic = true;
		if (!isComplete) {
			isFail=true;
			GAManager.Instance.LogDesignEvent ("LevelFail::Episode" + UserPrefs.currentEpisode + "::Level" + UserPrefs.currentLevel);
		
			GameManager.Instance.ChangeState (GameManager.SoundState.LEVELFAILSOUND, GameManager.GameState.CRASHED);

		}
	}
	IEnumerator activePanel()
	{
		yield return new WaitForSeconds(2.0f);
		GameObject.FindObjectOfType<HudStatus> ().activeUpgradePanel () ;


	}
	IEnumerator activeResetPanel()
	{
		yield return new WaitForSeconds(4.0f);
		if (DestroyedEnemies != Constants.NumberOfEnemies)
			GameObject.FindObjectOfType<HudStatus> ().activeResetPanel ();
		else
			Fail ();

		
		
	}
	public void HelipadEnemyInstantiate(){
		heli.SetActive (true);
		Transform carPosition=heli.GetComponent<helicptr> ().bikepos;
		heli.GetComponent<helicptr> ().startHeli ();

		GameObject car=	Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), carPosition.position, carPosition.rotation) as GameObject;
		GameObject.FindObjectOfType<ObjectIndicator> ().addNewEnemy (car.GetComponent<EnemyCar>());
		car.GetComponent<EnemyCar> ().FindTargets ();


	}
	public void HelipadEnemyInstantiateBoss()
	{
		heli.SetActive (true);
		Transform carPosition=heli.GetComponent<helicptr> ().bikepos;
		heli.GetComponent<helicptr> ().StartupHeli();
		
		GameObject car=	Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy4"), carPosition.position, carPosition.rotation) as GameObject;
		GameObject.FindObjectOfType<ObjectIndicator> ().addNewEnemy (car.GetComponent<EnemyCar>());
		car.GetComponent<EnemyCar> ().FindTargets ();


	}
	void resetCar()
			{
		GameObject.FindGameObjectWithTag("Player2").GetComponent<CarBlast>().DestroyParts();
		//GameObject.FindObjectOfType<CarBlast>().DestroyParts();
		Camera.main.GetComponent<SmoothFollow>().InitiateCar();
		GameObject player=Camera.main.GetComponent<SmoothFollow>().player();
		GameObject.FindObjectOfType<SetCarPosition>().setCarPosition(player);
		
		Camera.main.GetComponent<SmoothFollow>().target=player.GetComponent<CarBlast>().parts[0].transform.FindChild("COM").gameObject.transform;
		EnemyCar [] en = GameObject.FindObjectsOfType<EnemyCar>();
		foreach(EnemyCar e in en)
		{
			e.FindTargets();
		}


			}
}
