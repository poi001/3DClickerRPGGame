using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [field: Header("References")]
    [field: SerializeField] public PlayerSO Data { get; private set; }

    //field는 헤더가 겹칠 때, 사용되는 키워드이다.( 필드에 보여주기 위한 키워드 )
    //field: SerializeField는 프로퍼티가 있어도 인스펙터 창에 뜬다.
    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    //public이나 SerializeField이라도 프로퍼티가 있으면 인스펙터 창에 뜨지 않는다.
    public Animator Animator { get; private set; }
    public CharacterController Controller { get; private set; }

    private PlayerStateMachine stateMachine;

    private void Awake()
    {
        //게임매니저에 플레이어에 자신을 넣어준다
        GameManager.Instance.Player = this;

        AnimationData.Initialize();
        Animator = GetComponentInChildren<Animator>();
        Controller = GetComponent<CharacterController>();

        stateMachine = new PlayerStateMachine(this);
    }

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Update()
    {
        stateMachine.HandleInput();
        stateMachine.Update();
    }

}