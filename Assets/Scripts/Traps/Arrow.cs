using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
   
    [SerializeField] private Vector2 direction;

    private Rigidbody2D PlayerRB;
    [SerializeField] private TrapsData data;


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            
            this.GetComponent<Animator>().Play("Hit");
            PlayerRB = other.gameObject.GetComponent<Rigidbody2D>();
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x,0);
            PlayerRB.AddForce(direction*data.ArrowForce);
        }
            
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
