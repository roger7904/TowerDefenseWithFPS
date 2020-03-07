using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countturret : MonoBehaviour {

    public Text Turrettext;

    public static GameObject[] t1array;
	public static GameObject[] t2array;
	public static GameObject[] t3array;
	public static GameObject[] t4array;
    // Update is called once per frame
    
    void Update()
    {
        t1array=GameObject.FindGameObjectsWithTag("turret1");
        t2array=GameObject.FindGameObjectsWithTag("turret2");
        t3array=GameObject.FindGameObjectsWithTag("turret3");
        t4array=GameObject.FindGameObjectsWithTag("turret4");
        Turrettext.text = "Turret1:" + t1array.Length.ToString() + "\nTurret2:" + t2array.Length.ToString() + "\nTurret3:" + t3array.Length.ToString() + "\nTurret4:" + t4array.Length.ToString();

 
    }

}
