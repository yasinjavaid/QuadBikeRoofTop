using UnityEngine;
using System.Collections;

public class DetachablePartCustomization : MonoBehaviour {

	// Use this for initialization
	public float looseForce;
	public float breakForce;
	private Transform [] displacedPart;

	void Start () {
		if (this.gameObject.tag != "Player2") {
			displacedPart = this.gameObject.GetComponent<VehicleDamage> ().displaceParts;
			foreach (Transform T in displacedPart) {
				if(T!=null){
				T.gameObject.GetComponent<DetachablePart> ().looseForce = looseForce * Constants.EnemyCarsHealth [UserPrefs.currentEpisode - 1, UserPrefs.currentLevel - 1];;
				T.gameObject.GetComponent<DetachablePart> ().breakForce = breakForce * Constants.EnemyCarsHealth [UserPrefs.currentEpisode - 1, UserPrefs.currentLevel - 1];;
				}
			}
		} else {
			displacedPart = this.gameObject.GetComponent<VehicleDamage> ().displaceParts;
			foreach (Transform T in displacedPart) {

				T.gameObject.GetComponent<DetachablePart> ().looseForce = looseForce;
				T.gameObject.GetComponent<DetachablePart> ().breakForce = breakForce;
				
			}

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
