using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance => instance;
    
    public int hp;
    public int maxHp;

    public int speed;
    private Vector3 oldPos;
    private Vector3 newPos;
    public Camera playerCamera;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
        // 射线检测
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.ScreenPointToRay(Input.mousePosition), out hit, 1000, 1<<LayerMask.NameToLayer("Bullet")))
            {
                hit.transform.GetComponent<Bullet>().BulletDestroy(); // 点击销毁子弹
            }
        }
        
    }


    public void Dead()
    {
        EndPanel.Instance.Show();
    }

    public void Wound(int value)
    {
        this.hp -= value;
        GamePanel.Instance.UpdateHp(this.hp);

        if (hp <= 0)
        {
            Dead();
        }
    }

    public void Move()
    {
        // 上下
        if (Input.GetAxis("Vertical") > 0)
        {
            oldPos = transform.position;
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
            newPos = transform.position;
            
            // 边界限制
            if (playerCamera.WorldToScreenPoint(newPos).y > Screen.height)
            {
                transform.position = new Vector3(newPos.x, newPos.y, oldPos.z);
            }
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            oldPos = transform.position;
            transform.Translate(Vector3.back * (speed * Time.deltaTime));
            newPos = transform.position;
            
            if (playerCamera.WorldToScreenPoint(newPos).y < 0)
            {
                transform.position = new Vector3(newPos.x, newPos.y, oldPos.z);
            }
        }

        // 左右
        // 左右倾斜
        if (Input.GetAxisRaw("Horizontal") > 0) 
        {
            // 右
            oldPos = transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(-20, Vector3.forward), Time.deltaTime);
            transform.Translate(Vector3.right * (speed * Time.deltaTime), Space.World);
            newPos = transform.position;
            if (playerCamera.WorldToScreenPoint(newPos).x > Screen.width)
            {
                transform.position = new Vector3(oldPos.x, newPos.y, newPos.z);
            }
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            // 左
            oldPos = transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(20, Vector3.forward), Time.deltaTime);
            transform.Translate(Vector3.left * (speed * Time.deltaTime), Space.World);
            newPos = transform.position;
            if (playerCamera.WorldToScreenPoint(newPos).x < 0)
            {
                transform.position = new Vector3(oldPos.x, newPos.y, newPos.z);
            }
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime);
        }
        
    }
}