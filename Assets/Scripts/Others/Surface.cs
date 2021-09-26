using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreStuff;

public class Surface : MonoBehaviour
{
    [SerializeField] private float friction;

    private Core core;

    private void OnCollisionEnter2D(Collision2D other) {
        core = other.gameObject.GetComponentInChildren<Core>();

        core.Movement.SetFriction(friction);



        // if(other.transform.position.y > other.contacts[0].point.y)
        //     core.Movement.set

        // else
        //     playerRB.velocity = new Vector2(0,0);
    }

    private void OnCollisionExit2D(Collision2D other) {
        core.Movement.SetFriction(1f);
    }
}
