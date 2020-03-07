using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun3 : MonoBehaviour {

    //public float damage = 10f;//依距離判定，distancex,distancez
    public float range = 100f;
    public float fireRate = 15f;

    public int maxAmmo=10;
    private int currentAmmo;
    public float reloadtime=1f;
    private bool isreloading =false;

    public Camera fpscam;
    
    public GameObject impacteffect;
    public GameObject firepoint;
    public GameObject fireeffect;
    public GameObject player;

    private Transform cam;
    private Recoil recoilComponent;

    private float nextTimeTofire = 1f;
	private float t=1.5f;

	private int[] percent = { 1, 0, 0, 0, 0, 0, 0 };

    public Animator animator;

	// Use this for initialization
	void Start () {
        cam = GameObject.FindWithTag ("fpscamera").transform;
        recoilComponent = cam.parent.GetComponent<Recoil>();
		currentAmmo=maxAmmo;
	}
	
    void onEnable(){
        isreloading=false;
        animator.SetBool("reloading",false);
    }
	// Update is called once per frame
	void Update () {
        if(isreloading){
            return;
        }
        if(currentAmmo<=0){
           StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1") && t>= nextTimeTofire)
        {
            Shoot();
			t=0f;
        }
		t+=Time.deltaTime;

	}

    IEnumerator Reload(){

        isreloading=true;
        animator.SetBool("reloading",true);
        yield return new WaitForSeconds(reloadtime-.25f);
        animator.SetBool("reloading",false);
        yield return new WaitForSeconds(.25f);
        currentAmmo=maxAmmo;
        isreloading=false;

    }
    void Shoot()
    {
		int i = UnityEngine.Random.Range(0, 7);
        recoilComponent.StartRecoil(0.2f, -15f, 8f);
        currentAmmo--;
        Instantiate(fireeffect,firepoint.transform.position,firepoint.transform.rotation);
        
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            float distancex=Mathf.Abs(hit.transform.position.x-player.transform.position.x);
            float distancez=Mathf.Abs(hit.transform.position.z-player.transform.position.z);
            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null)
            {
				if(percent[i]==1){
					target.TakeDamage(100000);
				}  
            }
            GameObject impactGO= Instantiate(impacteffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO,5f);
        }
    }
}
