using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animator))]
public class PoliceAnimationController : MonoBehaviour {
	
	Animator animator;
	public EasyMobileJoystick joystick;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		UserPrefs.crashCause = 1;
		//joystick = GameObject.FindGameObjectWithTag ("Joystick");
//		TutorialManager.Instance.ChangeState (TutorialManager.TutorialStates.THIEFONMAP);

	}
	
	// Update is called once per frame
	void LateUpdate () {
		var x = Mathf.Abs(joystick.position.x);
		var y = Mathf.Abs(joystick.position.y);
		var value = x > y ? x : y;
//		value =  value > 0.45f && value < 0.6f ? 0.6f : value;
		value =  value > 0.5f  ? 0.75f : value;
		value =  value > 0f && value < 0.5f ? 0.6f : value;
	
		animator.SetFloat("value",value);
	}
}
