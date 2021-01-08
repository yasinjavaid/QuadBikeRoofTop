using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	public enum LevelType {Distance, TimeZone, Hit, EndPoint}
	public LevelType type;
	public float TotalVal;
	float currentVal;
	HudStatus hud;
	WheelControllerGenericNew playerCar;
	public GameObject EndPoint;
	//bool UserPrefs.isLevelFinish = true;
	float LevelFinsihTime = 0.5f;
	// Use this for initialization
	void Start () {
		GAManager.Instance.LogDesignEvent("LevelStart::Episode"+UserPrefs.currentEpisode+"::Level"+UserPrefs.currentLevel);
		hud = GameObject.FindObjectOfType<HudStatus>();
		hud.lvl = this.gameObject.GetComponent<Level>();
	//	Invoke("initData",1f);
		//initData();
	}
	public void initData()
	{
		UserPrefs.isLevelFinish = false;
		currentVal = 0;
		if(type == LevelType.Distance)
		{
			playerCar.distanceTravelled = 0;
			hud.lblName.text = "Distance";
			hud.lblDistance.text = "0/"+TotalVal.ToString()+"m";
		
		}
		else if(type == LevelType.TimeZone)
		{
			hud.lblName.text = "Time";
			hud.lblDistance.text = "0/"+TotalVal.ToString()+"s";

		}
		else if(type == LevelType.Hit)
		{
			hud.lblName.text = "Hits";
			hud.lblDistance.text = "0/"+TotalVal.ToString()+" cars";

		}
		else if(type == LevelType.EndPoint)
		{
			hud.lblName.text = "Distance";
			hud.lblDistance.text = Mathf.FloorToInt(Vector3.Distance(playerCar.gameObject.transform.position,EndPoint.transform.position)).ToString()+"m";
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
	void LateUpdate () {
		if (playerCar == null) {
			playerCar = GameObject.FindObjectOfType<WheelControllerGenericNew>();
			if(playerCar == null)
				return;
		}
		if(!UserPrefs.isLevelFinish)
		{
			if(type == LevelType.Distance)
			{
				currentVal = playerCar.distanceTravelled/4f;
				hud.lblDistance.text = Mathf.FloorToInt(currentVal).ToString()+"/"+TotalVal.ToString()+"m";
				if(currentVal+30f>TotalVal)
				{
					hud.countDown.gameObject.SetActive(true);
					hud.countDown.text = Mathf.FloorToInt(TotalVal-currentVal).ToString()+"m";
				}
				else
				{
					hud.countDown.gameObject.SetActive(false);
				}
				if(currentVal>=TotalVal)
				{
					hud.countDown.text = "Winner!";
					UserPrefs.isLevelFinish = true;
					playerCar.levelCompleted(LevelFinsihTime);
					ShowFront();
				}
			}
			else if(type == LevelType.TimeZone)
			{
				currentVal +=Time.deltaTime;
				hud.lblDistance.text = Mathf.FloorToInt(currentVal).ToString()+"/"+TotalVal.ToString()+"s";	
				if(currentVal+11f>TotalVal)
				{
					hud.countDown.gameObject.SetActive(true);
					hud.countDown.text = Mathf.FloorToInt(TotalVal-currentVal).ToString()+"s";
				}
				else
				{
					hud.countDown.gameObject.SetActive(false);
				}
				if(currentVal>=TotalVal)
				{
					hud.countDown.text = "Winner!";
					UserPrefs.isLevelFinish = true;
					playerCar.levelCompleted(LevelFinsihTime);
					ShowFront();
				}
			}
			else if(type == LevelType.Hit)
			{
				hud.lblDistance.text = currentVal+"/"+TotalVal.ToString()+" cars";
				if(currentVal>=TotalVal)
				{
					UserPrefs.isLevelFinish = true;
					playerCar.levelCompleted(LevelFinsihTime+1f);
					ShowFront();
				}
			}
			else if(type == LevelType.EndPoint)
			{
				currentVal = Vector3.Distance(playerCar.gameObject.transform.position,EndPoint.transform.position);
				hud.lblDistance.text = Mathf.FloorToInt(currentVal).ToString()+"m";
				if(currentVal<30f)
				{
					hud.countDown.gameObject.SetActive(true);
					hud.countDown.text = hud.lblDistance.text;
				}
				else
				{
					hud.countDown.gameObject.SetActive(false);
				}
				if(currentVal<=3f)
				{
					hud.lblDistance.text  = "0m";
					UserPrefs.isLevelFinish = true;
					playerCar.levelCompleted(LevelFinsihTime);
					hud.countDown.text = "Escaped!";
					ShowFront();
				}
			}
		}
		//lblDistance.text = string.Format ("{0:00.0} KM" , stats.Distance*10f);
	}
	public void CarHit()
	{
		if(type == LevelType.Hit)
		{
			currentVal++;
			hud.lblDistance.GetComponent<MoveHurdle>().enabled=true;
		}
	}
	public void ShowFront()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 25;
		Time.timeScale = 0.5f;
		Camera.main.GetComponent<SmoothFollowForCamView>().d = 10f;
		Camera.main.GetComponent<SmoothFollowForCamView>().h = 3f;
		Camera.main.GetComponent<SmoothFollow>().enabled = false;
		Camera.main.GetComponent<SmoothFollowForCamView>().enabled = true;
		SmoothFollowForCamView.leftView = false;
		SmoothFollowForCamView.rightView = false; 
		SmoothFollowForCamView.backView = false; 
		SmoothFollowForCamView.frontView = true;
		SmoothFollowForCamView.defaultView = false;
	}

}

