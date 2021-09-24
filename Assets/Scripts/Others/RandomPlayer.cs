using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlayer : MonoBehaviour
{
    private int player;

    [SerializeField] private PlayersData data;
    
    private void Start() 
    {
        player = Random.Range(0,data.players.Length);
        GameObject playerGO =Instantiate(data.players[player],transform.position,Quaternion.identity,transform);
    }
}
