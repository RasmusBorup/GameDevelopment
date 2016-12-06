using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed = 1f;

	bool movingNorth;
	bool movingSouth;
	bool movingEast;
	bool movingWest;
	Animator anim;
	Vector2 movement;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void FixedUpdate()
	{
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");
		Move (v, h);
		Animating (h, v);
	}

	void Move(float v, float h)
	{
		movement.Set (h, v);
		movement = movement * speed * Time.deltaTime;
		rigidbody2D.MovePosition (rigidbody2D.position + movement);
	}

	void Animating(float h, float v)
	{
		if (v > 0 && h == 0)
        {
            anim.SetBool("MovingNorth", true);
            GameObject.Find("Weapon").GetComponent<CircleCollider2D>().center = new Vector2(0, 0.17f);
        } else
        {
            anim.SetBool("MovingNorth", false);
        }
        if (v < 0 && h == 0)
        {
            anim.SetBool("MovingSouth", true);
            GameObject.Find("Weapon").GetComponent<CircleCollider2D>().center = new Vector2(0, -0.17f);
        } else
        {
            anim.SetBool("MovingSouth", false);
        }
        if (h > 0)
        {
            anim.SetBool("MovingEast", true);
            GameObject.Find("Weapon").GetComponent<CircleCollider2D>().center = new Vector2(0.17f, 0);
        } else
        {
            anim.SetBool("MovingEast", false);
        }
        if (h < 0)
        {
            anim.SetBool("MovingWest", true);
            GameObject.Find("Weapon").GetComponent<CircleCollider2D>().center = new Vector2(-0.17f, 0);
        } else
        {
            anim.SetBool("MovingWest", false);
        }
	}
}
