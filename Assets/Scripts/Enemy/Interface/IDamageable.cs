using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamable
{
    void Damage(float damageAmount);

    void Die();

    float MaxHp { get; set; }
    float CurrentHp { get; set; }
}
