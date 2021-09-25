using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Interactable
{

    private bool triggered;

    private Animator Anim;
    private CapsuleCollider2D flameCollider;

    [SerializeField] private TrapsData data;


    protected override void Awake()
    {
        base.Awake();
        Anim = GetComponent<Animator>();
        flameCollider = GetComponentInChildren<CapsuleCollider2D>();
        Anim.SetBool("on",false);

    }

    public override void Interact(Collision2D other)
    {
        base.Interact(other);
        Anim.Play("Hit");

        if(!triggered)
        {
            triggered=true;
            Invoke("TurnOn",data.fireWaitTime);
        }
        
    }

    public override bool CheckInteraction(Vector2 interactor)
    {
        return true;
    }

    private void TurnOn()
    {
        Anim.SetBool("on",true);
        flameCollider.enabled = true;
        Invoke("TurnOff",data.fireOnTime);
    }

    private void TurnOff()
    {
        Anim.SetBool("on",false);
        flameCollider.enabled = false;
        triggered=false;
    }

}
