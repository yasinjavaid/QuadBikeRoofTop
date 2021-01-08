using UnityEngine;
using System.Collections;

public class SetLabelColot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<UILabel> ().color = Color.white;
	}
}
