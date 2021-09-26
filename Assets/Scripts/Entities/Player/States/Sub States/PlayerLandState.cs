using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(Player entity ,string animBoolName) : base(entity, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.CreateDust();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isExitingState)
            return;

        if(xInput == 0)
            player.Core.Movement.SetVelocityX(0f);
        if(xInput !=0 )
            stateMachine.ChangeState(player.MoveState);
        else
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }
}
