using UnityEngine;
using System.Collections;

public class RateUsLocalize : MonoBehaviour {

	public UILabel lbltitle;
	public UILabel lblDescription;
	public UILabel lblRateUs;
	public GameObject panel1,panel2;
	
	// Use this for initialization
	void Start () {

		lbltitle.GetComponent<UILabel>().text = Localization.instance.Get("RateUsTitle");
//		lblDescription.GetComponent<UILabel>().lineWidth = 505;
		lblDescription.GetComponent<UILabel>().text = Localization.instance.Get("RateUsDescription");
		lblRateUs.GetComponent<UILabel>().text = Localization.instance.Get("RateUs");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
