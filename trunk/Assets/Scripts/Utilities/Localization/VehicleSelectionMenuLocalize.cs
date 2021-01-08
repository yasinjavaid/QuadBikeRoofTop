using UnityEngine;
using System.Collections;

public class VehicleSelectionMenuLocalize : MonoBehaviour {

	public GameObject paintArrow;
	public UILabel coinslbl;
	public UILabel selectlevellbl;
	public UILabel settingslbl;
	public UILabel nextBtnlbl;
	public UILabel getCoinsBtnlbl;
	public UILabel enoughCoinsMsg;
	public UILabel paintlbl;
	public UILabel wheellbl;
	public UILabel upgradelbl;

	
	//public UILabel firstVehicleNamelbl;
	//public UILabel secondVehicleNamelbl;
	//public UILabel thirdVehicleNamelbl;

	public UILabel vehicleNameLbl;
				
	
	//public UILabel secondVehicleunlockCoinslbl;
	//public UILabel thirdVehicleunlockCoinslbl;

	public GameObject carSpecsWindow;
	public UISlider carBraking;
	public UISlider carSpeed;
	public UISlider carHandling;

	public GameObject carBrakingFillBar;
	public GameObject carSpeedFillBar;
	public GameObject carHandlingFillBar;

	public UILabel carBrakesLbl;
	public UILabel carSpeedLbl;
	public UILabel carHandlingLbl;

	public GameObject[] allVehiclesInMenu = new GameObject[6];
	public GameObject bigLock;
	public GameObject UnlockAllBtn;

	// Ijaz: adding for bike menu Animations
	public UIPanel topAnchor; // Anchors always keeps its position so Panels are attached for animations
	public UIPanel topAnchorMain;
	public UIPanel bottomAnchor;
	public UIPanel bottomAnchorMain;
	public UIPanel leftAnchor;
	public UIPanel rightAnchor;
	public UIPanel rightAnchorMain;
	public GameObject centerAnchor;
	public GameObject carStand;


	// Adding for Truck menus
	public UIPanel PaintPanel;
	public UIPanel WheelsPanel;
	public UIPanel UpgradesPanel;
	public GameObject PaintBtn;
	public GameObject WheelsBtn;
	public GameObject UpgradesBtn;

	public UILabel TotalCoinsLbl;

	const string vehicleCustomBtnUp = "button";
	const string vehicleCustomBtnPress = "button-p";

	bool isFirstLoad = true;

	public GameObject lockedView;
	public GameObject UnlockedView;
	public UILabel Price;

	void Start () {

		if(UserPrefs.isSound)
		{
			SoundManager.Instance.GetComponent<AudioSource>().mute = false;
			SoundManager.Instance.gamePlayEffectsSource.mute = false;
		}
		IterateVehicles();
		//ResetLock ();
		upgradelbl.color = Color.white;
		wheellbl.color = Color.grey;
		paintlbl.color = Color.grey;
		GameObject temp = GameObject.FindGameObjectWithTag ("LevelSettings");
		if (temp != null) {
			Destroy(temp);		
		}
		checkEnoughCoinMsg();

		//VehicleSelectionMenuListenerNew.selectedVehicleIndex =0;
		//UserPrefs.currentVehicle = VehicleSelectionMenuListenerNew.selectedVehicleIndex+1;

		/*for (int i = 0; i < UserPrefs.vehicleUnlockArray.Length; i++){
			UserPrefs.vehicleUnlockArray[i] = true;
		}
		UserPrefs.isIgnoreAds = true;
*/
		//playStartAnim();
		//switchToMainMenuAnchors();

//		bool hideBtnUnlockAll = true;
//		for (int i = 0; i < UserPrefs.vehicleUnlockArray.Length; i++){
//			if(UserPrefs.vehicleUnlockArray[i] == false)
//				hideBtnUnlockAll = false;
//		}
//		UnlockAllBtn.SetActive(!hideBtnUnlockAll);

		coinslbl.GetComponent<UILabel>().text = string.Format("{0:#,###0}", UserPrefs.totalCoins);
		selectlevellbl.GetComponent<UILabel>().text = Localization.instance.Get("SELECT_VEHICLE");
		settingslbl.GetComponent<UILabel>().text = Localization.instance.Get("Settings");
//		nextBtnlbl.GetComponent<UILabel>().text = Localization.instance.Get("NEXT");
		//getCoinsBtnlbl.GetComponent<UILabel>().text = Localization.instance.Get("GET_COINS");
		
		
		//firstVehicleNamelbl.GetComponent<UILabel>().text = Localization.instance.Get("Vehicle_1_Name");;
		//secondVehicleNamelbl.GetComponent<UILabel>().text = Localization.instance.Get("Vehicle_2_Name");;
		//thirdVehicleNamelbl.GetComponent<UILabel>().text = Localization.instance.Get("Vehicle_3_Name");;
		
		//secondVehicleunlockCoinslbl.GetComponent<UILabel>().text = ConstantsNew.SecondVehicle_Unlock_Coins.ToString()+" "+Localization.instance.Get("Coins");
		//thirdVehicleunlockCoinslbl.GetComponent<UILabel>().text = ConstantsNew.ThirdVehicle_Unlock_Coins.ToString()+" "+Localization.instance.Get("Coins");

		try
		{
//			for(int i=0; i<UserPrefs.vehicleUnlockArray.Length; i++)
//			{
//
//					UserPrefs.vehicleUnlockArray[i] = true;
//			}
		

			//checkLockedvehicles();
			//updateSpecsWindow(1, transform); // default car
			updateNames();
		}
		catch(System.Exception ex)
		{
			Debug.LogError("Exception caught " + ex.ToString());
		}

		TotalCoinsLbl.text = UserPrefs.totalCoins.ToString();
		updateLockPanel();
	}

	void Update()
	{
		coinslbl.GetComponent<UILabel>().text = string.Format("{0:#,###0}", UserPrefs.totalCoins);

	}

	public void VehicleCustomBtnAction( int index){ // Button index for Paint, Wheels and Upgrades
		switch(index){
		case 0: // Upgrades
			UpgradesBtn.GetComponentInChildren<UISprite>().spriteName = vehicleCustomBtnPress ;
//			PaintBtn.GetComponentInChildren<UISprite>().spriteName = vehicleCustomBtnUp ;
			WheelsBtn.GetComponentInChildren<UISprite>().spriteName = vehicleCustomBtnUp ;
			UpgradesPanel.gameObject.SetActive(true);
//			PaintPanel.gameObject.SetActive(false);
			WheelsPanel.gameObject.SetActive(false);
			upgradelbl.color = Color.white;
			wheellbl.color = Color.grey;
//			paintlbl.color = Color.grey;
			break;
		case 1: // Paint
			UpgradesBtn.GetComponentInChildren<UISprite>().spriteName = vehicleCustomBtnUp ;
//			PaintBtn.GetComponentInChildren<UISprite>().spriteName = vehicleCustomBtnPress ;
			WheelsBtn.GetComponentInChildren<UISprite>().spriteName = vehicleCustomBtnUp ;
			UpgradesPanel.gameObject.SetActive(false);
//			PaintPanel.gameObject.SetActive(true);
			WheelsPanel.gameObject.SetActive(false);
			upgradelbl.color = Color.grey;
			wheellbl.color = Color.grey;
//			paintlbl.color = Color.white;
			break;
		case 2: // Wheels
			UpgradesBtn.GetComponentInChildren<UISprite>().spriteName = vehicleCustomBtnUp ;
//			PaintBtn.GetComponentInChildren<UISprite>().spriteName = vehicleCustomBtnUp ;
			WheelsBtn.GetComponentInChildren<UISprite>().spriteName = vehicleCustomBtnPress ;
			UpgradesPanel.gameObject.SetActive(false);
//			PaintPanel.gameObject.SetActive(false);
			WheelsPanel.gameObject.SetActive(true);
			upgradelbl.color = Color.grey;
			wheellbl.color = Color.white;
	//		paintlbl.color = Color.grey;
			break;
		default:
			break;
		}
	}

	void playStartAnim(){
		/*if(ConstantsNew.loadMainMenu){
			ConstantsNew.loadMainMenu = false;
			ManuAnimations.playAnimation(topAnchorMain.gameObject, 0);
			ManuAnimations.playAnimation(rightAnchorMain.gameObject, 2);
			ManuAnimations.playAnimation(bottomAnchorMain.gameObject, 1);
		}
		else{
			iTween.MoveTo(centerAnchor, iTween.Hash(  "x", centerAnchor.transform.position.x +.35f,  "time", 1.1, "easetype",iTween.EaseType.easeInOutCubic  )  ); 
			iTween.MoveTo(carStand, iTween.Hash(  "x", carStand.transform.position.x +.35f,  "time", 1.1, "easetype",iTween.EaseType.easeInOutCubic  )  ); 

			topAnchorMain.gameObject.SetActive(false);
			rightAnchorMain.gameObject.SetActive(false);
			bottomAnchorMain.gameObject.SetActive(false);

			topAnchor.gameObject.SetActive(true);
			bottomAnchor.gameObject.SetActive(true);
			rightAnchor.gameObject.SetActive(true);
			leftAnchor.gameObject.SetActive(true);

			ManuAnimations.playAnimation(topAnchor.gameObject, 0);
			ManuAnimations.playAnimation(bottomAnchor.gameObject, 1);
			ManuAnimations.playAnimation(rightAnchor.gameObject, 2);
			ManuAnimations.playAnimation(leftAnchor.gameObject, 3);

			//switchToBikeSelectMenuAnchors();
		}*/
	}

	public void switchToMainMenuAnchors(){
		iTween.MoveTo(centerAnchor, iTween.Hash(  "x", centerAnchor.transform.position.x -.35f,  "time", 1.1, "easetype",iTween.EaseType.easeInOutCubic  )  ); 
		iTween.MoveTo(carStand, iTween.Hash(  "x", carStand.transform.position.x -.35f,  "time", 1.1, "easetype",iTween.EaseType.easeInOutCubic  )  ); 

		iTween.MoveTo(bottomAnchor.gameObject, iTween.Hash(  "y", bottomAnchor.gameObject.transform.position.y -3f,  "time", 0.4, "easetype",iTween.EaseType.easeInOutCubic  )  ); 
		iTween.MoveTo(topAnchor.gameObject, iTween.Hash(  "y", topAnchor.gameObject.transform.position.y +3f,  "time", 0.4, "easetype",iTween.EaseType.easeInOutCubic  )  ); 
		iTween.MoveTo(rightAnchor.gameObject, iTween.Hash(  "x", rightAnchor.gameObject.transform.position.x +3f,  "time", 0.4, "easetype",iTween.EaseType.easeInOutCubic  )  ); 
		iTween.MoveTo(leftAnchor.gameObject, iTween.Hash(  "x", leftAnchor.gameObject.transform.position.x -3f,  "time", 0.4, "easetype",iTween.EaseType.easeInOutCubic  )  ); 

		Invoke("switchToMainMenuAnchorsHelper", 0.4f);

	}

	void switchToMainMenuAnchorsHelper(){
		bottomAnchor.gameObject.SetActive(false);
		topAnchor.gameObject.SetActive(false);
		leftAnchor.gameObject.SetActive(false);
		rightAnchor.gameObject.SetActive(false);
		bottomAnchor.transform.position = new Vector3(bottomAnchor.transform.position.x, bottomAnchor.transform.position.y +3f, bottomAnchor.transform.position.z);
		topAnchor.transform.position = new Vector3(topAnchor.transform.position.x, topAnchor.transform.position.y -3f, topAnchor.transform.position.z);
		rightAnchor.transform.position = new Vector3(rightAnchor.transform.position.x -3f, rightAnchor.transform.position.y, rightAnchor.transform.position.z);
		leftAnchor.transform.position = new Vector3(leftAnchor.transform.position.x +3f, leftAnchor.transform.position.y, leftAnchor.transform.position.z);

		topAnchorMain.gameObject.SetActive(true);
		rightAnchorMain.gameObject.SetActive(true);
		bottomAnchorMain.gameObject.SetActive(true);
		ManuAnimations.playAnimation(topAnchorMain.gameObject, 0);
		ManuAnimations.playAnimation(rightAnchorMain.gameObject, 2);
		ManuAnimations.playAnimation(bottomAnchorMain.gameObject, 1);
	}

	public void switchToBikeSelectMenuAnchors(){
		iTween.MoveTo(centerAnchor, iTween.Hash(  "x", centerAnchor.transform.position.x +.35f,  "time", 1.1, "easetype",iTween.EaseType.easeInOutCubic  )  ); 
		iTween.MoveTo(carStand, iTween.Hash(  "x", carStand.transform.position.x +.35f,  "time", 1.1, "easetype",iTween.EaseType.easeInOutCubic  )  ); 

		iTween.MoveTo(topAnchorMain.gameObject, iTween.Hash(  "y", topAnchorMain.gameObject.transform.position.y +3f,  "time", 0.4, "easetype",iTween.EaseType.easeInOutCubic  )  ); 
		iTween.MoveTo(bottomAnchorMain.gameObject, iTween.Hash(  "y", bottomAnchorMain.gameObject.transform.position.y -3f,  "time", 0.4, "easetype",iTween.EaseType.easeInOutCubic  )  ); 
		iTween.MoveTo(rightAnchorMain.gameObject, iTween.Hash(  "x", rightAnchorMain.gameObject.transform.position.x +3f,  "time", 0.4, "easetype",iTween.EaseType.easeInOutCubic  )  ); 

		Invoke("switchToBikeSelectMenuAnchorsHelper", 0.4f);

	}

	void switchToBikeSelectMenuAnchorsHelper(){
		topAnchorMain.gameObject.SetActive(false);
		bottomAnchorMain.gameObject.SetActive(false);
		rightAnchorMain.gameObject.SetActive(false);
		topAnchorMain.transform.position = new Vector3(topAnchorMain.transform.position.x, topAnchorMain.transform.position.y -3f, topAnchorMain.transform.position.z);
		bottomAnchorMain.transform.position = new Vector3(bottomAnchorMain.transform.position.x, bottomAnchorMain.transform.position.y +3f, bottomAnchorMain.transform.position.z);
		rightAnchorMain.transform.position = new Vector3(rightAnchorMain.transform.position.x -3f, rightAnchorMain.transform.position.y, rightAnchorMain.transform.position.z);

		bottomAnchor.gameObject.SetActive(true);
		topAnchor.gameObject.SetActive(true);
		leftAnchor.gameObject.SetActive(true);
		rightAnchor.gameObject.SetActive(true);
		ManuAnimations.playAnimation(bottomAnchor.gameObject, 1);
		ManuAnimations.playAnimation(topAnchor.gameObject, 0);
		ManuAnimations.playAnimation(leftAnchor.gameObject, 3);
		ManuAnimations.playAnimation(rightAnchor.gameObject, 2);
	}

	public void updateCoions(){
	//	Debug.Log("Coins updated");
		coinslbl.GetComponent<UILabel>().text = string.Format("{0:#,###0}", UserPrefs.totalCoins);
		
	}


	public void ResetLock(){

		if (UserPrefs.vehicleUnlockArray [UserPrefs.currentVehicle - 1] == true)
			bigLock.SetActive (false);
		else
			bigLock.SetActive (true);

	
	}
	public void checkLockedvehicles(){
		try
		{

			if(UserPrefs.vehicleUnlockArray[1] == true){
				allVehiclesInMenu[0].GetComponentInChildren<UISprite>().spriteName = "car2_unlocked_unselected";
			}
			else{
				allVehiclesInMenu[0].GetComponentInChildren<UISprite>().spriteName = "car2_locked";
			}

			if(UserPrefs.vehicleUnlockArray[2] == true){
				allVehiclesInMenu[1].GetComponentInChildren<UISprite>().spriteName = "car5_unlocked_unselected";
			}
			else{
				allVehiclesInMenu[1].GetComponentInChildren<UISprite>().spriteName = "car5_locked";
			}

			if(UserPrefs.vehicleUnlockArray[3] == true){
				allVehiclesInMenu[2].GetComponentInChildren<UISprite>().spriteName = "car1_unlocked_unselected";
			}
			else{
				allVehiclesInMenu[2].GetComponentInChildren<UISprite>().spriteName = "car1_locked";
			}

			if(UserPrefs.vehicleUnlockArray[4] == true){
				allVehiclesInMenu[3].GetComponentInChildren<UISprite>().spriteName = "car4_unlocked_unselected";
			}
			else{
				allVehiclesInMenu[3].GetComponentInChildren<UISprite>().spriteName = "car4_locked";
			}

			if(UserPrefs.vehicleUnlockArray[5] == true){
				allVehiclesInMenu[4].GetComponentInChildren<UISprite>().spriteName = "car6_unlocked_unselected";
			}
			else{
				allVehiclesInMenu[4].GetComponentInChildren<UISprite>().spriteName = "car6_locked";
			}

			if(UserPrefs.vehicleUnlockArray[6] == true){
				allVehiclesInMenu[5].GetComponentInChildren<UISprite>().spriteName = "car7_unlocked_unselected";
			}
			else{
				allVehiclesInMenu[5].GetComponentInChildren<UISprite>().spriteName = "car7_locked";
			}
		}
		catch(System.Exception ex)
		{
			Debug.LogError("Exception caught " + ex.ToString());
		}
	}


	public void updateLockPanel(){
	
		if(UserPrefs.vehicleUnlockArray[UserPrefs.currentVehicle-1]){
			UnlockedView.SetActive(true);
			lockedView.SetActive(false);
		}else{
			UnlockedView.SetActive(false);
			lockedView.SetActive(true);
			bigLock.SetActive(true);
			Price.text = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].price.ToString();
		}
	
	}
	public void updateSpecsWindow(int carNumber, Transform transformOfSelection){
		/*Vector3 tempPosition = transformOfSelection.position;
		tempPosition.y -= .067f;
		tempPosition.x -= .62f;
		carSpecsWindow.transform.position = tempPosition;
		*/
		//switch (UserPrefs.currentVehicle) {

		if(UserPrefs.vehicleUnlockArray[carNumber-1] == true){
			bigLock.SetActive(false);
		}
		else{
			bigLock.SetActive(true);
		}

		float factor =50;

		switch (carNumber/*UserPrefs.currentVehicle*/) {
		
		case 1: //Orange sports car
			carBraking.sliderValue = 0.4f+(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel/factor);
			carSpeed.sliderValue = 0.5f+(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel/factor);
			carHandling.sliderValue = 0.5f+(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel/factor);
			break;
		
		case 2: //Police
			carBraking.sliderValue = 0.55f+(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel/factor);
			carSpeed.sliderValue = 0.6f+(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel/factor);
			carHandling.sliderValue = 0.65f+(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel/factor);
			break;
		case 3: //Grey sports car
			carBraking.sliderValue = 0.75f+(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel/factor);
			carSpeed.sliderValue = 0.7f+(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel/factor);
			carHandling.sliderValue = 0.7f+(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel/factor);
			break;
		case 4: //Red sports car
			carBraking.sliderValue = 0.85f+(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel/factor);
			carSpeed.sliderValue = 0.85f+(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel/factor);
			carHandling.sliderValue = 0.8f+(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel/factor);
			break;
		case 5: //Red sports car
			carBraking.sliderValue = 0.85f+(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel/factor);
			carSpeed.sliderValue = 0.85f+(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel/factor);
			carHandling.sliderValue = 0.8f+(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel/factor);
			break;
		case 6: //Red sports car
			carBraking.sliderValue = 0.85f+(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel/factor);
			carSpeed.sliderValue = 0.85f+(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel/factor);
			carHandling.sliderValue = 0.8f+(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel/factor);
			break;
		case 7: //Red sports car
			carBraking.sliderValue = 0.85f+(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel/factor);
			carSpeed.sliderValue = 0.85f+(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel/factor);
			carHandling.sliderValue = 0.8f+(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel/factor);
			break;
			
		default:
			break;

		}

		carHandlingLbl.text =  ((int)(carHandling.sliderValue * 100)).ToString();
		carSpeedLbl.text = ((int)(carSpeed.sliderValue * 100)).ToString();
	    carBrakesLbl.text = ((int)(carBraking.sliderValue * 100)).ToString();
		
	}
		
	public void updateNames()
		{
			if(VehicleSelectionMenuListenerNew.selectedVehicleIndex == 0)
			{
			vehicleNameLbl.text = "Thunderchild";
			}
			else if(VehicleSelectionMenuListenerNew.selectedVehicleIndex == 1)
			{
			vehicleNameLbl.text = "Firebird";
			}
			else if(VehicleSelectionMenuListenerNew.selectedVehicleIndex == 2)
			{
			vehicleNameLbl.text = "Blizzard";
			}
			else if(VehicleSelectionMenuListenerNew.selectedVehicleIndex == 3)
			{
			vehicleNameLbl.text = "Kusaki GTW";
			}
			else if(VehicleSelectionMenuListenerNew.selectedVehicleIndex == 4)
			{
			vehicleNameLbl.text = "Breeze II";
			}
			else if(VehicleSelectionMenuListenerNew.selectedVehicleIndex == 5)
			{
				vehicleNameLbl.text = "Braldo-H2";
			}

			

		}

	public void scaleOnUpgrade(int upgradeItem){
		switch(upgradeItem){
		case 1:
			//iTween.ScaleFrom(carSpeed.gameObject, iTween.Hash("x", 2, "y",2, "z", 2,"time",2, "easetype","elastic"));
			iTween.ScaleFrom(carBrakingFillBar, iTween.Hash("x", 200, "y",30, "z", 1,"time",2, "easetype","elastic"));
			break;
		case 2:
			iTween.ScaleFrom(carHandlingFillBar, iTween.Hash("x", 200, "y",30, "z", 1,"time",2, "easetype","elastic"));
			break;
		case 3:
			iTween.ScaleFrom(carSpeedFillBar, iTween.Hash("x", 200, "y",30, "z", 1,"time",2, "easetype","elastic"));
			break;
		default:
			break;
		}
	}

	public void checkEnoughCoinMsg(){

		bool isUnlockAvailable = false;
		if(UserPrefs.vehicleUnlockArray[1] == false && (UserPrefs.totalCoins >= VehicleManager.vehicleArray[1].price)){
			isUnlockAvailable = true;
		}
		else if(UserPrefs.vehicleUnlockArray[2] == false && (UserPrefs.totalCoins >= VehicleManager.vehicleArray[2].price)){
			isUnlockAvailable = true;
		}
		/*else if(UserPrefs.vehicleUnlockArray[3] == false && (UserPrefs.totalCoins >= VehicleManager.vehicleArray[3].price)){
			isUnlockAvailable = true;
		}
		else if(UserPrefs.vehicleUnlockArray[4] == false && (UserPrefs.totalCoins >= VehicleManager.vehicleArray[4].price)){
			isUnlockAvailable = true;
		}*/

		if(isUnlockAvailable)
			enoughCoinsMsg.enabled = true;
		else
			enoughCoinsMsg.enabled = false;
	}

	void IterateVehicles(){

		CarStandController carStandController = GameObject.FindGameObjectWithTag("CarStand").GetComponent<CarStandController>();
		carStandController.enableCarAt(UserPrefs.currentVehicle-1);
		
		VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>() as VehicleSelectionMenuLocalize;	
		
		vehicleLocalize.updateSpecsWindow(UserPrefs.currentVehicle, transform);
		vehicleLocalize.updateNames();
		UserPrefs.currentVehicle = UserPrefs.currentVehicle;
		
		VehicleUpgradeMenuLocalize vehicleUpgradeLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleUpgradeMenuLocalize>();
		vehicleUpgradeLocalize.setPaintOverlays(UserPrefs.currentVehicle-1);
		vehicleUpgradeLocalize.setWheelsOverlays(UserPrefs.currentVehicle-1);
		//vehicleUpgradeLocalize.setUpgradesOverlays(UserPrefs.currentVehicle-1);
		//vehicleUpgradeLocalize.setCarColor(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].currentColor);
		//vehicleUpgradeLocalize.setTruckWheels(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].currentWheel);
		
		vehicleLocalize.updateLockPanel();

		VehicleSelectionMenuListenerNew.selectedVehicleIndex = UserPrefs.currentVehicle - 1;
	}
}
