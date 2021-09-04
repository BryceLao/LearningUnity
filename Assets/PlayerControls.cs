using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
    private Rigidbody2D rb;
    [SerializeField]
    private Animator anim;
        
    private void Start(){
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }
    private void Update() {    
        
        float HDirection=Input.GetAxis("Horizontal");

        if (HDirection < 0 ) {
          rb.velocity= new Vector2(-5, rb.velocity.y);
          transform.localScale = new Vector2(-1,1);
        anim.SetBool("running", true);
        }
        else if (HDirection > 0) {
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



    


    

