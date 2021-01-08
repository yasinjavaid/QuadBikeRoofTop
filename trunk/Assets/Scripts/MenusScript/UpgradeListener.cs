using UnityEngine;
using System.Collections;

public class UpgradeListener : MonoBehaviour {

	public UILabel msgLabel ;
	int [] productIdentifiersAmount = {ConstantsNew.PACKAGE_1_Coins,ConstantsNew.PACKAGE_2_Coins,ConstantsNew.PACKAGE_3_Coins,ConstantsNew.PACKAGE_4_Coins,ConstantsNew.PACKAGE_5_Coins };
	string [] productIdentifiers = {ConstantsNew.PACKAGE_1,ConstantsNew.PACKAGE_2,ConstantsNew.PACKAGE_3,ConstantsNew.PACKAGE_4,ConstantsNew.PACKAGE_5 };
	// Use this for initialization
	void Start () {

		if(msgLabel)
			msgLabel.text = GameConstants.POPUP_MESSAGE;

		/*GameObject coinNeededObj = GameObject.FindGameObjectWithTag("NeededCoinLbl");
		if(coinNeededObj){
			UILabel coinNeededLbl = coinNeededObj.GetComponent<UILabel>();
			coinNeededLbl.text = "You need " + VehicleUpgradeMenuListener.CoinsNeeded + " more coins to unlock!";
		}*/

	}
	
	
	void OnClick(){
		if(this.name.Equals("Nobtn")){

			GameManager.GameState previous=GameManager.Instance.GetPreviousGameState();	
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLEUPGRADEMENU);
			GameManager.Instance.SetPreviousGameState(previous);

		}
		
		if(this.name.Equals("YesBtn")){

			if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.OUTOFCOINSHANDLINGUPGRADE)
			{
				//redirect to store - Show out of coins dialog
			}
			/*else if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.CONFIRMHANDLINGUPGRADE)
			{
				VehicleUpgradeMenuListener.purchaseHandlingUpgrade();
			}*/
			else if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.CONFIRMENGINEUPGRADE)
			{

				VehicleUpgradeMenuListener.purchaseEngineUpgrade();
			}
			else if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.CONFIRMSTEERINGUPGRADE)
			{
				VehicleUpgradeMenuListener.purchaseHandlingUpgrade();

			}
			else if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.CONFIRMBRAKESUPGRADE)
			{
				VehicleUpgradeMenuListener.purchaseBrakeUpgrade();

			}
			else if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.CONFIRMCOLORUPGRADE)
			{
				VehicleUpgradeMenuListener.purchaseColor();
				VehicleSelectionMenuLocalize vehicleSelectionLocalizeColor = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>();
				vehicleSelectionLocalizeColor.paintArrow.SetActive(false);
				UserPrefs.isColorUpateDone = true;
			}
			else if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.CONFIRMWHEELUPGRADE)
			{
				VehicleUpgradeMenuListener.purchaseWheel();
			}else  if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.VEHICLEUNLOCK)
			{
				VehicleUpgradeMenuListener.purchaseVehicle();
			}

			GameManager.Instance.ChangeState(GameManager.SoundState.IAPORUPGRADESUCCESSSOUND);

			GameManager.GameState previous=GameManager.Instance.GetPreviousGameState();
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.VEHICLEUPGRADEMENU);
			GameManager.Instance.SetPreviousGameState(previous);

			VehicleSelectionMenuLocalize vehicleSelectionLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>();
			vehicleSelectionLocalize.updateCoions();
			VehicleSelectionMenuLocalize vehicleSelectionMenuLocalize = GameObject.FindGameObjectWithTag("VehicleSelectionMenu").GetComponent<VehicleSelectionMenuLocalize>();
			vehicleSelectionMenuLocalize.checkEnoughCoinMsg();

		}
		else if(this.name.Equals("YesBtnOnBuyCoin")){
			//Debug.Log("YesBtnOnBuyCoin clicked");
			//Destroy(GameObject.FindGameObjectWithTag("LevelBuyCoin"));

			int packageIndex = 0;
			int minDiff = productIdentifiersAmount[0] - VehicleUpgradeMenuListener.CoinsNeeded;
			for(int i = 1 ; i < productIdentifiersAmount.Length ; i++){
				if(productIdentifiersAmount[i] - VehicleUpgradeMenuListener.CoinsNeeded > 0 && productIdentifiersAmount[i] - VehicleUpgradeMenuListener.CoinsNeeded < minDiff){
					packageIndex = i;
					minDiff = productIdentifiersAmount[i] - VehicleUpgradeMenuListener.CoinsNeeded;
				}
			}
			GameManager.Instance.PurchasePackage(productIdentifiers[packageIndex]);
			GameManager.Instance.ChangeState(GameManager.Instance.GetPreviousGameState());
//			GameManager.GameState previous=GameManager.Instance.GetPreviousGameState();
//			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.STORE);
//			GameManager.Instance.SetPreviousGameState(previous);
		}
		else if(this.name.Equals("NoBtnOnBuyCoin")){
			//Debug.Log("NoBtnOnBuyCoin clicked");
			//Destroy(GameObject.FindGameObjectWithTag("LevelBuyCoin"));

			GAManager.Instance.LogDesignEvent("MainMenu::Shop");
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.GameState.STORE);
			Destroy(this.gameObject.transform.root.gameObject);
			//GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
		}

		else if(this.name.Equals("TryBtn")){
			GameObject temp = GameObject.FindGameObjectWithTag("PaintTutorialUpgrade");
			if(temp != null)
				Destroy(temp);
		}
	}
}
