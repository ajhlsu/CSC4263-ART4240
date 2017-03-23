using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndOfLevelTrigger : MonoBehaviour {
Animator anim;
    bool mailboxClosed = false;
    Rigidbody2D rigi;
    

    void Awake()
    {
        GameObject go = GameObject.Find("Environment_Mailbox_1");
        
        anim = go.GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collide)
    {
        anim.SetBool("Open", false);
        //collide.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 120));
        rigi = collide.GetComponent<Rigidbody2D>();
        mailboxClosed = true;
    }

    public void Update()
    {
        if (mailboxClosed)
        {
            if (rigi.transform.position.y > 4)
            {
                SceneManager.LoadScene("Completed");
            }
        }
    }

}
