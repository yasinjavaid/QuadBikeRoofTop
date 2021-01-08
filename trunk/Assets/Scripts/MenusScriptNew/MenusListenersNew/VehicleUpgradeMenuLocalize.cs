using UnityEngine;
using System.Collections;

public class VehicleUpgradeMenuLocalize : MonoBehaviour {

	public UILabel upgradeLevelLbl;
	public UILabel upgradeCoinsLbl;

	public GameObject []PaintOverlaysArr = new GameObject[3];
	public GameObject []WheelsOverlaysArr = new GameObject[9];
	public GameObject []UpgradeStatsOverlaysArr = new GameObject[3];
	public GameObject []UpgradeMaxOverlaysArr = new GameObject[3];

	public GameObject []VehicleBody;
	public GameObject []VehicleBodyDoor;
	public GameObject []VehicleWheels;
	private VehicleManager vehicleManager;

	public CarStandController allCars;
	//
	void Start () { 
		//PaintOverlaysArr[0].SetActive(false);
		//GameObject lbl = PaintOverlaysArr[2].transform.FindChild("Label").gameObject;
		//lbl.GetComponent<UILabel>().text = "yahooo";

		setUpgradesOverlays(UserPrefs.currentVehicle-1);
		vehicleManager = GameObject.FindGameObjectWithTag("VehicleManager").GetComponent<VehicleManager>();
	//	setCarColor(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].currentColor);
	//	setTruckWheels(VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].currentWheel);

		//setWheelsOverlays(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setPaintOverlays(int currentVehicleIndex){
		setPaintOverlaysHelper(currentVehicleIndex, 1);
		setPaintOverlaysHelper(currentVehicleIndex, 2);
		setPaintOverlaysHelper(currentVehicleIndex, 3);
		setPaintOverlaysHelper(currentVehicleIndex, 4);
		setPaintOverlaysHelper(currentVehicleIndex, 5);
		setPaintOverlaysHelper(currentVehicleIndex, 6);
//		setPaintOverlaysHelper(currentVehicleIndex, 7);
		//setPaintOverlaysHelper(currentVehicleIndex, 3);
	}
	void setPaintOverlaysHelper(int currentVehicleIndex, int paintColorIndex){
		UserPrefs.Save();
		if(VehicleManager.vehicleArray[currentVehicleIndex].colorUnlocked[paintColorIndex]){
			PaintOverlaysArr[paintColorIndex].SetActive(false);
		}
		else{
			PaintOverlaysArr[paintColorIndex].SetActive(true);

			GameObject lbl3 = PaintOverlaysArr[paintColorIndex].transform.FindChild("Label").gameObject;
			lbl3.GetComponent<UILabel>().text =  VehicleManager.vehicleArray[currentVehicleIndex].colorUnlockPrice[paintColorIndex].ToString();
		}
	}

	public void setWheelsOverlays(int currentVehicleIndex){
		setWheelsOverlaysHelper(currentVehicleIndex, 0);
		setWheelsOverlaysHelper(currentVehicleIndex, 1);
		setWheelsOverlaysHelper(currentVehicleIndex, 2);
		setWheelsOverlaysHelper(currentVehicleIndex, 3);
		setWheelsOverlaysHelper(currentVehicleIndex, 4);
		setWheelsOverlaysHelper(currentVehicleIndex, 5);
		setWheelsOverlaysHelper(currentVehicleIndex, 6);
		setWheelsOverlaysHelper(currentVehicleIndex, 7);
	//	setWheelsOverlaysHelper(currentVehicleIndex, 8);
	}
	void setWheelsOverlaysHelper(int currentVehicleIndex, int wheelIndex){
		if(VehicleManager.vehicleArray[currentVehicleIndex].wheelUnlocked[wheelIndex]){
			WheelsOverlaysArr[wheelIndex].SetActive(false);
		}
		else{
			WheelsOverlaysArr[wheelIndex].SetActive(true);

			GameObject lbl3 = WheelsOverlaysArr[wheelIndex].transform.FindChild("Label").gameObject;
			lbl3.GetComponent<UILabel>().text = VehicleManager.vehicleArray[currentVehicleIndex].wheelUnlockPrice[wheelIndex].ToString();
		}
	}

	public void setUpgradesOverlays(int currentVehicleIndex){
		//Debug.Log("setUpgradesOverlays :" + currentVehicleIndex);
		setUpgradesOverlaysHelper(currentVehicleIndex, 0);
		setUpgradesOverlaysHelper(currentVehicleIndex, 1);
		setUpgradesOverlaysHelper(currentVehicleIndex, 2);
	}
	void setUpgradesOverlaysHelper(int currentVehicleIndex, int upgradeIndex){
		switch(upgradeIndex){
		case 0:
			if(VehicleManager.vehicleArray[currentVehicleIndex].engineCurrentUpgradeLevel > 3){
				UpgradeStatsOverlaysArr[upgradeIndex].SetActive(false);
				UpgradeMaxOverlaysArr[upgradeIndex].SetActive(true);
			}
			else{
				UpgradeStatsOverlaysArr[upgradeIndex].SetActive(true);
				UpgradeMaxOverlaysArr[upgradeIndex].SetActive(false);
				GameObject lblLevel = UpgradeStatsOverlaysArr[upgradeIndex].transform.FindChild("LevelNo").gameObject;
				GameObject lblCoins = UpgradeStatsOverlaysArr[upgradeIndex].transform.FindChild("CoinTxt").gameObject;
				int LvlNo = VehicleManager.vehicleArray[currentVehicleIndex].engineCurrentUpgradeLevel;
				lblLevel.GetComponent<UILabel>().text = "LV . " + LvlNo.ToString();
				lblCoins.GetComponent<UILabel>().text =  VehicleManager.vehicleArray[currentVehicleIndex].engineUpgradePrice[LvlNo - 1].ToString();
			}
			break;
		case 1:
			if(VehicleManager.vehicleArray[currentVehicleIndex].handlingCurrentUpgradeLevel > 3){
				UpgradeStatsOverlaysArr[upgradeIndex].SetActive(false);
				UpgradeMaxOverlaysArr[upgradeIndex].SetActive(true);
			}
			else{
				UpgradeStatsOverlaysArr[upgradeIndex].SetActive(true);
				UpgradeMaxOverlaysArr[upgradeIndex].SetActive(false);
				GameObject lblLevel = UpgradeStatsOverlaysArr[upgradeIndex].transform.FindChild("LevelNo").gameObject;
				GameObject lblCoins = UpgradeStatsOverlaysArr[upgradeIndex].transform.FindChild("CoinTxt").gameObject;
				int LvlNo = VehicleManager.vehicleArray[currentVehicleIndex].handlingCurrentUpgradeLevel;
				lblLevel.GetComponent<UILabel>().text = "LV . " + LvlNo.ToString();
				lblCoins.GetComponent<UILabel>().text = VehicleManager.vehicleArray[currentVehicleIndex].handlingUpgradePrice[LvlNo - 1].ToString();
			}
			break;
		case 2:
//			Debug.Log("Case 1 :");
			if(VehicleManager.vehicleArray[currentVehicleIndex].brakeCurrentUpgradeLevel > 3){
				UpgradeStatsOverlaysArr[upgradeIndex].SetActive(false);
				UpgradeMaxOverlaysArr[upgradeIndex].SetActive(true);
			}
			else{
				UpgradeStatsOverlaysArr[upgradeIndex].SetActive(true);
				UpgradeMaxOverlaysArr[upgradeIndex].SetActive(false);
				GameObject lblLevel = UpgradeStatsOverlaysArr[upgradeIndex].transform.FindChild("LevelNo").gameObject;
				GameObject lblCoins = UpgradeStatsOverlaysArr[upgradeIndex].transform.FindChild("CoinTxt").gameObject;
				int LvlNo = VehicleManager.vehicleArray[currentVehicleIndex].brakeCurrentUpgradeLevel;
				lblLevel.GetComponent<UILabel>().text = "LV . " + LvlNo.ToString();
				lblCoins.GetComponent<UILabel>().text = VehicleManager.vehicleArray[currentVehicleIndex].brakeUpgradePrice[LvlNo - 1].ToString();
			}
			break;
		}
	}

	public void setTruckWheels(int wheelId )
	{
		return;
//		Renderer []renderer =VehicleWheels[UserPrefs.currentVehicle-1].GetComponentsInChildren<Renderer>();
//		
//		for(int i= 0;i< renderer.Length;i++){
//		
//				renderer[i].materials[1].mainTexture= vehicleManager.Wheels[wheelId-1];	
////			else
////				renderer[i].material.mainTexture= vehicleManager.Wheels[wheelId-1];
//		}
		GameObject[]addons = allCars.CarsOnStand[UserPrefs.currentVehicle-1].GetComponent<addonsInMenu>().addons;
		for(int i=0;i<addons.Length;i++)
		{
			if(i==wheelId-1 && wheelId<9)
			{
				addons[wheelId-1].SetActive(true);
			}
			else
			addons[i].SetActive(false);
		}
		//if(wheelId<9)
		
	}
	
	public void setCarColor(int colorId)
	{
		return;
		if(UserPrefs.currentVehicle == 1  )
		{
			VehicleBody[UserPrefs.currentVehicle-1].GetComponent<Renderer>().materials[1].color = vehicleManager.vehicleBodyColors[colorId-1];
		}
		else
		VehicleBody[UserPrefs.currentVehicle-1].GetComponent<Renderer>().material.color = vehicleManager.vehicleBodyColors[colorId-1];


		
	}
}
