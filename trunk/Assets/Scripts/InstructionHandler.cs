using UnityEngine;
using System.Collections;

public class InstructionHandler : MonoBehaviour {
	public GameObject infoPanel;
	string arrest= "Arrest the Thief";
	string deliever= "Pick the thief and deliver to other place";
	string irds= "Crash the thief car by hitting";
	string briefcase= "Collect the briefcase before Thief can";
	// Use this for initialization
	void Awake () {
//		ShowInfoPanel("Test Drive");
		infoPanel.gameObject.SetActive (false);
		TutorialManager.Instance.infoPanel = this.gameObject;
//		TutorialManager.Instance.mapArrow = GameObject.FindGameObjectWithTag ("Indicator").GetComponent<UISprite>();
//		StartCoroutine (waitToShowInstructions ());
	}
	
	// Update is called once per frame
	void Update () {
		//InstructionPanel
	}
	public void ShowInfoPanel(string textToDisplay){

		infoPanel.SetActive (true);
		infoPanel.GetComponentInChildren<UILabel>().text = textToDisplay;
		infoPanel.GetComponent<UIPanel>().alpha = 1;
		var tweenAlpha = infoPanel.AddComponent<TweenAlpha>();
		tweenAlpha.from = 1;
		tweenAlpha.to = 0;
		tweenAlpha.duration = 7;
		tweenAlpha.delay = 0;
		StartCoroutine(HideInfoPanel());
	}
	
	IEnumerator HideInfoPanel(){
		yield return new WaitForSeconds(7);
		Destroy(infoPanel.GetComponent<TweenAlpha>());
	}
	 public void setInstruction()
	{
		if(UserPrefs.isTutorial)
		{
			if(Constants.levelType[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1] == 1)
			{
				ShowInfoPanel(arrest);
			}
			else if(Constants.levelType[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1] == 2)
			{
				ShowInfoPanel(deliever);
			}
			else if(Constants.levelType[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1] == 3)
			{
				ShowInfoPanel(irds);
			}
			else if(Constants.levelType[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1] == 4)
			{
				ShowInfoPanel(briefcase);
			}
		}
		else
		{
			if(Constants.levelType[UserPrefs.currentEpisode-1,UserPrefs.currentLevel-1] == 1)
			{

			}
		}
	}
	IEnumerator waitToShowInstructions()
	{
		yield return new WaitForSeconds (1.5f);
		setInstruction ();
	}
}
