using UnityEngine;
using System.Collections;

public class LavaRolling : MonoBehaviour {

	// Use this for initialization
	float v = 0;

	public Renderer lava;
	public ParticleSystem [] particles;
	void Start () {
		StartCoroutine("particleHandler");
	}
	
	// Update is called once per frame
	void Update () {
		v+=0.005f;
		lava.material.SetTextureOffset("_Splat1",new Vector2(0,v));
	}
	IEnumerator particleHandler()
	{
		foreach(ParticleSystem p in particles)
		{
			p.enableEmission = false;
		}
	a:
		yield return new WaitForSeconds(20f);
		foreach(ParticleSystem p in particles)
		{
			p.enableEmission = false;
			if(Random.Range(0,2)==1)
			{
				p.enableEmission = true;
			}
		}
		goto a;

	}
}
