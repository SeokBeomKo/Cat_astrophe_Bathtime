using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExcuteShotState : IPlayerShotState
{
    public PlayerController player { get; set; }
    public PlayerShotStateMachine stateMachine { get; set; }

    public PlayerExcuteShotState(PlayerShotStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
        player = stateMachine.playerController;
    }
    public void Execute()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            stateMachine.ChangeState(PlayerShotStateEnums.EXIT);
            return;
        }
        Debug.Log("Excute");
    }

    public void OnStateEnter()
    {
    }

    public void OnStateExit()
    {
    }
}
