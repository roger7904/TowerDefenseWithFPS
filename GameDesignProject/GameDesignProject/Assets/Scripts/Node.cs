using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Node : MonoBehaviour {
    
	public GameObject LaserBeamer;
    public GameObject MissileLauncher_water;
	public GameObject MissileLauncher_wood;
	public GameObject MissileLauncher_fire;
    public GameObject StandardTurret_water;
	public GameObject StandardTurret_wood;
	public GameObject StandardTurret_fire;
    public GameObject buttonturret_water;
	public GameObject buttonturret_wood;
	public GameObject buttonturret_fire;
    public Color hoverColor;
	public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	[HideInInspector]
	public bool isUpgraded = false;

	private Renderer rend;
	private Color startColor;

	BuildManager buildManager;

	
	
	void Start ()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;

		buildManager = BuildManager.instance;
	
    }

	public Vector3 GetBuildPosition ()
	{
		return transform.position + positionOffset;
	}

	void OnMouseDown ()
	{
		Shop.checkattribute=false;
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (turret != null)
		{
			buildManager.SelectNode(this);
			return;
		}

		if (!buildManager.CanBuild)
			return;

		if (PlayerStats.Money < buildManager.GetTurretToBuild().cost)
		{
			Debug.Log("Not enough money to build that!");
			return;
		}
		BuildTurret(buildManager.GetTurretToBuild());
		if(buildManager.GetTurretToBuild().prefab == LaserBeamer){
			PauseMenu.turrets.Add("LaserBeamer");
			
		}else if(buildManager.GetTurretToBuild().prefab == MissileLauncher_water){
			PauseMenu.turrets.Add("MissileLauncher(water)");

		}else if(buildManager.GetTurretToBuild().prefab == MissileLauncher_wood){
			PauseMenu.turrets.Add("MissileLauncher(wood)");
			
		}else if(buildManager.GetTurretToBuild().prefab == MissileLauncher_fire){
			PauseMenu.turrets.Add("MissileLauncher(fire)");
			
		}else if(buildManager.GetTurretToBuild().prefab == StandardTurret_water){
			PauseMenu.turrets.Add("StandardTurret(water)");
			
		}else if(buildManager.GetTurretToBuild().prefab == StandardTurret_wood){
			PauseMenu.turrets.Add("StandardTurret(wood)");
			
		}else if(buildManager.GetTurretToBuild().prefab == StandardTurret_fire){
			PauseMenu.turrets.Add("StandardTurret(fire)");
			
		}else if(buildManager.GetTurretToBuild().prefab == buttonturret_water){
			
			PauseMenu.turrets.Add("buttonturret(water)");
			
		}else if(buildManager.GetTurretToBuild().prefab == buttonturret_wood){
			
			PauseMenu.turrets.Add("buttonturret(wood)");
			
		}else if(buildManager.GetTurretToBuild().prefab == buttonturret_fire){
			
			PauseMenu.turrets.Add("buttonturret(fire)");
			
		}
		PauseMenu.positionx.Add(GetBuildPosition ().x);
		PauseMenu.positiony.Add(GetBuildPosition ().y);
		PauseMenu.positionz.Add(GetBuildPosition ().z);
		buildManager.SelectTurretToBuild(null);
	}

	void BuildTurret (TurretBlueprint blueprint)
	{
		if (PlayerStats.Money < blueprint.cost)
		{
			Debug.Log("Not enough money to build that!");
			return;
		}

		PlayerStats.Money -= blueprint.cost;

		GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

		turretBlueprint = blueprint;

		GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);
        Debug.Log("Turret build!");
	}
	void testbuild(GameObject turret){
		GameObject _turret = (GameObject)Instantiate(turret, GetBuildPosition(), Quaternion.identity);
	}
	public void UpgradeTurret ()
	{
		if (PlayerStats.Money < turretBlueprint.upgradeCost)
		{
			Debug.Log("Not enough money to upgrade that!");
			return;
		}

		PlayerStats.Money -= turretBlueprint.upgradeCost;

		//Get rid of the old turret
		Destroy(turret);

		//Build a new one
		GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

		GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);

		isUpgraded = true;

		Debug.Log("Turret upgraded!");
	}

	public void SellTurret ()
	{
		PlayerStats.Money += turretBlueprint.GetSellAmount();
		GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
    
        Destroy(effect, 5f);

		Destroy(turret);
		turretBlueprint = null;
        
        //Debug.Log(countlaserBeamer);
    }

	void OnMouseEnter ()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (!buildManager.CanBuild)
			return;

		if (buildManager.HasMoney)
		{
			rend.material.color = hoverColor;
		} else
		{
			rend.material.color = notEnoughMoneyColor;
		}

	}

	void OnMouseExit ()
	{
		rend.material.color = startColor;
    }

}
