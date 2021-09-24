using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "BackgroundData", menuName = "Data/BackgroundData")]
public class BackgroundData : ScriptableObject
{
    [Header("Fruits")]
    public TileBase[] BackgroundTiles;     
}