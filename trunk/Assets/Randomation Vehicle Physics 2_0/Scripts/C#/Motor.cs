﻿using UnityEngine;
using System.Collections;

//Class for engines
public class Motor : MonoBehaviour
{
	protected VehicleParent vp;
	public bool ignition;
	public float power = 1;
	private bool notBlast = false;
	[Tooltip("Throttle curve, x-axis = input, y-axis = output")]
	public AnimationCurve inputCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
	protected float actualInput;//Input after applying the input curve
	
	public AudioSource snd;
	
	[Header("Engine Audio")]
	
	public float minPitch;
	public float maxPitch;
	[System.NonSerialized]
	public float targetPitch;
	protected float pitchFactor;
	protected float airPitch;
	
	[Header("Nitrous Boost")]
	
	public bool canBoost = true;
	[System.NonSerialized]
	public bool boosting;
	public float boost = 1;
	bool boostReleased;
	bool boostPrev;
	
	[Tooltip("X-axis = local z-velocity, y-axis = power")]
	public AnimationCurve boostPowerCurve = AnimationCurve.EaseInOut(0, 0.1f, 50, 0.2f);
	public float maxBoost = 1;
	public float boostBurnRate = 0.01f;
	public AudioSource boostLoopSnd;
	AudioSource boostSnd;//AudioSource for boostStart and boostEnd
	public AudioClip boostStart;
	public AudioClip boostEnd;
	public ParticleSystem[] boostParticles;
	
	[Header("Damage")]
	
	[RangeAttribute(0, 1)]
	public float strength = 1;
	//[System.NonSerialized]
	public float health = 1;
	public float damagePitchWiggle;
	public ParticleSystem smoke;
	float initialSmokeEmission;
	private bool Enemy;
	HudStatus hud;
	EnemyHealth eh;
	public virtual void Start()
	{
		vp = transform.root.GetComponent<VehicleParent>();
		if (transform.root.gameObject.tag == "Player2") {
			strength = strength + Constants.PlayerCarHealth [UserPrefs.currentEpisode - 1, UserPrefs.currentLevel - 1];
			if(strength>=1.0f)
			{
				strength=0.98f;
			}

			hud=GameObject.FindObjectOfType<HudStatus>();
			
		} else {
			strength = strength  + Constants.EnemyCarsHealth [UserPrefs.currentEpisode - 1, UserPrefs.currentLevel - 1];
			eh=	this.gameObject.transform.root.GetComponentInChildren<EnemyHealth>();
			
		}
		
		//Get engine sound
		snd = GetComponent<AudioSource>();
		if (snd)
		{
			snd.pitch = minPitch;
		}
		
		//Get boost sound
		if (boostLoopSnd)
		{
			GameObject newBoost = Instantiate(boostLoopSnd.gameObject, boostLoopSnd.transform.position, boostLoopSnd.transform.rotation) as GameObject;
			boostSnd = newBoost.GetComponent<AudioSource>();
			boostSnd.transform.parent = boostLoopSnd.transform;
			boostSnd.transform.localPosition = Vector3.zero;
			boostSnd.transform.localRotation = Quaternion.identity;
			boostSnd.loop = false;
		}
		
		if (smoke)
		{
			initialSmokeEmission = smoke.emissionRate;
		}
	}
	
	public virtual void FixedUpdate()
	{
		health = Mathf.Clamp01(health);
		
		//Boost logic
		boost = Mathf.Clamp(boosting ? boost - boostBurnRate * Time.timeScale * 0.05f : boost, 0, maxBoost);
		boostPrev = boosting;
		
		if (canBoost && ignition && health > 0 && !vp.crashing && boost > 0 && (vp.hover ? vp.accelInput != 0 || Mathf.Abs(vp.localVelocity.z) > 1 : vp.accelInput > 0 || vp.localVelocity.z > 1))
		{
			if (((boostReleased && !boosting) || boosting) && vp.boostButton)
			{
				boosting = true;
				boostReleased = false;
			}
			else
			{
				boosting = false;
			}
		}
		else
		{
			boosting = false;
		}
		
		if (!vp.boostButton)
		{
			boostReleased = true;
		}
		
		if (boostLoopSnd && boostSnd)
		{
			if (boosting && !boostLoopSnd.isPlaying)
			{
				boostLoopSnd.Play();
			}
			else if (!boosting && boostLoopSnd.isPlaying)
			{
				boostLoopSnd.Stop();
			}
			
			if (boosting && !boostPrev)
			{
				boostSnd.clip = boostStart;
				boostSnd.Play();
			}
			else if (!boosting && boostPrev)
			{
				boostSnd.clip = boostEnd;
				boostSnd.Play();
			}
		}
	}
	
	public virtual void Update()
	{
		//Set engine sound properties
		if (transform.root.tag == "Player2") {
			hud.HealthBar.sliderValue = health;


		} else {
			if(eh)
			eh.health=health;

		}

		if (snd)
		{
			if (ignition && health > 0)
			{
				snd.enabled = true;
				snd.pitch = Mathf.Lerp(snd.pitch, Mathf.Lerp(minPitch, maxPitch, targetPitch), 20 * Time.deltaTime) + Mathf.Sin(Time.time * 200*  (1 - health)) * (1 - health) * 0.1f * damagePitchWiggle;
				snd.volume = Mathf.Lerp(snd.volume, 0.7f + targetPitch * 0.8f, 20 * Time.deltaTime);
			}
			else
			{
				snd.enabled = false;
			}
		}
		
		//Play boost particles
		if (boostParticles.Length > 0)
		{
			foreach (ParticleSystem curBoost in boostParticles)
			{
				if (boosting && curBoost.isStopped)
				{
					curBoost.Play();
				}
				
				else if (curBoost)
				{
					if(!boosting && curBoost.isPlaying)
						curBoost.Stop();
				}
			}
		}
		
		if (smoke)
		{
			smoke.emissionRate = health < 0.6f ? initialSmokeEmission * (1 - health) : 0;
		}
		if (Enemy) {
			
			if (health < 0.3f) {
				if (!notBlast) {
					notBlast = true;
					BlastCar ();
					
				}
			}
		}
		else
		{
			if (health <= 0.0f) {
				if (!notBlast) {
					
					notBlast = true;
					BlastCar ();
					
				}
			}
			
		}
		
		
	}
	
	void BlastCar()
	{
		if(notBlast)
			if(this.transform.root.gameObject.GetComponent<CarBlast> ().enabled ==false)
				this.transform.root.gameObject.GetComponent<CarBlast> ().enabled = true;
		//Camera.main.GetComponent<SmoothFollow>().target.LookAt(this.transform.root);
		//Invoke("ResetCam",3f);
	}
	//	void ResetCam()
	//	{
	//		Camera.main.GetComponent<SmoothFollow>().target.localEulerAngles = new Vector3(0,0,0);
	//	}
	void OnCollisionEnter(Collision collision) {
		
		if(transform.root.tag!="Player2")
			health=health-collision.relativeVelocity.magnitude*0.05f;
		
		
		
	}
	
	
}