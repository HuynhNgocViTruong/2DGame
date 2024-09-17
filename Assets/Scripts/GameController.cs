using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.FindWithTag("Deathzone").transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
