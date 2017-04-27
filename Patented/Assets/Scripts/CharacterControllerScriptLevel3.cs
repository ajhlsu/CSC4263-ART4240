using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CharacterControllerScriptLevel3 : MonoBehaviour 
{

	public float maxSpeed = 30000f;
	private bool facingRight = true;
	private Rigidbody2D rigi;

	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 10f;

	private Rigidbody2D proj;
	public float hasItem = 0;
	GameObject clone;
	public Rigidbody2D projectile;
	bool played = false;
    Rigidbody2D test;
    float x;

    public int soundListener = 0;


	public AudioClip[] audioClip;

	void Start ()
	{
		rigi = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		proj = GameObject.Find("Projectile_1").GetComponent<Rigidbody2D>();
		projectile = proj;
	}

	void FixedUpdate ()
	{
        if (soundListener > 0)
        {
            PlaySound(soundListener);
            soundListener = 0;
        }

        if (hasItem > 0) 
		{
			if (played == false) {
				PlaySound (1);
				played = true;
			}
			CheckForItem (hasItem);
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
			PlaySound (0);
			rigi.AddForce(new Vector2(0, jumpForce*2));

		}

        if (gameObject.transform.position.y < -90)
        {
            PlaySound(3);
        }

            if (gameObject.transform.position.y < -100)
        {
            int lives = PlayerPrefs.GetInt("Lives");
            if (lives > 1)
            {
                PlayerPrefs.SetInt("Lives", lives - 1);
                SceneManager.LoadScene("3 Lifeloss");
            }
            else
                SceneManager.LoadScene("GameOver");
        }

        if (test != null)
        {
            if (facingRight)
            {
                if (test.transform.position.x > x + 36)
                {
                    Destroy(test.gameObject);

                }
            }
            else
            {
                if (test.transform.position.x < x - 36)
                {
                    Destroy(test.gameObject);

                }

            }
        }
        
    }

	void PlaySound(int clip)
	{
		GetComponent<AudioSource> ().clip = audioClip[clip];
		GetComponent<AudioSource> ().Play ();
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
			jumpForce = 1200f;
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
            PlaySound(4);
			FireProjectile();
		}
	}

	void FireProjectile()
	{
		Rigidbody2D clone;

		if(facingRight)
		{
            Vector3 loc = new Vector3 (transform.position.x+1, transform.position.y, transform.position.z);
			clone = Instantiate (projectile, loc, transform.rotation) as Rigidbody2D; 
			clone.AddForce(new Vector2(1000f *2, 0));
            test = clone;
            x = loc.x;
		}
		else
		{
            Vector3 loc = new Vector3 (transform.position.x-1, transform.position.y, transform.position.z);
			clone = Instantiate (projectile, loc, transform.rotation) as Rigidbody2D; 
			clone.AddForce(new Vector2(-1000f* 2, 0));
            test = clone;
            x = loc.x;
        }
	}
}