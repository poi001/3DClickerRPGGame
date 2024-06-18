using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }

    // States
    public PlayerIdleState IdleState { get; }

    //public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    //public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;

    public Transform MainCamTransform { get; set; }



    public PlayerStateMachine(Player player)
    {
        this.Player = player;

        IdleState = new PlayerIdleState(this);

        MainCamTransform = Camera.main.transform;

        MovementSpeed = player.Data.GroundData.BaseSpeed;
        //RotationDamping = player.Data.GroundData.BaseRotationDamping;
    }
}