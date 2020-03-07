using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour {

	public GameObject ui;

	public string menuSceneName = "MainMenu";

	public SceneFader sceneFader;

	
	public static List<float> positionx=new List<float>();
	public static List<float> positiony=new List<float>();
	public static List<float> positionz=new List<float>();
	public static List<string> turrets=new List<string>();
	
	void Start(){
		positionx.Clear();
		positiony.Clear();
		positionz.Clear();
		turrets.Clear();
	}
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			Toggle();
		}
	}

	public void Toggle ()
	{
		ui.SetActive(!ui.activeSelf);

		if (ui.activeSelf)
		{
			Time.timeScale = 0f;
		} else
		{
			Time.timeScale = 1f;
		}
	}

	public void Retry ()
	{
		Toggle();
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

	public void Menu ()
	{
		Toggle();
		sceneFader.FadeTo(menuSceneName);
	}

	public void Save(){
		Toggle();
		PlayerPrefs.SetString("Levelnum",SceneManager.GetActiveScene().name);
		for(int i=0;i<turrets.Count;i++){
			string s=i.ToString();
			PlayerPrefs.SetFloat("positionx"+s,positionx[i]);
			PlayerPrefs.SetFloat("positiony"+s,positiony[i]);
			PlayerPrefs.SetFloat("positionz"+s,positionz[i]);
			PlayerPrefs.SetString("turrets"+s,turrets[i]);
		}
		PlayerPrefs.SetInt("count",turrets.Count);
		PlayerPrefs.SetInt("waveindex",WaveSpawner.waveindexflag);
		PlayerPrefs.SetInt("money",PlayerStats.Money);
		PlayerPrefs.SetInt("lives",PlayerStats.Lives);
	}
}
