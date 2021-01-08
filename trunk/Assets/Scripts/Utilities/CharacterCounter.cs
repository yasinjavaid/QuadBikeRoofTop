using UnityEngine;
using System.Collections;

[RequireComponent (typeof(UILabel))]
public class CharacterCounter : MonoBehaviour {

	public UILabel labelToCount;
	public int totalCharacters = 140;
	UILabel mLabel;
	// Use this for initialization
	void Start () {
		mLabel = this.GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () {
		mLabel.text = (totalCharacters - labelToCount.text.Length).ToString();
	}
}
