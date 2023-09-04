using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr
{
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance => instance;

    public MusicData musicData;
    public RankData rankData;
    public PlaneData planeData;
    public BulletData bulletData;
    public FireData fireData;
    
    public int modelIndex = 0; // 当前选择的model

    private GameDataMgr()
    {
        // 初始化读取数据
        musicData = XmlDataManager.Instance.Load(typeof(MusicData), "musicData.xml") as MusicData;
        rankData = XmlDataManager.Instance.Load(typeof(RankData), "rankData.xml") as RankData;
        planeData = XmlDataManager.Instance.Load(typeof(PlaneData), "planeData.xml") as PlaneData;
        bulletData = XmlDataManager.Instance.Load(typeof(BulletData), "bulletData.xml") as BulletData;
        fireData = XmlDataManager.Instance.Load(typeof(FireData), "fireData.xml") as FireData;
    }

    #region 保存数据

    public void SaveMusicData()
    {
        XmlDataManager.Instance.Save(musicData, "musicData.xml");
    }

    public void SaveRankData()
    {
        XmlDataManager.Instance.Save(rankData, "rankData.xml");
    }

    #endregion

    #region 音效相关

    // 音乐开关
    public void ChangeMusicOpen(bool isOpen)
    {
        musicData.musicOpen = isOpen;
    }

    // 音效开关
    public void ChangeSoundOpen(bool isOpen)
    {
        musicData.soundOpen = isOpen;
    }

    // 音乐大小
    public void ChangeMusicVolume(float volume)
    {
        musicData.musicVolume = volume;
    }

    // 音效大小
    public void ChangeSoundVolume(float volume)
    {
        musicData.soundVolume = volume;
    }

    #endregion

    #region 排行榜相关

    public void AddRankInfo(string name, int time)
    {
        RankInfo rankInfo = new RankInfo(name, time);
        rankData.rankInfos.Add(rankInfo);

        // 排序, 时间久的在前面返回-1
        rankData.rankInfos.Sort((a, b) => a.time > b.time ? -1 : 1);

        // 剔除20名以外
        if (rankData.rankInfos.Count > 20)
        {
            rankData.rankInfos.RemoveAt(20);
        }

        SaveRankData();
    }

    #endregion

    #region 模型选择

    public PlaneInfo GetModelInfo()
    {
        return planeData.planeInfos[modelIndex];
    }

    #endregion
}