using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public enum AIState
{
    Idle,
    Moving,
    Attacking
}

public class Enemy : MonoBehaviour, IDamagable
{
    [Header("Stats")]
    public int health;                  //체력
    public float moveSpeed;             //이동 속도
    //public ItemData[] dropOnDeath;    //드랍 아이템

    [Header("AI")]
    private AIState aiState;            //상태
    public float detectDistance = 1.0f;

    [Header("Combat")]
    public int damage;
    public float attackRate = 2.5f;
    private float lastAttackTime;
    //public float attackDistance;

    private float playerDistance;

    private NavMeshAgent agent;
    private Animator animator;
    private SkinnedMeshRenderer[] meshRenderers;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        meshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
    }

    private void Start()
    {
        SetState(AIState.Moving);
    }

    private void Update()
    {
        playerDistance = Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position);

        animator.SetBool("IsMoving", aiState != AIState.Idle);

        switch (aiState)
        {
            case AIState.Idle:
                IdleUpdate();
                break;
            case AIState.Moving:
                MovingUpdate();
                break;
            case AIState.Attacking:
                AttackingUpdate();
                break;
        }
    }

    private void SetState(AIState state)
    {
        aiState = state;

        switch (aiState)
        {
            case AIState.Idle:
                agent.speed = moveSpeed;
                agent.isStopped = true;
                aiState = AIState.Idle;
                break;
            case AIState.Moving:
                agent.speed = moveSpeed;
                agent.isStopped = false;
                aiState = AIState.Moving;
                break;
            case AIState.Attacking:
                agent.speed = moveSpeed;
                agent.isStopped = true;
                aiState = AIState.Attacking;
                animator.SetTrigger("IsAttacking");
                break;
        }
    }

    void IdleUpdate()
    {
        if(!GameManager.Instance.Player.IsDead) SetState(AIState.Moving);
    }

    void MovingUpdate()
    {
        if (aiState == AIState.Moving && GameManager.Instance.Player.IsDead)
        {
            SetState(AIState.Idle);
            return;
        }
        if (playerDistance < detectDistance)
        {
            SetState(AIState.Attacking);
            return;
        }

        agent.SetDestination(GameManager.Instance.Player.transform.position);
    }

    void AttackingUpdate()
    {
        lastAttackTime += Time.deltaTime;

        if (lastAttackTime > attackRate)
        {
            lastAttackTime = 0.0f;
            SetState(AIState.Moving);
            GameManager.Instance.Player.Condition.GetComponent<IDamagable>().TakePhysicalDamage(damage);
        }
    }

    public void TakePhysicalDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
            Die();

        StartCoroutine(DamageFlash());
    }

    void Die()
    {
        //for (int x = 0; x < dropOnDeath.Length; x++)
        //{
        //    Instantiate(dropOnDeath[x].dropPrefab, transform.position + Vector3.up * 2, Quaternion.identity);
        //}

        Destroy(gameObject);
    }

    IEnumerator DamageFlash()
    {
        for (int x = 0; x < meshRenderers.Length; x++)
            meshRenderers[x].material.color = new Color(1.0f, 0.6f, 0.6f);

        yield return new WaitForSeconds(0.1f);
        for (int x = 0; x < meshRenderers.Length; x++)
            meshRenderers[x].material.color = Color.white;
    }
}
