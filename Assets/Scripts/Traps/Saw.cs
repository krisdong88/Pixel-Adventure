using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Spikes
{

    
    public float speed;
    public float amount;

    private float timer;

    private void FixedUpdate() 
    {
        transform.localPosition =new Vector3(transform.localPosition.x,transform.localPosition.y + Mathf.Sin(timer * speed) * amount,0);

        timer += Time.deltaTime;

        if(speed == 0)
            timer =0;
    }
}
