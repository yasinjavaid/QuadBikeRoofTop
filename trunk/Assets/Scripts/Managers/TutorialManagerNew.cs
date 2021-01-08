using UnityEngine;
using System.Collections;

public class TutorialManagerNew : SingeltonBase<TutorialManagerNew> {

	public GameObject infoPanel;
	public GameObject enterBtnArrow;
	public GameObject mapArrow;
	bool isTutorialPanelShown = false;
	UILabel tutorialLabel;

	public GameObject textPanel;

	public enum TutorialState{
		INTROSITINCAR,
		INTROPICKNDROP,
		DROPTHIEF,
		INTROARRESTTHIEF,
		INTROSMASHTHIEFCAR,
		INTROCOLLECTITEM,
		GETOUTOFCAR,
		SHOWENTERBTNARROW,
		HIDEENTERBTNARROW,
		SHOWMAPARROW,
		NONE
	}
	TutorialState currentState;

	// Use this for initialization
	void Start () {
		if(infoPanel != null)
			tutorialLabel = infoPanel.transform.FindChild("textLabel").GetComponent<UILabel>();

		currentState = TutorialState.NONE;

		StartCoroutine(InitailizeTutorial());
	}
	
	// Update is called once per frame
	void Update () {
		if(isTutorialPanelShown && Input.GetMouseButtonDown(0)){
			isTutorialPanelShown = false;
			infoPanel.SetActive(false);
			Time.timeScale = 1;
		}
	}

	public void ChangeState(TutorialState state){
		switch (state){
		case TutorialState.INTROSITINCAR:
			if(!UserPrefs.isSitInCarTutorialCompleted && currentState == TutorialState.NONE){
				GAManager.Instance.LogDesignEvent("Tutorial::Intruction1::Tap");
				currentState = state;
				isTutorialPanelShown = true;
				infoPanel.SetActive(true);
				tutorialLabel.text = "Locate your car and get into it";
				ShowMapArrow(true);
//				Time.timeScale = 0;
			}
			break;
		case TutorialState.INTROPICKNDROP:
			if(!UserPrefs.isPicknDropTutorialCompleted && currentState == TutorialState.INTROSITINCAR){
				GAManager.Instance.LogDesignEvent("Tutorial::SitInCar");
				GAManager.Instance.LogDesignEvent("Tutorial::Intruction2::Tap");
				currentState = state;
				isTutorialPanelShown = true;
				infoPanel.SetActive(true);
				tutorialLabel.text = "Drive your car towards the green spot";
				ShowMapArrow(true);
				Time.timeScale = 0;
			}
			break;
		case TutorialState.DROPTHIEF:
			if(!UserPrefs.isPicknDropTutorialCompleted && currentState == TutorialState.INTROPICKNDROP){
				GAManager.Instance.LogDesignEvent("Tutorial::PickArrestedCriminal");
				GAManager.Instance.LogDesignEvent("Tutorial::Intruction3::Tap");
				currentState = state;
				isTutorialPanelShown = true;
				infoPanel.SetActive(true);
				tutorialLabel.text = "Drop the arrested criminal to police station";
				ShowMapArrow(true);
				Time.timeScale = 0;
			}
			break;
		case TutorialState.INTROARRESTTHIEF:
			if(!UserPrefs.isArrestThiefTutorialCompleted && currentState == TutorialState.INTROSITINCAR){
				currentState = state;
				isTutorialPanelShown = true;
				infoPanel.SetActive(true);
				tutorialLabel.text = "Locate and drive your car towards the green spot.";
				ShowMapArrow(true);
				UserPrefs.isSitInCarTutorialCompleted = true;
//				Time.timeScale = 0;
			}
			break;
		case TutorialState.INTROSMASHTHIEFCAR:
			if(!UserPrefs.isSmashCarTutorialCompleted && currentState == TutorialState.NONE){
				currentState = state;
				isTutorialPanelShown = true;
				infoPanel.SetActive(true);
				tutorialLabel.text = "Locate criminal’s car and smash it.";
				ShowMapArrow(true);
//				Time.timeScale = 0;
			}
			break;
		case TutorialState.INTROCOLLECTITEM:
			if(!UserPrefs.isCollectItemTutorialCompleted && currentState == TutorialState.NONE){
				currentState = state;
				isTutorialPanelShown = true;
				infoPanel.SetActive(true);
				tutorialLabel.text = "Locate precious item and collect it before the thief does";
				ShowMapArrow(true);
//				Time.timeScale = 0;
			}
			break;
		case TutorialState.GETOUTOFCAR:
			if(((!UserPrefs.isArrestThiefTutorialCompleted && currentState == TutorialState.INTROARRESTTHIEF) || (!UserPrefs.isCollectItemTutorialCompleted && currentState == TutorialState.INTROCOLLECTITEM))  && !GameObject.FindObjectOfType<PlayerManager>().isPoliceManEnabled){
				isTutorialPanelShown = true;
				infoPanel.SetActive(true);
				tutorialLabel.text = "Get out of car in order to arrest the theif";
				ShowEnterButtonArrow(true);
				Time.timeScale = 0;
			}
			break;
		case TutorialState.SHOWMAPARROW:
			ShowMapArrow(true);
			break;
		case TutorialState.SHOWENTERBTNARROW:
			if(currentState == TutorialState.INTROSITINCAR && !UserPrefs.isSitInCarTutorialCompleted){
				ShowEnterButtonArrow(true);
			}
			break;
		case TutorialState.HIDEENTERBTNARROW:
//			if(currentState == TutorialState.INTROSITINCAR && !UserPrefs.isSitInCarTutorialCompleted){
				ShowEnterButtonArrow(false);
//			}
			break;
		case TutorialState.NONE:
			break;
		}
	}

	IEnumerator InitailizeTutorial(){
		yield return new WaitForSeconds(0.7f);
		if(UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 1){
			GAManager.Instance.LogDesignEvent("Tutorial::lvlStart");
			ChangeState(TutorialState.INTROSITINCAR);
		}else if(UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 2){
			ChangeState(TutorialState.INTROSITINCAR);
		}else if(UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 3){
			ChangeState(TutorialState.INTROSMASHTHIEFCAR);
		}else if(UserPrefs.currentEpisode == 1 && UserPrefs.currentLevel == 6){
			ChangeState(TutorialState.INTROCOLLECTITEM);
		}else if(Constants.levelType[UserPrefs.currentEpisode - 1, UserPrefs.currentLevel - 1] == 1){
			ShowInfoPanel("Arrest the running culprit");
		}else if(Constants.levelType[UserPrefs.currentEpisode - 1, UserPrefs.currentLevel - 1] == 2){
			ShowInfoPanel("Pick and drop the arrested thief");
		}else if(Constants.levelType[UserPrefs.currentEpisode - 1, UserPrefs.currentLevel - 1] == 3){
			ShowInfoPanel("Smash car of running criminal");
		}else if(Constants.levelType[UserPrefs.currentEpisode - 1, UserPrefs.currentLevel - 1] == 4){
			ShowInfoPanel("Collect the item before the thief does");
		}
	}

	void ShowEnterButtonArrow(bool show){
		enterBtnArrow.SetActive(show);
	}

	void ShowMapArrow(bool show){
		mapArrow.SetActive(show);
	}

	public void ShowInfoPanel(string textToDisplay){
		textPanel.SetActive (true);
		textPanel.GetComponentInChildren<UILabel>().text = textToDisplay;
		textPanel.GetComponent<UIPanel>().alpha = 1;
		var tweenAlpha = textPanel.AddComponent<TweenAlpha>();
		tweenAlpha.from = 1;
		tweenAlpha.to = 0;
		tweenAlpha.duration = 7;
		tweenAlpha.delay = 0;
		StartCoroutine(HideInfoPanel());
	}

	IEnumerator HideInfoPanel(){
		yield return new WaitForSeconds(7);
		Destroy(textPanel.GetComponent<TweenAlpha>());
	}
}
