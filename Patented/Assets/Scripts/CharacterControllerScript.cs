using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour 
	{
		public float maxSpeed = 1f;
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

		void FixedUpdate ()
		{
			float move = Input.GetAxis("Horizontal")/4;

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
				rigi.AddForce(new Vector2(0, jumpForce/3));

			}

            if (gameObject.transform.position.y < -2)
            {
                int lives = PlayerPrefs.GetInt("Lives");
                if (lives > 1)
                {
                    PlayerPrefs.SetInt("Lives", lives - 1);
                    SceneManager.LoadScene("LifeLoss");
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
	}

