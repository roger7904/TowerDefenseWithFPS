using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour {

	public static string chooseturret;
	public static string chooseattribute;
	public TurretBlueprint standardTurret_water;
	public TurretBlueprint standardTurret_wood;
	public TurretBlueprint standardTurret_fire;
    public TurretBlueprint missileLauncher_water;
	public TurretBlueprint missileLauncher_wood;
    public TurretBlueprint missileLauncher_fire;
	public TurretBlueprint buttonturret_water;
    public TurretBlueprint buttonturret_wood;
	public TurretBlueprint buttonturret_fire;
	public TurretBlueprint laserBeamer;


	public GameObject weapon;
	public GameObject grenade;
	public GameObject rocketpress;
	public Button rocketbutton;

	public GameObject attributeb1;
	public GameObject attributeb2;
	public GameObject attributeb3;
	public static bool checkattribute=false;

    BuildManager buildManager;


	void Start ()
	{
		buildManager = BuildManager.instance;
		attributeb1.SetActive(false);
		attributeb2.SetActive(false);
		attributeb3.SetActive(false);
		checkattribute=false;
	}

	public void chooseStandardTurret (){
		chooseturret="StandardTurret";
		if(!checkattribute){
			attributeb1.SetActive(true);
			attributeb2.SetActive(true);
			attributeb3.SetActive(true);
			checkattribute=true;
		}else{
			attributeb1.SetActive(false);
			attributeb2.SetActive(false);
			attributeb3.SetActive(false);
			checkattribute=false;
		}
		
	}


	public void chooseMissileLauncher (){
		chooseturret="MissileLauncher";
		if(!checkattribute){
			attributeb1.SetActive(true);
			attributeb2.SetActive(true);
			attributeb3.SetActive(true);
			checkattribute=true;
		}else{
			attributeb1.SetActive(false);
			attributeb2.SetActive(false);
			attributeb3.SetActive(false);
			checkattribute=false;
		}
	}

	public void SelectLaserBeamer()
	{
		Debug.Log("Laser Beamer Selected");
		buildManager.SelectTurretToBuild(laserBeamer);
		attributeb1.SetActive(false);
		attributeb2.SetActive(false);
		attributeb3.SetActive(false);
		checkattribute=false;
	}

	public void choosebuttonturret (){
		chooseturret="buttonturret";
		if(!checkattribute){
			attributeb1.SetActive(true);
			attributeb2.SetActive(true);
			attributeb3.SetActive(true);
			checkattribute=true;
		}else{
			attributeb1.SetActive(false);
			attributeb2.SetActive(false);
			attributeb3.SetActive(false);
			checkattribute=false;
		}
	}

	public void buyweapon(){
		if (PlayerStats.Money < 150)
		{
			return;
		}
		Debug.Log("buyweapon");
		Vector3 pos = new Vector3(Random.Range(0f, 75f), 2.5f, Random.Range(0f, -75f)); 
        Instantiate(weapon, pos, transform.rotation);
		PlayerStats.Money -= 150;
		attributeb1.SetActive(false);
		attributeb2.SetActive(false);
		attributeb3.SetActive(false);
		checkattribute=false;
	}

	public void buygrenade(){
		if (PlayerStats.Money < 70)
		{
			return;
		}
		Debug.Log("buygrenade");
		Vector3 pos = new Vector3(Random.Range(0f, 75f), 2f, Random.Range(0f, -75f)); 
        Instantiate(grenade, pos, transform.rotation);
		PlayerStats.Money -= 70;
		attributeb1.SetActive(false);
		attributeb2.SetActive(false);
		attributeb3.SetActive(false);
		checkattribute=false;
	}

	public void buyrocket(){
		if (PlayerStats.Money < 100)
		{
			return;
		}
		Debug.Log("buyrocket");
		rocketpress.SetActive(true);
		rocketbutton.interactable=false;
		PlayerStats.Money -= 100;
		attributeb1.SetActive(false);
		attributeb2.SetActive(false);
		attributeb3.SetActive(false);
		checkattribute=false;
	}

	public void choosewater (){
		chooseattribute="water";
		if(chooseturret=="StandardTurret"){
			buildManager.SelectTurretToBuild(standardTurret_water);
			Debug.Log("Standard Turret water Selected");
		}else if(chooseturret=="MissileLauncher"){
			buildManager.SelectTurretToBuild(missileLauncher_water);
			Debug.Log("Missile Launcher water Selected");
		}else if(chooseturret=="buttonturret"){
			buildManager.SelectTurretToBuild(buttonturret_water);
			Debug.Log("button turret water Selected");
		}
		attributeb1.SetActive(false);
		attributeb2.SetActive(false);
		attributeb3.SetActive(false);
		checkattribute=false;
	}

	public void choosewood (){
		chooseattribute="wood";
		if(chooseturret=="StandardTurret"){
			buildManager.SelectTurretToBuild(standardTurret_wood);
			Debug.Log("Standard Turret wood Selected");
		}else if(chooseturret=="MissileLauncher"){
			buildManager.SelectTurretToBuild(missileLauncher_wood);
			Debug.Log("Missile Launcher wood Selected");
		}else if(chooseturret=="buttonturret"){
			buildManager.SelectTurretToBuild(buttonturret_wood);
			Debug.Log("button turret wood Selected");
		}
		attributeb1.SetActive(false);
		attributeb2.SetActive(false);
		attributeb3.SetActive(false);
		checkattribute=false;
	}

	public void choosefire (){
		chooseattribute="fire";
		if(chooseturret=="StandardTurret"){
			buildManager.SelectTurretToBuild(standardTurret_fire);
			Debug.Log("Standard Turret fire Selected");
		}else if(chooseturret=="MissileLauncher"){
			buildManager.SelectTurretToBuild(missileLauncher_fire);
			Debug.Log("Missile Launcher fire Selected");
		}else if(chooseturret=="buttonturret"){
			buildManager.SelectTurretToBuild(buttonturret_fire);
			Debug.Log("button turret fire Selected");
		}
		attributeb1.SetActive(false);
		attributeb2.SetActive(false);
		attributeb3.SetActive(false);
		checkattribute=false;
	}

	public void SelectTurret(){
		if(chooseturret=="StandardTurret"){
			if(chooseattribute=="water"){
				buildManager.SelectTurretToBuild(standardTurret_water);
				Debug.Log("Standard Turret water Selected");
			}else if(chooseattribute=="wood"){
				buildManager.SelectTurretToBuild(standardTurret_wood);
				Debug.Log("Standard Turret wood Selected");
			}else if(chooseattribute=="fire"){
				buildManager.SelectTurretToBuild(standardTurret_fire);
				Debug.Log("Standard Turret fire Selected");
			}
		}else if(chooseturret=="MissileLauncher"){
			if(chooseattribute=="water"){
				buildManager.SelectTurretToBuild(missileLauncher_water);
				Debug.Log("Missile Launcher water Selected");
			}else if(chooseattribute=="wood"){
				buildManager.SelectTurretToBuild(missileLauncher_wood);
				Debug.Log("Missile Launcher wood Selected");
			}else if(chooseattribute=="fire"){
				buildManager.SelectTurretToBuild(missileLauncher_fire);
				Debug.Log("Missile Launcher fire Selected");
			}
		}else if(chooseturret=="buttonturret"){
			if(chooseattribute=="water"){
				buildManager.SelectTurretToBuild(buttonturret_water);
				Debug.Log("button turret water Selected");
			}else if(chooseattribute=="wood"){
				buildManager.SelectTurretToBuild(buttonturret_wood);
				Debug.Log("button turret wood Selected");
			}else if(chooseattribute=="fire"){
				buildManager.SelectTurretToBuild(buttonturret_fire);
				Debug.Log("button turret fire Selected");
			}
		}
	}
}
