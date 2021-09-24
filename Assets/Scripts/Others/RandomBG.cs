using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBG : MonoBehaviour
{   
    public int bg {get; private set;}
    
    void Awake()
    {
        bg = Random.Range(0,7);
    }

}
