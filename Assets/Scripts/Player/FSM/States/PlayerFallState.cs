using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : IPlayerState
{
    public PlayerController player {get; set;}
    public PlayerStateMachine stateMachine {get; set;}

    public PlayerFallState(PlayerStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public void Execute()
    {
    }

    public void Init(PlayerStateMachine stateMachine)
    {
    }

    public void OnStateEnter()
    {
    }

    public void OnStateExit()
    {
    }

    public void ChangeState(IPlayerState newState)
    {

    }
}
