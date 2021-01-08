using UnityEngine;
using System.Collections;

public class ChildLabel : MonoBehaviour {

	public UILabel parent;
	UILabel _mLabel;
	// Use this for initialization
	void Start () {
		_mLabel = this.GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () {
		_mLabel.text = parent.text;
	}
}
