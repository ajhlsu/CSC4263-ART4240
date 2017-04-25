using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CharacterControllerScripLevel2 : MonoBehaviour 
{

	public float maxSpeed = 30000f;
	private bool facingRight = true;
	private Rigidbody2D rigi;

	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700;

	private Rigidbody2D proj;
	public float hasItem = 0;
	GameObject clone;
	public Rigidbody2D projectile;

	void Start ()
	{
		rigi = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		proj = GameObject.Find("Circle").GetComponent<Rigidbody2D>();
		projectile = proj;
	}

	void FixedUpdate ()
	{

		if (hasItem>0) 
		{
			CheckForItem(hasItem);

		}
		float move = Input.GetAxis("Horizontal")*2;

		if(move > 0 && !facingRight)
		{
			Flip();
		}
		else if(move < 0 && facingRight)
		{
			Flip();
		}
		anim.SetFloat("Speed", Mathf.Abs(move)*100000);
		rigi.velocity = new Vector2(move * maxSpeed, rigi.velocity.y);

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("Ground", grounded);

		anim.SetFloat("vSpeed", rigi.velocity.y);


		if(grounded && Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool("Ground", false);
			rigi.AddForce(new Vector2(0, jumpForce* 2));

		}

		if (gameObject.transform.position.y < -100)
		{
			int lives = PlayerPrefs.GetInt("Lives");
			if (lives > 1)
			{
				PlayerPrefs.SetInt("Lives", lives - 1);
				SceneManager.LoadScene("2 Lifeloss");
			}
			else
				SceneManager.LoadScene("GameOver");
		}



	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


	public void CheckForItem(float item)
	{
		if (item == 1) 
		{
			jumpForce = 1200;
		}

		if (item == 2) 
		{
			sendProjectile();
		}
	}

	public void sendProjectile()
	{
		if (Input.GetKeyDown (KeyCode.C)) 
		{

			FireProjectile();
		}
	}

	void FireProjectile()
	{
		Rigidbody2D clone;
		Vector3 loc = new Vector3 (transform.position.x + 10, transform.position.y, transform.position.z);
		clone = Instantiate (projectile, transform.position, transform.rotation) as Rigidbody2D; 
		if(facingRight)
			clone.AddForce(new Vector2(1000f, 0));
		else
			clone.AddForce(new Vector2(-1000f, 0));
	}
}