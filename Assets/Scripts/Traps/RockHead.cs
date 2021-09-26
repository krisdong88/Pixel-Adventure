using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHead : MonoBehaviour
{

    
    
    [SerializeField] private TrapsData data;
    [SerializeField] private bool Linear;
    [SerializeField] private float Speed;
    [SerializeField] private Vector2 direction;
    [SerializeField] private LayerMask WhatIsGround;
    private CameraShake cameraShake;

    
    private Animator Anim;
    private Rigidbody2D RockHeadRB;


    private bool waiting;
    private float velocity;

    

    private void Awake() 
    {
        Anim = GetComponent<Animator>();
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();

        if(Speed == 0)
            Speed = data.RockHeadVelocity;
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.position.y >transform.position.y && other.gameObject.tag =="Player")
            other.transform.parent.parent = transform;
    }

    private void OnCollisionExit2D(Collision2D other) {
        other.transform.parent.parent = null;
    }

    private void Update() 
    {   
        RaycastHit2D hit = Physics2D.Raycast(transform.position,direction,1f,WhatIsGround);
        if(hit)
        {
            
            transform.position = new Vector3(hit.point.x-direction.x,hit.point.y-direction.y);
           Anim.SetFloat("H",direction.x);
            Anim.SetFloat("V",direction.y);
            Anim.Play("Hit");
            ChangeDirection();
            StartCoroutine(cameraShake.Shake());
            waiting = true;


        }

            
    }

    void FixedUpdate()
    {
        if(!waiting)
            transform.Translate(direction*velocity);
        
        if(velocity <Speed)
            velocity+=0.02f;
        else
            velocity = Speed;
    }

    private void ChangeDirection()
    {
        if(Linear)
            direction = -direction;
        else
        {   if(direction.x ==0)
                direction = new Vector2(direction.y,direction.x);
            else
                direction = -new Vector2(direction.y,direction.x);
        }
        Invoke("SetWaiting",1f);
    }

    private void SetWaiting()
    {
        waiting = false;
        velocity=0;
    }

}
