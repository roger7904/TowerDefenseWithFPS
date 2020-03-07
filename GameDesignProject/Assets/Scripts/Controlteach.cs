using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Controlteach : MonoBehaviour {

	// public GameObject b1;
	// public GameObject b2;
	// public GameObject b3;
	// public GameObject b4;
	// public GameObject b5;
	// public GameObject b6;
	// public GameObject b7;
	public Button bb1;
	public Button bb2;
	public Button bb3;
	public Button bb4;
	public Button bb5;
	public Button bb6;
	public Button bb7;

	public GameObject t1;
	public GameObject t2;
	public GameObject t3;
	public GameObject t4;
	public GameObject t5;
	public GameObject t6;
	public GameObject t7;
	public GameObject t8;
	public GameObject t9;
	public GameObject t10;

	public GameObject t11;
	public GameObject t12;
	public GameObject t13;
	public GameObject t14;
	public GameObject t15;
	public GameObject t16;
	public GameObject tnew;
	public SceneFader sceneFader;

	public bool check1=false;
	public bool check2=false;

	public bool check3=false;

	public bool check4=false;
	public bool check5=false;
	public bool check6=false;

	public bool check7=false;
	public bool check8=false;
	public bool check9=false;

	public bool check10=false;
	public bool check11=false;
	public bool check12=false;
	public bool check13=false;
	public bool check14=false;
	public bool check15=false;
	public bool checknew=false;


	public  bool checkgun=false;
	public  bool checkgrenade=false;
	public  bool checkrocket=false;
	public  bool test=false;



	
	void Start () {
		bb1.interactable=false;
			bb2.interactable=false;
			bb3.interactable=false;
			bb4.interactable=false;
			bb5.interactable=false;
			bb6.interactable=false;
			bb7.interactable=false;
		t1.SetActive(true);
		check1=true;
		test=false;
		checkgrenade=false;
		checkgun=false;
		checkrocket=false;
		
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(teach());
	}
	IEnumerator teach(){
		if(check1){
			if(Input.GetKeyDown(KeyCode.Return)){
				t1.SetActive(false);
				t2.SetActive(true);
				check2=true;
				check1=false;
				yield return new WaitForSeconds(1f);
			}
		}
		if(check2){
			if(Input.GetKeyDown(KeyCode.Return)){
				t2.SetActive(false);
				t3.SetActive(true);
				check3=true;
				check2=false;
				yield return new WaitForSeconds(1f);
			}
		}
		if(check3){
			if(Input.GetKeyDown(KeyCode.Return)){
				t3.SetActive(false);
				t4.SetActive(true);
				check4=true;
				check3=false;
				yield return new WaitForSeconds(1f);
			}
		}
		if(check4){
			if(Input.GetKeyDown(KeyCode.Return)){
				t4.SetActive(false);
				t5.SetActive(true);
				check5=true;
				check4=false;
				yield return new WaitForSeconds(1f);
			}
		}
		if(check5){
			if(Input.GetKeyDown(KeyCode.Return)){
				t5.SetActive(false);
				t6.SetActive(true);
				check6=true;
				check5=false;
				// b1.SetActive(true);
				// b2.SetActive(true);
				// b3.SetActive(true);
				// b4.SetActive(true);
				// b5.SetActive(true);
				// b6.SetActive(true);
				// b7.SetActive(true);
				
				yield return new WaitForSeconds(1f);
			}
		}
		if(check6){
			if(Input.GetKeyDown(KeyCode.Return)){
				t6.SetActive(false);
				t7.SetActive(true);
				check7=true;
				check6=false;
				yield return new WaitForSeconds(1f);
			}
		}
		if(check7){
			if(Input.GetKeyDown(KeyCode.Return)){
				t7.SetActive(false);
				t8.SetActive(true);
				check8=true;
				check7=false;
				bb1.interactable=true;
				test=true;
				yield return new WaitForSeconds(1f);
			}
		}
		if(countturret.t1array.Length==1){
			if(test){
				t10.SetActive(false);
				t11.SetActive(true);
				bb5.interactable=true;
				bb6.interactable=true;
				bb7.interactable=true;
				check11=true;
				check10=false;
				test=false;
				yield return new WaitForSeconds(1f);
			}
			
		}
		if(checkgrenade&&checkgun&&checkrocket){
			t11.SetActive(false);
			tnew.SetActive(true);
			checknew=true;
			check11=false;
			checkgrenade=false;
			yield return new WaitForSeconds(0.1f);

		}
		if(tnew){
			if(Input.GetKeyDown(KeyCode.Q)){
				yield return new WaitForSeconds(0.1f);
				StartCoroutine(fpsteach());
			}
		}
		
	}

	IEnumerator fpsteach(){
		tnew.SetActive(false);
		t12.SetActive(true);
		yield return new WaitForSeconds(7f);
		t12.SetActive(false);
		t13.SetActive(true);
		yield return new WaitForSeconds(20f);
		t13.SetActive(false);
		t14.SetActive(true);
		yield return new WaitForSeconds(10f);
		t14.SetActive(false);
		t15.SetActive(true);
		yield return new WaitForSeconds(7f);
		t15.SetActive(false);
		t16.SetActive(true);
		yield return new WaitForSeconds(3f);
		sceneFader.FadeTo("MainMenu");
	}

	public void clickturret1(){
		if(check8){
			t8.SetActive(false);
			t9.SetActive(true);
			check9=true;
			check8=false;
		}
	}
	public void clickwater(){
		if(check9){
			t9.SetActive(false);
			t10.SetActive(true);
			check10=true;
			check9=false;
		}
	}
	public void clickgun(){
		if(check11){
			checkgun=true;
		}
	}
	public void clickgrenade(){
		if(check11){
			checkgrenade=true;
		}
	}
	public void clickrocket(){
		if(check11){
			checkrocket=true;
		}
	}
	
}
