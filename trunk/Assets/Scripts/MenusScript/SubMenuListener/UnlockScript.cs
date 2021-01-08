using UnityEngine;
using System.Collections;

public class UnlockScript : MonoBehaviour {

	public UILabel purcahsingText;
	// Use this for initialization
	void Start () {
		purcahsingText.text = "Do you want to unlock this Taxi for $ "+GameConstants.getCoinsToUnlock(VehicleSelectionMenuListenerNew.selectedVehicleIndex)+" ?";
	}
	
	void OnClick(){
		GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND);
	
		if(this.name.Equals("Nobtn")){
			Destroy(GameObject.FindGameObjectWithTag("LevelThankyou"));
			Resources.UnloadUnusedAssets();
		}
		else if(this.name.Equals("YesBtn")){

			
			/*if(VehicleSelectionMenuListenerNew.selectedVehicleIndex == 1){
				GameManager.Instance.PurchaseProductResult(Constants.POLICE_02,true);
			}
			else if(VehicleSelectionMenuListenerNew.selectedVehicleIndex == 2){
				GameManager.Instance.PurchaseProductResult(Constants.POLICE_03,true);
			}
			else if(VehicleSelectionMenuListenerNew.selectedVehicleIndex == 3){
				GameManager.Instance.PurchaseProductResult(Constants.POLICE_04,true);
			}
			else if(VehicleSelectionMenuListenerNew.selectedVehicleIndex == 4){
				GameManager.Instance.PurchaseProductResult(Constants.POLICE_05,true);
			}
			else if(VehicleSelectionMenuListenerNew.selectedVehicleIndex == 5){//Hummer Police
				GameManager.Instance.PurchaseProductResult(Constants.POLICE_06_HUMMER,true);
			}

			UserPrefs.totalCoins -= GameConstants.getCoinsToUnlock(VehicleSelectionMenuListenerNew.selectedVehicleIndex);
			UserPrefs.Save();
			Destroy(GameObject.FindGameObjectWithTag("LevelThankyou"));
			Resources.UnloadUnusedAssets();
			*/
		}
		
	}
}
