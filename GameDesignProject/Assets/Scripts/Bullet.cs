using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;

	public static float speed = 70f;

	public static int damage = 0;
	public float ADdamage;
	public float APdamage;

	public float explosionRadius = 0f;
	public GameObject impactEffect;

	private string attributeString;
	private float attribute;
	public void Seek (Transform _target)
	{
		target = _target;
	}
	private float ad;
	private float ap;
	// Update is called once per frame
	void Update () {
        if(transform.name=="Missile(water)(Clone)" || transform.name=="Missile(wood)(Clone)" || transform.name=="Missile(fire)(Clone)"){
			if(Turret2.turret2effect){
				explosionRadius=8f;
			}else{
				explosionRadius=0f;
			}
		}
		if (target == null)
		{
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt(target);

	}

	void HitTarget ()
	{
		GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(effectIns, 5f);

		if (explosionRadius > 0f)
		{
			Explode();
		} else
		{
			Damage(target);
		}

		Destroy(gameObject);
	}

	void Explode ()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
		foreach (Collider collider in colliders)
		{
			if (collider.tag == "Enemy")
			{
				Damage(collider.transform);
			}
		}
	}

	void Damage (Transform enemy)
	{
		Enemy e = enemy.GetComponent<Enemy>();
		if (e != null)
		{
				if(e.name=="weillin(water)(Clone)"){
					attributeString="water";
				}else if(e.name=="weillin(wood)(Clone)"){
					attributeString="wood";
				}else if(e.name=="weillin(fire)(Clone)"){
					attributeString="fire";
				}else if(e.name=="tzuyen(water)(Clone)"){
					attributeString="water";
				}else if(e.name=="tzuyen(wood)(Clone)"){
					attributeString="wood";
				}else if(e.name=="tzuyen(fire)(Clone)"){
					attributeString="fire";
				}else if(e.name=="journey(water)(Clone)"){
					attributeString="water";
				}else if(e.name=="journey(wood)(Clone)"){
					attributeString="wood";
				}else if(e.name=="journey(fire)(Clone)"){
					attributeString="fire";
				}
			if(transform.name=="Bullet(water)(Clone)" || transform.name=="Bullet2(water)(Clone)" || transform.name=="Missile(water)(Clone)"){
				if(attributeString=="water"){
					attribute=1f;
				}else if(attributeString=="wood"){
					attribute=0.5f;
				}else if(attributeString=="fire"){
					attribute=1.2f;
				}
			}else if(transform.name=="Bullet(wood)(Clone)" || transform.name=="Bullet2(wood)(Clone)" || transform.name=="Missile(wood)(Clone)"){
				if(attributeString=="water"){
					attribute=1.2f;
				}else if(attributeString=="wood"){
					attribute=1f;
				}else if(attributeString=="fire"){
					attribute=0.5f;
				}
			}else if(transform.name=="Bullet(fire)(Clone)" || transform.name=="Bullet2(fire)(Clone)" || transform.name=="Missile(fire)(Clone)"){
				if(attributeString=="water"){
					attribute=0.5f;
				}else if(attributeString=="wood"){
					attribute=1.2f;
				}else if(attributeString=="fire"){
					attribute=1f;
				}
			}
			if(transform.name=="Bullet(water)(Clone)" || transform.name=="Bullet(wood)(Clone)" || transform.name=="Bullet(fire)(Clone)"){
				if(Turret1.turret1effect==5){
					ad=ADdamage-e.ADdefense;
					ap=APdamage-e.APdefense+5;
					if(ad<=0f){
						ad=0f;
					}
					if(ap<=0f){
						ap=0f;
					}
				}else if(Turret1.turret1effect==10){
					ad=ADdamage-e.ADdefense;
					ap=APdamage-e.APdefense+10;
					if(ad<=0f){
						ad=0f;
					}
					if(ap<=0f){
						ap=0f;
					}
				}else if(Turret1.turret1effect==15){
					ad=ADdamage-e.ADdefense;
					ap=APdamage-e.APdefense+20;
					if(ad<=0f){
						ad=0f;
					}
					if(ap<=0f){
						ap=0f;
					}
				}else{
					ad=ADdamage-e.ADdefense;
					ap=APdamage-e.APdefense;
					if(ad<=0f){
						ad=0f;
					}
					if(ap<=0f){
						ap=0f;
					}
				}
			}else{
				ad=ADdamage-e.ADdefense;
					ap=APdamage-e.APdefense;
					if(ad<=0f){
						ad=0f;
					}
					if(ap<=0f){
						ap=0f;
					}
			}
			if(transform.name=="Missile(water)(Clone)" || transform.name=="Missile(wood)(Clone)" || transform.name=="Missile(fire)(Clone)"){
				if(e.name=="journey(fire)(Clone)" || e.name=="tzuyen(fire)(Clone)" || e.name=="weillin(fire)(Clone)"){
					if(explosionRadius==8){
						e.TakeDamage(0);
					}else{
						e.TakeDamage((ad+ap)*attribute);
					}
				}else{
					e.TakeDamage((ad+ap)*attribute);
				}
			}else{
				e.TakeDamage((ad+ap)*attribute);
			}
		}
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}

	
}
