using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
    public Animator anim;
    public Rigidbody2D rb;
    private void Update() {      
        if (Input.GetKey(KeyCode.A)) {
          rb.velocity= new Vector2(-5, rb.velocity.y);
          transform.localScale = new Vector2(-1,1);
            anim.SetBool("running", true);
        }
        else if (Input.GetKey(KeyCode.D)) {
            rb.velocity= new Vector2(5, rb.velocity.y);
            transform.localScale = new Vector2(1,1);
            anim.SetBool("running", true);
        }
        else{
            anim.SetBool("running", false);
        }
       if (Input.GetKey(KeyCode.Space)) {
            rb.velocity= new Vector2(rb.velocity.x, 10f);   
        }
    }
}



    


    

