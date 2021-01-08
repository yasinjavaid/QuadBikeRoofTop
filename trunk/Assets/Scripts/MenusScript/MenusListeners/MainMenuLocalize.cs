using UnityEngine;
using System.Collections;

public class MainMenuLocalize : MonoBehaviour {

	// Use this for initialization
	public GameObject NoAdsBtn;
	public GameObject SocialBtn;
	public GameObject socialPanel;

	public GameObject btnBack;
	public GameObject socialLayer;

	public UILabel TotalCoinsLbl;
	void Start () {

		setCoinsText();
		if(UserPrefs.isSound)
		{
			SoundManager.Instance.GetComponent<AudioSource>().mute = false;
		}

	}

	public void setState(){
		if(GameManager.Instance.GetCurrentGameState()== GameManager.GameState.MAINMENU){
			socialLayer.SetActive(true);
			btnBack.SetActive(false);
		}else{
			socialLayer.SetActive(false);
			btnBack.SetActive(true);
		}
	}

	public void setStateForSubMenu(){ // Submenus include Settings menu and shop
		socialLayer.SetActive(false);
		btnBack.SetActive(true);
	}

	void Update()
	{
		TotalCoinsLbl.GetComponent<UILabel>().text = string.Format("{0:#,###0}", UserPrefs.totalCoins);

	}

	public void setCoinsText(){
		TotalCoinsLbl.text = string.Format("{0:#,###0}", UserPrefs.totalCoins);//UserPrefs.totalCoins.ToString();
	}

	public void socialBtnAction(bool isPressed){
		if(isPressed){
			SocialBtn.GetComponentInChildren<UISprite>().spriteName = "share-p" ;
			iTween.MoveTo(socialPanel, iTween.Hash(  "y", socialPanel.transform.position.y -1.083f,  "time", 0.4, "easetype",iTween.EaseType.easeInOutCubic  )  ); 
		}
		else{
			SocialBtn.GetComponentInChildren<UISprite>().spriteName = "share-up" ;
			iTween.MoveTo(socialPanel, iTween.Hash(  "y", socialPanel.transform.position.y +1.083f,  "time", 0.4, "easetype",iTween.EaseType.easeInOutCubic  )  ); 
		}
	}
}
