using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 10;
	public int currentHealth;

	bool isDead;
	// Use this for initialization
	void Avake () {
		currentHealth = startingHealth;
	}

	public void TakeDamage (int amount, Vector3 hitPoint)
	{
		if(currentHealth <= 0)
		{
			Death ();
		}
	}

	void Death ()
	{
		isDead = true;

		gameObject.SetActive (false);
	}
}
