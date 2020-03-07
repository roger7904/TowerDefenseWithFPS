using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour {

	public static int waveIndex;
	public static List<float> positionx=new List<float>();
	public static List<float> positiony=new List<float>();
	public static List<float> positionz=new List<float>();
	public static List<string> turrets=new List<string>();
	
	
	public void save(){
		for(int i=0;i<turrets.Count;i++){
			string s=i.ToString();
			PlayerPrefs.SetFloat("positionx"+s,positionx[i]);
			PlayerPrefs.SetFloat("positiony"+s,positiony[i]);
			PlayerPrefs.SetFloat("positionz"+s,positionz[i]);
			PlayerPrefs.SetString("turrets"+s,turrets[i]);
		}
		PlayerPrefs.SetInt("count",turrets.Count);
		
		
	}
}
