using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

	public float delay =2f;
	public float radius=10f;
 

	public GameObject explosioneffect;

	float countdown;
	bool hasExploded=false;
	// Use this for initialization
	void Start () {
		countdown=delay;
	}
	
	// Update is called once per frame
	void Update () {
		countdown-=Time.deltaTime;
		if(countdown<=0 && !hasExploded){
			Explode();
			hasExploded=true;
		}
	}

	void Explode(){
		//show effect
		GameObject explosioneffectGO= Instantiate(explosioneffect,transform.position,transform.rotation);
		//get nearby object
		Collider[] colliders=Physics.OverlapSphere(transform.position,radius);

		foreach(Collider nearbyob in colliders){
			Rigidbody rigidbody= nearbyob.GetComponent<Rigidbody>();

			Enemy dest =nearbyob.GetComponent<Enemy>();
			if(dest !=null){
				if(dest.name=="journey(fire)(Clone)" || dest.name=="tzuyen(fire)(Clone)" || dest.name=="weillin(fire)(Clone)"){
					dest.TakeDamage(0);
				}else{
					dest.TakeDamage(250);
				}
			}
		}
		Destroy(explosioneffectGO,3f);
		Destroy(gameObject);


	}
}
