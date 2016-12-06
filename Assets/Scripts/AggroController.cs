using UnityEngine;
using System.Collections;

public class AggroController : MonoBehaviour 
{
    GameObject player;
    bool playerInAggroRange;
    PlayerHealth playerHealth;
    // Use this for initialization
    void Start () 
    {
        player = GameObject.Find("Player");
        if (player == null)
        {
            Debug.Log ("Det går galt i starten");
        }
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    
    // Update is called once per frame
    void Update () 
    {
        if (playerInAggroRange )
        {
            MoveTowardsPlayer();
        }
//        MoveTowardsPlayer();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other == player.gameObject)
        {
            playerInAggroRange = true;
            Debug.Log("Player in Aggro Range");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other == player.gameObject)
        {
            playerInAggroRange = false;
        }
    }

    void MoveTowardsPlayer()
    {
        Debug.Log("Should follow player now");
//        Vector2 moveVector = new Vector2();
//        Vector3 move = (player.transform.position - transform.position).normalized;
//        moveVector = (player.transform.position - transform.position).normalized * Time.deltaTime;
        GetComponentInParent<Rigidbody2D>().MovePosition(player.transform.position);

    }
}
