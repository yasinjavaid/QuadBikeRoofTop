using UnityEngine;
using System.Collections;

public class PoliceCarActivatorLocalize : MonoBehaviour {

	// Use this for initialization
	public GameObject   policeCars;
	Transform [] children ;

	void Start () {children = policeCars.GetComponentsInChildren<Transform>();
		policeCarDeactivator ();
	
	}

	// Update is called once per frame
	 void Update () {
	
	}
	public void policeCarActivator()
	{
		policeCars.SetActive (true);
		foreach(Transform t in children)
			t.gameObject.SetActive(true);
	}
	public void policeCarDeactivator()
	{

		policeCars.SetActive (false);


	}
	public bool isActive()
	{

		if (policeCars.activeInHierarchy)
			return true;
		else 
		return	false;
	}
	public void ResetCarPosition()
	{



	}

}
