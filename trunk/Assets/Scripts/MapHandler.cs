using UnityEngine;
using System.Collections;
using System.Linq;

public class MapHandler : MonoBehaviour {

	public enum MapObjects{
		POLICE,
		THIEF,
		CAMERA,
		POLICECAR,
		THIEFCAR,
		OTHER,
		BRIEFCASE,
		CHECKPOINTS,
		LIMITS
	}

	public Transform target;
	public MapObjects targetType;
	public Transform [] limits;
	public Camera mapCamera;
	public Transform secondaryTarget;

	Transform orginalTarget;

	float yPos;

	void OnEnable(){
		StartCoroutine(WaitBeforeFindingTarget());
	}

	// Use this for initialization
	void Start () {
		if(targetType == MapObjects.CAMERA){
			yPos = this.transform.position.y;
		}
	}

	// Update is called once per frame
	void LateUpdate () {
		if(target != null){
			switch(targetType){
			case MapObjects.POLICE:
				this.transform.position = new Vector3(target.position.x, this.transform.position.y, target.position.z);
				this.transform.localEulerAngles = new Vector3 (this.transform.localEulerAngles.x, target.localEulerAngles.y, this.transform.localEulerAngles.z);
				break;
			case MapObjects.CAMERA:
				this.transform.position = new Vector3(target.position.x, yPos, target.position.z);
				this.transform.localEulerAngles = new Vector3 (this.transform.localEulerAngles.x, target.localEulerAngles.y, this.transform.localEulerAngles.z);
				break;
			case MapObjects.THIEF:
				var temp = GameObject.FindWithTag("Thief");
				if(temp != null)
					target = temp.transform;
//				if(WheelControllerGeneric.isThiefOnBoard)
//					this.gameObject.SetActive(false);
				RegularPlacement();
				break;
			case MapObjects.THIEFCAR:
				RegularPlacement();
				break;
			case MapObjects.POLICECAR:
				RegularPlacement();
				break;
			case MapObjects.CHECKPOINTS:
				temp = GameObject.FindWithTag("Respawn");
				if(temp != null)
					target = temp.transform;
				RegularPlacement();
				break;
			case MapObjects.BRIEFCASE:
				temp = GameObject.FindWithTag("TargetToSteal");
				if(temp != null)
					target = temp.transform;
				RegularPlacement();
				break;
			case MapObjects.LIMITS:
				this.transform.position = new Vector3(target.position.x, this.transform.position.y, target.position.z);
				break;
			}
		}
	}

	public void SwitchToSecondaryTarget(){
		if(secondaryTarget != null)
			target = target == orginalTarget ? secondaryTarget : orginalTarget;
	}

	IEnumerator WaitBeforeFindingTarget(){
		yield return new WaitForSeconds(1);
		if(targetType == MapObjects.POLICECAR && target == null){
			var temp = GameObject.FindWithTag("Player2");
			if(temp != null)
				target = temp.transform;
		}else if(targetType == MapObjects.THIEF && target == null){
			var temp = GameObject.FindWithTag("Thief");
			if(temp != null)
				target = temp.transform;
		}else if(targetType == MapObjects.THIEFCAR && target == null){
			var temp = GameObject.FindWithTag("Player");
			if(temp != null)
				target = temp.transform;
		}else if(targetType == MapObjects.POLICE && target == null){
			var temp = GameObject.FindWithTag("Police");
			if(temp != null)
				target = temp.transform;
		}else if(targetType == MapObjects.BRIEFCASE && target == null){
			var temp = GameObject.FindWithTag("TargetToSteal");
			if(temp != null)
				target = temp.transform;
		}else if(targetType == MapObjects.CHECKPOINTS && target == null){
			var temp = GameObject.FindWithTag("Respawn");
			if(temp != null)
				target = temp.transform;
		}

		if(target == null)
			this.gameObject.SetActive(false);
		if(target != null){
			orginalTarget = target;
			if(targetType == MapObjects.OTHER || targetType == MapObjects.BRIEFCASE){
				this.transform.position = new Vector3(target.position.x, this.transform.position.y, target.position.z);
			}
		}
	}

	void RegularPlacement(){
//		var xArray = new float[] {limits[0].position.x,limits[1].position.x,limits[2].position.x,limits[3].position.x};
//		var zArray = new float[] {limits[0].position.z,limits[1].position.z,limits[2].position.z,limits[3].position.z};
//
////		var xLimit1 = xArray.OrderBy(z => z).Skip(1).First();
////		var zLimit1 = zArray.OrderByDescending(z=>z).Skip(1).First();
////		var xLimit2 = xArray.OrderByDescending(z=>z).Skip(1).First();
////		var zLimit2 = zArray.OrderBy(z => z).Skip(1).First();
//
//		var xLimit1 = xArray.Min();
//		var zLimit1 = zArray.Max();
//		var xLimit2 = xArray.Max();
//		var zLimit2 = zArray.Min();
//
//		var xPos = Mathf.Clamp(target.position.x,xLimit1,xLimit2);
//		var zPos = Mathf.Clamp(target.position.z,zLimit2,zLimit1);
//		
//		this.transform.position = new Vector3(xPos, this.transform.position.y, zPos);
		this.transform.position = new Vector3(target.transform.position.x,this.transform.position.y,target.transform.position.z);
		Vector3 pos = mapCamera.WorldToViewportPoint (transform.position);
		pos.x = Mathf.Clamp01(pos.x);
		pos.y = Mathf.Clamp01(pos.y);
		this.transform.position = mapCamera.ViewportToWorldPoint(pos);
		this.transform.localEulerAngles = new Vector3 (this.transform.localEulerAngles.x, target.localEulerAngles.y + 180, this.transform.localEulerAngles.z);
	}
}
