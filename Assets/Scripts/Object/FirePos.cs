using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum E_FirePos
{
    Top,
    LeftTop,
    RightTop,

    Left,
    Right,

    Bottom,
    BottomLeft,
    BottomRight
}

public class FirePos : MonoBehaviour
{
    public E_FirePos type;
    public Camera camera;
    public Vector3 pos;
    public Vector3 defaultDir;
    private List<BulletInfo> bulletInfos;
    private BulletInfo bulletInfo;
    private List<FireInfo> fireInfos;
    private FireInfo fireInfo;
    public float time;
    public float nowBulletCd;
    public float nowFireCd;
    public int nowBulletCount;

    public void Init()
    {
        // 到平面到摄像机距离
        float distance = 223.7f;

        switch (type)
        {
            // 四个角初始位置
            case E_FirePos.LeftTop:

                pos = camera.ScreenToWorldPoint(new Vector3(0, Screen.height, distance));
                defaultDir = Vector3.right;
                break;
            case E_FirePos.RightTop:
                pos = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, distance));
                defaultDir = Vector3.back;
                break;
            case E_FirePos.BottomLeft:
                pos = camera.ScreenToWorldPoint(new Vector3(0, 0, distance));
                defaultDir = Vector3.forward;
                break;
            case E_FirePos.BottomRight:
                pos = camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, distance));
                defaultDir = Vector3.left;
                break;

            // 四边中心点初始位置
            case E_FirePos.Top:
                pos = camera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, distance));
                defaultDir = Vector3.right;
                break;
            case E_FirePos.Left:
                pos = camera.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, distance));
                defaultDir = Vector3.forward;
                break;
            case E_FirePos.Right:
                pos = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, distance));
                defaultDir = Vector3.back;
                break;
            case E_FirePos.Bottom:
                pos = camera.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, distance));
                defaultDir = Vector3.left;
                break;
        }

        transform.position = pos;

        // 初始化数据
        bulletInfos = GameDataMgr.Instance.bulletData.bulletInfos;
        fireInfos = GameDataMgr.Instance.fireData.fireInfos;
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
        ResetFireInfo();
    }

    // 重置发射信息
    public void ResetFireInfo()
    {
        // 随机子弹信息
        // bulletInfo = bulletInfos[Random.Range(0, bulletInfos.Count)];
        bulletInfo = bulletInfos[0];
        // 随机发射信息
        // fireInfo = fireInfos[Random.Range(0, fireInfos.Count)];
        fireInfo = fireInfos[0];
        // 重置cd
        nowBulletCd = fireInfo.bulletCd;
        nowFireCd = fireInfo.fireCd;
        nowBulletCount = fireInfo.bulletCount;
    }

    public void Fire()
    {
        GameObject bullet;

        switch (fireInfo.type)
        {
            // 连发
            case 1:
                bullet = Instantiate(Resources.Load<GameObject>(bulletInfo.resPath), transform.position,
                    Quaternion.LookRotation(Player.Instance.transform.position - transform.position));
                bullet.AddComponent<Bullet>().Init(bulletInfo);
                break;
            // 瞬发散弹
            case 2:

                break;
            // 顺序散弹
            case 3:
                break;
        }

        nowBulletCount--;
    }

    // Update is called once per frame
    void Update()
    {
        // 子弹数量足够和cd完成才发射
        if (nowBulletCount != 0 && nowBulletCd < 0)
        {
            Fire();
            nowBulletCd = fireInfo.bulletCd; // 
        }

        nowBulletCd -= Time.deltaTime;

        // 子弹发射完毕进入开火点cd
        if (nowBulletCount == 0)
        {
            nowFireCd -= Time.deltaTime;
        }

        // 开火点cd完成重置开火信息
        if (nowFireCd < 0)
        {
            ResetFireInfo();
        }
    }
}