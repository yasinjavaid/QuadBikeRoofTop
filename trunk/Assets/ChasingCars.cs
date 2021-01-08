using UnityEngine;
using System.Collections;

public class ChasingCars : MonoBehaviour {
	public GameObject [] policeCars;
	public UISlider BustedBar;
	public GameObject BustedbrObject;
	bool coolDownCheck=false;
	//bool UserPrefs.isLevelFinish = false;
	public bool canBusted = true;
	public bool Busted=true;
	// Use this for initialization
	int isBustBarTutorialSeen = 0;
	void Start () {
		isBustBarTutorialSeen = PlayerPrefs.GetInt("Busted",0);
		BustedbrObject = GameObject.FindGameObjectWithTag ("BustedBar");
		UserPrefs.isLevelFinish = false;
		BustedbrObject.SetActive (false);

	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (coolDownCheck && BustedBar!=null) {
			if(BustedbrObject)
			BustedBar.sliderValue -= 0.001f;
			if (BustedBar.sliderValue <= 0) {
				BustedBar.sliderValue=0.0f;
				BustedbrObject.SetActive (false);
				coolDownCheck = false;
			}
		}
	}
	public bool isCarsChasing()
	{
		foreach (GameObject cars in policeCars) {

			if(cars)
				return true;

		}
		return false;

	}
	public bool isEligbleForReset()
	{

		float distance1;
		float distance2;

		if (policeCars [0] && policeCars [1]) {
			distance1 = Vector3.Distance (this.gameObject.transform.position, policeCars [0].transform.position);
			distance2 = Vector3.Distance (this.gameObject.transform.position, policeCars [1].transform.position);
		
			if (distance1 > 50f && distance2 > 50f) {
				resetCarPosition ();
				return true;
			} else
				return false;

		} else 
			return false;


	}
	 void resetCarPosition()
	{
	
		foreach (GameObject cars in policeCars) {
			
//			//cars.GetComponent<carResetPosition>().resetPosition();
//			cars.SetActive(false);
//				cars.GetComponent<FollowAI>().target=null;

		
			
		
		}


	}
	public void setCars(GameObject [] car)
	{
		policeCars = car;


	}
	void OnTriggerEnter(Collider other)
	{
		//Debug.Log(other.name);
		if ((other.gameObject.name == "Main_body" || other.gameObject.name.Contains("Police_Car_New")) && Busted) {	
//			if(other.gameObject.name == "Main_body")
//			{
//				canBusted =true;
//			}
			BustedbrObject.SetActive(true);
			if(BustedBar==null){
				
				BustedBar = BustedbrObject.GetComponent<UISlider> ();
				BustedBar.sliderValue = 0.0f;
			}
		

		}


	}
	void OnTriggerStay(Collider other) {

		if((other.gameObject.name=="Main_body"|| other.gameObject.name.Contains("Police_Car_New" ))&& Busted)
		{	

//			else
//				BustedBar.sliderValue = 0.0f;

			if(BustedBar==null)
				return;
				coolDownCheck=false;

				
				BustedBar.sliderValue+=0.001f;
				if(BustedBar.sliderValue>=1)
				{
					 BustedBar.sliderValue=1;
					if(!UserPrefs.isLevelFinish){	
						UserPrefs.isLevelFinish = true;
						GetComponent<WheelControllerGenericNew>().levelFailed(0.5f);
						GameObject.FindObjectOfType<Level>().ShowFront();
						HudStatus hud =GameObject.FindObjectOfType<HudStatus>();
						hud.countDown.gameObject.SetActive(true);
						hud.countDown.text = "Busted!";
					}
					//level failed here;

				}
			if(isBustBarTutorialSeen == 0)
			{
				if(BustedBar.sliderValue>0.1f)
				{
					PlayerPrefs.SetInt("Busted",1);
					isBustBarTutorialSeen = 1;
					HudStatus hud =GameObject.FindObjectOfType<HudStatus>();
					hud.instructionLbl.text = "Don't let this bar complete, otherwise you'll be busted!";
					hud.TutorialPanel.SetActive(true);
					Transform t = hud.TutorialPanel.transform.FindChild("Arrow3D").transform;
					t.localPosition = new Vector3(14f,-198.77f,0f);
					t.localEulerAngles = new Vector3(0f,0f,180f);
					t.localScale = new Vector3(100f,100,100f);
					Time.timeScale = 0f;
				}
			}



				



		}
	




	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "Main_body"|| other.gameObject.name.Contains("Police_Car_New")) {

			coolDownCheck=true;


		}
		
	}

}
