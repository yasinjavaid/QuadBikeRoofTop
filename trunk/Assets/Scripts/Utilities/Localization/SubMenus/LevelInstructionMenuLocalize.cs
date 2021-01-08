using UnityEngine;
using System.Collections;

public class LevelInstructionMenuLocalize : MonoBehaviour {
	
	public UILabel lblInstructionTitle;
	public UILabel lblInstructionsDesc;
	
	
	
	
	
	// Use this for initialization
	void Start () {
		lblInstructionTitle.GetComponent<UILabel>().text = Localization.instance.Get("LevelInstructionsTitle");
		if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.PICKPASSENGERINSTRUCTIONS)
		{
			//lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("PICKPASSENGERINSTRUCTIONS");
			PICKUPDescription();
		}
		else if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.DROPPASSENGERINSTRUCTIONS)
		{
		//	lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("DROPPASSENGERINSTRUCTIONS") + " "   +  UserPrefs.remainingtTimeForCurrentLevel  + " " + Localization.instance.Get("DROPPASSENGERINSTRUCTIONS2");
			DROPDescription();
		} 
		else if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.DROPPASSENGERINSTRUCTIONS2)
		{
			//	lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("DROPPASSENGERINSTRUCTIONS") + " "   +  UserPrefs.remainingtTimeForCurrentLevel  + " " + Localization.instance.Get("DROPPASSENGERINSTRUCTIONS2");
			DROPDescription2();
		} 
		else if(GameManager.Instance.GetCurrentGameState()==GameManager.GameState.WAIT)
		{
		//	lblInstructionTitle.GetComponent<UILabel>().text ="Comming Soon";
		//	lblInstructionsDesc.GetComponent<UILabel>().text = "Text Comming Soon";
			WaitStateDescription();
		} 
	}
	
	
	void PICKUPDescription(){
		lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE1LEVEL1INSTRUCTIONS");
//		if(UserPrefs.currentEpisode==1)
//		{
//			switch (UserPrefs.currentLevel)	
//			{
//				case 1:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE1LEVEL1INSTRUCTIONS");
//					break;
//				case 2:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE1LEVEL2INSTRUCTIONS");
//					break;
//				case 3:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE1LEVEL3INSTRUCTIONS");
//					break;
//				case 4:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE1LEVEL4INSTRUCTIONS");
//					break;
//				default:
//					break;
//			}
//		}
//		else if(UserPrefs.currentEpisode==2)
//		{
//			
//			switch (UserPrefs.currentLevel)	
//			{
//				case 1:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE2LEVEL1INSTRUCTIONS");
//					break;
//				case 2:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE2LEVEL2INSTRUCTIONS");
//					break;
//				case 3:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE2LEVEL3INSTRUCTIONS");
//					break;
//				case 4:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE2LEVEL4INSTRUCTIONS");
//					break;
//				default:
//					break;
//			}
//		}
//		else if(UserPrefs.currentEpisode==3)
//		{
//			
//			switch (UserPrefs.currentLevel)	
//			{
//				case 1:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE3LEVEL1INSTRUCTIONS");
//					break;
//				case 2:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE3LEVEL2INSTRUCTIONS");
//					break;
//				case 3:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE3LEVEL3INSTRUCTIONS");
//					break;
//				case 4:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE3LEVEL4INSTRUCTIONS");
//					break;
//				default:
//					break;
//			}
//		}	
	}	

	void DROPDescription2(){
		lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE1LEVEL12INSTRUCTIONS");
	}

	void DROPDescription(){
		lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE1LEVEL11INSTRUCTIONS");
//		if(UserPrefs.currentEpisode==1)
//		{
//			switch (UserPrefs.currentLevel)	
//			{
//				case 1:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE1LEVEL11INSTRUCTIONS");
//					break;
//				case 2:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE1LEVEL21INSTRUCTIONS");
//					break;
//				case 3:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE1LEVEL31INSTRUCTIONS");
//					break;
//				case 4:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE1LEVEL41INSTRUCTIONS");
//					break;
//				default:
//					break;
//			}
//		}
//		else if(UserPrefs.currentEpisode==2)
//		{
//			
//			switch (UserPrefs.currentLevel)	
//			{
//				case 1:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE2LEVEL11INSTRUCTIONS");
//					break;
//				case 2:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE2LEVEL21INSTRUCTIONS");
//					break;
//				case 3:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE2LEVEL31INSTRUCTIONS");
//					break;
//				case 4:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE2LEVEL41INSTRUCTIONS");
//					break;
//				default:
//					break;
//			}
//		}
//		else if(UserPrefs.currentEpisode==3)
//		{
//			
//			switch (UserPrefs.currentLevel)	
//			{
//				case 1:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE3LEVEL11INSTRUCTIONS");
//					break;
//				case 2:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE3LEVEL21INSTRUCTIONS");
//					break;
//				case 3:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE3LEVEL31INSTRUCTIONS");
//					break;
//				case 4:
//					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE3LEVEL41INSTRUCTIONS");
//					break;
//				default:
//					break;
//			}
//		}	
	}
	
		void WaitStateDescription(){
		
		if(UserPrefs.currentEpisode==3)
		{
			switch (UserPrefs.currentLevel)	
			{
				case 1:
					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE3LEVEL11INSTRUCTIONS");
					break;
				case 2:
					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE3LEVEL21INSTRUCTIONS");
					break;
				case 3:
					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE3LEVEL31INSTRUCTIONS");
					break;
				case 4:
					lblInstructionsDesc.GetComponent<UILabel>().text = Localization.instance.Get("EPISODE3LEVEL41INSTRUCTIONS");
					break;
				default:
					break;
			}
		}
	}
		
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
}
