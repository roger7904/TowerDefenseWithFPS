using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menumusic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menumusicobj;
    GameObject myUIMusic;
    GameObject GlobalUIMusic;
    // Start is called before the first frame update
    void Start()
    {
        myUIMusic=GameObject.FindGameObjectWithTag("menumusic");
        GlobalUIMusic=GameObject.FindGameObjectWithTag("music");
        if(myUIMusic==null){
            myUIMusic=(GameObject)Instantiate(menumusicobj);
        }
        if(GlobalUIMusic!=null){
            Destroy(GlobalUIMusic);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
