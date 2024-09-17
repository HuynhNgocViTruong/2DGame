using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    Rigidbody2D rig { get; set; }
    bool IsFacingRight { get; set; }

    void MoveEnemy(Vector2 velocity);
    void CheckLeftOrRightFacing(Vector2 velocity);
}
