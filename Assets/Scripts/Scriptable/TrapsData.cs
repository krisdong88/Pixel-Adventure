using UnityEngine;

[CreateAssetMenu(fileName = "TrapsData", menuName = "Data/TrapsData")]
public class TrapsData : ScriptableObject 
{
    [Header("Boxes")]
    public int box1Life = 1;
    public int box2Life = 5;
    public int box3Life = 5;

    [Header("Trampoline")]
    public float trampolineJumpForce = 2000f;

    [Header("Fan")]
    public float fanTimer = 5f;
    public float weakFanForce = 70f;
    public float MidFanForce = 83.385f;
    public float strongFanForce = 90f;

    [Header("Arrow")]
    public float ArrowForce = 1300f;

    [Header("Platform")]
    public float platformSpeed = 10f;
    public float platformWaitTime = 1f;
}