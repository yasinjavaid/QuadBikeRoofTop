using UnityEngine;
using System.Collections;

public class Lap : MonoBehaviour {

	// Use this for initialization
	public GameObject p1,p2,p3;
	static bool isPassedFromLast = false;
	public static int lapNo = 1;
	UILabel lapLbl,timeLbl;
	static float time;
	static float timeToCompleteLevel = 30f;
	static bool isPlaying = false;
	public int MaxLaps=0;
	public float TotalTime=0;
	static int MaxLap = 2;
	void Start () {

		HudStatus hud = GameObject.FindObjectOfType<HudStatus>();
		hud.LapNo.gameObject.SetActive(true);
		hud.timeLbl.gameObject.SetActive(true);
		hud.laptimeBG.SetActive(true);
		lapLbl =  hud.LapNo;
		timeLbl = hud.timeLbl;

		if (this.gameObject.name != "p1") {
			this.gameObject.SetActive (false);
		} else {
			MaxLap = MaxLaps;
			timeToCompleteLevel=TotalTime;

		}
		lapLbl.text = ""+lapNo.ToString()+"/"+MaxLap.ToString();
		lapNo = 1;
		time = 0;
		isPlaying = true;
	}
	public static void initData()
	{
		lapNo = 1;
		time = 0;
		isPlaying = true;
	}
	// Update is called once per frame
	void Update () {
		if(isPlaying){
			time+=Time.deltaTime;
			if(time>=timeToCompleteLevel)
			{
				isPlaying = false;
				this.gameObject.GetComponentInParent<LevelsData>().LevelFail();
			}
			else
			{
				timeLbl.text = ""+Mathf.FloorToInt(timeToCompleteLevel-time).ToString();
			}
		}
	}
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player2")
		{
			if(this.gameObject.name == "p1")
			{
				p2.SetActive(true);
				p1.SetActive(false);
				if(isPassedFromLast)
				{
					lapNo++;
					if(lapNo>MaxLap && isPlaying)
					{
						isPlaying = false;
						this.gameObject.GetComponentInParent<LevelsData>().LevelComplete();
					}
					else
					{
						lapLbl.text = ""+lapNo.ToString()+"/"+MaxLap.ToString();
					}
				}
				isPassedFromLast = false;
			}
			else if(this.gameObject.name == "p2")
			{
				p3.SetActive(true);
				p2.SetActive(false);
				isPassedFromLast = false;
			}
			else if(this.gameObject.name == "p3")
			{
				p1.SetActive(true);
				p3.SetActive(false);
				isPassedFromLast = true;
			}
		}
	}
}
