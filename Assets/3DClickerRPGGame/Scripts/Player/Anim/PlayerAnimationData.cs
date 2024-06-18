using System;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
    [SerializeField] private string groundParameterName = "@Ground";
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string runParameterName = "Run";

    [SerializeField] private string attackParameterName = "@Attack";
    [SerializeField] private string comboAttackParameterName = "ComboAttack";
    [SerializeField] private string skillCastingParameterName = "SkillCasting";

    public int GroundParameterHash { get; private set; }
    public int IdleParameterHash { get; private set; }
    public int RunParameterHash { get; private set; }

    public int AttackParameterHash { get; private set; }
    public int SkillCastingParameterHash { get; private set; }



    public void Initialize()
    {
        //���ڸ� ����(�ؽð�)���� �ٲ��ִ� �ڵ���̴�. ������ ���ڿ� �񱳺��� ���������� ���ϴ� ���� ���ɻ� ū �̵��̱� ����
        GroundParameterHash = Animator.StringToHash(groundParameterName);
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        RunParameterHash = Animator.StringToHash(runParameterName);

        AttackParameterHash = Animator.StringToHash(attackParameterName);
        SkillCastingParameterHash = Animator.StringToHash(skillCastingParameterName);
    }
}