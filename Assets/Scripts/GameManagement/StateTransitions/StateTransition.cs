// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using UnityEngine;

namespace GameManagement.StateTransitions
{
    public class StateTransition : MonoBehaviour
    {
        [SerializeField] protected GameStateMachine gameStateMachine;
        [SerializeField] private GameState toState;

        protected void Transition()
        {
            gameStateMachine.ChangeState(toState);
        }
    }
}
