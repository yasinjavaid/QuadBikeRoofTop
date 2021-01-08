using UnityEngine;
using System.Collections;

public class PauseMenuStatus : MonoBehaviour {

	public UIImageButton buttonsBtn;
	public UIImageButton tiltBtn;
	public UIImageButton steerBtn;
	public UIImageButton soundBtn;
	public UIImageButton kphBtn;
	public UIImageButton mphBtn;
	public UILabel coinsRequiredLbl;
	public UISprite vehicleSprite;
	public UILabel need;
	public UILabel toUnlock;
	public UISprite coinsSprite;
	public UISprite lockSprite;
	string []vehicleSpritesNames = {"c1","c2","c3","c4","c5"};

	// Use this for initialization
	void Start () {
		SetPauseMenuStatus();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetPauseMenuStatus(){
		switch (UserPrefs.accelerometerFactor){
		case 0:
			buttonsBtn.GetComponentInChildren<UISprite>().spriteName = "touch-deactive";
			tiltBtn.GetComponentInChildren<UISprite>().spriteName = "tilt-deactive";
			steerBtn.GetComponentInChildren<UISprite>().spriteName = "steering-active";//steering-active
//			buttonsBtn.collider.enabled = true;
//			tiltBtn.collider.enabled = true;
//			steerBtn.collider.enabled = false;
			break;

		case 1:
			buttonsBtn.GetComponentInChildren<UISprite>().spriteName = "touch-deactive";
			tiltBtn.GetComponentInChildren<UISprite>().spriteName = "tilt-active";//tilt-deactive
			steerBtn.GetComponentInChildren<UISprite>().spriteName = "steering-deactivr";
//			buttonsBtn.collider.enabled = true;
//			tiltBtn.collider.enabled = false;
//			steerBtn.collider.enabled = true;
			break;

		case 2:
			buttonsBtn.GetComponentInChildren<UISprite>().spriteName = "touch-active";//touch-deactive
			tiltBtn.GetComponentInChildren<UISprite>().spriteName = "tilt-deactive";
			steerBtn.GetComponentInChildren<UISprite>().spriteName = "steering-deactivr";
//			buttonsBtn.collider.enabled = false;
//			tiltBtn.collider.enabled = true;
//			steerBtn.collider.enabled = true;
			break;
		}

		soundBtn.GetComponentInChildren<UISprite>().spriteName = UserPrefs.soundState ? "sound-on" : "sound-off";
		SetSound ();
//		switch (UserPrefs.isKPH){
//		case true:
//			kphBtn.collider.enabled = false;
//			mphBtn.collider.enabled = true;
//			kphBtn.GetComponentInChildren<UILabel>().color = new Color32(128,128,128,255);
//			mphBtn.GetComponentInChildren<UILabel>().color = new Color32(255,158,0,255);
//			break;
//
//		case false:
//			kphBtn.collider.enabled = true;
//			mphBtn.collider.enabled = false;
//			mphBtn.GetComponentInChildren<UILabel>().color = new Color32(128,128,128,255);
//			kphBtn.GetComponentInChildren<UILabel>().color = new Color32(255,158,0,255);
//			break;
//		}
//
		var indexOfNextVehicleToUnlock = 0;
		for(int i = 0 ; i < UserPrefs.vehicleUnlockArray.Length ; i++){
			if(!UserPrefs.vehicleUnlockArray[i]){
				indexOfNextVehicleToUnlock = i;
				break;
			}
		}
		if (VehicleManager.vehicleArray [indexOfNextVehicleToUnlock].price - UserPrefs.totalCoins < 0)
			coinsRequiredLbl.text = "0";
		else
			coinsRequiredLbl.text = (VehicleManager.vehicleArray[indexOfNextVehicleToUnlock].price - UserPrefs.totalCoins).ToString();

		if (indexOfNextVehicleToUnlock != 0) {
			vehicleSprite.spriteName = vehicleSpritesNames[indexOfNextVehicleToUnlock];
		}
		else 
		{
			vehicleSprite.spriteName = vehicleSpritesNames[Random.Range(0,4)];	
			need.enabled = false;
			toUnlock.enabled = false;
			coinsRequiredLbl.enabled = false;
			coinsSprite.enabled = false;
			lockSprite.enabled = false;
		}
	}

	public void SetSound(){
		if(UserPrefs.isSound)
		{
			GameManager.Instance.ChangeState(GameManager.SoundState.UNMUTESOUND);
		}
		else
		{
			GameManager.Instance.ChangeState(GameManager.SoundState.MUTESOUND);
		}
		UserPrefs.Save();
		
	}
}
