using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadethrow : MonoBehaviour {

	public float throwforce=40f;
	public GameObject grenadeprefab;

	public GameObject weaponholder;
	public GameObject changegrenade;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.G)){
			ThrowGrenade();
			weaponholder.SetActive(true);
			changegrenade.SetActive(false);
		}
	}

	void ThrowGrenade(){
		GameObject grenade =Instantiate(grenadeprefab,transform.position,transform.rotation);
		Rigidbody rb=grenade.GetComponent<Rigidbody>();
		rb.AddForce(transform.forward*throwforce,ForceMode.VelocityChange);



	}
}
