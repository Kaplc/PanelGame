using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanel : BasePanel<EndPanel>
{
    public UIButton btnSure;
    public UILabel lbSeconds;
    public UIInput ipName;
    
    public override void Init()
    {
        btnSure.onClick.Add(new EventDelegate(() =>
        {
            GameDataMgr.Instance.AddRankInfo(ipName.value, (int)GamePanel.Instance.time);
            SceneManager.LoadScene("BeginScenes");
        }));
        Hide();
    }

    public override void Show()
    {
        base.Show();
        lbSeconds.text = (int)GamePanel.Instance.time + "s";
    }
}
