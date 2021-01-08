using UnityEngine;
using System.Collections;

public class CarBlast : MonoBehaviour {
	public GameObject [] parts = new GameObject[5];
	public GameObject explosion;
	public GameObject fire;
	GameObject Parent;
	// Use this for initialization
	void Start () {
	
		blastCar();
		
	}
	void OnEnable()
	{
		LevelsData level=	GameObject.FindObjectOfType<LevelsData> ();
		if (this.gameObject.tag == "Player2") {
			EnemyCar [] enemy=GameObject.FindObjectsOfType<EnemyCar>();
			for(int i=0;i<enemy.Length;i++)
			{
				enemy[i].gameObject.GetComponentInChildren<Motor>().health=0.5f;

			}
			level.LevelFail ();
		}
			else {
			Destroy(this.GetComponent<EnemyCar>());
			LevelsData.DestroyedEnemies++;
			if(LevelsData.helicopterEnemiesDestroyed<Constants.NumberofHelipEnemies)
				level.HelipadEnemyInstantiate();
			LevelsData.helicopterEnemiesDestroyed++;

			if (LevelsData.DestroyedEnemies == Constants.NumberOfEnemies)
			{
				GameObject Player=GameObject.FindGameObjectWithTag("Player2");
				if(Player.GetComponentInChildren<Motor>().health<0.2f)
				Player.GetComponentInChildren<Motor>().health=0.001f;
				level.LevelComplete ();

			}
			
			}
		
	}

	// Update is called once per frame
	void Update () {
		
	}
	
	public void blastCar()
	{
		//GameObject.Find("EmptyBody").transform.parent = parts[0].transform;
		//		Destroy(GameObject.FindGameObjectWithTag("Player").rigidbody);
		//Destroy(GameObject.FindGameObjectWithTag("ArrowRed"));
		Parent=parts [0].transform.root.gameObject;
		if (this.gameObject.tag == "Player2")
			this.GetComponent<EnginePowerManager> ().ragDollActivator ();
		MonoBehaviour[] scripts = Parent.GetComponents<MonoBehaviour> ();
		Parent.GetComponent<BoxCollider> ().enabled = false;
		//Destroy (Parent.GetComponent<Rigidbody> ());
		foreach(MonoBehaviour script in scripts)
		{

			script.enabled = false;
		}
		for(int i = 0 ;i<parts.Length; i++ )
		{
			//if(!UserPrefs.isTutorial)
				if(i!=0)
			{
				parts[i].GetComponentInChildren<Wheel>().enabled=false;
			}
			parts[i].transform.parent = null;
			parts[i].AddComponent<Rigidbody>();
			parts[i].AddComponent<BoxCollider>();
			


			if((i+1) == parts.Length)
			{
				Destroy(parts[i]);
				//parts[i].gameObject.SetActive(false);
			}
			else
				if(i!=0)
				parts[i].GetComponent<Rigidbody>().AddExplosionForce(0f,parts[i].transform.position,0f);
		}
		if (this.gameObject.GetComponent<BlinkTexture> ()) {

			parts [0].GetComponent<Rigidbody> ().mass = 6000;
		} else {

			parts [0].GetComponent<Rigidbody> ().mass = 600;

		}
//		var exp = Instantiate(Resources.Load("explosion") , parts[0].transform.position, Quaternion.identity) as GameObject;
//		var fire = Instantiate(Resources.Load("fire") , parts[0].transform.position , Quaternion.identity) as GameObject;
//		exp.transform.parent = parts[0].transform;
//		fire.transform.parent = parts[0].transform;
		//Parent.SetActive (false);

		//explosion.SetActive (true);
		if (UserPrefs.isSound) {
			SoundManager.Instance.gamePlayEffectsSource.mute=false;
			SoundManager.Instance.gamePlayEffectsSource.PlayOneShot (SoundManager.Instance.carExplosion);
		}

		fire.SetActive (true);
		for (int i = 0; i<parts.Length; i++) {
			if(parts[i])
			Destroy(parts[i],10f);

		}
		if(Parent)
		Destroy (Parent,5);
	}
 public	void DestroyParts(){
		for (int i = 0; i<parts.Length; i++) {
			if(parts[i])
				Destroy(parts[i]);
			
		}
		Destroy (Parent);

	}
	
}
