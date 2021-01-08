using UnityEngine;
using System.Collections;

public class RotateGameObject : MonoBehaviour {

	public enum Axis{
		y,x,z
	}

	public static Axis axis;
	public Axis axs;
	public float rotationFactor = 30;
	public float time = 0.4f;

	// Use this for initialization
	void Start () {
		//time = 0.03f;
//		axis = Axis.y;
		axis = axs;
	}

	void OnEnable(){
		RotateWithItween ();
	}

	void RotateWithItween(){
		switch(axis){
		case Axis.x : iTween.RotateAdd(this.gameObject, iTween.Hash("x",rotationFactor,"isLocal",true,"time",time,
			                                                            "onComplete", "RotateWithItween", "onCompleteTarget", gameObject
			                                                            ,"easeType", iTween.EaseType.linear));
			break;
		case Axis.y: iTween.RotateAdd(this.gameObject, iTween.Hash("y",rotationFactor,"isLocal",true,"time",time,
			                                                           "onComplete", "RotateWithItween", "onCompleteTarget", gameObject
			                                                           ,"easeType", iTween.EaseType.linear));
			break;
		case Axis.z: iTween.RotateAdd(this.gameObject, iTween.Hash("z",rotationFactor,"isLocal",true,"time",time,
			                                                           "onComplete", "RotateWithItween", "onCompleteTarget", gameObject
			                                                           ,"easeType", iTween.EaseType.linear));
			break;
		}
	}

	public void SetDefaultValues(){
		rotationFactor = 25;
		time = 0.04f;
	}

}
