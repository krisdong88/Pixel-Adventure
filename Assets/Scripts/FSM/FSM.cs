using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiniteStateMachine
{
    public class FSM
    {
        public State CurrentState { get; set; }

        public void Initialize(State startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }

        public void ChangeState(State newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}