using UnityEngine;
using System.Collections;

public class CarHit : MonoBehaviour {

	// Use this for initialization
	Rigidbody rb;
	public GameObject particls;
	public GameObject fire;
	public GameObject explosion;
	bool isHit = false;
	float maxHitVelocity = 8;
	bool isDestroying = false;
	void Start () {
		rb = this.GetComponent<Rigidbody>();
		maxHitVelocity = Mathf.Clamp(UserPrefs.currentLevel+8,8,17);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnEnable()
	{
		particls.SetActive(false);
		explosion.SetActive(false);
		fire.SetActive(false);
	}
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Player2")
		{

			Rigidbody playerRB = col.gameObject.GetComponent<Rigidbody>();
			if(playerRB.velocity.magnitude > maxHitVelocity && !isHit)
			{
				isHit = true;
				particls.SetActive(true);
				StartCoroutine("EnableFire",col.gameObject);
//				SmoothFollowForCamView.TargetTwo = this.transform;
				rb.AddForce(Vector3.up * playerRB.velocity.magnitude * 75000);
				rb.AddForce(col.transform.forward * playerRB.velocity.magnitude * 50000);
				GetComponent<CamViews>().EnableCamView();
				//Camera.main.GetComponent<CameraControl>().enabled = false;
				//Camera.main.GetComponent<SmoothFollowForCamView>().enabled = true;
				GetComponent<RotateGameObject>().enabled = true;
				Invoke("disaleRotation",2f);
				Invoke("disableParticals",5f);
				isDestroying = true;
				col.gameObject.GetComponent<ChasingCars>().canBusted =false;
			}
			else{
				if(!isDestroying)
				col.gameObject.GetComponent<ChasingCars>().canBusted =true;
			}
		}
	}
	IEnumerator EnableFire(GameObject p)
	{
		GameObject.FindObjectOfType<Level>().CarHit();
		yield return new WaitForSeconds(0.5f);
		fire.SetActive(true);
		yield return new WaitForSeconds (1.2f);
		rb.AddForce(p.transform.forward  * 50000);
		yield return new WaitForSeconds(0.01f);
		rb.AddForce(Vector3.up * 75000);
		explosion.SetActive(true);
		GetComponent<RotateGameObject>().enabled = true;
		Invoke("disaleRotation",2f);
		yield return new WaitForSeconds(7f);
		particls.SetActive(false);
		explosion.SetActive(false);
		fire.SetActive(false);
		this.gameObject.SetActive(false);
		isHit = false;
		p.gameObject.GetComponent<ChasingCars>().canBusted =true;

	}
	void disaleRotation()
	{
		GetComponent<RotateGameObject>().enabled = false;
		iTween.Stop(this.gameObject);
	}
	void disableParticals()
	{
		particls.SetActive(false);

	}
}
