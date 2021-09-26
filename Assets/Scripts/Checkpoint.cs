using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private Animator Anim;

    private bool triggerd;

    private void Awake() {
        Anim = GetComponent<Animator>();    
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(triggerd)
            return;
        
        Anim.Play("Trigger");

        triggerd = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(triggerd)
            return;
        Anim.Play("Trigger");

        triggerd =true;
    }
}
