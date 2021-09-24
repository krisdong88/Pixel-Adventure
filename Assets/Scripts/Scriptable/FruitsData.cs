using UnityEngine;

[CreateAssetMenu(fileName = "FruitsData", menuName = "Data/FruitsData")]
public class FruitsData : ScriptableObject 
{
    [Header("Fruits")]
    public GameObject[] fruits;    
}