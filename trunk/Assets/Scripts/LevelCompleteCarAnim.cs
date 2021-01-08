using UnityEngine;
using System.Collections;

public class LevelCompleteCarAnim : MonoBehaviour {

	// Use this for initialization
	public Transform startMarker;
	public Transform mid1,mid2;
	public Transform endMarker;
	private Transform endPoint;
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	ParticleEmitter [] smoke;
	bool stopAnim = false;
	public bool isPlayer = false;
	public GameObject [] playerCars;
	bool canSkid = false;
	float skidSpeed = 1.5f;
	VehicleManager vehicleManager;
	void Start() {
		vehicleManager = GameObject.FindGameObjectWithTag("VehicleManager").GetComponent<VehicleManager>();
		if(isPlayer){
			endPoint = mid1;
			playerCars[UserPrefs.currentVehicle-1].SetActive(true);
			setVehicleColor();
			setVehicleWheels();

		}
		else
		{
			endPoint = endMarker;
		}
		Time.timeScale = 0.5f;
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 25;
		//Time.timeScale = newTimeScale;
		startTime = Time.time;
		this.transform.position = startMarker.position;
		this.transform.rotation = startMarker.rotation;
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
		//	Debug.Log(Vector3.Distance(this.transform.position,endPoint.transform.position));
			if(Vector3.Distance(this.transform.position,endPoint.transform.position)>1f)
			{
				this.transform.Translate(Vector3.forward * speed);
			}
			else
			{
				stopAnim = true;
				if(!isPlayer)
				{
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
	IEnumerator skid()
	{
		yield return new WaitForSeconds(0.5f);
		canSkid = true;
		yield return new WaitForSeconds(0.1f);
		//canSkid = false;
		endPoint = mid2;
		stopAnim = false;
		skidSpeed = -1.5f;
		yield return new WaitForSeconds(0.1f);
		endPoint = endMarker;
		stopAnim = false;
		canSkid =   false;
		foreach(ParticleEmitter g in smoke)
		{
			g.emit = false;
		}
		Time.timeScale = 1f;
		QualitySettings.vSyncCount = 1;
		Application.targetFrameRate = 300;
		yield return new WaitForSeconds(0.5f);
			stopAnim = true;
		yield return new WaitForSeconds(4f);
		GameManager.Instance.ChangeState(GameManager.SoundState.LEVELSUCCESSSOUND ,GameManager.GameState.LEVELCOMPLETE);

		//GameManager.Instance.ChangeState(GameManager.SoundState.LEVELFAILSOUND ,GameManager.GameState.CRASHED);	

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
