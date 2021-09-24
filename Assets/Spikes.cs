using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    private CameraShake cameraShake;
    private GameObject player;
    private void Awake() 
    {
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        StartCoroutine(cameraShake.Shake(.1f,.1f));
        other.gameObject.GetComponent<Collider2D>().enabled = false;
        other.gameObject.GetComponent<Player>().enabled = false;
        Destroy(other.transform.GetChild(0).gameObject);
        Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x,20);
        rb.AddTorque(rb.velocity.x);
        player = other.gameObject;

        Invoke("DestroyOB",2f);
    }

    private void DestroyOB()
    {
        Destroy(player);
    }

    
}
