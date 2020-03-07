using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levelloader : MonoBehaviour {

	public GameObject loadingScreen;
	public Slider slider;

	public Text progresstext;
	public static bool iscomefromload=false;

	void Start(){
		Cursor.visible=true;
		Screen.lockCursor = false;
	}
	public void LoadLevel(){
		StartCoroutine(LoadAsynchronously(PlayerPrefs.GetString("Levelnum")));
		iscomefromload=true;
	}

	IEnumerator LoadAsynchronously(string scenename){
		AsyncOperation operation=SceneManager.LoadSceneAsync(scenename);

		loadingScreen.SetActive(true);

		while (!operation.isDone)
		{
			float progress=Mathf.Clamp01(operation.progress/.9f);
			
			slider.value=progress;
			progresstext.text=progress*100f+"%";
			yield return null;
		}
	}
}
