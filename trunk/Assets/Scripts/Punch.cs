using UnityEngine;
using System.Collections;

public class Punch : MonoBehaviour {

	// Use this for initialization
	public Vector3 amount;
	public float time;
	public float Delay;
	public float startTime;
	Vector3 resetPos;
	public Vector3 forceDirection;
	public float forceFactor = 99999;
	public float resetTime = 5f;
	public bool PlayOnStart = false;
	void Start () {
		resetPos = this.transform.localPosition;
		if(PlayOnStart){
			Invoke("playTween",startTime);
			//InvokeRepeating("ResetPos",startTime+time,resetTime);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision other)
	{
//		Debug.Log(other.gameObject.tag);

		if(other.gameObject.tag == "Player2")
		{
			if(other.gameObject.GetComponent<Rigidbody>().mass>4000)
			{
				time=4.0f;

			}
			else
				time=1.0f;
			//other.gameObject.rigidbody.AddForce(this.transform.forward*100f);
		//	other.gameObject.GetComponent<Rigidbody>().AddForce(forceDirection*forceFactor);
//			if(UserPrefs.isSound)
//			{
//				SoundManager.Instance.GetComponent<AudioSource>().PlayOneShot(SoundManager.Instance.HitSound);
//			}
		}
	}
	public void playTween()
	{

		iTween.PunchPosition(this.gameObject, iTween.Hash("amount",amount,"time", time, "delay", Delay,"loopType","loop"));

	}
	void ResetPos()
	{
		iTween.Stop(this.gameObject);
		this.transform.localPosition = resetPos;
		playTween();
	}
	public void ResetPosition()
	{
		Invoke("Reset",1f);
	}
	void Reset()
	{
		iTween.Stop(this.gameObject);
		this.transform.localPosition = resetPos;
	}
}
