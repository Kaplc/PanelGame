using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginPanel : BasePanel<BeginPanel>
{
    public UIButton btnStart;
    public UIButton btnRank;
    public UIButton btnSetting;
    public UIButton btnQuit;
    
    public override void Init()
    {
        //开始按钮
        btnStart.onClick.Add(new EventDelegate(() =>
        {
            
        }));
        //排行榜按钮
        btnRank.onClick.Add(new EventDelegate(() =>
        {
            RankPanel.Instance.Show();
        }));
        //设置按钮
        btnSetting.onClick.Add(new EventDelegate(() =>
        {
            SettingPanel.Instance.Show();
        }));
        //退出按钮
        btnQuit.onClick.Add(new EventDelegate(() =>
        {
            Application.Quit();
        }));
    }
}