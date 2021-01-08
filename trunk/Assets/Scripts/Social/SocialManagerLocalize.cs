using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Prime31;

namespace Prime31
{

	public class SocialManagerLocalize : MonoBehaviour {
#if UNITY_ANDROID
	// Use this for initialization
		//public UIInput tweetDialogue;
		public UIInput tweetTxt;
		void Start () {
			tweetTxt.text = string.Format(Constants.tweet,Constants.bitlyLink);
		}
		
		// Update is called once per frame
		void Update () {
		
		}

//		void OnEnable()
//		{
//			#if UNITY_ANDROID
//			TwitterManager.loginSucceededEvent += loginSucceeded;
//			#endif
//		}
//		
//		
//		void OnDisable()
//		{
//			#if UNITY_ANDROID
//
//			TwitterManager.loginSucceededEvent -= loginSucceeded;
//			#endif
//		}
//		
//		
//		void twitterInitializedEvent()
//		{
//			Debug.Log( "twitterInitializedEvent" );
//		}
//		
//		
//		void loginSucceeded( string username )
//		{
//			Debug.Log( "Successfully logged in to Twitter - SocialManager: " + username );
//			GameManager.Instance.ChangeState(GameManager.GameState.TWEETDAILOG);
//		}
		
		
		void loginFailed( string error )
		{
			Debug.Log( "Twitter login failed: " + error );
		}

		public void showTwitterDialogue(){
			//tweetDialogue.text = "Hey, I am the text to tweet.";
			//tweetDialogue.gameObject.SetActive(true);
			tweetTxt.text = "Hey, I have cleared Level " + UserPrefs.currentLevel;
			Instantiate(Resources.Load("SubMenusNew/TweetPopup"));
		}

		public void postTweet(){
			Debug.Log("Post tweet msg : " + tweetTxt.text);
			SocialManager socialManager = GameObject.FindGameObjectWithTag("SocialManager").GetComponent<SocialManager>();
			socialManager.TwitterPostStatus(tweetTxt.text);
		}

		public void hideTwitterDialogue(){
			//tweetDialogue.gameObject.SetActive(false);
			GameObject temp = GameObject.FindGameObjectWithTag("TweetPopup");
			if(temp)
				Destroy(temp);
		}

#endif
	}
}
