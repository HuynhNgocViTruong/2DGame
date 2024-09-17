using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState CuerrentEnemyState { get; set; }

    public void Initialize(EnemyState staringState)
    {
        CuerrentEnemyState = staringState;
        CuerrentEnemyState.EnterState();
    }

    public void ChangeState(EnemyState newState)
    {
        CuerrentEnemyState.ExitState();
        CuerrentEnemyState = newState;
        CuerrentEnemyState.EnterState();
    }
}
