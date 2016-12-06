using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour 
{
    [SerializeField]
    float speed = 0.1f;
	int damage = 1;
	float timeBetweenAttacks = 1f;
	PlayerHealth playerHealth;
	GameObject player;
    float timer;
    int playerTriggered;

	// Use this for initialization
	void Start () 
	{
        playerTriggered = 0;
		player = GameObject.Find ("Player");
        if (player == null)
        {
            Debug.Log ("Det går galt i starten");
        }
		playerHealth = player.GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        timer += Time.deltaTime;
		if (playerTriggered == 2 && timer >= timeBetweenAttacks && playerHealth.hp > 0) 
		{
            Attack ();
		}
        if (playerTriggered > 0)
        {
            MoveTowardsPlayer();
        }
        if (playerHealth.hp <= 0)
        {
            playerTriggered = 0;
        }
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == player) 
		{
            playerTriggered++;
            Debug.Log ("Player in range");
		}
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerTriggered--;
            Debug.Log("Player out of Range");
        }
    }

	void Attack()
	{
        timer = 0f;
		playerHealth.TakeDamage (damage);
	}

    void MoveTowardsPlayer()
    {
//        Debug.Log("Should follow player now");
        Vector2 moveVector = new Vector2();
        //        Vector3 move = (player.transform.position - transform.position).normalized;
        moveVector = (player.transform.position - transform.position).normalized * Time.deltaTime;
        rigidbody2D.MovePosition(rigidbody2D.position + moveVector);
    }
}
