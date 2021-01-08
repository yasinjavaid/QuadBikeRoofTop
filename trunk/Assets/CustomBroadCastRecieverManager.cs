using UnityEngine;
using System.Collections;

public class CustomBroadCastRecieverManager : MonoBehaviour {

	void Awake()
		
	{
		
		DontDestroyOnLoad (this);
		
	}
	
	//
	
	void Start () {
		
		getReferrer ();
		
	}
	
	public void ProceedCallBack(string args)
		
	{
		
		try {
			
			Debug.Log ("$$$$$$$$$Custom Broadcast Received :: Referrer = : " + args.ToString ());
			
		} catch (System.Exception ex) {
			
			Debug.LogError ("Exception caught " + ex.ToString ());
			
		}
		
	}
	void getReferrer()
		
	{
		
		try {
			
			using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
				using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {		
					AndroidJavaClass cls_CompassActivity = new AndroidJavaClass ("com.tapinator.custombroadcastreceiver.ReferrerReceiver");	
					object[] args = new object[]{obj_Activity,"AmbulanceParkingPro", this.gameObject.name,"ProceedCallBack",""};	
					cls_CompassActivity.CallStatic ("getReferrer", args);
					
					
					
				}
				
			}
			
		} catch (System.Exception ex) {
			
			Debug.LogError ("Exception caught " + ex.ToString ());
			
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
