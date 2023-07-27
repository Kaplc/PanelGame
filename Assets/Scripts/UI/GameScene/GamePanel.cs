using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    public UIButton btnClose;
    public UILabel lbSeconds;
    public List<GameObject> hpList;

    public float time;
    
    public override void Init()
    {
        btnClose.onClick.Add(new EventDelegate(() =>
        {
            QuitPanel.Instance.Show();
            Time.timeScale = 0;
        }));
        UpdateHp(50);
    }

    private void Update()
    {
        time += Time.deltaTime;
        // 更新时间
        lbSeconds.text = (int)time + "s";
    }

    public void UpdateHp(int hp)
    {
        for (int i = 0; i < hp/10; i++)
        {
            hpList[i].SetActive(true);
        }
    }
}
