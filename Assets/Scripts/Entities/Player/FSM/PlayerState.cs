using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FiniteStateMachine;

public class PlayerState : State
{
    protected Player player{ get=> (Player)entity;}
    protected PlayerData playerData {get => (PlayerData)data;}

    public PlayerState(Entity entity, string animBoolName) : base(entity, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //  Debug.Log(AnimBoolName);
    }
}
