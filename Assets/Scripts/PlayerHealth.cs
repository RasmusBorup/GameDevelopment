using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour 
{
	public int hp;
	
    [SerializeField]
	int maxHp = 5;
    [SerializeField]
    Color damageColor = new Color(1f, 0f, 0f, 0.1f);
    [SerializeField]
    float colorSpeed;

	
	bool dead;
	bool damaged;
    Image damagedImage;

	// Use this for initialization
	void Start () 
	{
		hp = maxHp;
        damagedImage = GameObject.Find("DamagedImage").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (damaged)
        {
            damagedImage.color = damageColor;
        } 
        else
        {
            damagedImage.color = Color.Lerp(damagedImage.color, Color.clear, colorSpeed * Time.deltaTime);
        }
        damaged = false;
	}

	public void TakeDamage(int damage)
	{
		damaged = true;
		hp -= damage;
		if (hp <= 0) 
		{
			dead = true;
		}
    }
}
