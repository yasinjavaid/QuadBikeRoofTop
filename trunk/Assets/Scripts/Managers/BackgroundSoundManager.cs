using UnityEngine;
using System.Collections;

public class BackgroundSoundManager :SingeltonBase<BackgroundSoundManager> {
	
	
	 public AudioSource backgrpundmusicSource;
	public AudioClip backgroundMusicClip;
	// Use this for initialization
	bool isalreadyplaying = false;
	void Start () {
//		DontDestroyOnLoad(gameObject);
//		backgrpundmusicSource = gameObject.GetComponent<AudioSource>();
//		Debug.LogError(backgrpundmusicSource+"abc"+UserPrefs.isMusic);
		
		if(!UserPrefs.isSound)
		{
//			backgrpundmusicSource.Stop();
//			isalreadyplaying = false;
		}
		else{
//			Debug.LogError("Playing");
//			backgrpundmusicSource.audio.clip = backgroundMusicClip;
//			backgrpundmusicSource.Play();
//			isalreadyplaying = true;
		}
	}
	// Update is called once per frame
	void Update () {
		//playOrStopMusic ();
	}
	public void playOrStopMusic(){
		
//		if(!UserPrefs.isSound)
//		{
//			backgrpundmusicSource.Stop();
//			isalreadyplaying = false;
//		}
//		else if(!isalreadyplaying){
//			isalreadyplaying = true;
//			backgrpundmusicSource.audio.clip = backgroundMusicClip;
//			backgrpundmusicSource.Play();
//		}
	} 
	public void stopBGSound()
	{
		isalreadyplaying = false;
		backgrpundmusicSource.Stop();
	}
}
