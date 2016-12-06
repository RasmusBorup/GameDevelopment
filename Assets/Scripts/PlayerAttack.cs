using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public int damage = 1;
	public float timeBetweenAttacks = 0.5f;
	public float range = 1f;

	float timer;
	int attackableMask;
    Collider[] colidersInRange;


	void Awake ()
	{
		attackableMask = LayerMask.GetMask ("Attackable");
	}

	void Update ()
	{
		timer += Time.deltaTime;
		
		if(Input.GetButton ("Fire1") && timer >= timeBetweenAttacks)
		{
			Attack ();
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "enemy")
        {
            Debug.Log("Hej Fjende" + other.name);
        }
    }
	
	void Attack ()
	{
        Debug.Log("Attacked");
//		timer = 0f;
//		if()
//		{/*
//			EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
//			if(enemyHealth != null)
//			{
//				enemyHealth.TakeDamage (damagePerShot, shootHit.point);
//			}
//			gunLine.SetPosition (1, shootHit.point);*/
//		}
//		else
//		{
//			attackLine.SetPosition (1, attackRay.origin + attackRay.direction * range);
//		}
	}
}