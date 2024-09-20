using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamable, IMoveable, ITriggerCheck
{
    #region Enemy Variable
    [field: SerializeField] public float MaxHp { get; set; } = 0;
    [field: SerializeField] public float Dame { get; set; }
    [field: SerializeField] public string EnemyLvl { get; set; }
    [field: SerializeField] public float enemySpeed { get; set; }
    [field: SerializeField] public float Min { get; set; }
    [field: SerializeField] public float Max { get; set; }
    [field: SerializeField] public float timeBetweenAtk { get; set; }
    [field: SerializeField] public float timeStillExit { get; set; }
    public float CurrentHp { get; set; }
    #endregion

    #region Status Variable
    public bool IsFacingRight { get; set; } = true;
    public bool IsAggroed { get; set; }
    public bool IsWithinStrikingDistance { get; set; }
    private float count = 0;
    #endregion

    #region State Machine Variable
    public EnemyStateMachine stateMachine { get; set; }

    public EnemyChaseState chaseState { get; set; }
    public EnemyIdleState IdleState { get; set; }
    public EnemyAttackState attackState { get; set; }
    #endregion

    public Animator animator;
    public Transform player { get; set; }
    private Collider2D myCollider;
    public Vector3 curr { get; set; }
    public Rigidbody2D rig { get; set; }

    private void Awake()
    {
        stateMachine = new EnemyStateMachine();

        IdleState = new EnemyIdleState(this, stateMachine);
        chaseState = new EnemyChaseState(this, stateMachine);
        attackState = new EnemyAttackState(this, stateMachine);
    }

    private void Start()
    {
        CurrentHp = MaxHp;
        myCollider = GetComponent<Collider2D>();
        if(GameObject.FindGameObjectWithTag("Player").transform!=null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
        rig = GetComponent<Rigidbody2D>();
        curr = transform.position;

        stateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        if(player!=null)
            stateMachine.CuerrentEnemyState.FrameUpdate();
    }

    public void FixedUpdate()
    {
        if (player != null)
            stateMachine.CuerrentEnemyState.PhysicsUpdate();
    }

    #region Health/Attack/Die
    public void Damage(float damageAmount)
    {
        CurrentHp -= damageAmount;
        Vector3 randomness = new Vector3(Random.Range(0f, 0.5f), Random.Range(0f, 0.5f), Random.Range(0f, 0.5f));
        DamePopUpGenerator.current.CreatePopUp(transform.position + randomness, damageAmount.ToString(), Color.red);

        if (CurrentHp <= 0)
        {
            Die();
        }
    }

    public void Attack()
    {
        if (IsWithinStrikingDistance)
        {
            //Giảm máu player trong này
            player.GetComponent<CharacterController_2D>().hp -= 10;
        }
    }

    public void Die()
    {
        if (myCollider != null)
        {
            if(count < 1)
            {
                GetComponent<LootBag>().InstantiateLoots(transform.position);
                count += 1;
            }
            myCollider.enabled = false;
            rig.isKinematic = true;
            enemySpeed = 0;
            animator.SetTrigger("Dead");
            Destroy(gameObject, 5f);
        }
    }
    #endregion

    #region Movement
    public void MoveEnemy(Vector2 velocity)
    {
        rig.velocity = velocity;
        CheckLeftOrRightFacing(velocity);
    }

    public void CheckLeftOrRightFacing(Vector2 velocity)
    {
        if (IsFacingRight && velocity.x < 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        } else if (!IsFacingRight && velocity.x > 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
    }
    #endregion

    #region Animation
    private void AnimationTriggerEvent()
    {
        stateMachine.CuerrentEnemyState.AnimationTriggerEvent();
    }
    #endregion

    #region Distance Check

    public void SetAggroStatus(bool isAggroed)
    {
        IsAggroed = isAggroed;
    }

    public void SetStrikingDistance(bool isWithinStrikingDistance)
    {
        IsWithinStrikingDistance = isWithinStrikingDistance;
    }

    #endregion
}
