using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rocketbutton : MonoBehaviour {

	public GameObject rocketpress;

	public Button rocketbuttonn;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)){
			rocketpress.SetActive(true);
			rocketbuttonn.interactable=true;
		}
	}
}
