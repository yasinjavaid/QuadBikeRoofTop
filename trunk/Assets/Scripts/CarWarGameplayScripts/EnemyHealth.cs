using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	// Use this for initialization
	public Transform healthbar;
	public Transform fillbar;
	[Range(0.0f, 1.0f)]
	public float health = 1f;
	Transform target;
	void Start () {
		target = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
	// Update is called once per frame
	void Update () {
		healthbar.LookAt(target);
		fillbar.localScale = new Vector3(health,1,1);
	}
}
