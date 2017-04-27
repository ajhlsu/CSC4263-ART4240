using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAISide : MonoBehaviour {

	Animator anim;
	Rigidbody2D rigidBody;
	Vector2 currentPosition;
	Vector2 initialPosition;

	private void Start()
	{
		rigidBody = gameObject.GetComponent<Rigidbody2D>();
		initialPosition = gameObject.transform.position;
	}

	void Update()
	{
		currentPosition = initialPosition;
		currentPosition.x = initialPosition.x + Mathf.Sin(Time.timeSinceLevelLoad)*10;
		rigidBody.MovePosition(currentPosition);
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		Animator anim;
		anim = other.GetComponent<Animator>();

		{
			if (other.tag.Contains("Player"))
			{
                if (other.GetComponent<CharacterControllerScript>() != null)
                {
                    other.GetComponent<CharacterControllerScript>().soundListener = 3;
                }
                if (other.GetComponent<CharacterControllerScripLevel2>() != null)
                {
                    other.GetComponent<CharacterControllerScripLevel2>().soundListener = 3;
                }
                if (other.GetComponent<CharacterControllerScriptLevel3>() != null)
                {
                    other.GetComponent<CharacterControllerScriptLevel3>().soundListener = 3;
                }
                anim.SetBool("Death", true);
				other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 125));

                Destroy(other.GetComponent<BoxCollider2D>());
                Destroy(other.GetComponent<CircleCollider2D>());
            }
		}
	}
}
