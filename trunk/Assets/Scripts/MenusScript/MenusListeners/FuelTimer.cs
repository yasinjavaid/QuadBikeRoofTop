using UnityEngine;
using System.Collections;
using System;

public class FuelTimer : MonoBehaviour {
		public float time ;
	// Use this for initialization
	void Start () {
		int carFuelwithUpgrade = 1;//VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].carFuel+(VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].tiresCurrentUpgradeLevel)*ConstantsNew.FUEL_UPGRADE_FACTOR;
		if(UserPrefs.currentEpisode==1)
		{
			switch(UserPrefs.currentLevel)
			{
			
				case 1:
					carFuelwithUpgrade+=250;   // 500
//					GAManager.Instance.LogDesignEvent("PlayArea:LevelStarted:Lvl#"+UserPrefs.currentLevel+":Episode#" + UserPrefs.currentEpisode);
					break;
				case 2:
				carFuelwithUpgrade+=250;    // 500
					break;
				case 3:
				carFuelwithUpgrade+=250;   // 500
					break;
				case 4:
				carFuelwithUpgrade+=250;   // 500
					break;
				case 5:							
				carFuelwithUpgrade+=250;   // 500
					break;
				case 6:
				carFuelwithUpgrade+=250;   // 500
					break;
				case 7:
				carFuelwithUpgrade+=250;   // 500
					break;
				case 8:
				carFuelwithUpgrade+=250;   // 500
					break;
				case 9:
				carFuelwithUpgrade+=250;   // 500
					break;
				case 10:
				carFuelwithUpgrade+=250;   // 500
					break;
				case 11:
				carFuelwithUpgrade+=250;   // 500
					break;
				case 12:
				carFuelwithUpgrade+=250;   // 500
					break;
			
			}
		}

		if(UserPrefs.currentEpisode==2)
		{
			switch(UserPrefs.currentLevel)
			{
			case 1:
				carFuelwithUpgrade+=250;   // 500
//				GAManager.Instance.LogDesignEvent("PlayArea:LevelStarted:Lvl#"+UserPrefs.currentLevel+":Episode#" + UserPrefs.currentEpisode);
				break;
			case 2:
				carFuelwithUpgrade+=250;   // 500
				break;
			case 3:
				carFuelwithUpgrade+=250;   // 500
				break;
			case 4:
				carFuelwithUpgrade+=250;   // 500
				break;
			case 5:							
				carFuelwithUpgrade+=250;   // 500
				break;
			case 6:
				carFuelwithUpgrade+=250;   // 500
				break;
			case 7:
				carFuelwithUpgrade+=250;   // 500
				break;
			case 8:
				carFuelwithUpgrade+=250;   // 500
				break;
			case 9:
				carFuelwithUpgrade+=250;   // 500
				break;
			case 10:
				carFuelwithUpgrade+=250;   // 500
				break;

				
			}
		}

		if(UserPrefs.currentEpisode==3)
		{
			switch(UserPrefs.currentLevel)
			{
				case 1:
				carFuelwithUpgrade+=250;   // 500
//				GAManager.Instance.LogDesignEvent("PlayArea:LevelStarted:Lvl#"+UserPrefs.currentLevel+":Episode#" + UserPrefs.currentEpisode);
					break;
				case 2:
				carFuelwithUpgrade+=250;   // 500
					break;
				case 3:
				carFuelwithUpgrade+=250;   // 500
					break;
				case 4:
				carFuelwithUpgrade+=250;   // 500
					break;
				case 5:							
				carFuelwithUpgrade+=250;   // 500
					break;
				case 6:
				carFuelwithUpgrade+=250;   // 500
					break;
				case 7:
				carFuelwithUpgrade+=250;   // 500
					break;
				case 8:
				carFuelwithUpgrade+=250;   // 500
					break;
				case 9:
				carFuelwithUpgrade+=250;   // 500
					break;
				case 10:
				carFuelwithUpgrade+=250;   // 500
					break;
				case 11:
				carFuelwithUpgrade+=250;   // 500
					break;
				case 12:
				carFuelwithUpgrade+=250;   // 500
					break;
			}
		}

		
		time = carFuelwithUpgrade;
		time = Constants.timePerLevel [UserPrefs.currentEpisode-1, UserPrefs.currentLevel-1];
	//	time = 5f;
//		Invoke("InitiatePopup",1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.GAMEPLAY)
		{
			this.SetTimer();
			UserPrefs.remainingtTimeForCurrentLevel = (Math.Truncate(1 * time) / 1).ToString();
			
		}
	}
	void InitiatePopup()
	{
		GameManager.Instance.ChangeState(GameManager.GameState.PICKPASSENGERINSTRUCTIONS);
	}
	public bool isFuelUpgrade()
	{
		if(GameObject.Find("MenuManager").GetComponent<MenuManager>().additionalUpgradeSelection.Equals("Fuel",System.StringComparison.InvariantCultureIgnoreCase))
		{
			// upgrade fuel here
			return true;
		}
		return false;
	}
	public bool isNewMenu()
	{
		if(GameObject.Find("MenuManager").GetComponent<MenuManager>().menuType==2)
		{
			return true;
		}
		return false;
	}
		
	private void SetTimer(){
	//	if(UserPrefs.currentEpisode!=2)
	//	{
			time= time-Time.deltaTime;
	//	}
		float timerAngle;
		if(time>0){
			
			if(isNewMenu() && isFuelUpgrade())
			{
				int carFuelwithUpgrade = 1;//VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].carFuel+(VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].tiresCurrentUpgradeLevel)*ConstantsNew.FUEL_UPGRADE_FACTOR;
				timerAngle=270+(180f-((180f/carFuelwithUpgrade)*time));			
			}
			else
			{
				 timerAngle = 270+(180f-((180f/Constants.timePerLevel[UserPrefs.currentEpisode-1 ,UserPrefs.currentLevel-1])*time));
			}
			//timerSprite.transform.eulerAngles = new Vector3(0,0,timerAngle);
		}
		else{
//			if(UserPrefs.currentEpisode!=2)
//			{
//				GameManager.Instance.ChangeState(GameManager.SoundState.POPUPSOUND,GameManager.GameState.TIMEOVER);
		  //}
		}
	}
	public void AddTime(float timeToAdd)
	{
  
  		if(this.gameObject.name=="time")
		{
 		  time = time + timeToAdd;
			GameObject.FindGameObjectWithTag("Player2").GetComponent<Rigidbody>().isKinematic = false;
  		}
 	}
	
	
}
