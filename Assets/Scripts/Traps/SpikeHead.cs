using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : Spikes
{
    
    [SerializeField] private TrapsData data;
    [SerializeField] private bool Linear;
    [SerializeField] private float Speed;
    [SerializeField] private Vector2 direction;
    [SerializeField] private LayerMask WhatIsGround;

    
    private Animator Anim;
    private Rigidbody2D RockHeadRB;


    private bool waiting;
    private float velocity;

    protected override void Awake()
    {
        base.Awake();
        Anim = GetComponent<Animator>();

        if(Speed == 0)
            Speed = data.SpikeHeadVelocity;
    }


    private void Update() 
    {   
        RaycastHit2D hit = Physics2D.Raycast(transform.position,direction,1.3f,WhatIsGround);
        if(hit)
        {
            
            transform.position = new Vector3(hit.point.x-(direction.x*1.3f),hit.point.y-(direction.y*1.3f));
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
