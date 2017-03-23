using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour {


    Animator anim;
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
