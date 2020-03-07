using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "MainLevel";

	public SceneFader sceneFader;

	//public static bool iscomefromload=false;

	void start(){
		Levelloader.iscomefromload=false;
	}
	public void Play ()
	{
		Levelloader.iscomefromload=false;
		sceneFader.FadeTo(levelToLoad);
	}

	public void Quit ()
	{
		Debug.Log("Exciting...");
		Application.Quit();
	}

	public void Teach ()
	{
		Levelloader.iscomefromload=false;
		sceneFader.FadeTo("Teach");
	}

	

}
