using UnityEngine;
using System.Collections;
using Prime31;

public class TweetDailogListner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		if(this.gameObject.name.Equals("btnOk")){
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
			var socialManagerLocalize = this.transform.root.GetComponent<SocialManagerLocalize>();
			socialManagerLocalize.postTweet();
		}else if(this.gameObject.name.Equals("btnCancel")){
			GameManager.Instance.ChangeState(GameManager.SoundState.BUTTONCLICKSOUND, GameManager.Instance.GetPreviousGameState());
		}
	}
}

