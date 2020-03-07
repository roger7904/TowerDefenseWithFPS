using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunsound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip AC;
    GameObject Cylinder;
    Vector3 v;
    
    // Start is called before the first frame update
    void Start()
    {
        Cylinder=GameObject.FindGameObjectWithTag("Cylinder");
        v = Cylinder.transform.position;
        AudioSource.PlayClipAtPoint(AC, v);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
