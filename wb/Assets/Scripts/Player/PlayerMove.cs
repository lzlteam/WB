using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Animator anim;
    private CharacterController m_Controller;
    public float mSpeed=2.0f;
    public float rSpeed=1.5f;
    public float jumpSpeed = 1.5f;
    private float jumpTimer = 0;
    private float jumpLastTimer = 0;
    private float jumpIntervel = 1;
    private float pTarget;
    void Start()
    {
        m_Controller = GetComponent<CharacterController>();
        anim =GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (PlayerManager.instance.GetHp() > 0)   
        {
            Move();//玩家的移动
            Rotate();//玩家跟随摄像机位置旋转 }
        }
    }
    public void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space)&&Time.time- jumpLastTimer>jumpIntervel)
        {
            Vector3 moveDirection = new Vector3(h, jumpSpeed, v);
            moveDirection.y = jumpSpeed;
            jumpTimer = 1;
            jumpLastTimer = Time.time;
            anim.SetBool("Jumping", true);
            m_Controller.Move(moveDirection * Time.deltaTime);
        }
        if (jumpTimer > 0.5) jumpTimer -= Time.deltaTime;
        else if (anim.GetBool("Jumping") == true) anim.SetBool("Jumping", false);
       
        if (Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f)
        {
            anim.SetInteger("Speed", 2);
            Vector3 moveDirection = new Vector3(h, 0, v);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= mSpeed;
            m_Controller.Move(moveDirection * Time.deltaTime);
        }
        else
        {
            anim.SetInteger("Speed", 0);
        }
    }

    public void Rotate()
    {
        pTarget = GameObject.Find("Main Camera").transform.eulerAngles.y;
        float angle = transform.eulerAngles.y - pTarget;
        if (angle < 0) angle += 360;
        if (angle > 180 && angle < 360 - rSpeed) transform.Rotate(0, rSpeed, 0);
        if (angle > rSpeed && angle < 180) transform.Rotate(0, -rSpeed, 0);
    }



}
