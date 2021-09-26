using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBall : MonoBehaviour
{
    [SerializeField] private float ThetaZero;
    [SerializeField] private float W;
    [SerializeField] private bool CircleMotion;
    [SerializeField] private int direction;


    private float angle;
    private float timer;

    void FixedUpdate()
    {
        timer += 0.01f;

        if(!CircleMotion)
            angle = ThetaZero *Mathf.Cos(W * timer);
        else
            angle = direction*  W;
        
        transform.Rotate(0f,0f,angle);
        transform.GetChild(0).Rotate(0f,0f,-angle);



    }
}
