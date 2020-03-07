using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour {

	
	public float radius=15f;
	public GameObject explosioneffect;
	private void OnTriggerEnter(Collider other){
        Explode();
    }
	void Explode(){
		//show effect
		GameObject explosioneffectGO=Instantiate(explosioneffect,transform.position,transform.rotation);
		//get nearby object
		Collider[] colliders=Physics.OverlapSphere(transform.position,radius);

		foreach(Collider nearbyob in colliders){
			Rigidbody rigidbody= nearbyob.GetComponent<Rigidbody>();

			Enemy dest =nearbyob.GetComponent<Enemy>();
			if(dest !=null){
				if(dest.name=="journey(fire)(Clone)" || dest.name=="tzuyen(fire)(Clone)" || dest.name=="weillin(fire)(Clone)"){
					dest.TakeDamage(0);
				}else{
					dest.TakeDamage(200);
				}
			}
		}
		Destroy(explosioneffectGO,5f);
		Destroy(gameObject);
	}
}
