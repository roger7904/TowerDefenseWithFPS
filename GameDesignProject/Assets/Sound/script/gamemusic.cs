using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemusic : MonoBehaviour
{
    public GameObject gamemusicobj;
    GameObject gamemusic2;
    GameObject UIMusic;
    // Start is called before the first frame update
    void Start()
    {
        UIMusic=GameObject.FindGameObjectWithTag("menumusic");
        gamemusic2=GameObject.FindGameObjectWithTag("music");
        if(gamemusic2==null){
            gamemusic2=(GameObject)Instantiate(gamemusicobj);
        }
        if(UIMusic!=null){
            Destroy(UIMusic);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}