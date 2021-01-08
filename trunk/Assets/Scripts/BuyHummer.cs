using UnityEngine;
using System.Collections;

public class BuyHummer : MonoBehaviour {

	// Use this for initialization
	public GameObject panel;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(UserPrefs.isTryHummerPurchaseSucceed){
			UserPrefs.isTryHummerPurchaseSucceed = false;
			UserPrefs.Save();
			purchaseHummer();
		}
	}
	public void purchaseHummer(){
		Debug.Log("+++ purchaseHummer public method called");
//		GAManager.Instance.LogDesignEvent("PurchaseJeep::Yes::Buy");

		int coinsRequired = VehicleManager.vehicleArray[2].price;
		GameManager.Instance.SubtractCoins(coinsRequired);
//		GAManager.Instance.LogDesignEvent("CarUnlocked::Car"+UserPrefs.currentVehicle.ToString());
		UserPrefs.vehicleUnlockArray[2] = true;
		UserPrefs.Save();
		panel.SetActive(false);
	}
	void OnClick()
	{
		if (this.gameObject.name == "btnYes") {
//			GAManager.Instance.LogDesignEvent("PurchaseJeep::Yes");
			int coinsRequired = VehicleManager.vehicleArray[2].price;
			if(UserPrefs.totalCoins>=coinsRequired )
			{
				GameManager.Instance.SubtractCoins(coinsRequired);
//				GAManager.Instance.LogDesignEvent("CarUnlocked::Car"+UserPrefs.currentVehicle.ToString());
				UserPrefs.vehicleUnlockArray[2] = true;
				UserPrefs.Save();
				panel.SetActive(false);
			}
			else
			{
				UserPrefs.isTryHummerPurchase = true;
				GameManager.Instance.PurchasePackage(ConstantsNew.PACKAGE_4);
			}
		}
		else if (this.gameObject.name == "btnNo") {
//			GAManager.Instance.LogDesignEvent("PurchaseJeep::No");
			panel.SetActive(false);
		}
	}

}
