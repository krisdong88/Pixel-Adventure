using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovingBackground : MonoBehaviour
{
    
    public float speed = 0.008f;
    public Transform other;

    [SerializeField] private BackgroundData data;

    private Tilemap tilemap;


    private void Awake() 
    {
        tilemap = GetComponent<Tilemap>();    
    }

    private void Start() 
    {
        int bg = GetComponentInParent<RandomBG>().bg;
        for (int i = -3; i < 5; i++)
            for (int j = -1; j < 4; j++)
                tilemap.SetTile(new Vector3Int(i,j,0),data.BackgroundTiles[bg]);
        
    }

    private void Update()
    {
        if(transform.position.y < -5*4)
            transform.position = new Vector3(0,other.position.y+4*4,0);

        transform.position = new Vector3(0,transform.position.y-speed,0);
    }
}
