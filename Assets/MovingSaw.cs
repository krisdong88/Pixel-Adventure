using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSaw : Spikes
{

    private Vector2[] points;
    [SerializeField] private int current;
    private int next;

    [SerializeField] private TrapsData data;


    protected override void Awake() 
    {
        base.Awake();
        points = new Vector2[4];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.parent.GetChild(i).localPosition;
            if(transform.localPosition.x == points[i].x && transform.localPosition.y == points[i].y)
                current =i;
        }
            

        next = current+1;
    }

    

    private void FixedUpdate() 
    {
        if(Mathf.Abs(transform.localPosition.x - points[next].x)<0.01 && Mathf.Abs(transform.localPosition.y - points[next].y)<0.01)
        {
            nextPoint();
        }
        else
        {
            transform.Translate(direction(points[current],points[next])*(data.sawSpeed/100f));
        }
    }

    private void nextPoint()
    {
        
        if(next < 3)
        {
            current = next;
            next++;
        }
        else 
        {
            current = 3;
            next = 0;
        }
    }

    private Vector2 direction(Vector2 point1,Vector2 point2)
    {
        return new Vector2(point2.x-point1.x,point2.y-point1.y).normalized;
    }
}
