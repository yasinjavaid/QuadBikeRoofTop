using UnityEngine;
using System.Collections;

public class RacerControl : MonoBehaviour {

	public GameObject health;
	public float RacerNumber = 1;
	public float totalHealth = 30;
	float currentDamage = 0;
	// Use this for initialization
	void Start () {
		totalHealth = Constants.totalMagnitude [UserPrefs.currentEpisode - 1, UserPrefs.currentLevel - 1];
		//RacerNumber = Random.Range(1.0f,3.5f);
		SetSpeed();
		//this.GetComponent<IRDSCarControllerAI>().EnableSpeedRestriction(6,7,true,10.0f * 10);
		//this.GetComponent<IRDSCarControllerAI>().EnableSpeedRestriction(7,6,true,10.0f * 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetSpeed(){
//		this.GetComponent<IRDSCarControllerAI>().EnableSpeedRestriction(0,9,true,18.0f * RacerNumber);
	}

	public float SetHealth(float magnitude){
		currentDamage += magnitude;
//		health.transform.localScale = new Vector3(health.transform.localScale.x,(1 - currentDamage/totalHealth) * health.transform.localScale.y, health.transform.localScale.z);
//		if(1 - currentDamage/totalHealth < 0.5f) health.GetComponent<UISprite>().color = Color.red;
//		if(health.transform.localScale.y <= 0) health.transform.localScale =  new Vector3(0,0,0) ;
		return currentDamage >= totalHealth ? 0 : 1;
	}
}
