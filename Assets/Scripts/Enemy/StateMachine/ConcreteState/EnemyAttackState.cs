using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private float timer;
    private float timeBetweenAtk;
    private float ExitTimer;
    private float timeStillExit = 1;

    public EnemyAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        
    }

    public override void EnterState()
    {
        base.EnterState();
        timeBetweenAtk = enemy.timeBetweenAtk;
        timeStillExit = enemy.timeStillExit;
        AnimationTriggerEvent();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (enemy.EnemyLvl == "Lv1")
        {
            Lv1();
        }
        else
        {
            enemy.animator.SetTrigger("Attack");
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void AnimationTriggerEvent()
    {
        base.AnimationTriggerEvent();
        enemy.animator.SetBool("Walk", false);
        enemy.animator.SetBool("Idle", true);
        //enemy.animator.SetTrigger("Attack");
    }

    #region Level01
    private void Lv1()
    {
        enemy.MoveEnemy(Vector2.zero);

        if (timer > timeBetweenAtk)
        {
            timer = 0;
            if (enemy.IsWithinStrikingDistance)
            {
                enemy.animator.SetTrigger("Attack");
            }
        }

        if (!enemy.IsWithinStrikingDistance)
        {
            ExitTimer += Time.deltaTime;
            if (ExitTimer > timeStillExit)
                enemy.stateMachine.ChangeState(enemy.chaseState);
        }
        else
        {
            ExitTimer = 0;
        }


        timer += Time.deltaTime;
    }
    #endregion
}
