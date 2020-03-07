using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static bool GameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;

	private GameObject loadturret;
	private Vector3 loadvector;
	private string s;

	public GameObject turret1_water;
	public GameObject turret1_wood;
	public GameObject turret1_fire;
	
	public GameObject turret2_water;
	public GameObject turret2_wood;
	public GameObject turret2_fire;
	public GameObject turret3;
	public GameObject turret4_water;
	public GameObject turret4_wood;
	public GameObject turret4_fire;

	void Start ()
	{
		GameIsOver = false;
		if(Levelloader.iscomefromload){
			for(int i=0;i<PlayerPrefs.GetInt("count");i++){
				s=i.ToString();
				if(PlayerPrefs.GetString("turrets"+s)=="StandardTurret(water)"){
					loadturret=turret1_water;
				}else if(PlayerPrefs.GetString("turrets"+s)=="StandardTurret(wood)"){
					loadturret=turret1_wood;
				}else if(PlayerPrefs.GetString("turrets"+s)=="StandardTurret(fire)"){
					loadturret=turret1_fire;
				}else if(PlayerPrefs.GetString("turrets"+s)=="MissileLauncher(water)"){
					loadturret=turret2_water;
				}else if(PlayerPrefs.GetString("turrets"+s)=="MissileLauncher(wood)"){
					loadturret=turret2_wood;
				}else if(PlayerPrefs.GetString("turrets"+s)=="MissileLauncher(fire)"){
					loadturret=turret2_fire;
				}else if(PlayerPrefs.GetString("turrets"+s)=="LaserBeamer"){
					loadturret=turret3;
				}else if(PlayerPrefs.GetString("turrets"+s)=="buttonturret(water)"){
					loadturret=turret4_water;
				}else if(PlayerPrefs.GetString("turrets"+s)=="buttonturret(wood)"){
					loadturret=turret4_wood;
				}else if(PlayerPrefs.GetString("turrets"+s)=="buttonturret(fire)"){
					loadturret=turret4_fire;
				}
				loadvector=new Vector3(PlayerPrefs.GetFloat("positionx"+s),PlayerPrefs.GetFloat("positiony"+s),PlayerPrefs.GetFloat("positionz"+s));
				Instantiate(loadturret,loadvector,Quaternion.identity);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (GameIsOver)
			return;

		if (PlayerStats.Lives <= 0)
		{
			EndGame();
		}
	}

	void EndGame ()
	{
		GameIsOver = true;
		gameOverUI.SetActive(true);
	}

	public void WinLevel ()
	{
		GameIsOver = true;
		completeLevelUI.SetActive(true);
	}

}
