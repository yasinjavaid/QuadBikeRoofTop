using UnityEngine;
using System.Collections;

public class CarPosition : MonoBehaviour {
	
	VehicleManager vehicleManager;
	public GameObject [] addons;
	void Start () {
		GAManager.Instance.LogDesignEvent("EpisodeSelection::Episode"+UserPrefs.currentEpisode.ToString());
		vehicleManager = GameObject.FindGameObjectWithTag("VehicleManager").GetComponent<VehicleManager>();
//		Invoke ("setVehicle", 0.5f);
//		setVehicleColor();
		setVehicleWheels();
	}
	private void setVehicle()
	{
		this.SetCarPosition ();
		

	}
	
	// Update is called once per frame
	void Update () {
//	Debug.Log("car posti called. -----------------------" +UserPrefs.currentEpisode);
	}
	
	/*-207.1507
		 	this.gameObject.transform.position = new Vector3(-574.0372f,0.04997941f,-64.91128f);
			this.gameObject.transform.Rotate(0,0,0);	
			this.gameObject.transform.position = new Vector3(-207.1507f,0.04997941f,-83.58601f);
			this.gameObject.transform.Rotate(0,41.09f,0);
	  */
	private void SetCarPosition()
	{
		var pos =  GameObject.FindGameObjectWithTag("CarPosition");
		this.gameObject.transform.position = pos.transform.position;
		this.gameObject.transform.rotation = pos.transform.rotation;
	}
	private void CarPositions(){
	//	Debug.Log("car posti called. -----------------------" +UserPrefs.currentEpisode);
		if(!UserPrefs.isTutorialFinished){
			this.gameObject.transform.position = new Vector3(-170.4862f,10.46531f,10.2378f);
			this.gameObject.transform.Rotate(0,0f,0);	
		}	
		else if(UserPrefs.currentEpisode==1){
			this.CarPositionFirstEpisode();
		}
		else if(UserPrefs.currentEpisode==2){
			this.CarPositionSecondEpisode();

		}
		else if(UserPrefs.currentEpisode==3){
			this.CarPositionThirdEpisode();
		}
		
		//*ALi
//			this.gameObject.transform.position = new Vector3(0.7826686f,0.04974141f,260.5974f);
//			this.gameObject.transform.Rotate(0,-31.8f,0);	
		
		// level 8 car position
//		this.gameObject.transform.position = new Vector3(-206.9699f,0.04992358f,-82.1748f);
//			this.gameObject.transform.Rotate(0,41.94f,0);	
		
		// level 9 car position
//		this.gameObject.transform.position = new Vector3(-25.61581f,5.802897f,40.98045f);
//			this.gameObject.transform.Rotate(0,0f,0);
		
		// level 10 car position
//		this.gameObject.transform.position = new Vector3(42.87842f,5.802897f,18.47994f);
//			this.gameObject.transform.Rotate(0,80f,0);
		
		// level 11 car position
//		this.gameObject.transform.position = new Vector3(13.40938f,9.813167f,35.48162f);
//			this.gameObject.transform.Rotate(3.27f,0f,0);
		
		
	}
	
	private void CarPositionFirstEpisode(){
		if(UserPrefs.currentLevel == 1)
		{ 
			this.gameObject.transform.position = new Vector3(163.424f,-5.112335f,-111.5975f);
			this.gameObject.transform.Rotate(0,270f,0);		
		}
		else if(UserPrefs.currentLevel == 2)
		{
			this.gameObject.transform.position = new Vector3(-87.72518f,-11.00272f,42.47454f);
			this.gameObject.transform.Rotate(0,119.84f,0);
		}
		else if(UserPrefs.currentLevel == 3)
		{	
			this.gameObject.transform.position = new Vector3(79.7f,-10.2f,-263.3f);
			this.gameObject.transform.Rotate(0,0f,0);
		}
		else if(UserPrefs.currentLevel == 4)
		{
			this.gameObject.transform.position = new Vector3(28.88155f,-5.090255f,29.94839f);
			this.gameObject.transform.Rotate(0,-66.52f,0f);
		}
		else if(UserPrefs.currentLevel == 5)
		{
			this.gameObject.transform.position = new Vector3(-38.08f,-11.01f,-115.11f);
			this.gameObject.transform.Rotate(0f,0f,0f);
		}
		else if(UserPrefs.currentLevel == 6)
		{
			this.gameObject.transform.position = new Vector3(255.3781f,-5.074239f,-6.954731f);
			this.gameObject.transform.Rotate(0,-53.86f,0);
		}
		else if(UserPrefs.currentLevel == 7)
		{
			this.gameObject.transform.position = new Vector3(38.04f,-5.07f,-58.9f);
			this.gameObject.transform.Rotate(0,0f,0f);	
		}
		else if(UserPrefs.currentLevel == 8)
		{
			this.gameObject.transform.position = new Vector3(-85.08f,-7.62f,-265.49f);
			this.gameObject.transform.Rotate(0f,0,0f);
		}
		else if(UserPrefs.currentLevel == 9)
		{
			this.gameObject.transform.position = new Vector3(-254.0746f,11.7f,-31.4f);
			this.gameObject.transform.Rotate(0f,90f,0f);
		}
		else if(UserPrefs.currentLevel == 10)
		{
			this.gameObject.transform.position = new Vector3(109.9965f,12.75867f,231.4353f);
			this.gameObject.transform.Rotate(0f,180f,0f);
		}

	}
	private void CarPositionSecondEpisode(){
		
		if(UserPrefs.currentLevel == 1)
		{ 
			//irds level 1
			this.gameObject.transform.position = new Vector3(31.61318f,-5.020606f,70.93529f);
			this.gameObject.transform.Rotate(0,18.78f,0);
		}
		else if(UserPrefs.currentLevel == 2)
		{
			//irds level 2
			this.gameObject.transform.position = new Vector3(-246.4278f,-11.03583f,174.8569f);
			this.gameObject.transform.Rotate(0f,250f,0f);
		}
		else if(UserPrefs.currentLevel == 3)
		{
			//breifcase level 1
			this.gameObject.transform.position = new Vector3(-288.8298f,-10.99479f,171.929f);
			this.gameObject.transform.Rotate(0f,120.73f,0f);
		}
		else if(UserPrefs.currentLevel == 4)
		{
			//breifcase level 2
			this.gameObject.transform.position = new Vector3(265.9301f,-4.990045f,43.63324f);
			this.gameObject.transform.Rotate(0f,201.02f,0f);
		}
		else if(UserPrefs.currentLevel == 5)
		{
			//pick n drop level 1
			this.gameObject.transform.position = new Vector3(-61.22939f,-8.436251f,-262.4932f);
			this.gameObject.transform.Rotate(0f,250f,0f);
		}
		else if(UserPrefs.currentLevel == 6)
		{
			//pick n drop level 2
			this.gameObject.transform.position = new Vector3(30.35216f,-4.910885f,-197.2629f);
			this.gameObject.transform.Rotate(0f,-46.25f,0f);
		}
		else if(UserPrefs.currentLevel == 7) {		
			//thief level 1
			this.gameObject.transform.position = new Vector3(166.1351f,13.98618f,221.0986f);
			this.gameObject.transform.Rotate(0f,290.6f,0f);
		}
		else if(UserPrefs.currentLevel == 8) {	
			// theif level 2
			this.gameObject.transform.position = new Vector3(-100.1049f,-7.243136f,-271.9387f);
			this.gameObject.transform.Rotate(0f,72.03f,0f);
		} 
		else if(UserPrefs.currentLevel == 9) {	
			this.gameObject.transform.position = new Vector3(207.41f,13.07f,-21.11f);
			this.gameObject.transform.Rotate(0,270,0);
		} 
		else if(UserPrefs.currentLevel == 10) {	
			this.gameObject.transform.position = new Vector3(-362.2113f,11.8131f,-140.0168f);
			this.gameObject.transform.Rotate(0,90,0);
		} 
	}

	private void CarPositionThirdEpisode(){
		if (UserPrefs.currentLevel == 1) {
			this.gameObject.transform.position = new Vector3(31.8f,-5.1f,-173.5f);
			this.gameObject.transform.Rotate(0f,0f,0f);
		} else if (UserPrefs.currentLevel == 2) {
			this.gameObject.transform.position = new Vector3(145.07f,-4.94f,-223.95f);
			this.gameObject.transform.Rotate(0,0f,0);	
		} else if (UserPrefs.currentLevel == 3) {
			this.gameObject.transform.position = new Vector3(224.82f,-5.002f,-2.72f);
			this.gameObject.transform.Rotate(0f,-90f,0f);
		} else if (UserPrefs.currentLevel == 4) {
			this.gameObject.transform.position = new Vector3(-246f,-2.66f,243.37f);
			this.gameObject.transform.Rotate(0,90f,0);
		} else if (UserPrefs.currentLevel == 5) {		
			this.gameObject.transform.position = new Vector3(196.25f,-5.15f,-116.75f);
			this.gameObject.transform.Rotate(0,-90f,0);			
		} else if (UserPrefs.currentLevel == 6) {		
			this.gameObject.transform.position = new Vector3(151.8f,-5f,-141.6f);
			this.gameObject.transform.Rotate(0f,0f,0f);
		} else if (UserPrefs.currentLevel == 7) {	
			this.gameObject.transform.position = new Vector3(30.24f,-5.09f,-174.83f);
			this.gameObject.transform.Rotate(0,0f,0); 	
		} else if (UserPrefs.currentLevel == 8) {		
			this.gameObject.transform.position = new Vector3 (-48.67f, -11.03f, -171.47f);
			this.gameObject.transform.Rotate (0, 0, 0);	
		} else if (UserPrefs.currentLevel == 9) {		
			this.gameObject.transform.position = new Vector3 (-257.93f, 12.75867f, 161.371f);
			this.gameObject.transform.Rotate (0, 90, 0);	
		} else if (UserPrefs.currentLevel == 10) {		
			this.gameObject.transform.position = new Vector3 (49.38495f, 12.85049f, -75.7148f);
			this.gameObject.transform.Rotate (0, 132.8533f, 0);	
		}
	}


	private void setVehicleWheels()
	{
		//		int currentCarRim = VehicleManager.vehicleArray[Use]
		int wheelId = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].currentWheel-1;
		addons[wheelId].SetActive(true);
//		Renderer []renderer =GameObject.FindGameObjectWithTag("Wheels").GetComponentsInChildren<Renderer>();
//		
//		for(int i= 0;i< renderer.Length;i++){
//
//				renderer[i].materials[1].mainTexture= vehicleManager.Wheels[wheelId];	
//
//				//renderer[i].material.mainTexture= vehicleManager.Wheels[wheelId];	
//
//		}
		
	}
	
	private void setVehicleColor()
	{
		
		int colorId = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].currentColor-1;
		//Renderer []rendererBody =GameObject.FindGameObjectWithTag("VehicleBody").GetComponentsInChildren<Renderer>();
		//Renderer []rendererDoor =GameObject.FindGameObjectWithTag("Door").GetComponentsInChildren<Renderer>();
		GameObject rendererBody = GameObject.FindGameObjectWithTag("PoliceBody");
//		GameObject rendererDoor =GameObject.FindGameObjectWithTag("Door");

//		if(UserPrefs.currentVehicle == 1  )
//		{
//			VehicleBody[UserPrefs.currentVehicle-1].GetComponent<Renderer>().materials[1].color = vehicleManager.vehicleBodyColors[colorId-1];
//		}
//		else
//			VehicleBody[UserPrefs.currentVehicle-1].GetComponent<Renderer>().material.color = vehicleManager.vehicleBodyColors[colorId-1];
		if(UserPrefs.currentVehicle == 1 )
		{
			rendererBody.GetComponent<Renderer>().materials[1].color = vehicleManager.vehicleBodyColors[colorId];

		}
		rendererBody.GetComponent<Renderer>().material.color = vehicleManager.vehicleBodyColors[colorId];

//		switch(UserPrefs.currentVehicle){
//		case 1:
//			rendererBody.renderer.material.mainTexture = vehicleManager.Truck1[colorId];
//			rendererDoor.renderer.material.mainTexture = vehicleManager.Truck1[colorId];
//			break;
//			
//		case 2:
//			rendererBody.renderer.material.mainTexture = vehicleManager.Truck2[colorId];
//			rendererDoor.renderer.material.mainTexture = vehicleManager.Truck2[colorId];
//			break;
//			
//		case 3:
//			rendererBody.renderer.materials[1].mainTexture = vehicleManager.Truck3[colorId];
//			rendererDoor.renderer.material.mainTexture = vehicleManager.Truck3[colorId];
//			break;
//			
//			/*case 4:
//			rendererBody.renderer.material.mainTexture = vehicleManager.Truck4[colorId];
//			rendererDoor.renderer.material.mainTexture = vehicleManager.Truck4[colorId];
//			break;
//			
//		case 5:
//			rendererBody.renderer.material.mainTexture = vehicleManager.Truck5[colorId];
//			rendererDoor.renderer.material.mainTexture = vehicleManager.Truck5[colorId];
//			break;
//		*/
//		default:
//			break;
//			
//		}
		
	}
	


}
