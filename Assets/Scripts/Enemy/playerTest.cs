using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTest : MonoBehaviour
{
    private GameObject enemyObject;
    public float dame = 24;
    private void Start()
    {
        enemyObject = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        enemyObject = GameObject.FindGameObjectWithTag("Enemy");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == enemyObject)
        {
            Debug.Log("check");
            check();
        }
    }

    public void check()
    {
        if (enemyObject != null)
        {
            Enemy newEnemy = enemyObject.GetComponent<Enemy>();
            if (newEnemy != null)
            {
                newEnemy.Damage(dame);
                Debug.Log("Nice");
            }
            else
            {
                Debug.Log("Đếu ổn r");
            }
        }
    }
}
