using UnityEngine;
using System.Collections;

[RequireComponent (typeof(UILabel))]
public class CoinsLabel : MonoBehaviour {

	UILabel label;
	// Use this for initialization
	void Start () {
		label = this.GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () {
		label.text = string.Format("{0:###,###}" , UserPrefs.totalCoins);
	}
}
