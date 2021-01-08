using UnityEngine;
using System.Collections;

public class RockColiision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void  OnCollisionEnter (Collision collisionInfo){

		if(collisionInfo.gameObject.tag== "Water")
		{
			MeshCollider RockMeshCollider = (MeshCollider)this.gameObject.transform.GetComponent<Collider>();
			RockMeshCollider.convex=false;
		}

	}

}
