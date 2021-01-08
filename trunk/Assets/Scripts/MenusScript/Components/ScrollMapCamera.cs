using UnityEngine;
using System.Collections;

public class ScrollMapCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	float addingFactor = 200;
	float addingFactorX = 1;
	float addingFactorY = 1;
	float previousX = 0;
	float previousY = 180;

	bool moveMap = false;

	// Update is called once per frame
	void LateUpdate () {
		if(Input.GetMouseButtonUp(0)){
			StartCoroutine("ResetMapCamera");
			moveMap = false;
		}

//		Debug.LogError("x " + Input.mousePosition.x + " y " + Input.mousePosition.y + " w " + Screen.width + " h " + Screen.height);

//		if(Input.mousePosition.x >= 0 && Input.mousePosition.x <= Screen.width * 0.28f && 
//		   Input.mousePosition.y >= Screen.height * 0.375f && Input.mousePosition.y <= Screen.height * 0.73f){

			if(Input.GetMouseButtonDown(0) && (Input.mousePosition.x >= 0 && Input.mousePosition.x <= Screen.width * 0.35f && 
			                                   Input.mousePosition.y >= Screen.height * 0.68f && Input.mousePosition.y <= Screen.height * 0.98f)){
				this.GetComponent<MapHandler>().enabled = false;
				StopCoroutine("ResetMapCamera");
				moveMap = true;
			}
			
			if(Input.GetMouseButton(0) && moveMap){

				if(Input.mousePosition.x > previousX){
					this.transform.Translate(-Vector3.right * Time.deltaTime * addingFactor, Space.World);
//					addingFactorX = -10f;
				}else if(Input.mousePosition.x < previousX){ 
					this.transform.Translate(Vector3.right * Time.deltaTime * addingFactor, Space.World);
//					addingFactorX = 10f;
				}
//				else addingFactorX = 0;
				
				if(Input.mousePosition.y > previousY){
					this.transform.Translate(-Vector3.forward * Time.deltaTime * addingFactor, Space.World);
//					addingFactorY = -10f;
				}
				else if(Input.mousePosition.y < previousY){
					this.transform.Translate(Vector3.forward * Time.deltaTime * addingFactor, Space.World);
//					addingFactorY = 10f;
				}
//				else addingFactorY = 0;
				
				previousX = Input.mousePosition.x;
				previousY = Input.mousePosition.y;
				
//				this.transform.localPosition = new Vector3(this.transform.localPosition.x + Input.mousePosition.x * addingFactorX,this.transform.localPosition.y, this.transform.localPosition.z + Input.mousePosition.y * addingFactorY);
			}

//		}

	}

	IEnumerator ResetMapCamera(){
		yield return new WaitForSeconds(2);
		this.GetComponent<MapHandler>().enabled = true;
	}

}
