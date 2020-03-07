using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

	private Transform target;
	private int wavepointIndex = 0;

	private Enemy enemy;

	private int effectbuff;

	void Start()
	{
		enemy = GetComponent<Enemy>();

		target = Waypoints.points[0];
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}

		enemy.speed = enemy.startSpeed;
	}

	void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
			EndPath();
			return;
		}

		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
	}

	void EndPath()
	{
		if(Turret3.buttonturreteffect){
			effectbuff=3;
		}else{
			effectbuff=0;
		}
		if(enemy.name=="weillin(water)(Clone)"){
			PlayerStats.Lives-=2;
			PlayerStats.Money += 100;
		}
		if(enemy.name=="weillin(wood)(Clone)"){
			PlayerStats.Lives-=3;
			PlayerStats.Money += 100;
		}
		if(enemy.name=="weillin(fire)(Clone)"){
			PlayerStats.Lives-=3;
			PlayerStats.Money += 100;
		}
		if(enemy.name=="tzuyen(water)(Clone)"){
			PlayerStats.Lives-=3;
			PlayerStats.Money += 150;
		}
		if(enemy.name=="tzuyen(wood)(Clone)"){
			PlayerStats.Lives-=5;
			PlayerStats.Money += 150;
		}
		if(enemy.name=="tzuyen(fire)(Clone)"){
			PlayerStats.Lives-=6;
			PlayerStats.Money += 150;
		}
		if(enemy.name=="journey(water)(Clone)"){
			PlayerStats.Lives-=9;
			PlayerStats.Money += 150;
		}
		if(enemy.name=="journey(wood)(Clone)"){
			PlayerStats.Lives-=11;
			PlayerStats.Money += 150;
		}
		if(enemy.name=="journey(fire)(Clone)"){
			PlayerStats.Lives-=15;
			PlayerStats.Money += 150;
		}
		PlayerStats.Lives+=effectbuff;
		
		WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}

}
