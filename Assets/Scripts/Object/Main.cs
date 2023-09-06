using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        // 初始化玩家
        PlaneInfo planeInfo = GameDataMgr.Instance.GetModelInfo();
        player = Instantiate(Resources.Load<GameObject>(planeInfo.resPath), Vector3.zero, Quaternion.identity);
        Player playerCpm = player.AddComponent<Player>();
        playerCpm.playerCamera = Camera.main;
        playerCpm.maxHp = planeInfo.hp;
        playerCpm.hp = planeInfo.hp;
        playerCpm.speed = planeInfo.speed * 10;
    }
}