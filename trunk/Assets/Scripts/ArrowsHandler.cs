using UnityEngine;
using System.Collections;

public class ArrowsHandler : MonoBehaviour {
	
	
////	GameObject [] ArrowsGreen = null;
//	public GameObject ArrowRed = null;
////	private float SinkSpeed=5f;
////	private float elapsed=0.0f;
////	private float seaLevel= 0.0f;
////	private float bobFrequency= 0.2f;
//
//	GameObject [] NextSpot = null;
//	GameObject [] ParkSpots = null;
//	GameObject FinalSpot = null;
//	GameObject AccidentSpot = null;
//	public GameObject thiefCar;
//	GameObject HUDMenu;
//	float timer;
//	private bool isHudActive = false;
//	private bool LevelFinished = false;
//	private int CurrentSpot=0;
//
//	public static bool isFinalSpot=false;
//
//	CarControl car;
//
//	
//	// Use this for initialization
//	void Start () {
//		ArrowRed = this.gameObject;
//		setArrowOnStart ();
////		thiefCar = GameObject.FindGameObjectWithTag("Player");
//		HUDMenu = GameObject.FindGameObjectWithTag("Hud");
//		//HUDMenu.SetActive(false);
//	
////		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.DUMMYSTATE);
////		timer = Time.time;
////		ArrowsGreen = GameObject.FindGameObjectsWithTag("ArrowGreen");
////
////		if(GameObject.FindGameObjectWithTag("FinalSpot")!=null)
////		{
////			FinalSpot = GameObject.FindGameObjectWithTag("FinalSpot");
////			isFinalSpot = true;
////		}
////		else
////			AccidentSpot = GameObject.FindGameObjectWithTag("AccidentSpot");
////
////		if(FinalSpot == null) FinalSpot = GameObject.FindGameObjectWithTag("AccidentSpot");
//
////		ParkSpots=GameObject.FindGameObjectsWithTag("ParkSpot");
////	
////		if(ParkSpots.Length>1)
////		{
////			if(isFinalSpot)
////				FinalSpot.SetActive(false);
////			else
////				AccidentSpot.SetActive(false);
////			SortSpots();
////		}
//
//	}
//
//	void SortSpots()
//	{
//
//
//////		int SpotNumber=1;
////		int smallSpotNumber=1;
////		GameObject temp=new GameObject();
////		for(int i=0;i<ParkSpots.Length;i++)
////		{
////			for(int j=0;j<ParkSpots.Length;j++)
////			{
////				smallSpotNumber=int.Parse(ParkSpots[j].name[ParkSpots[j].name.Length-1].ToString());
////				if(smallSpotNumber<=SpotNumber)
////				{
////					temp=ParkSpots[j];
////					ParkSpots[j]=ParkSpots[smallSpotNumber-1];
////					ParkSpots[smallSpotNumber-1]=temp;
////				}
////			}
////			SpotNumber++;
//
//		//}
//
//	}
//	
//	// Update is called once per frame
//	void Update () {
//			
////		if(!isHudActive && Time.time>timer+3.0f)
////		{
////			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.GAMEPLAY);
////			//HUDMenu.SetActive(true);
////			isHudActive = true;
////		}
//		// 3D Arrow Handling	
//			
//////		BoatController myBoatController=(BoatController) GameObject.FindGameObjectWithTag("Boat").GetComponent("BoatController");
////
////		if(Vector3.Distance(ParkSpots[CurrentSpot].transform.position,ArrowRed.transform.position)<10 && !LevelFinished && !(CurrentSpot+1==ParkSpots.Length) ){
////
////
////			if(CurrentSpot+2==ParkSpots.Length)
////			{
////
////				if(isFinalSpot)
////					FinalSpot.SetActive(true);
////				else
////					AccidentSpot.SetActive(true);
////
////				CurrentSpot++;
////			}
////			else if(!(CurrentSpot+1==ParkSpots.Length))
////			{
////				CurrentSpot++;
////			}
////
////		}
////		else if(Vector3.Distance(ParkSpots[CurrentSpot].transform.position,ArrowRed.transform.position)<7 && !LevelFinished && CurrentSpot+1==ParkSpots.Length ){
////
////			if(CurrentSpot+1==ParkSpots.Length)
////			{
////				car = GameObject.FindGameObjectWithTag("Player").GetComponent<CarControl>();
////
////				car.brakeForceFactor=2.5f;
////		
////				CarMain.handBrakValue=1f;
////				CarMain.SendInput(car,false,false);
////				
////				LevelFinished = true;
////				StartCoroutine(FinishLevel());
////
////				CurrentSpot++;
////			}
//
//
//		//}
//		if(Constants.levelType[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1] == 1)
//		{
//			thiefCar = GameObject.FindGameObjectWithTag("Thief");
//			if(thiefCar != null)
//				setArrowDirection();
//		}
//		else if(Constants.levelType[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1] == 2)
//		{
//			thiefCar = GameObject.FindGameObjectWithTag("Respawn");
//			if(thiefCar != null)
//				setArrowDirection();
//		}
//		else if(Constants.levelType[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1] == 3)
//		{
//			thiefCar = GameObject.FindGameObjectWithTag("Player");
//			if(thiefCar != null)
//				setArrowDirection();
//		}
//		else if(Constants.levelType[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1] == 4)
//		{
//			thiefCar = GameObject.FindGameObjectWithTag("TargetToSteal");
//			if(thiefCar != null)
//				setArrowDirection();
//		}
//
//
//
//
//	}
//	void setArrowOnStart()
//	{
//		if(Constants.levelType[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1] == 1)
//		{
//			thiefCar = GameObject.FindGameObjectWithTag("Thief");
//			if(thiefCar != null)
//				setArrowDirection();
//		}
//		else if(Constants.levelType[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1] == 2)
//		{
//			thiefCar = GameObject.FindGameObjectWithTag("Respawn");
//			if(thiefCar != null)
//				setArrowDirection();
//		}
//		else if(Constants.levelType[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1] == 3)
//		{
//			thiefCar = GameObject.FindGameObjectWithTag("Player2");
//			if(thiefCar != null)
//				setArrowDirection();
//		}
//		else if(Constants.levelType[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1] == 4)
//		{
//			thiefCar = GameObject.FindGameObjectWithTag("TargetToSteal");
//			if(thiefCar != null)
//				setArrowDirection();
//		}
//	
//	}
//	void setArrowDirection()
//	{
//		Vector3 dir = (thiefCar.transform.position - ArrowRed.transform.position).normalized;    
//		Quaternion rotation = Quaternion.LookRotation(dir);
//		ArrowRed.transform.eulerAngles=new Vector3(rotation.eulerAngles.x+85,rotation.eulerAngles.y,rotation.eulerAngles.z);
//	}
//	IEnumerator FinishLevel()
//	{
//
//
//
//		var terrorist = GameObject.FindWithTag("Terrorist");
////		if(terrorist != null) terrorist.GetComponent<TerroristControl>().DoAttack();
//		yield return new WaitForSeconds(2);
//		
//		WheelControllerGeneric script = (WheelControllerGeneric) GameObject.FindGameObjectWithTag("Player").transform.GetComponent("WheelControllerGeneric");
//		script.LevelCompleted();
//		
//	}
}
