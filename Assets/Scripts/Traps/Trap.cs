using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Interactable
{
    [SerializeField] private TrapsData data;

    public override void Interact(Collision2D other)
    {
        shake = true;
        base.Interact(other);
        GetComponent<Animator>().Play("Jump");
        playerRB.AddForce(Vector2.up*data.trampolineJumpForce);

    }

}
