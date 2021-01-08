using UnityEngine;
using System.Collections;

public class ParkingLotEffects : MonoBehaviour {

	public GameObject [] cubes;
	public GameObject arrow;
	public GameObject front,back;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HideArrow(){
		arrow.SetActive(false);
	}

	public void SetCubeColor(Color color){
		foreach(var cube in cubes){
//			cube.renderer.material.SetColor("_ReflectColor",color);
			cube.GetComponent<Renderer>().material.color = color;
		}
	}
}
