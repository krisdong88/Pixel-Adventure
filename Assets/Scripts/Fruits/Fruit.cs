using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public bool Istantiated { get; private set; } = false;

    private void Start() 
    {
        if(!Istantiated)
            GetComponent<Rigidbody2D>().isKinematic = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            this.GetComponent<Animator>().Play("Collected");
            this.GetComponent<Collider2D>().enabled = false;
        }
            
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    public void SetIstantiated() => Istantiated = true;

}
