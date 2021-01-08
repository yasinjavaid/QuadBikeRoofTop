using UnityEngine;
using System.Collections;

public class GameObjectDisable : MonoBehaviour {

	// Use this for initialization
	public float timeToDisable = 3f;
	void Start () {
	
	}
	void OnEnable()
	{
		Invoke("disableIt",timeToDisable);
	}
	void disableIt()
	{
		this.gameObject.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
