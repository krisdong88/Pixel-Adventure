using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using FiniteStateMachine;

public class PlayerJumpState : PlayerAbilityState
{
    private int amountOfJumpsLeft;

    public PlayerJumpState(Entity entity, string animBoolName) : base(entity, animBoolName)
    {
        amountOfJumpsLeft = playerData.amountOfJumps;
    }

    public override void Enter()
    {
        base.Enter();
        player.InputHandler.UseJumpInput();
        core.Movement.Jump(playerData.jumpForce);
        isAbilityDone = true;
        amountOfJumpsLeft--;
        player.InAirState.SetIsJumping();

        if(!isGrounded)
            player.Anim.SetBool("doubleJump",true);
    }

    public override void Exit()
    {
        base.Exit();
        player.Anim.SetBool("doubleJump",false);
    }



    public bool CanJump() => amountOfJumpsLeft > 0;

    public void Resetjumps() => amountOfJumpsLeft = playerData.amountOfJumps;

    public void UseJump() => amountOfJumpsLeft--;
}
