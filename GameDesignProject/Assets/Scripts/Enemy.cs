using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    
    public float startSpeed = 5f;

	[HideInInspector]
	public float speed;

	public float startHealth = 100;
	public float ADdefense;
	public float APdefense;
	private float health;
	


	public int worth = 50;

	public GameObject deathEffect;

	[Header("Unity Stuff")]
	public Image healthBar;

	private bool isDead = false;
    //private int[] percent = { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    void Start ()
	{
		speed = startSpeed;
		health = startHealth;
	}

	public void TakeDamage (float amount)
	{
        
        //int i = UnityEngine.Random.Range(0, 10);
        health -= amount;

		healthBar.fillAmount = health / startHealth;

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}

	public void Slow (float pct)
	{
		speed = startSpeed * (1f - pct);
	}

	void Die ()
	{
		isDead = true;

		PlayerStats.Money += worth;

		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);

		WaveSpawner.EnemiesAlive--;

		Destroy(gameObject);
	}

}
