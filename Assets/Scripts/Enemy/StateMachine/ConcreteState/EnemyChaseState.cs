using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        
    }

    public override void EnterState()
    {
        base.EnterState();
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
            enemy.animator.SetBool("Walk", false);
            enemy.animator.SetBool("Idle", true);
        }

        Check();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void AnimationTriggerEvent()
    {
        base.AnimationTriggerEvent();
        enemy.animator.SetBool("Walk", true);
        enemy.animator.SetBool("Idle", false);
    }

    private void Check()
    {
        if (enemy.IsWithinStrikingDistance)
        {
            enemy.stateMachine.ChangeState(enemy.attackState);
        }

        if (!enemy.IsAggroed)
        {
            enemy.stateMachine.ChangeState(enemy.IdleState);
        }
    }

    #region Level01
    private void Lv1()
    {
        Vector2 moveDirection = (enemy.player.position - enemy.transform.position).normalized;

        enemy.MoveEnemy(moveDirection * enemy.enemySpeed);
    }
    #endregion
}
