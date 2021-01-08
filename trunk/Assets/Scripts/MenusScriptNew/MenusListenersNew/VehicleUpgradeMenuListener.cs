using UnityEngine;
using System.Collections;

public class VehicleUpgradeMenuListener : MonoBehaviour {

	private static int selectedColor = -1;
	private static int selectedWheel = -1;
	public static int CoinsNeeded = 0;

	// Use this for initialization
	void Start () {

		SaveandLoad.Load();

		UpdateValues();
	}

	private static void UpdateValues()
	{

//		Debug.Log("color purchased");
		VehicleUpgradeMenuLocalize vehicleUpgradeLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleUpgradeMenuLocalize>();
		vehicleUpgradeLocalize.setPaintOverlays(UserPrefs.currentVehicle-1);
		vehicleUpgradeLocalize.setWheelsOverlays(UserPrefs.currentVehicle-1);
		vehicleUpgradeLocalize.setUpgradesOverlays(UserPrefs.currentVehicle-1);
		selectedColor = -1;
		selectedWheel = -1;

		VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>() as VehicleSelectionMenuLocalize;	
		vehicleLocalize.updateSpecsWindow(UserPrefs.currentVehicle, null); 
		//vehicleLocalize.scaleOnUpgrade();
	}
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnClick(){
		
	//	Debug.Log("Current Vehicle"+UserPrefs.currentVehicle+ "Current Episode"+UserPrefs.currentEpisode);
		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND);
		if(this.name == "btnGetCoins"){
			
			Debug.Log("getCoins" );
			//Destroy(GameObject.FindGameObjectWithTag("VehicleSelectionMenu"));
			//Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.STORE);

		}
		else if(this.name == "btnBack"){
			Debug.Log("backBtn" );
			MenuManager.Instance.SwitchPreviousMenu();

		}
		else if(this.name == "btnNext"){
			
			Debug.Log("nextBtn" );
			MenuManager.Instance.SwitchNextMenu();

		}
		else if(this.name == "btnSettings"){
			
			Debug.Log("settingsBtn" );
//			GAManager.Instance.LogDesignEvent("MainMenu:Settings");
			ShowSettingMenu();

		}
		else if(this.name == "SpeedBtn"){
			UpgradeEngine();
		}
		else if(this.name == "SteeringBtn"){
			UpgradeHandling();

		}
		else if(this.name == "BrakingBtn"){
			UpgradeBrake();

		}
		else if(this.gameObject.name.Equals("btnCoinsUpLeft")){
			//Destroy(GameObject.FindGameObjectWithTag("VehicleSelectionMenu"));
			//Resources.UnloadUnusedAssets();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.STORE);
		}
		else if(this.name == "Color1"){
			Debug.Log("clicked :" + this.name);
			selectedColor = 1;

			UpgradeColor(selectedColor);
		}
		else if(this.name == "Color2"){
			Debug.Log("clicked :" + this.name);
			selectedColor = 2;
			UpgradeColor(selectedColor);
		}
		else if(this.name == "Color3"){
			Debug.Log("clicked :" + this.name);
			selectedColor = 3;
			UpgradeColor(selectedColor);
		}
		else if(this.name == "Color4"){
			Debug.Log("clicked :" + this.name);
			selectedColor = 4;

			UpgradeColor(selectedColor);
		}
		else if(this.name == "Color5"){
			Debug.Log("clicked :" + this.name);
			selectedColor = 5;
			
			UpgradeColor(selectedColor);
		}
		else if(this.name == "Color6"){
			Debug.Log("clicked :" + this.name);
			selectedColor = 6;
			
			UpgradeColor(selectedColor);
		}
		else if(this.name == "Color7"){
			Debug.Log("clicked :" + this.name);
			selectedColor = 7;
			
			UpgradeColor(selectedColor);
		}
//		else if(this.name == "Wheel0"){
//			Debug.Log("clicked :" + this.name);
//			selectedWheel = 0;
//			UpgradeWheel(selectedWheel);
//		}
		else if(this.name == "Wheel1"){
			Debug.Log("clicked :" + this.name);
			selectedWheel = 1;
			UpgradeWheel(selectedWheel);
		}
		else if(this.name == "Wheel2"){
			Debug.Log("clicked :" + this.name);
			selectedWheel = 2;
			UpgradeWheel(selectedWheel);
		}
		else if(this.name == "Wheel3"){
			Debug.Log("clicked :" + this.name);
			selectedWheel = 3;
			UpgradeWheel(selectedWheel);
		}
		else if(this.name == "Wheel4"){
			Debug.Log("clicked :" + this.name);
			selectedWheel = 4;
			UpgradeWheel(selectedWheel);
		}
		else if(this.name == "Wheel5"){
			Debug.Log("clicked :" + this.name);
			selectedWheel = 5;
			UpgradeWheel(selectedWheel);
		}
		else if(this.name == "Wheel6"){
			Debug.Log("clicked :" + this.name);
			selectedWheel = 6;
			UpgradeWheel(selectedWheel);
		}
		else if(this.name == "Wheel7"){
			Debug.Log("clicked :" + this.name);
			selectedWheel = 7;
			UpgradeWheel(selectedWheel);
		}
		else if(this.name == "Wheel8"){
			Debug.Log("clicked :" + this.name);
			selectedWheel = 8;
			UpgradeWheel(selectedWheel);
		}
		else if(this.name == "Wheel9"){
			Debug.Log("clicked :" + this.name);
			selectedWheel = 9;
			UpgradeWheel(selectedWheel);
		}
		else if(this.name == "UpgradeBtn1"){
			Debug.Log("clicked :" + this.name);
		}
		else if(this.name == "UpgradeBtn2"){
			Debug.Log("clicked :" + this.name);
		}
		else if(this.name == "UpgradeBtn3"){
			Debug.Log("clicked :" + this.name);
		}
//		if(UserPrefs.isSound)
//			SoundManager.Instance.gamePlayEffectsSource.PlayOneShot(SoundManager.Instance.buttonClickSound);
	}

	void UpgradeColor(int colorNumber)
	{
		if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].colorUnlocked[colorNumber-1]){
			VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].currentColor = colorNumber;
			VehicleUpgradeMenuLocalize vehicleUpgradeLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleUpgradeMenuLocalize>();
			vehicleUpgradeLocalize.setCarColor(colorNumber);
			SaveandLoad.Save();
		}else{
			Debug.Log("Upgrading color");

			int coinsRequired = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].colorUnlockPrice[colorNumber - 1];


			//UserPrefs.totalCoins = 10;
			if(UserPrefs.totalCoins >= coinsRequired)
			{
				GameConstants.POPUP_MESSAGE = "Upgrade Paint for "+coinsRequired + " Coins?";
				GameManager.Instance.ChangeState(GameManager.GameState.CONFIRMCOLORUPGRADE);
			}
			else
			{

				VehicleUpgradeMenuListener.CoinsNeeded = coinsRequired - UserPrefs.totalCoins;
				GameConstants.POPUP_MESSAGE = string.Format("You need {0} more coins to unlock. \n Buy more?",VehicleUpgradeMenuListener.CoinsNeeded) ;
				Instantiate (Resources.Load ("SubMenusNew/LevelBuyCoin"));
				//GameManager.Instance.ChangeState(GameManager.GameState.OUTOFCOINSCOLORUPGRADE);
			}
		}

	}

	void UpgradeWheel(int wheelNumber)
	{
		Debug.Log("Upgrading wheel");


		if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].wheelUnlocked[wheelNumber-1]){
			VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].currentWheel = wheelNumber;
			VehicleUpgradeMenuLocalize vehicleUpgradeLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleUpgradeMenuLocalize>();
			vehicleUpgradeLocalize.setTruckWheels(wheelNumber);
			SaveandLoad.Save();

		}else{
			int coinsRequired = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].wheelUnlockPrice[wheelNumber - 1];


			//UserPrefs.totalCoins = 10;
			if(UserPrefs.totalCoins >= coinsRequired)
			{
				GameConstants.POPUP_MESSAGE = "Upgrade Wheel for "+coinsRequired + " coins?";
				GameManager.Instance.ChangeState(GameManager.GameState.CONFIRMWHEELUPGRADE);
			}
			else
			{
				VehicleUpgradeMenuListener.CoinsNeeded = coinsRequired - UserPrefs.totalCoins;
				string.Format("You need {0} more coins to unlock. \n Buy more?",VehicleUpgradeMenuListener.CoinsNeeded) ;
				Instantiate (Resources.Load ("SubMenusNew/LevelBuyCoin"));
			}
		}


	}

	void UpgradeEngine(){


		if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel<4){
			int coinsRequire = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel-1 ];

			//UserPrefs.totalCoins = 10;
			if(UserPrefs.totalCoins >= coinsRequire)
			{
				GameConstants.POPUP_MESSAGE = "Upgrade engine for "+coinsRequire+ " coins?" ;
				GameManager.Instance.ChangeState(GameManager.GameState.CONFIRMENGINEUPGRADE);
			}
			else
			{
				VehicleUpgradeMenuListener.CoinsNeeded = coinsRequire - UserPrefs.totalCoins;
				string.Format("You need {0} more coins to unlock. \n Buy more?",VehicleUpgradeMenuListener.CoinsNeeded) ;
				Instantiate (Resources.Load ("SubMenusNew/LevelBuyCoin"));			
			}
		}

		
	}
	

	void UpgradeHandling(){

		if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel<4){


			int coinsRequire = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel-1 ];

			if(UserPrefs.totalCoins >= coinsRequire)
			{
				GameConstants.POPUP_MESSAGE = "Upgrade brakes for "+coinsRequire+ " coins?";
				GameManager.Instance.ChangeState(GameManager.GameState.CONFIRMSTEERINGUPGRADE);
			}
			else
			{
				VehicleUpgradeMenuListener.CoinsNeeded = coinsRequire - UserPrefs.totalCoins;
				string.Format("You need {0} more coins to unlock. \n Buy more?",VehicleUpgradeMenuListener.CoinsNeeded) ;
				Instantiate (Resources.Load ("SubMenusNew/LevelBuyCoin"));			}
		}
	
	}
	
	
	void UpgradeBrake(){
		if(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel<4){
			int coinsRequire = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel-1 ];


			if(UserPrefs.totalCoins >= coinsRequire)
			{
				GameConstants.POPUP_MESSAGE = "Upgrade health for "+coinsRequire+ " coins?";
				GameManager.Instance.ChangeState(GameManager.GameState.CONFIRMBRAKESUPGRADE);
			}
			else
			{
				VehicleUpgradeMenuListener.CoinsNeeded = coinsRequire - UserPrefs.totalCoins;
				string.Format("You need {0} more coins to unlock. \n Buy more?",VehicleUpgradeMenuListener.CoinsNeeded) ;
				Instantiate (Resources.Load ("SubMenusNew/LevelBuyCoin"));			}
		}


	}

	public void ShowSettingMenu(){
		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.LEVELSETTINGS); 
	}

	static void updateCoins()
	{
		try{

			//MainMenuLocalize mainMenuLocalize = GameObject.FindGameObjectWithTag("TopBar").GetComponent<MainMenuLocalize>();
			//mainMenuLocalize.setCoinsText();

		}catch(UnityException e){
		}
	}
	
	public static void purchaseEngineUpgrade()
	{
		int coinsRequire = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel-1 ];
		GameManager.Instance.SubtractCoins(coinsRequire);
		//GameObject.FindGameObjectWithTag("VehicleUpgradeMenu").GetComponent<UpgradeMenuLocalize>().lbCoins.text = UserPrefs.totalCoins.ToString();
		updateCoins();
		VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].engineCurrentUpgradeLevel++;
		//Debug.Log("Incrementing engine val at ="+ (UserPrefs.currentVehicle-1));

		VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>() as VehicleSelectionMenuLocalize;	
		vehicleLocalize.scaleOnUpgrade(1); // 1 for engine/ speed

		UpdateValues();

		SaveandLoad.Save();

		GAManager.Instance.LogDesignEvent("VVehicleSelectionMenu::UpgradesUnlocked");
	}
	
	public static void purchaseBrakeUpgrade()
	{
		int coinsRequire = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel-1 ];
		GameManager.Instance.SubtractCoins(coinsRequire);
		updateCoins();
		VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].brakeCurrentUpgradeLevel++;

		VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>() as VehicleSelectionMenuLocalize;	
		vehicleLocalize.scaleOnUpgrade(3); // 3 for Braking

		UpdateValues();
		SaveandLoad.Save();

		GAManager.Instance.LogDesignEvent("VehicleSelectionMenu::UpgradesUnlocked");
	}
	
	public static void purchaseHandlingUpgrade()
	{
		int coinsRequire = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingUpgradePrice[ VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel-1 ];
		GameManager.Instance.SubtractCoins(coinsRequire);
		updateCoins();
		VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].handlingCurrentUpgradeLevel++;

		VehicleSelectionMenuLocalize vehicleLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>() as VehicleSelectionMenuLocalize;	
		vehicleLocalize.scaleOnUpgrade(2); // 2 for handling / steering

		UpdateValues();	
		SaveandLoad.Save();

		GAManager.Instance.LogDesignEvent("VehicleSelectionMenu::UpgradesUnlocked");
	}

	public static void purchaseColor()
	{
		int coinsRequired = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].colorUnlockPrice[selectedColor - 1];
		GameManager.Instance.SubtractCoins(coinsRequired);
		updateCoins();
		
		VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].colorUnlocked[selectedColor - 1] = true;
		VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].currentColor = selectedColor;
		UpdateValues();	
		VehicleUpgradeMenuLocalize vehicleUpgradeLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleUpgradeMenuLocalize>();
		
		vehicleUpgradeLocalize.setCarColor(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].currentColor);
		
		SaveandLoad.Save();
		
		if(!UserPrefs.isColorUpateDone && UserPrefs.currentLevel == 2){
			GAManager.Instance.LogDesignEvent("VehicleUpgradeMenu::Upgraded::ForceColor");
		}
		else{
			GAManager.Instance.LogDesignEvent("VehicleSelectionMenu::PaintUnlocked");
		}
	}

	public static void purchaseWheel()
	{
		int coinsRequired = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].wheelUnlockPrice[selectedWheel - 1];
		GameManager.Instance.SubtractCoins(coinsRequired);
		updateCoins();
		
		VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].wheelUnlocked[selectedWheel - 1] = true;
		VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].currentWheel = selectedWheel;
		UpdateValues();	
		VehicleUpgradeMenuLocalize vehicleUpgradeLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleUpgradeMenuLocalize>();

		vehicleUpgradeLocalize.setTruckWheels(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].currentWheel);

		SaveandLoad.Save();

		GAManager.Instance.LogDesignEvent("VehicleSelectionMenu::WheelUnlocked");

	}

	public static void purchaseVehicle()
	{
		Debug.LogError("Current V "+ UserPrefs.currentVehicle);
		int coinsRequired = VehicleManager.vehicleArray[UserPrefs.currentVehicle-1].price;
		GameManager.Instance.SubtractCoins(coinsRequired);
		updateCoins();
		GAManager.Instance.LogDesignEvent("VehicleSelectionMenu::Vehicle"+UserPrefs.currentVehicle.ToString()+"::Unlocked");
		UserPrefs.vehicleUnlockArray[UserPrefs.currentVehicle-1] = true;
		UserPrefs.Save();

		VehicleSelectionMenuLocalize vehicleMenu = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>();
		vehicleMenu.ResetLock();
		vehicleMenu.updateLockPanel();


	}




}
