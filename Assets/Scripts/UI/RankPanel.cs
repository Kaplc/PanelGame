using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    public UIButton btnClose;
    public UIScrollView svRank;

    public List<RankItem> listItems = new List<RankItem>();

    public override void Init()
    {
        btnClose.onClick.Add(new EventDelegate(() => { Hide(); }));

        Hide();
        for (int i = 0; i < 10; i++)
        {
            GameDataMgr.Instance.rankData.rankInfos.Add(new RankInfo("123", 1));
        }
    }

    public override void Show()
    {
        base.Show();
        // 清除上次的rankItem
        for (int i = 0; i < listItems.Count; i++)
        {
            Destroy(listItems[i].gameObject);
        }
        listItems.Clear();
        
        // 读取排行榜数据
        List<RankInfo> rankInfos = GameDataMgr.Instance.rankData.rankInfos;
        // 生成对象
        for (int i = 0; i < rankInfos.Count; i++)
        {
            GameObject rankItem = Instantiate(Resources.Load<GameObject>("Prefabs/SpRankItem"));
            rankItem.transform.SetParent(svRank.transform, false);
            rankItem.transform.localPosition = new Vector3(-20, 58, 0) + new Vector3(0, i * -60, 0);
            rankItem.GetComponent<RankItem>().InitInfo(i + 1, rankInfos[i].name, rankInfos[i].time);
            
            listItems.Add(rankItem.GetComponent<RankItem>());
        }
    }
}