using UnityEngine;
using System.Collections;

public class AutoDestruct : MonoBehaviour {
	
	public float lifeTime = 1;
	private float creationTime;
	public bool isFakeLoading = false;
	// Use this for initialization
	void Start () {
		creationTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
//		if(Time.time > (creationTime + lifeTime)){
//			Vector3 gernadePosition = transform.position;
//			if(isFakeLoading && UserPrefs.isAudioDisabled){
//				UserPrefs.isSound = true;
//				UserPrefs.isAudioDisabled = false;
//			}
//			Destroy(gameObject);
//		}
	}
}
