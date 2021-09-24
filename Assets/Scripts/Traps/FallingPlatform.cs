using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : Interactable
{

    private Animator Anim;
    private Rigidbody2D PlatformRB;
    private ParticleSystem ParticleSystem;

    public float speed;
    public float amount;

    [SerializeField] private TrapsData data;

    protected override void Awake()
    {
        base.Awake();
        Anim = GetComponent<Animator>();
        PlatformRB = GetComponent<Rigidbody2D>();
        Anim.SetBool("on",true);

    }

    private void Update()
    {
        transform.position =new Vector3(transform.position.x,transform.position.y + Mathf.Sin(Time.time * speed) * amount/1000,0);

        if(transform.position.y < -10)
            Destroy(gameObject);
    }


    public override bool CheckInteraction(Vector2 interactor)
    {
        return interactor.y >transform.position.y;
    }

    public override void Interact(Collision2D other)
    {
        base.Interact(other);

        Invoke("TurnOff",data.fallingPlatformWaitTime);

        speed =15;
        amount= 10;
    }

    private void TurnOff()
    {
        Anim.SetBool("on",false);
        PlatformRB.isKinematic = false;
        ParticleSystem.Stop();
    }


}
