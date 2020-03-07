using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class randombon : MonoBehaviour {

	public GameObject grenadeprefab;

	public GameObject rocketbutton;
	public GameObject thisGO;

	


	void OnEnable(){
		Debug.Log("test");
        StartCoroutine(Bombing());
		rocketbutton.SetActive(false);
    }

	// void Bombing(){
	// 	for (int i = 0; i < 50; i++)
	// 	{
	// 		Vector3 pos = new Vector3(Random.Range(0f, 75f), 40f, Random.Range(0f, -75f)); 
    //     	Instantiate(grenadeprefab, pos, transform.rotation);
	// 	}
		
	// }

	IEnumerator Bombing(){
		
        for (int i = 0; i < 10; i++)
	 	{
	 		Vector3 pos = new Vector3(Random.Range(0f, 75f), 40f, Random.Range(0f, -75f)); 
         	Instantiate(grenadeprefab, pos, transform.rotation);
	 	}
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 10; i++)
	 	{
	 		Vector3 pos = new Vector3(Random.Range(0f, 75f), 40f, Random.Range(0f, -75f)); 
         	Instantiate(grenadeprefab, pos, transform.rotation);
	 	}
        yield return new WaitForSeconds(1f);
		for (int i = 0; i < 10; i++)
	 	{
	 		Vector3 pos = new Vector3(Random.Range(0f, 75f), 40f, Random.Range(0f, -75f)); 
         	Instantiate(grenadeprefab, pos, transform.rotation);
	 	}
        yield return new WaitForSeconds(1f);
		for (int i = 0; i < 10; i++)
	 	{
	 		Vector3 pos = new Vector3(Random.Range(0f, 75f), 40f, Random.Range(0f, -75f)); 
         	Instantiate(grenadeprefab, pos, transform.rotation);
	 	}
        yield return new WaitForSeconds(1f);
		for (int i = 0; i < 10; i++)
	 	{
	 		Vector3 pos = new Vector3(Random.Range(0f, 75f), 40f, Random.Range(0f, -75f)); 
         	Instantiate(grenadeprefab, pos, transform.rotation);
	 	}
        yield return new WaitForSeconds(1f);
		thisGO.SetActive(false);		
    }
}
