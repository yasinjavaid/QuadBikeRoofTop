using UnityEngine;
using System.Collections;

public class OutOfFuelLocalize : MonoBehaviour {

	
	public UILabel outOfFuellbl;
	
	public UILabel fiveLTRlbl;	
	public UILabel tenLTRlbl;
	public UILabel twentyLTRlbl;
	
	public UILabel twentyfiveCoinslbl;	
	public UILabel fiftyCoinslbl;	
	public UILabel seventyFiveCoinslbl;	
	
	
	void Start () {
		GAManager.Instance.LogDesignEvent("levelOutOfFuel:"+"Level"+UserPrefs.currentLevel+"Episode"+UserPrefs.currentEpisode);
		
		outOfFuellbl.GetComponent<UILabel>().text = Localization.instance.Get("outOfFuel");
		fiveLTRlbl.GetComponent<UILabel>().text = ConstantsNew.outOfFuelPackageOneFuel.ToString() +ConstantsNew.space + Localization.instance.Get("LTR");
		tenLTRlbl.GetComponent<UILabel>().text = ConstantsNew.outOfFuelPackageTwoFuel.ToString() + ConstantsNew.space +Localization.instance.Get("LTR");
		twentyLTRlbl.GetComponent<UILabel>().text = ConstantsNew.outOfFuelPackageThreeFuel.ToString() +ConstantsNew.space + Localization.instance.Get("LTR");
				
		twentyfiveCoinslbl.GetComponent<UILabel>().text   = Localization.instance.Get("INAPP_CURRENCY") + " " + ConstantsNew.outOfFuelPackageOneCoins.ToString();
		fiftyCoinslbl.GetComponent<UILabel>().text        = Localization.instance.Get("INAPP_CURRENCY") + " " + ConstantsNew.outOfFuelPackageTwoCoins.ToString();
		seventyFiveCoinslbl.GetComponent<UILabel>().text  = Localization.instance.Get("INAPP_CURRENCY") + " " + ConstantsNew.outOfFuelPackageThreeCoins .ToString();
	}
}
