using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
    private Rigidbody2D rb;
    [SerializeField]
    private Animator anim;
    private enum State {idle,running, jumping, falling}     
    private State state= State.idle;
    private Collider2D coll;
    [SerializeField]
    private LayerMask ground;
    private void Start(){
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        coll=GetComponent<Collider2D>();
    }
    private void Update() {    
        
        float HDirection=Input.GetAxis("Horizontal");

        if(HDirection < 0 ) {
          rb.velocity= new Vector2(-5, rb.velocity.y);
          transform.localScale = new Vector2(-1,1);
        }
        else if(HDirection > 0) {
            rb.velocity= new Vector2(5, rb.velocity.y);
            transform.localScale =  new Vector2(1,1);
        }
        else{

        }
       if(Input.GetButtonDown("Jump") &&  coll.IsTouchingLayers(ground)) {
            rb.velocity= new Vector2(rb.velocity.x, 10f);   
            state=State.jumping;
        }
       VelocityState();
       anim.SetInteger("state", (int)state);
    }

    private void VelocityState(){
        if(state== State.jumping){
            if(rb.velocity.y < 0.1f){
                state=State.falling;
            }
        }
        else if(state==State.falling){
            if(coll.IsTouchingLayers(ground)){
                state=State.idle;
            }
        }
        else if(Math.Abs(rb.velocity.x) > 2f){
            state=State.running;   
        }
        else{
            state=State.idle;
        }
    }
}



    


    

