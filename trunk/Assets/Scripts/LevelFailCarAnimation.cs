using UnityEngine;
using System.Collections;

public class LevelFailCarAnimation : MonoBehaviour {

	// Use this for initialization
	public Transform startMarker;
	public Transform endMarker;
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	ParticleEmitter [] smoke;
	bool stopAnim = false;
	public bool isPlayer = false;
	public GameObject [] playerCars;
	bool canSkid = false;
	float skidSpeed = 1.5f;
	public bool isLevelComplete = false;
	public GameObject fire;
	VehicleManager vehicleManager;
	void Start() {
		vehicleManager = GameObject.FindGameObjectWithTag("VehicleManager").GetComponent<VehicleManager>();
		if (isPlayer) {
			playerCars [UserPrefs.currentVehicle - 1].SetActive (true);
			setVehicleColor ();
			setVehicleWheels ();
		}
		Time.timeScale = 0.5f;
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 25;
		//Time.timeScale = newTimeScale;
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
		smoke = this.GetComponentsInChildren<ParticleEmitter>();
		foreach(ParticleEmitter g in smoke)
		{
			g.emit = true;
		}
		if(isPlayer){
		StartCoroutine(skid());
		}
	}
	void FixedUpdate() {
		if(!stopAnim){
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);

			if(distCovered > journeyLength)
			{
				stopAnim = true;
				if(!isPlayer)
				{
					if(isLevelComplete)
					{
						fire.SetActive(true);
						Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
						rb.AddForce(Vector3.up * Random.Range(500f,1500f));
						GetComponent<RotateGameObject>().enabled = true;
						Invoke("DiableRotation",1.5f);
					
					}
					foreach(ParticleEmitter g in smoke)
					{
						g.emit = false;
					}
				}
			}
		}
		if(canSkid)
		{
			if(isPlayer){
				this.transform.Rotate(Vector3.up * skidSpeed);
			}
		}
	}
	void DiableRotation()
	{
		GetComponent<RotateGameObject>().enabled = false;
		iTween.Stop(this.gameObject);
	}
	IEnumerator skid()
	{
		yield return new WaitForSeconds(0.5f);
		canSkid = true;
		yield return new WaitForSeconds(0.0f);
	//	skidSpeed = 3f;
		yield return new WaitForSeconds(0.5f);
		canSkid =   false;
		foreach(ParticleEmitter g in smoke)
		{
			g.emit = false;
		}
		Time.timeScale = 1f;
		QualitySettings.vSyncCount = 1;
		Application.targetFrameRate = 300;
		yield return new WaitForSeconds(4f);
		GameManager.Instance.ChangeState(GameManager.SoundState.LEVELFAILSOUND ,GameManager.GameState.CRASHED);	

	}
	public void setVehicleColor()
	{
		int colorId = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].currentColor-1;
		GameObject rendererBody = GameObject.FindGameObjectWithTag("PoliceBody");
		if(UserPrefs.currentVehicle == 1 )
		{
			rendererBody.GetComponent<Renderer>().materials[1].color = vehicleManager.vehicleBodyColors[colorId];
			
		}
		else
			rendererBody.GetComponent<Renderer>().material.color = vehicleManager.vehicleBodyColors[colorId];
		
		
	}
	public void setVehicleWheels()
	{
		int wheelId = VehicleManager.vehicleArray[(UserPrefs.currentVehicle-1)].currentWheel-1;
		Renderer []renderer =GameObject.FindGameObjectWithTag("Wheels").GetComponentsInChildren<Renderer>();
		
		for(int i= 0;i< renderer.Length;i++){
			
			renderer[i].materials[1].mainTexture= vehicleManager.Wheels[wheelId];	
			
			//renderer[i].material.mainTexture= vehicleManager.Wheels[wheelId];	
			
		}
		
	}
}
