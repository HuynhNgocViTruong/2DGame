﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController_2D : MonoBehaviour {

    Rigidbody2D m_rigidbody;
    Animator m_Animator;
    Transform m_tran;

    private float h = 0;
    private float v = 0;

    
    public float hp = 100;
    public float MoveSpeed = 40;

    public SpriteRenderer[] m_SpriteGroup;

    public bool Once_Attack = false;


    // Use this for initialization
    void Start () {
        m_rigidbody = this.GetComponent<Rigidbody2D>();
        m_Animator = this.transform.Find("BURLY-MAN_1_swordsman_model").GetComponent<Animator>();
        m_tran = this.transform;
        m_SpriteGroup = this.transform.Find("BURLY-MAN_1_swordsman_model").GetComponentsInChildren<SpriteRenderer>(true);
    }
	
	// Update is called once per frame
	void Update () {


        spriteOrder_Controller();


        if (Input.GetKeyDown(KeyCode.Z))
        {
            Once_Attack = false;
            m_Animator.SetTrigger("Attack");

            m_rigidbody.velocity = new Vector3(0, 0, 0);
        }

        else if (Input.GetKeyDown(KeyCode.X))
        {
            Once_Attack = false;
            m_Animator.SetTrigger("Attack2");

            m_rigidbody.velocity = new Vector3(0, 0, 0);
        }

/*        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") || m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Die")||
            m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Hit")|| m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
            return;*/

        Move_Fuc();
        isDead();
    }

    public int sortingOrder = 0;
    public int sortingOrderOrigine = 0;

    private float Update_Tic = 0;
    private float Update_Time = 0.1f;

    void spriteOrder_Controller()
    {

        Update_Tic += Time.deltaTime;

        if (Update_Tic > 0.1f)
        {
            sortingOrder = Mathf.RoundToInt(this.transform.position.y * 100);
            //Debug.Log("y::" + this.transform.position.y);
            //  Debug.Log("sortingOrder::" + sortingOrder);
            for (int i = 0; i < m_SpriteGroup.Length; i++)
            {

                m_SpriteGroup[i].sortingOrder = sortingOrderOrigine - sortingOrder;

            }

            Update_Tic = 0;
        }
    }

    // character Move Function
    void Move_Fuc()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_rigidbody.AddForce(Vector2.left * MoveSpeed);
            if (B_FacingRight)
                Filp();

            m_Animator.SetBool("Run", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            m_rigidbody.AddForce(Vector2.right * MoveSpeed);
            if (!B_FacingRight)
                Filp();

            m_Animator.SetBool("Run", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            m_Animator.SetBool("Run", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_rigidbody.AddForce(Vector2.up * 5000);
            //m_Animator.SetBool("Run", false);
        }
    }


    // character Filp 
    bool B_Attack = false;
    bool B_FacingRight = true;

    void Filp()
    {
        B_FacingRight = !B_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;

        m_tran.localScale = theScale;
    }

    private void isDead()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
