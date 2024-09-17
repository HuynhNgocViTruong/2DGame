using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEvent_Sender : MonoBehaviour {
    private CharacterController_2D m_parent;
    private Enemy enemy;
    void Start()
    {
        m_parent = this.transform.root.transform.GetComponent<CharacterController_2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            enemy = other.gameObject.transform.GetComponent<Enemy>();
            enemy.Damage(10);
            Debug.Log("hit::" + other.name);

        }

    }


}
