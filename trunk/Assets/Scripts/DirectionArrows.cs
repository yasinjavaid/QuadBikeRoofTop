using UnityEngine;
using System.Collections;

public class DirectionArrows : MonoBehaviour {

	// Use this for initialization
	float val = 0f;
	public float speed = 0.01f;
	private Renderer rend;
	void Start () {
		rend = this.GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		val +=speed;
		rend.material.mainTextureOffset = new Vector2(val,0f);
	}
}
