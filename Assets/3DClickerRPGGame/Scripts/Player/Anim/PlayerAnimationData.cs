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
        //글자를 정수(해시값)으로 바꿔주는 코드들이다. 이유는 문자열 비교보다 정수값으로 비교하는 것이 성능상 큰 이득이기 때문
        GroundParameterHash = Animator.StringToHash(groundParameterName);
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        RunParameterHash = Animator.StringToHash(runParameterName);

        AttackParameterHash = Animator.StringToHash(attackParameterName);
        SkillCastingParameterHash = Animator.StringToHash(skillCastingParameterName);
    }
}