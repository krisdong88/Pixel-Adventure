using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{

    [SerializeField] private bool On;
    private float timer;

    private Animator Anim;
    private AreaEffector2D Effector;
    private ParticleSystem PS;

    [SerializeField] private TrapsData data;
    
    private void Awake()
    {
        Anim = GetComponent<Animator>();
        Effector = GetComponent<AreaEffector2D>();
        PS = GetComponent<ParticleSystem>();
    }

    private void Start() 
    {
        Turn(On);
    }

    private void Update()
    {
        if(Time.time >= timer + data.fanTimer)
            Turn(!On);
    }

    private void Turn(bool value)
    {
        On = value;
        Anim.SetBool("On",value);
        Effector.enabled = value;
        if(On) PS.Play(); else PS.Stop();
        timer = Time.time;
    }

}
