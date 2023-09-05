using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int id;
    public int type;
    public float forwardSpeed;
    public float rightSpeed;
    public float lifeTime;

    public float time;

    public void Init(BulletInfo info)
    {
        id = info.id;
        type = info.type;
        forwardSpeed = info.forwardSpeed;
        rightSpeed = info.rightSpeed;
        lifeTime = info.lifeTime;
        Invoke(nameof(NoEffDestroy), lifeTime); // Invoke判空
    }

    public void BulletDestroy()
    {
        // 爆炸特效
        GameObject destroyObj = Instantiate(Resources.Load<GameObject>("Prefabs/Effect/WoundEff"), transform.position, transform.rotation);
        Destroy(destroyObj, 2);
        
        // 子弹销毁
        Destroy(gameObject);
    }
    
    // 无特效销毁
    public void NoEffDestroy()
    {
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().Wound(1);
            
            BulletDestroy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        // 向前移动
        gameObject.transform.Translate(Vector3.forward * (forwardSpeed * Time.deltaTime));
        
        // 分类型侧向移动
        switch (type)
        {
            case 2:
                // 正弦移动
                gameObject.transform.Translate(Vector3.right * (Mathf.Sin(time * 3) * Time.deltaTime * rightSpeed));
                break;
            case 3:
                // 右弧形
                gameObject.transform.Rotate(Vector3.up, rightSpeed * Time.deltaTime);
                break;
            case 4:
                // 左弧形
                gameObject.transform.rotation *= Quaternion.AngleAxis(-rightSpeed * Time.deltaTime, Vector3.up);
                break;
            case 5:
                // 跟踪
                gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Player.Instance.transform.position- transform.position),
                    Time.deltaTime * rightSpeed);
                break;
        }
    }
}
