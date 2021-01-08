using UnityEngine;
using System.Collections;
using Prime31;

namespace Prime31{
	public class SocialManager : MonoBehaviour {
#if UNITY_ANDROID
		// Use this for initialization
		private bool isLoginRequestSent=false;
		void Start () {
			isLoginRequestSent = false;
			DontDestroyOnLoad(this.gameObject);
			TwitterInit();
		}
		
		// Update is called once per frame
		void Update () {
			if (isLoginRequestSent) {
				if(TwitterIsLogedIn()){
					GameManager.Instance.ChangeState(GameManager.GameState.TWEETDAILOG);
					isLoginRequestSent = false;
				}
			}
		}

		void OnEnable()
		{
			#if UNITY_ANDROID
//			TwitterManager.loginSucceededEvent += loginSucceeded;
			#endif
		}

		void OnDisable()
		{
			#if UNITY_ANDROID
			
		//	TwitterManager.loginSucceededEvent -= loginSucceeded;
			#endif
		}

		void loginSucceeded( string username )
		{
			Debug.Log( "Successfully logged in to Twitter - SocialManager: " + username );
			GameManager.Instance.ChangeState(GameManager.GameState.TWEETDAILOG);
		}

		public void TwitterInit(){
//			TwitterAndroid.init("vwF5sSiLmWgHP5KK7hM9nuNtv", "h8r5FueYxZUulzGt71vXg7ywx57DSmnbKcKrniqGJJxsMPsu4B");
		//	TwitterAndroid.init("XVfRatZT04NcFfq6HG6GMpk4V", "0R4E86gj0BTY0ZmrFIzJJPuQJcHMO6WJexA0cN49e5kBGO4Iq9");
		}

		public void TwitterLogin(){
			isLoginRequestSent = true;

		//	TwitterAndroid.showLoginDialog();
		}

		public bool TwitterIsLogedIn(){
		//	var isLoggedIn = TwitterAndroid.isLoggedIn();
		//	Debug.Log( "Is logged in?: " + isLoggedIn );
			return false;
		//	return isLoggedIn;
		}

		public void TwitterPostStatus(string status){
			//TwitterAndroid.postStatusUpdate( "im an update from the Twitter Android Plugin " + Random.Range(1, 10));
		//	TwitterAndroid.postStatusUpdate(status);
		}


#endif
	}
}
