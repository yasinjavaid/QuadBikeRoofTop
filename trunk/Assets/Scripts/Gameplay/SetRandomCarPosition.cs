using UnityEngine;
using System.Collections;

public class SetRandomCarPosition : MonoBehaviour {

	public GameObject[] carPositions;
	public GameObject[] enemyCarPosition;

	public Transform StartingPoint;

	// Use this for initialization
	void Start () {
		enableCarPosition ();
		//randomEnemySpawning ();
		EnemySpawning();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void enableCarPosition()
	{
		carPositions[Random .Range(0,carPositions.Length)].SetActive(true);
	}
	void EnemySpawning()
	{
		Constants.NumberofHelipEnemies = 0;
		Constants.isBossMode = false;
		if(UserPrefs.currentEpisode == 3)//island
		{
			EnemyCar.isLap = false;
			if(UserPrefs.currentLevel == 1)
			{



				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 4500;
				Car2.GetComponent<Rigidbody>().mass = 4500;
				Car1.GetComponent<FollowAI>().speed=0.45f;
				Car2.GetComponent<FollowAI>().speed=0.45f;

				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				//Car3.GetComponent<FollowAI>().speed=0.6;
				Constants.NumberOfEnemies = 2;
			}
			else if(UserPrefs.currentLevel == 2)
			{
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;

				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 4600;
				Car2.GetComponent<Rigidbody>().mass = 4600;
				Constants.NumberOfEnemies = 2;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Car1.GetComponent<FollowAI>().speed=0.47f;
				Car2.GetComponent<FollowAI>().speed=0.47f;

//				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;


				Constants.NumberOfEnemies = 1;


			}
			else if(UserPrefs.currentLevel == 3)
			{
				float rand=Random.Range(0,4);
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 4700;
				Car2.GetComponent<Rigidbody>().mass = 4700;
				Constants.NumberOfEnemies = 2;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Car1.GetComponent<FollowAI>().speed=0.49f;
				Car2.GetComponent<FollowAI>().speed=0.49f;
			}
			else if(UserPrefs.currentLevel == 4)
			{
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 4900;
				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
				Car2.GetComponent<Rigidbody>().mass = 4900;
				Constants.NumberOfEnemies = 2;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Car1.GetComponent<FollowAI>().speed=0.52f;
				Car2.GetComponent<FollowAI>().speed=0.52f;
				
				
			}
			else if(UserPrefs.currentLevel == 5)
			{
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 4900;
				Car2.GetComponent<Rigidbody>().mass = 4900;
				Constants.NumberOfEnemies = 2;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Car1.GetComponent<FollowAI>().speed=0.53f;
				Car2.GetComponent<FollowAI>().speed=0.53f;
				
			}
			else if(UserPrefs.currentLevel == 6)
			{
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
				var Car3 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[2].transform.position, enemyCarPosition[2].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 5000;
				Car2.GetComponent<Rigidbody>().mass = 5000;
				Car3.GetComponent<Rigidbody>().mass = 5000;
				Constants.NumberOfEnemies = 3;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Car1.GetComponent<FollowAI>().speed=0.55f;
				Car2.GetComponent<FollowAI>().speed=0.55f;
				Car3.GetComponent<FollowAI>().speed=0.55f;
			}
			else if(UserPrefs.currentLevel == 7)
			{
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
				var Car3 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[2].transform.position, enemyCarPosition[2].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 5100;
				Car2.GetComponent<Rigidbody>().mass = 5100;
				Car3.GetComponent<Rigidbody>().mass = 5100;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Constants.NumberOfEnemies = 3;
				Car1.GetComponent<FollowAI>().speed=0.56f;
				Car2.GetComponent<FollowAI>().speed=0.56f;
				Car3.GetComponent<FollowAI>().speed=0.56f;
			}
			else if(UserPrefs.currentLevel == 8)
			{
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
				var Car3 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[2].transform.position, enemyCarPosition[2].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 5200;
				Car2.GetComponent<Rigidbody>().mass = 5200;
				Car3.GetComponent<Rigidbody>().mass = 5200;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Constants.NumberOfEnemies = 3;
				Car1.GetComponent<FollowAI>().speed=0.6f;
				Car2.GetComponent<FollowAI>().speed=0.6f;
				Car3.GetComponent<FollowAI>().speed=0.6f;
			}
		}
		else if(UserPrefs.currentEpisode == 2)//lava
		{
			EnemyCar.isLap = false;
			if(UserPrefs.currentLevel == 1)
			{
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 3500;
				Car2.GetComponent<Rigidbody>().mass = 3500;
				Car1.GetComponent<FollowAI>().speed=0.4f;
				Car2.GetComponent<FollowAI>().speed=0.4f;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				//Car3.GetComponent<FollowAI>().speed=0.6;
				Constants.NumberOfEnemies = 2;
			}
			else if(UserPrefs.currentLevel == 2)
			{
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 3700;
				Car2.GetComponent<Rigidbody>().mass = 3700;
				Constants.NumberOfEnemies = 2;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Car1.GetComponent<FollowAI>().speed=0.42f;
				Car2.GetComponent<FollowAI>().speed=0.42f;
			}
			else if(UserPrefs.currentLevel == 3)
			{
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 3700;
				Car2.GetComponent<Rigidbody>().mass = 3700;
				Constants.NumberOfEnemies = 2;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Car1.GetComponent<FollowAI>().speed=0.45f;
				Car2.GetComponent<FollowAI>().speed=0.45f;
			}
			else if(UserPrefs.currentLevel == 4)
			{
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 3800;
				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
				Car2.GetComponent<Rigidbody>().mass = 3800;
				Constants.NumberOfEnemies = 2;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Car1.GetComponent<FollowAI>().speed=0.47f;
				Car2.GetComponent<FollowAI>().speed=0.47f;
				
				
			}
			else if(UserPrefs.currentLevel == 5)
			{
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 4000;
				Car2.GetComponent<Rigidbody>().mass = 4000;
				Constants.NumberOfEnemies = 2;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Car1.GetComponent<FollowAI>().speed=0.49f;
				Car2.GetComponent<FollowAI>().speed=0.49f;
				
			}
			else if(UserPrefs.currentLevel == 6)
			{
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
				var Car3 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[2].transform.position, enemyCarPosition[2].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 4100;
				Car2.GetComponent<Rigidbody>().mass = 4100;
				Car3.GetComponent<Rigidbody>().mass = 4100;
				Constants.NumberOfEnemies = 3;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Car1.GetComponent<FollowAI>().speed=0.51f;
				Car2.GetComponent<FollowAI>().speed=0.51f;
				Car3.GetComponent<FollowAI>().speed=0.51f;
			}
			else if(UserPrefs.currentLevel == 7)
			{
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
				var Car3 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[2].transform.position, enemyCarPosition[2].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 4300;
				Car2.GetComponent<Rigidbody>().mass = 4300;
				Car3.GetComponent<Rigidbody>().mass = 4300;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Constants.NumberOfEnemies = 3;
				Car1.GetComponent<FollowAI>().speed=0.51f;
				Car2.GetComponent<FollowAI>().speed=0.51f;
				Car3.GetComponent<FollowAI>().speed=0.51f;
			}
			else if(UserPrefs.currentLevel == 8)
			{
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
				var Car3 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[2].transform.position, enemyCarPosition[2].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 4500;
				Car2.GetComponent<Rigidbody>().mass = 4500;
				Car3.GetComponent<Rigidbody>().mass = 4500;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Constants.NumberOfEnemies = 3;
				Car1.GetComponent<FollowAI>().speed=0.54f;
				Car2.GetComponent<FollowAI>().speed=0.54f;
				Car3.GetComponent<FollowAI>().speed=0.54f;
			}
		}
		else if(UserPrefs.currentEpisode == 1)//rooftop
		{
			EnemyCar.isLap = false;
			if(UserPrefs.currentLevel == 1)
			{
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				//		var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
//				var Car3 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[2].transform.position, enemyCarPosition[2].transform.rotation) as GameObject;
//				var Car4 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[3].transform.position, enemyCarPosition[3].transform.rotation) as GameObject;
				Destroy(Car1.GetComponent<EnginePowerManager>());
				Destroy(Car1.GetComponent<FollowAI>());
				Destroy(Car1.GetComponent<EnemyCar>());
				Constants.NumberOfEnemies = 1;
				Car1.GetComponent<Rigidbody>().mass=700;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Constants.NumberofHelipEnemies=0;

			}

			else if(UserPrefs.currentLevel == 2)
			{

				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 2600;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Constants.NumberOfEnemies = 1;
				Car1.GetComponent<FollowAI>().speed=0.2f;
			}
			else if(UserPrefs.currentLevel == 3)
			{
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 2600;
				Constants.isBossMode=true;
//				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
//				Car2.GetComponent<Rigidbody>().mass = 2800;
				//				var Car3 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[2].transform.position, enemyCarPosition[2].transform.rotation) as GameObject;
//				var Car4 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[3].transform.position, enemyCarPosition[3].transform.rotation) as GameObject;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Car1.GetComponent<FollowAI>().speed=0.22f;

				Constants.NumberOfEnemies = 2;
			}
			else if(UserPrefs.currentLevel == 4)
			{
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 2700;
				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
				Car2.GetComponent<Rigidbody>().mass = 2700;
				Constants.NumberOfEnemies = 3;
				Constants.NumberofHelipEnemies=1;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Car1.GetComponent<FollowAI>().speed=0.3f;
				Car2.GetComponent<FollowAI>().speed=0.3f;


			}
			else if(UserPrefs.currentLevel == 5)
			{
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 2900;
				Car2.GetComponent<Rigidbody>().mass = 2900;
				Constants.NumberOfEnemies = 3;
				Constants.NumberofHelipEnemies=1;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Car1.GetComponent<FollowAI>().speed=0.35f;
				Car2.GetComponent<FollowAI>().speed=0.35f;

			}
			else if(UserPrefs.currentLevel == 6)
			{
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
				//var Car3 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[2].transform.position, enemyCarPosition[2].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 3100;
				Car2.GetComponent<Rigidbody>().mass = 3100;
				//Car3.GetComponent<Rigidbody>().mass = 2800;
				Constants.NumberOfEnemies = 3;
				Constants.NumberofHelipEnemies=1;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Car1.GetComponent<FollowAI>().speed=0.39f;
				Car2.GetComponent<FollowAI>().speed=0.39f;
			//	Car3.GetComponent<FollowAI>().speed=0.33f;
			}
			else if(UserPrefs.currentLevel == 7)
			{
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
				//var Car3 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[2].transform.position, enemyCarPosition[2].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 3300;
				Car2.GetComponent<Rigidbody>().mass = 3300;
				//Car3.GetComponent<Rigidbody>().mass = 2900;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Constants.NumberOfEnemies = 3;
				Constants.NumberofHelipEnemies=1;
				Car1.GetComponent<FollowAI>().speed=0.41f;
				Car2.GetComponent<FollowAI>().speed=0.41f;
				//Car3.GetComponent<FollowAI>().speed=0.40f
			}
			else if(UserPrefs.currentLevel == 8)
			{
				var Car1 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[0].transform.position, enemyCarPosition[0].transform.rotation) as GameObject;
				var Car2 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[1].transform.position, enemyCarPosition[1].transform.rotation) as GameObject;
				var Car3 = Instantiate (Resources.Load ("Vehicles/QuadBikeEnemy"+Random.Range(0,4)), enemyCarPosition[2].transform.position, enemyCarPosition[2].transform.rotation) as GameObject;
				Car1.GetComponent<Rigidbody>().mass = 3500;
				Car2.GetComponent<Rigidbody>().mass = 3500;
				Car3.GetComponent<Rigidbody>().mass = 3500;
				Constants.enemyMass=Car1.GetComponent<Rigidbody>().mass;
				Constants.NumberOfEnemies = 4;
				Constants.NumberofHelipEnemies=1;
				Car1.GetComponent<FollowAI>().speed=0.42f;
				Car2.GetComponent<FollowAI>().speed=0.45f;
				Car3.GetComponent<FollowAI>().speed=0.5f;
			}
		
		}
		if(UserPrefs.currentEpisode==1)
		Constants.enemyMass-=500;
		else
			Constants.enemyMass-=400;
	}

	void randomEnemySpawning()
	{
		Constants.NumberOfEnemies = 0;
		for (int i=0; i<enemyCarPosition.Length; i++) 
		{
			int RandomEnemyCar=Random.Range(0,3);
			if(RandomEnemyCar==0)
			{
				var Car = Instantiate (Resources.Load ("Vehicles/MustangNew 1"), enemyCarPosition[i].transform.position, enemyCarPosition[i].transform.rotation) as GameObject;
				if(UserPrefs.currentEpisode==2||UserPrefs.currentEpisode==1)
				{

					Car.GetComponent<Rigidbody>().mass=1500f;

				}

			}
			else if(RandomEnemyCar==2)
			{

				var Car = Instantiate (Resources.Load ("Vehicles/MustangNew 1"), enemyCarPosition[i].transform.position, enemyCarPosition[i].transform.rotation) as GameObject;
				if(UserPrefs.currentEpisode==2||UserPrefs.currentEpisode==1)
				{
					
					Car.GetComponent<Rigidbody>().mass=1500f;
					
				}
			}
			else if(RandomEnemyCar==1)
			{
				var Car = Instantiate (Resources.Load ("Vehicles/MustangNew 1"), enemyCarPosition[i].transform.position, enemyCarPosition[i].transform.rotation) as GameObject;
				if(UserPrefs.currentEpisode==2||UserPrefs.currentEpisode==1)
				{
					
					Car.GetComponent<Rigidbody>().mass=1500f;
					
				}

			}
			Constants.NumberOfEnemies++;
		}
	}
}
