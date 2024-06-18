using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [field: Header("References")]
    [field: SerializeField] public PlayerSO Data { get; private set; }

    //field�� ����� ��ĥ ��, ���Ǵ� Ű�����̴�.( �ʵ忡 �����ֱ� ���� Ű���� )
    //field: SerializeField�� ������Ƽ�� �־ �ν����� â�� ���.
    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    //public�̳� SerializeField�̶� ������Ƽ�� ������ �ν����� â�� ���� �ʴ´�.
    public Animator Animator { get; private set; }
    public CharacterController Controller { get; private set; }

    private PlayerStateMachine stateMachine;

    private void Awake()
    {
        //���ӸŴ����� �÷��̾ �ڽ��� �־��ش�
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