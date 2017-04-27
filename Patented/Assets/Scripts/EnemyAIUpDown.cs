using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIUpDown : MonoBehaviour {


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
        currentPosition.y = initialPosition.y + Mathf.Sin(Time.timeSinceLevelLoad)*5;
        rigidBody.MovePosition(currentPosition);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Animator anim;
        anim = other.GetComponent<Animator>();
        
        {
            if (other.tag.Contains("Player"))
            {
                anim.SetBool("Death", true);
                other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 125));
                
                Destroy(other);
            }
        }
    }
}
