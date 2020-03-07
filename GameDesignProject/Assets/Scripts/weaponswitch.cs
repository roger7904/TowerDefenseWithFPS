
using UnityEngine;

public class weaponswitch : MonoBehaviour {

    public int selectweapon = 0;
	// Use this for initialization
	void Start () {
        Selectweapon();
	}
	
	// Update is called once per frame
	void Update () {
        int previous = selectweapon;
		if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectweapon >= transform.childCount - 1)
            {
                selectweapon = 0;
            }
            else
            {
                selectweapon++;
            }        
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectweapon <=0)
            {
                selectweapon = transform.childCount - 1;
            }
            else
            {
                selectweapon--;
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            selectweapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2){
            selectweapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3){
            selectweapon = 2;
        }
        if (previous != selectweapon)
        {
            Selectweapon();
        }
    }

    void Selectweapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selectweapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
