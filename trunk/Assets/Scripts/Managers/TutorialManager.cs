using UnityEngine;
using System.Collections;

public class TutorialManager : SingeltonBase<TutorialManager> {
	public GameObject infoPanel;
	public enum TutorialStates{
		FINDVEHICLE,
		SIT,
		DRIVE,
		ARRESTTHIEF,
		THIEFONMAP,
		CHECKPOINT,
		LIMITEDTIME,
		ENTERVEHICLE,
		NEXTCHECKPOINT,
		PICKTHIEF,
		THIEFINAPPRACH,
		LOCATEBRIEFCASE,
		PICKBEFORETHIEF,
		INTRO,
		HIT,
		LEAVEVEHICLE
	}
	public TutorialStates tutorialState;
	public TutorialStates previousState;
	//Sprite
	public UISprite mapArrow;
	// Use this for initialization
	void OnEnable()
	{
		if(UserPrefs.currentLevel == 2)
			ChangeState (TutorialStates.FINDVEHICLE);
	}
	void Start () {
//		infoPanel = GameObject.FindGameObjectWithTag ("InstructionPanel");
//		mapArrow.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ChangeState(TutorialStates state)
	{
//		if(state == TutorialStates.THIEFONMAP)
//		{
////			infoPanel.GetComponent<InstructionHandler>().infoPanel
//			StartCoroutine(enableArrow());
//			StartCoroutine(disableArrow());
//			tutorialState = TutorialStates.THIEFONMAP;
//
////			infoPanel.GetComponent<InstructionHandler>().ShowInfoPanel(InstrustionStrings.thiefOnMap);
//			if(UserPrefs.currentLevel == 1){
//				StartCoroutine(waitToShowText(InstrustionStrings.thiefOnMap,1f));
//				ChangeState (TutorialStates.LIMITEDTIME);
//			}
//			else if(UserPrefs.currentLevel == 3){
//				StartCoroutine(waitToShowText(InstrustionStrings.thiefCarOnMap,1f));
//				ChangeState (TutorialStates.HIT);
//			}
//
//
//		}
//		else if(state == TutorialStates.LIMITEDTIME)
//		{
//			StartCoroutine(waitToShowText(InstrustionStrings.limitedTime,6f));
//
//			tutorialState = TutorialStates.LIMITEDTIME;
//			ChangeState (TutorialStates.ARRESTTHIEF);
//		}
//		else if(state == TutorialStates.ARRESTTHIEF)
//		{
//			StartCoroutine(waitToShowText(InstrustionStrings.arrestThief,13f));
//
//			tutorialState = TutorialStates.ARRESTTHIEF;
//			ChangeState (TutorialStates.FINDVEHICLE);
//		}
//		else if(state == TutorialStates.FINDVEHICLE)
//		{
//			StartCoroutine(enableArrow());
//			StartCoroutine(disableArrow());
//
//			if(tutorialState == TutorialStates.ARRESTTHIEF)
//				StartCoroutine(waitToShowText(InstrustionStrings.findVehicle,20f));
//			else
//				StartCoroutine(waitToShowText(InstrustionStrings.findVehicle,1f));
//			tutorialState = TutorialStates.FINDVEHICLE;
//		}
//		else if(state == TutorialStates.ENTERVEHICLE)
//		{
//			StartCoroutine(waitToShowText(InstrustionStrings.enterVehicle,0f));
//			tutorialState = TutorialStates.ENTERVEHICLE;
//		}
//		else if(state == TutorialStates.CHECKPOINT)
//		{
//			if(UserPrefs.currentLevel == 2){
//				StartCoroutine(enableArrow());
//				StartCoroutine(disableArrow());
//				StartCoroutine(waitToShowText(InstrustionStrings.locateCheckPoint,1f));
//				tutorialState = TutorialStates.CHECKPOINT;
//			}
//		}
//		else if(state == TutorialStates.NEXTCHECKPOINT)
//		{
//			StartCoroutine(enableArrow());
//			StartCoroutine(disableArrow());
//			StartCoroutine(waitToShowText(InstrustionStrings.locateNextCheckPoint,1f));
//			tutorialState = TutorialStates.NEXTCHECKPOINT;
//		}
//		else if(state == TutorialStates.PICKTHIEF)
//		{
//
//			StartCoroutine(waitToShowText(InstrustionStrings.pickThief,1f));
//			tutorialState = TutorialStates.PICKTHIEF;
//		}
//		else if(state == TutorialStates.THIEFINAPPRACH)
//		{
//			
//			StartCoroutine(waitToShowText(InstrustionStrings.approachingThief,1f));
//			tutorialState = TutorialStates.THIEFINAPPRACH;
//		}
//		else if(state == TutorialStates.LOCATEBRIEFCASE)
//		{
//			StartCoroutine(enableArrow());
//			StartCoroutine(disableArrow());
//			StartCoroutine(waitToShowText(InstrustionStrings.locateBriefcase,1f));
//			tutorialState = TutorialStates.LOCATEBRIEFCASE;
//		}
//		else if(state == TutorialStates.PICKBEFORETHIEF)
//		{
//
//			StartCoroutine(waitToShowText(InstrustionStrings.pickBriefcase,1f));
//			tutorialState = TutorialStates.PICKBEFORETHIEF;
//
//		}
//		else if(state == TutorialStates.INTRO)
//		{
//			tutorialState = TutorialStates.INTRO;
//			if(UserPrefs.currentLevel == 1 || UserPrefs.currentLevel == 3)
//				ChangeState (TutorialStates.THIEFONMAP);
//			else if(UserPrefs.currentLevel == 2)
//				ChangeState (TutorialStates.FINDVEHICLE);
//			mapArrow =  GameObject.FindGameObjectWithTag ("Indicator").GetComponent<UISprite>();
//			mapArrow.enabled = false;
//		}
//		else if(state == TutorialStates.HIT)
//		{
//			StartCoroutine(waitToShowText(InstrustionStrings.hitThief,7f));
//			tutorialState = TutorialStates.HIT;
//		}
//		else if(state == TutorialStates.LEAVEVEHICLE)
//		{
//			StartCoroutine(waitToShowText(InstrustionStrings.leaveVehicle,7f));
//			tutorialState = TutorialStates.LEAVEVEHICLE;
//		}
	}
	public IEnumerator waitToShowText(string textToDisplay,float time)
	{
		yield return new WaitForSeconds (time);
		infoPanel.GetComponent<InstructionHandler>().ShowInfoPanel(textToDisplay);
	}
	IEnumerator disableArrow()
	{
		yield return new WaitForSeconds (6f);
		mapArrow.enabled = false;
	}
	IEnumerator enableArrow()
	{
		yield return new WaitForSeconds (1.2f);
		mapArrow.enabled = true;
	}
}
