using UnityEngine;
using System.Collections;

public class MoveHurdle : MonoBehaviour {

	// Use this for initialization
	public GameObject target;
	public Method method;
	public MethodType type;
	public EaseType easetype;
	public LoopType loopType;
//	public Axis axis1;
//	public float AxisValue;
//	public Axis axis2;
//	public Axis axis3;
	public float XValue;
	public float YValue;
	public float ZValue;

	public float duration;
	public float Delay;
	public float startDelay = 0f;
	public bool ignoreTimeScale = false;
	public enum EaseType{
		easeInQuad,
		easeOutQuad,
		easeInOutQuad,
		easeInCubic,
		easeOutCubic,
		easeInOutCubic,
		easeInQuart,
		easeOutQuart,
		easeInOutQuart,
		easeInQuint,
		easeOutQuint,
		easeInOutQuint,
		easeInSine,
		easeOutSine,
		easeInOutSine,
		easeInExpo,
		easeOutExpo,
		easeInOutExpo,
		easeInCirc,
		easeOutCirc,
		easeInOutCirc,
		linear,
		spring,
		/* GFX47 MOD START */
		//bounce,
		easeInBounce,
		easeOutBounce,
		easeInOutBounce,
		/* GFX47 MOD END */
		easeInBack,
		easeOutBack,
		easeInOutBack,
		/* GFX47 MOD START */
		//elastic,
		easeInElastic,
		easeOutElastic,
		easeInOutElastic,
		/* GFX47 MOD END */
		punch
	}
	public enum Method{
		add,
		by,
		from,
		to,
		update
	}
	public enum MethodType{
		move,
		rotate,
		scale
	}
	public enum LoopType{

		none,

		loop,

		pingPong
	}
	public enum Axis{
		x,
		y,
		z
	}
	public bool PlayOnStart = true;
	void OnEnable () 
	{
		if(PlayOnStart)
		Invoke("startAnim",startDelay);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startAnim()
	{
		//this.transform.localScale = new Vector3 (80, 80, 80);
		iTween.Launch(target, iTween.Hash("x",XValue,"y",YValue,"z",ZValue, "easeType",easetype.ToString(), "loopType", loopType.ToString(),"time", duration, "delay", Delay,"type",type.ToString(), "method",method.ToString(),"islocal",true,"ignoretimescale",ignoreTimeScale ));
	//	StartCoroutine (stopAfterDuration ());
	}
	public void pauseAnim()
	{
		iTween.Pause(target);
	}
	public void resumeAnim()
	{
		iTween.Resume(target);
	}
	public void stopAnim()
	{
		iTween.Stop(target);
	}

//	public void stopOnCompleteSingleIteration(){
//		StartCoroutine(stopAfterDuration());
//	}

	IEnumerator stopAfterDuration(){
		yield return new WaitForSeconds(duration + Delay);
		iTween.Stop(target);
		this.GetComponent<MoveHurdle> ().enabled = false;
	}
}
