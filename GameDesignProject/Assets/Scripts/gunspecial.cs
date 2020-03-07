using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunspecial : MonoBehaviour {

    //public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

 

    public Camera fpscam;
    
    public GameObject impacteffect;
    public GameObject firepoint;
    public GameObject fireeffect;
    public GameObject player;


    private float nextTimeTofire = 0f;

    
	// Use this for initialization
	
	
    
	// Update is called once per frame
	void Update () {
        

        if (Input.GetButton("Fire1") && Time.time>= nextTimeTofire)
        {
            nextTimeTofire = Time.time + 1f / fireRate;
            Shoot();
        }


	}

   
    void Shoot()
    {
       
        
        Instantiate(fireeffect,firepoint.transform.position,firepoint.transform.rotation);
        
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            
            Enemy target = hit.transform.GetComponent<Enemy>();
            float distancex=Mathf.Abs(hit.transform.position.x-player.transform.position.x);
            float distancez=Mathf.Abs(hit.transform.position.z-player.transform.position.z);
            if (target != null)
            {
                target.TakeDamage(distancex+distancez);
            }
            GameObject impactGO= Instantiate(impacteffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO,5f);
        }
    }
}
