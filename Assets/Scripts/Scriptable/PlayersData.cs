using UnityEngine;

[CreateAssetMenu(fileName = "PlayersData", menuName = "Data/PlayersData")]
public class PlayersData : ScriptableObject 
{
    [Header("Players")]
    public GameObject[] players;
}