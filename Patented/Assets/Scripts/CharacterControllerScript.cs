using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour 
	{
		public float maxSpeed = .1f;
		private bool facingRight = true;
		private Rigidbody2D rigi;

		Animator anim;

		bool grounded = false;
		public Transform groundCheck;
		float groundRadius = 0.2f;
		public LayerMask whatIsGround;
		public float jumpForce = 10f;

		void Start ()
		{
			rigi = GetComponent<Rigidbody2D>();
			anim = GetComponent<Animator>();

		}

		void Update ()
		{
			float move = Input.GetAxis("Horizontal")/4;
			anim.SetFloat("Speed", Mathf.Abs(move)*100);
			rigi.velocity = new Vector2(move * maxSpeed, rigi.velocity.y);

			grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
			anim.SetBool("Ground", grounded);

			anim.SetFloat("vSpeed", rigi.velocity.y);
			
			if(move > 0 && !facingRight)
			{
				Flip();
			}
			else if(move < 0 && facingRight)
			{
				Flip();
			}
			
			if(grounded && Input.GetKeyDown(KeyCode.Space))
			{
				anim.SetBool("Ground", false);
				rigi.AddForce(new Vector2(0, jumpForce/3));

			}

		}

		/*private void OnTriggerEnter2D(Collider2D other)
		{
			{
				anim.SetBool("Death", true);
				rigi.AddForce(new Vector2(0, jumpForce));
				float  realLives = PlayerPrefs.GetFloat("Lives");
				realLives--;
				PlayerPrefs.SetFloat("Lives", realLives);
				if ( realLives>0)
					Application.LoadLevel("Save");
				else
				{
					rigi.AddForce(new Vector2(0, jumpForce));
				}
				//Vector3 position = new Vector3(-7, -2, 0);
				//Quaternion rotation = new Quaternion();
				//Instantiate(rigi.gameObject, position, rotation);
				//Destroy(rigi.gameObject);
			}
		}
		*/
		

		void Flip()
		{
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

