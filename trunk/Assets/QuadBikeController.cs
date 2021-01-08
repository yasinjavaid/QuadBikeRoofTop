using UnityEngine;
using System.Collections;

public class QuadBikeController : MonoBehaviour {
	Animator animatorController;
	// Use this for initialization
	void Start () {
		animatorController = this.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void isLeft(bool value)
	{
		if(animatorController)
		animatorController.SetBool ("Left", value);

	}
	public void isRight(bool value)
	{
		if(animatorController)
		animatorController.SetBool ("Right", value);

	}
	public void levelComplete(bool value)
	{
		if(animatorController)
		animatorController.SetBool ("levelComplete", value);

	}
	public void isDead(bool value)
	{
		if(animatorController)
		animatorController.SetBool ("death", value);

	}
}
