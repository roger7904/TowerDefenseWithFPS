using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameracontrol : MonoBehaviour
{
    public GameObject mainview;
    public GameObject fpsview;
    public bool check;
    
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;
    public GameObject b5;
    public GameObject b6;
    public GameObject b7;
    public GameObject b8;
    public GameObject b9;
    public GameObject b10;
    public GameObject centerpointimg;

    public GameObject canvasobject;
    // Use this for initialization
    void Start()
    {
        mainview.gameObject.active = true;
        fpsview.gameObject.active = false;
        check = true;
        centerpointimg.SetActive(false);
        // b1.SetActive(true);
        // b2.SetActive(true);
        // b3.SetActive(true);
        // b4.SetActive(true);
        // b5.SetActive(true);
        // b6.SetActive(true);
        // b7.SetActive(true);
        // b8.SetActive(true);
        // b9.SetActive(true);
        // b10.SetActive(true);
    }

    // Update is called once per frame
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (check)
            {
                Cursor.visible=false;
		        Screen.lockCursor = true;
                mainview.gameObject.active = false;
                fpsview.gameObject.active = true;
                centerpointimg.SetActive(true);
                b1.SetActive(false);
                b2.SetActive(false);
                b3.SetActive(false);
                b4.SetActive(false);
                b5.SetActive(false);
                b6.SetActive(false);
                b7.SetActive(false);
                b8.SetActive(false);
                b9.SetActive(false);
                b10.SetActive(false);
                check = false;
                
               
            }
            else
            {
                Cursor.visible=true;
		        Screen.lockCursor = false;
                centerpointimg.SetActive(false);
                mainview.gameObject.active = true;
                fpsview.gameObject.active = false;
                b1.SetActive(true);
                b2.SetActive(true);
                b3.SetActive(true);
                b4.SetActive(true);
                b5.SetActive(true);
                b6.SetActive(true);
                b7.SetActive(true);
                
                check = true;
         
            }
        }
    }
}
