using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlbutton1 : MonoBehaviour {

    public Button mybutton1;
    public Button mybutton2;
    public Button mybutton3;
    public Button mybutton4;
    public Text mytext;
	// Use this for initialization
	void Start () {
  
	}
	
	// Update is called once per frame
	void Update () {
        if (mytext.text=="00.00")
        {
            mybutton1.interactable = false;
            mybutton2.interactable = false;
            mybutton3.interactable = false;
            mybutton4.interactable = false;
        }
        else
        {
            mybutton1.interactable = true;
            mybutton2.interactable = true;
            mybutton3.interactable = true;
            mybutton4.interactable = true;
        }
    }
}
