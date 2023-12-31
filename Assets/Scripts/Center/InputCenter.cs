using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCenter : MonoBehaviour
{
    [Header("플레이어 컨트롤러")]
    [SerializeField] public PlayerController playerController;
    [Header("플레이어 인풋 핸들")]
    [SerializeField] public InputHandler inputHandle;

    private void Start() 
    {
        inputHandle.OnPlayerRunInput += ChangeRunState;
        inputHandle.OnPlayerJumpInput += ChangeJumpState;
        inputHandle.OnPlayerDiveRollInput += ChangeRollState;
        inputHandle.OnPlayerAimSwitchInput += ChangeAimState;

        inputHandle.OnWeaponSwapInput += SwapWeapon;
    }

    void SwapWeapon(int number)
    {
        playerController.weaponStrategy.SwapWeapon(number);
    }

    void ChangeAimState()
    {
        if (playerController.stateMachine.curState is PlayerMoveState moveState)
        {
            playerController.stateMachine.ChangeStateInput(PlayerMovementStateEnums.AIM_MOVE);
        }
        else
        {
            playerController.stateMachine.ChangeStateInput(PlayerMovementStateEnums.AIM);
        }
    }

    void ChangeRunState()
    {
        if (playerController.stateMachine.curState is PlayerAimState aimState)
        {
            playerController.stateMachine.ChangeStateInput(PlayerMovementStateEnums.AIM_MOVE);
        }
        else
        {
            playerController.stateMachine.ChangeStateInput(PlayerMovementStateEnums.MOVE);
        }
    }

    void ChangeJumpState()
    {
        if ((playerController.stateMachine.curState is PlayerJumpState jumpstate ||
            playerController.stateMachine.curState is PlayerFallState fallState) &&
            playerController.playerStats.GetDoubleCount() > 0)
        {
            playerController.stateMachine.ChangeStateInput(PlayerMovementStateEnums.DOUBLE);
        }
        else
        {
            playerController.stateMachine.ChangeStateInput(PlayerMovementStateEnums.JUMP);
        }
    }

    void ChangeRollState()
    {
        if (0 == playerController.playerStats.GetRollCount()) return;

        if (playerController.stateMachine.curState is PlayerIdleState idleState)
        {
            playerController.stateMachine.ChangeStateInput(PlayerMovementStateEnums.BACKROLL);
        }
        else
        {
            playerController.stateMachine.ChangeStateInput(PlayerMovementStateEnums.DIVEROLL);
        }
    }

    
}
