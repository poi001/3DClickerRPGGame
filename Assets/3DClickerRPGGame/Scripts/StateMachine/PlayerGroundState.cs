using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundState : PlayerBaseState
{
    public PlayerGroundState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.GroundParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.GroundParameterHash);
    }

    public override void Update()
    {
        base.Update();
    }

    //protected override void OnMovementCanceled(InputAction.CallbackContext context)
    //{
    //    if (stateMachine.MovementInput == Vector2.zero)
    //    {
    //        return;
    //    }

    //    stateMachine.ChangeState(stateMachine.IdleState);

    //    base.OnMovementCanceled(context);
    //}

}