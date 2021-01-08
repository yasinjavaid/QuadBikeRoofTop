using UnityEngine;
using System.Collections;

public class HideMenu : MonoBehaviour {

	public GameManager.GameState myState;
	public bool hasOtherStates;
	public GameManager.GameState[] myOtherStates;
	public bool hasForeground;
	public GameObject foreground;
	public EpisodeMenuListenerNew episodeListner;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.GetCurrentGameState () != myState) {
			if(hasOtherStates){
				foreach(var state in myOtherStates){
					if(GameManager.Instance.GetCurrentGameState() == state)
						return;
				}
			}
			if(hasForeground)
				foreground.SetActive(false);
			SetPanels (0);	
		} else {
			if(hasForeground)
				foreground.SetActive(true);
			if(hasOtherStates){
				foreach(var state in myOtherStates){
					if(GameManager.Instance.GetCurrentGameState() == state){
						SetPanels(1);	
						break;
					}
				}
			}
			SetPanels(1);		
		}
						
	}

	void SetPanels(int value){
		if (this.GetComponentInChildren<UIPanel> ().alpha == value)
			return;

		foreach (var panel in this.GetComponentsInChildren<UIPanel>()) {
			panel.alpha = value;
		}
		if (value == 1 && myState == GameManager.GameState.EPISODEMENU) {
			episodeListner.setepiosdeCoinsPanel();
		}
	}
}
