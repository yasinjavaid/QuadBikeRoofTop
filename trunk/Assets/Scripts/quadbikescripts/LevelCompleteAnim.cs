using UnityEngine;
using System.Collections;

public class LevelCompleteAnim : MonoBehaviour {

	// Use this for initialization
	GameObject player;
	VehicleParent vp;
	public bool isLevelComplete = false;
	public bool startAnim = false;
	public Transform viewPoint,startP;
	FollowAI f ;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(startAnim)
		{
			startAnim = false;
			FindPlayer();
		}
		if(isLevelComplete)
		{
			vp.SetBrake(1f);
			vp.SetSteer(1f);
		}
	}
	void FindPlayer()
	{
		startAnim = false;
		Camera.main.GetComponent<CamLookAtNew>().enabled = false;
		Camera.main.transform.position = viewPoint.position;
		Camera.main.transform.eulerAngles = viewPoint.eulerAngles;
		player=GameObject.FindGameObjectWithTag("Player2");


		if(player!=null)
		{
			player.GetComponent<Rigidbody>().isKinematic = false;
			vp = player.GetComponent<VehicleParent>();
			player.transform.position = startP.position;
			player.transform.eulerAngles =  startP.eulerAngles;
//			f = player.AddComponent<FollowAI>();
//			f.target = this.transform;
//			f.speed = 0.25f;
//			f.stopTimeReverse = 2f;
//			f.reverseAttemptTime = 0.5f;
//			f.resetReverseCount = -1;
//			f.rollResetTime = 3f;
			StartCoroutine("waait");
		//	Invoke("waait",3f);
			Camera.main.GetComponent<SmoothFollow>().target = null;
		}
	}
	IEnumerator waait()
	{
		//yield return new WaitForSeconds(2f);
		//f.target = null;
//		f.enabled = false;
//		Destroy(f);
		yield return new WaitForSeconds(2f);

		isLevelComplete = true;
	}
}
