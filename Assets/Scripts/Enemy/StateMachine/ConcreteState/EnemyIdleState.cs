using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private Vector3 targetPos;
    private Vector3 direction;
    private bool right=true;

    public EnemyIdleState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {

    }

    public override void EnterState()
    {
        base.EnterState();
        AnimationTriggerEvent();

        targetPos = GetPos();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (enemy.IsAggroed)
        {
            enemy.stateMachine.ChangeState(enemy.chaseState);
        }

        if(enemy.EnemyLvl == "Lv1")
        {
            Lv1();
        }
        else
        {
            enemy.animator.SetBool("Walk", false);
            enemy.animator.SetBool("Idle", true);
        }
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

    #region Level01
    private Vector3 GetPos()
    {
        //return enemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * enemy.MovementRange;
        if (right)
        {
            right = false;
            return enemy.curr + new Vector3(enemy.Max, 0f , 0f);
        }
        else if(!right)
        {
            right = true;
            return enemy.curr + new Vector3(enemy.Min, 0f, 0f);
        }
        else
        {
            return enemy.curr;
        }
    }

    private void Lv1()
    {
        direction = (targetPos - enemy.transform.position).normalized;
        enemy.MoveEnemy(direction * enemy.enemySpeed);

        if ((enemy.transform.position - targetPos).sqrMagnitude < 0.01f)
        {
            targetPos = GetPos();
        }
    }
    #endregion

}
