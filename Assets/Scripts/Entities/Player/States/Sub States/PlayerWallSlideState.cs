using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerTouchingWallState
{
    public PlayerWallSlideState(Entity entity, string animBoolName) : base(entity, animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isExitingState)
            return;
            
        core.Movement.SetVelocityY(-playerData.wallSlideVelocity);

        player.Anim.SetFloat("yVelocity",core.Movement.CurrentVelocity.y);

        // if(grabInput && yInput == 0)
        //     stateMachine.ChangeState(player.WallGrabState);
        
        
    }
}
