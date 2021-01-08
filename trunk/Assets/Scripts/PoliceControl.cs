using UnityEngine;
using System.Collections;

public class PoliceControl : MonoBehaviour {

	protected  Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StandUp()
	{
		animator.SetBool("isTakePosition",true);
	}

	public void TakeAim()
	{
		animator.SetBool("isAim",true);

	}
}
